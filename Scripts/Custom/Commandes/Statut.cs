using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class Statut
    {
        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(EventSink_Login);
            CommandSystem.Register("Statut", AccessLevel.Player, new CommandEventHandler(Statut_OnCommand));
        }

        private static void EventSink_Login(LoginEventArgs args)
        {
            Mobile from = args.Mobile;
        }

        [Usage("Statut")]
        [Description("montre votre faim, soif et fatigue")]
        public static void Statut_OnCommand(CommandEventArgs e)
        {
            TMobile from = e.Mobile as TMobile;

            if (from != null)
            {
                from.SendMessage(String.Format("Fatigue: {0} / 1000", from.Fatigue));
            }
        }

    }
}
