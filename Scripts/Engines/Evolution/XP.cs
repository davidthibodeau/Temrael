using System;
using System.IO;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Accounting;
using Server.Regions;
using Server.Commands;

namespace Server.Engines.Evolution
{
    public class XP
    {
        public static TimeSpan m_IntervaleXP = TimeSpan.FromMinutes(10);
        public static DateTime LastReset = DateTime.Now;

        private const int ExpGain = 750;

        public static void Initialize()
        {
            CommandSystem.Register("manualxpreset", AccessLevel.Owner, new CommandEventHandler(ManualXPReset_OnCommand));
            CommandSystem.Register("xpmode", AccessLevel.Player, new CommandEventHandler(XPMode_OnCommand));

            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day, 3, 0, 0);
            DateTime next = today.AddDays(7 - (int)today.DayOfWeek);

            new XPResetTimer(next - now).Start();
            // Comme en haut. A supprimer apres la date
            if (LastReset.AddDays(7) < now)
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
                Experience m = (e.Mobile as PlayerMobile).Experience;
                m.XPMode = !m.XPMode;
                e.Mobile.SendMessage("Vous avez choisi le mode d'expérience " + (!m.XPMode ? "journalier." : "hebdomadaire."));
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

                        if (pm.Experience.NextExp < DateTime.Now)
                        {
                            CheckXP(pm);
                            pm.Experience.NextExp = DateTime.Now.AddMinutes(20);
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
                    bool[,] ticks = (m as TMobile).Experience.Ticks;
                    for (int i = 0; i < 7; i++)
                    {
                        for (int j = 0; j < 9; j++)
                        {
                            ticks[i, j] = false;
                        }
                    }
                }
            }

            foreach (CompensationGump.MJ mj in CompensationGump.GetMJs())
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

            int XPgain = (int)(ExpGain * XPparCount(GetNextTick(pm.Experience)));
            pm.Experience.XP += XPgain;

            CompensationGump.MJ mj = CompensationGump.GetMJ((Account)pm.Account);
            if (mj != null)
            {
                mj.XpGainedThisWeek += XPgain;
                CompensationGump.WriteLine(String.Format("{0} recoit {1} xp. Le total courant de la semaine est de {2}.",
                    mj.Nom, XPgain, mj.XpGainedThisWeek));
            }
        }

        public static int GetNextTick(Experience pm)
        {
            DateTime now = DateTime.Now;
            bool[,] ticks = pm.Ticks;

            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i <= (pm.XPMode ? 6 : (int)now.DayOfWeek); i++)
                {
                    if (ticks != null && !ticks[i, j])
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

        private static int RequiredXP(int niveau)
        {
            if (niveau == 0) return 500;
            if (niveau == 1) return 1000;

            int xp = 1000;
            for (int i = niveau; i > 1; i--)
            {
                xp += niveau * 1000;
            }
            return xp;
        }

        public static int GetNeededXP(Experience exp)
        {
            if (exp == null)
                return 1000;

            return RequiredXP(exp.Niveau);
        }

        public static bool CanEvolve(Mobile from)
        {
            if (from is TMobile)
            {
                TMobile pm = from as TMobile;
                try
                {
                    int currentXP = pm.Experience.XP;
                    int neededXP = GetNeededXP(pm.Experience);

                    if (currentXP > neededXP)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Misc.ExceptionLogging.WriteLine(ex, "{0} est niveau {1}.", pm, pm.Experience.Niveau);
                }
            }
            

            return false;
        }

        public static void Evolve(Mobile from)
        {
            if (from is TMobile)
            {
                TMobile pm = from as TMobile;

                Experience exp = pm.Experience;

                int currentXP = exp.XP;
                int neededXP = GetNeededXP(pm.Experience);

                if (currentXP > neededXP)
                {
                    exp.Niveau++;

                    int SkillsCaps = 1000;
                    if (exp.Niveau > 50)
                        SkillsCaps = 9000;
                    else if (exp.Niveau > 30)
                        SkillsCaps = 7000 + (exp.Niveau - 30) * 100;
                    else
                        SkillsCaps = 1000 + exp.Niveau * 200;
                    
                    if (SkillsCaps > 9000)
                        SkillsCaps = 9000;

                    pm.SkillsCap = SkillsCaps;

                    pm.SendMessage("Vous gagnez un niveau !");
                }
                else
                    pm.SendMessage("Il vous manque des points d'experieces pour gagner votre niveau !");
            }
        }
    }
}