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

namespace Server
{
    public class XP
    {
        public static Hashtable m_XPparNiveau = new Hashtable();
        public static Hashtable m_XPparCount = new Hashtable();
        public static TimeSpan m_IntervaleXP = TimeSpan.FromMinutes(10);
        public static DateTime LastReset = DateTime.Now;

        private const int ExpGain = 750;

        private static int[] m_ExpReqTable = new int[] { 0, 0, 1000, 3000,
            6000, 10000, 15000, 21000, 28000, 36000, 45000, 55000, 66000,
            78000, 91000, 105000, 120000, 136000, 153000, 171000, 190000,
            210000, 231000, 253000, 276000, 300000, 325000, 351000, 378000,
            405000, 435000
            };

        public static void Initialize()
        {
            MakeXPparCount();

            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day, 3, 0, 0);

            if (now < today)
                new XPResetTimer(today - now);
            else
            {
                if (LastReset < today)
                    ResetEndOfDay();
                new XPResetTimer(today.AddDays(1) - now);
            }
            new XPTimer().Start();
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
            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is TMobile)
                {
                    ((TMobile)m).CoteCount = 0;
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


            //int Cote = pm.Cote;
            int Count = pm.CoteCount;
            int XPparCote = ExpGain;
            double XPparCount = 0.01;

            if (m_XPparCount.Contains(Count))
                XPparCount = (double)m_XPparCount[Count];
            else
                XPparCount = 0.01;

            int XPgain = (int)(XPparCote * XPparCount);

            if (XPgain < 0)
            {
                XPgain = 0;
            }

            if (XPgain > ExpGain)
                XPgain = ExpGain;

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