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
using Server.Mobiles.Vendeurs;

namespace Server.Engines.Evolution
{
    public class XP
    {
        public static TimeSpan m_IntervaleXP = TimeSpan.FromMinutes(10);
        public static DateTime LastReset = DateTime.Now;

        

        public static void Initialize()
        {
            //CommandSystem.Register("manualxpreset", AccessLevel.Owner, new CommandEventHandler(ManualXPReset_OnCommand));
            CommandSystem.Register("xpmode", AccessLevel.Player, new CommandEventHandler(XPMode_OnCommand));

            new XPTimer().Start();
        }

        //private static void ManualXPReset_OnCommand(CommandEventArgs e)
        //{
        //    ResetWeek();
        //}

        private static void XPMode_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
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

                    if (m != null && m is PlayerMobile)
                    {
                        PlayerMobile pm = (PlayerMobile)m;

                        pm.Experience.Tick(pm);
                    }
                }
            }
        }

        private static int RequiredXP(int niveau)
        {
            if (niveau == 0) return 500;
            if (niveau == 1) return 1000;
            int xp = 1000 * niveau + RequiredXP(niveau - 1);
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
            if (from is PlayerMobile)
            {
                PlayerMobile pm = from as PlayerMobile;
                int currentXP = pm.Experience.XP;
                int neededXP = GetNeededXP(pm.Experience);

                if (currentXP > neededXP)
                {
                    return true;
                }
            }
            
            return false;
        }

        public static void Evolve(Mobile from)
        {
            if (from is PlayerMobile)
            {
                PlayerMobile pm = from as PlayerMobile;

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