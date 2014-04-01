using System;
using System.IO;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Systemes;
using Server.Accounting;
using Server.Regions;
using Server.Commands;

namespace Server
{
    public class XP
    {
        public static Hashtable m_XPparNiveau = new Hashtable();
        public static Hashtable m_XPparCote = new Hashtable();
        public static Hashtable m_XPparCount = new Hashtable();
        public static TimeSpan m_IntervaleXP = TimeSpan.FromMinutes(10);
        public static DateTime LastReset = DateTime.Now;

        private static double[] m_ExpGainTable = new double[] { 200.0, 250.0, 300.0, 350.0,
            400.0, 500.0, 600.0 };

        private static int[] m_ExpReqTable = new int[] { 0, 0, 1000, 3000,
            6000, 10000, 15000, 21000, 28000, 36000, 45000, 55000, 66000,
            78000, 91000, 105000, 120000, 136000, 153000, 171000, 190000,
            210000, 231000, 253000, 276000, 300000, 325000, 351000, 378000,
            405000, 435000
            };

        public static void Initialize()
        {
            MakeXPparCote();
            MakeXPparCount();

            CommandSystem.Register("manualxpreset", AccessLevel.Owner, new CommandEventHandler(ManualXPReset_OnCommand));

            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day, 3, 0, 0);

            if (now < today)
                new XPResetTimer(today - now);
            else
            {
                if (LastReset < today)
                {
                    Console.WriteLine("Le dernier reset de gain d'xp journalier était le {0}. Un reset est maintenant fait.", LastReset.ToString());
                    ResetEndOfDay();
                }
                new XPResetTimer(today.AddDays(1) - now);
            }
            new XPTimer().Start();
        }

        private static void ManualXPReset_OnCommand(CommandEventArgs e)
        {
            CommandLogging.WriteLine(e.Mobile, "Lancement d'un reset de gain d'xp journalier manuel.");
            ResetEndOfDay();
        }

        public class XPTimer : Timer
        {
            public XPTimer()
                : base(m_IntervaleXP, m_IntervaleXP)
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {

                foreach (NetState state in NetState.Instances)
                {
                    Mobile m = state.Mobile;

                    if (m != null && m is TMobile)
                    {
                        TMobile pm = (TMobile)m;

                        if (pm.NextExp < DateTime.Now)
                        {
                            CheckXP(pm);
                            pm.NextExp = DateTime.Now.AddMinutes(20);
                        }
                    }
                }
            }
        }

       public class XPResetTimer : Timer
        {
            public XPResetTimer(TimeSpan delay)
                : base(delay, TimeSpan.FromDays(1))
            {
                Priority = TimerPriority.FiveSeconds;
            }

            protected override void OnTick()
            {
                ResetEndOfDay();
            }
        }

