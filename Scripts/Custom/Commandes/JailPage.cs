using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class Jail
    {
        public static void Initialize()
        {
            CommandSystem.Register("Jail1", AccessLevel.Counselor, new CommandEventHandler(Jail1_OnCommand));
            CommandSystem.Register("Jail2", AccessLevel.Counselor, new CommandEventHandler(Jail2_OnCommand));
            CommandSystem.Register("Jail3", AccessLevel.Counselor, new CommandEventHandler(Jail3_OnCommand));
            CommandSystem.Register("Jail4", AccessLevel.Counselor, new CommandEventHandler(Jail4_OnCommand));

            CommandSystem.Register("Page1", AccessLevel.Counselor, new CommandEventHandler(Page1_OnCommand));
            CommandSystem.Register("Page2", AccessLevel.Counselor, new CommandEventHandler(Page2_OnCommand));
            CommandSystem.Register("Page3", AccessLevel.Counselor, new CommandEventHandler(Page3_OnCommand));
            CommandSystem.Register("Page4", AccessLevel.Counselor, new CommandEventHandler(Page4_OnCommand));

            CommandSystem.Register("EndJail", AccessLevel.Counselor, new CommandEventHandler(EndJail_OnCommand));
            CommandSystem.Register("EndPage", AccessLevel.Counselor, new CommandEventHandler(EndPage_OnCommand));

        }

        public static void Jail1_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(5835, 1129, 0));
        }

        public static void Jail2_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(5835, 1165, 0));
        }

        public static void Jail3_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(5870, 1165, 0));
        }

        public static void Jail4_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(5870, 1129, 0));
        }

        public static void Page1_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(6116, 1333, 10));
        }

        public static void Page2_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(6115, 1347, 10));
        }

        public static void Page3_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(6130, 1347, 10));
        }

        public static void Page4_OnCommand(CommandEventArgs e)
        {
            GoJailPage(e.Mobile, new Point3D(6130, 1334, 10));
        }

        public static void EndJail_OnCommand(CommandEventArgs e)
        {
            e.Mobile.BeginTarget(12, false, TargetFlags.None, new TargetCallback(EndJailPage_OnTarget));
        }

        public static void EndPage_OnCommand(CommandEventArgs e)
        {
            e.Mobile.BeginTarget(12, false, TargetFlags.None, new TargetCallback(EndJailPage_OnTarget));
        }

        private static void EndJailPage_OnTarget(Mobile from, object targeted)
        {
            try
            {
                if (targeted is TMobile)
                {
                    TMobile m = (TMobile)targeted;

                    if (m.AccessLevel <= from.AccessLevel && m.OldLocation != Point3D.Zero)
                    {
                        m.MoveToWorld(m.OldLocation, Map.Felucca);
                    }
                    else
                    {
                        from.SendMessage("Vous ne pouvez le renvoyer en jeu.");
                    }
                }
                else
                {
                    from.SendMessage("Vous devez choisir un joueur.");
                }
            }
            catch
            {
            }
        }

        public static void GoJailPage(Mobile from, Point3D p)
        {
            from.BeginTarget(12, false, TargetFlags.None, new TargetStateCallback(JailPage_OnTarget), p);
        }

        private static void JailPage_OnTarget(Mobile from, object targeted, object state)
        {
            try
            {
                Point3D p = (Point3D)state;

                if (targeted is TMobile)
                {
                    TMobile m = (TMobile)targeted;

                    if (m.AccessLevel <= from.AccessLevel)
                    {
                        m.OldLocation = m.Location;
                        m.MoveToWorld(p, Map.Felucca);
                    }
                    else
                    {
                        from.SendMessage("Vous ne pouvez l'envoyer en jail/salle de page.");
                    }
                }
                else
                {
                    from.SendMessage("Vous devez choisir un joueur.");
                }
            }
            catch
            {
            }
        }
    }
}