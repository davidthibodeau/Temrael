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
            CommandSystem.Register("manualxpreset", AccessLevel.Owner, new CommandEventHandler(ManualXPReset_OnCommand));
            CommandSystem.Register("xpmode", AccessLevel.Player, new CommandEventHandler(XPMode_OnCommand));

            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day, 3, 0, 0);
            DateTime next = today.AddDays(6 - (int)today.DayOfWeek);

            new XPResetTimer(next - now).Start();

            if (LastReset.AddDays(6 - (int)today.DayOfWeek) < now)
            {
                Console.WriteLine("Le dernier reset de gain d'xp hebdomadaire était le {0}. Un reset est maintenant fait.", LastReset.ToString());
                ResetEndOfDay();
            }

            new XPTimer().Start();
        }

        private static void ManualXPReset_OnCommand(CommandEventArgs e)
        {
            ResetEndOfDay();
        }

        private static void XPMode_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is TMobile)
            {
                TMobile m = e.Mobile as TMobile;
                m.XPMode = !m.XPMode;
                m.SendMessage("Vous avez choisi le mode d'expérience " + (!m.XPMode ? "journalier." : "hebdomadaire."));
            }
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
                : base(delay, TimeSpan.FromDays(7))
            {
                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                ResetEndOfDay();
            }
        }

        public static void ResetEndOfDay()
        {
            CommandLogging.WriteLine("Lancement d'un reset de gain d'xp journalier manuel.");
            
            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is TMobile)
                {
                    bool[,] ticks = (m as TMobile).Ticks;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            ticks[i, j] = false;
                        }
                    }
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

        public static void CheckXP(TMobile pm)
        {
            if (pm == null)
                return;
            if (pm.Region is Jail) // Pas d'xp quand le joueur est en jail.
                return;

            int XPgain = (int)(ExpGain * XPparCount(GetNextTick(pm)));
            pm.XP += XPgain;

            CompensationGump.MJ mj = CompensationGump.GetMJ((Account)pm.Account);
            if (mj != null)
            {
                mj.XpGainedThisWeek += XPgain;
                CompensationGump.WriteLine(String.Format("{0} recoit {1} xp. Le total courant de la semaine est de {2}.",
                    mj.Nom, XPgain, mj.XpGainedThisWeek));
            }
        }

        public static int GetNextTick(TMobile pm)
        {
            DateTime now = DateTime.Now;
            bool[,] ticks = pm.Ticks;

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i <= (pm.XPMode ? 6 : (int)now.DayOfWeek); i++)
                {
                    if (!ticks[i, j])
                    {
                        ticks[i, j] = true;
                        return j;
                    }
                }
            }
            return -1;
        }

        public static double XPparCount(int i)
        {
            switch (i)
            {
                case 0: return 1.00;
                case 1: return 0.95;
                case 2: return 0.90;
                case 3: return 0.85;
                case 4: return 0.80;
                case 5: return 0.75;
                case 6: return 0.70;
                case 7: return 0.65;
                case 8: return 0.60;
                default: return 0.01;
            }
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
    }
}