        public static void ResetEndOfDay()
        {
            ArrayList targets = new ArrayList();

            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is TMobile)
                    targets.Add((TMobile)m);
            }

            if (targets.Count > 0)
            {
                for (int i = 0; i < targets.Count; i++)
                {
                    TMobile pm = (TMobile)targets[i];

                    pm.CoteCount = 1;
                }
            }

            foreach (CompensationGump.MJ mj in Systemes.CompensationGump.GetMJs())
            {
                CompensationGump.WriteLine(String.Format(
                    "Verification de paiement pour {0}. Son prochain paiement est le {1}.", 
                    mj.Nom, mj.NextCompensation.ToString()));
                if (mj.NextCompensation < DateTime.Now)
                {
                    mj.PayerXP();
                }
            }

            LastReset = DateTime.Now;
        }

        public static int GetCote(TMobile pm)
        {
            int CoteMoyenne = 0;

            foreach (int cotation in pm.ListCote)
            {
                CoteMoyenne += cotation;
            }

            if (pm.ListCote.Count > 0)
            {
                double avg = CoteMoyenne / (double)pm.ListCote.Count;
                if (avg - (int)avg < 0.5)
                    return (int)avg;
                else
                    return (int)avg + 1;
            }
            else
                return 0;
        }

        public static void CheckXP(TMobile pm)
        {
            if (pm == null)
                return;
            if (pm.Region is Jail) // Pas d'xp quand le joueur est en jail.
                return;

            int CoteMoyenne = GetCote(pm);

            /*foreach (Cote cotation in pm.CoteList)
            {
                CoteMoyenne = cotation.GetCote();
            }*/

            //int Cote = pm.Cote;
            int Count = pm.CoteCount;
            int XPparCote = 1600;
            double XPparCount = 0.01;

            //CoteMoyenne += 5;

            if (CoteMoyenne > 5)
              {
                 CoteMoyenne = 5;
                 pm.Cote = 5;
              }

            if (CoteMoyenne < 0)
               {
                 CoteMoyenne = 0;
                 pm.Cote = 0;
               }

            if (m_XPparCote.Contains(CoteMoyenne))
                XPparCote = (int)m_ExpGainTable[CoteMoyenne];
                //XPparCote = (int)m_XPparCote[CoteMoyenne];

            if (m_XPparCount.Contains(Count))
                XPparCount = (double)m_XPparCount[Count];
            else
                XPparCount = 0.01;

            int XPgain = (int)(XPparCote * XPparCount);

            if (XPgain < 0)
            {
                XPgain = 0;
            }

            if (XPgain > 500)
                XPgain = 500;

            //pm.SendMessage(Convert.ToString(XPgain));
            //pm.SendMessage(Convert.ToString(CoteMoyenne));

            pm.XP += XPgain;

            CompensationGump.MJ mj = CompensationGump.GetMJ((Account)pm.Account);
            if (mj != null)
            {
                mj.XpGainedThisWeek += XPgain;
                CompensationGump.WriteLine(String.Format("{0} recoit {1} xp. Le total courant de la semaine est de {2}.",
                    mj.Nom, XPgain, mj.XpGainedThisWeek));
            }

            pm.CoteCount++;

            //if (AOS.Testing)
            //    pm.SendMessage("XP : " + XPgain.ToString());
        }

        public static void ChangePallier(TMobile pm)
        {
            if (pm == null)
                return;

            int Cote = pm.Cote;
            //int Pallier = 9;
            //double Moyenne = pm.GetAverageCote();         
        }

        public static void MakeXP()
        {
            int baseGain = 2000;
            int value = 1000;

            for (int i = 1; i < 101; i++)
            {
                if (i > 1)
                {
                    value += baseGain;
                    m_XPparNiveau[i] = value;
                }
                else
                {
                    m_XPparNiveau[i] = value;
                }
                baseGain += 1000;
            }
        }

        public static void MakeXPparCote()
        {
            if (m_XPparCote == null)
                m_XPparCote = new Hashtable();

            for (int i = 0; i < 21; i++)
            {
                int value = -1000 + 325 * i;
                m_XPparCote[i] = value;
            }
        }

        public static void MakeXPparCount()
        {
            if (m_XPparCount == null)
                m_XPparCount = new Hashtable();

            m_XPparCount[0] = 1.00;
            m_XPparCount[1] = 0.95;
            m_XPparCount[2] = 0.90;
            m_XPparCount[3] = 0.85;
            m_XPparCount[4] = 0.80;
            m_XPparCount[5] = 0.75;
            m_XPparCount[6] = 0.70;
            m_XPparCount[7] = 0.65;
            m_XPparCount[8] = 0.60;
        }

        
        public static void SetSkills(TMobile from, int skillcaptotal, double skillcapind)
        {
            from.SkillsCap = skillcaptotal;

            for (int i = 0; i < from.Skills.Length; ++i)
            {
                //if (!IsLoreSkill(from.Skills[i]))
                    from.Skills[i].Cap = (double)skillcapind;
            }
            
            //from.SkillsPlace += (double)3.0;
        }

        public static void SetPAs(TMobile from)
        {
            from.AptitudesLibres++;

            int paEnAttente = Aptitudes.GetRemainingPA(from) - Aptitudes.GetDisponiblePA(from);

            //if (paEnAttente > 15)
            //    paEnAttente = 15;

            from.AptitudesLibres += paEnAttente;
        }

        public static void SetPCs(TMobile from)
        {
            from.CompetencesLibres += 25;

            int compEnAttente = Competences.GetRemainingComp(from) - Competences.GetDisponibleComp(from);

            //if (paEnAttente > 15)
            //    paEnAttente = 15;

            from.CompetencesLibres += compEnAttente;
        }

        public static void SetPSs(TMobile from)
        {
            //from.StatistiquesLibres += 5;

            int statsEnAttente = Statistiques.GetRemainingStats(from) - Statistiques.GetDisponibleStats(from);

            //if (paEnAttente > 15)
            //    paEnAttente = 15;

            from.StatistiquesLibres += statsEnAttente;
        }


        public static int GetNeededXP(TMobile pm)
        {
            if (pm == null)
                return 1000;

            int neededXP = 0;

            if (pm.Niveau > 30)
                neededXP = 435000 + (30000 * (pm.Niveau - 30));
            else
                neededXP = m_ExpReqTable[pm.Niveau + 1];

            return neededXP;
        }

        public static int GetNiveauXP(TMobile pm)
        {
            if (pm == null)
                return 1000;

            int neededXP = 0;

            if (pm.Niveau > 19)
                neededXP = 190000 + (20000 * (pm.Niveau - 20));
            else
                neededXP = m_ExpReqTable[pm.Niveau];

            return neededXP;

        }

        public static bool CanEvolve(Mobile from)
        {
            if (from is TMobile)
            {
                TMobile pm = from as TMobile;
                try
                {
                    int currentXP = pm.XP;
                    int neededXP = GetNeededXP(pm);

                    if (currentXP > neededXP)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Misc.ExceptionLogging.WriteLine(ex, "{0} est niveau {1}.", pm, pm.Niveau);
                }
            }
            

            return false;
        }

        public static void Evolve(Mobile from)
        {
            try
            {
                if (from is TMobile)
                {
                    TMobile pm = from as TMobile;

                    int currentXP = pm.XP;
                    int neededXP = GetNeededXP(pm);

                    if (currentXP > neededXP)
                    {
                        pm.Niveau++;

                        int SkillsCaps = 350 + pm.Niveau * 15;
                        double SkillsInd = 40 + pm.Niveau * 2.0;

                        if (SkillsInd > 100)
                            SkillsInd = 100;

                        if (SkillsCaps > 800)
                            SkillsCaps = 800;

                        SetSkills(pm, SkillsCaps, SkillsInd);
                        SetPAs(pm);
                        SetPCs(pm);
                        SetPSs(pm);

                        pm.SendMessage("Vous gagnez un niveau !");
                    }
                    else
                        pm.SendMessage("Il vous manque des points d'experieces pour gagner votre niveau !");
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex);
            }
        }
    }
}