using System;
using Server;
using Server.Mobiles;
using Server.Targeting;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class Tip
    {
        public static void Initialize()
        {
            CommandSystem.Register("Tip", AccessLevel.GameMaster, new CommandEventHandler(Tip_OnCommand));
        }

        public static void Tip_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            string tip = e.ArgString.Trim();

            if (tip == null || tip.Length < 1)
            {
                from.SendMessage("Votre tip doit faire plus de 1 charactère !");
            }
            else
            {
                from.BeginTarget(12, false, TargetFlags.None, new TargetStateCallback(Tip_OnTarget), tip);
            }
        }

        private static void Tip_OnTarget(Mobile from, object targeted, object state)
        {
            if (targeted is TMobile)
            {
                string tip = state as string;

                ((TMobile)targeted).Tip(from, tip);
            }
        }
    }
}