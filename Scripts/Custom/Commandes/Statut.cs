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

            string messagefaim = GetFaim(from, false);
            string messagesoif = GetSoif(from, false);

            if (messagefaim != null)
                from.SendMessage(messagefaim);
            if (messagesoif != null)
                from.SendMessage(messagesoif);

            Timer t = new FaimSoifTimer(from);
            t.Start();
        }

        [Usage("Statut")]
        [Description("montre votre faim, soif et fatigue")]
        public static void Statut_OnCommand(CommandEventArgs e)
        {
            TMobile from = e.Mobile as TMobile;

            if (from != null)
            {
                string messagefaim = GetFaim(from, true);
                string messagesoif = GetSoif(from, true);

                if (messagefaim != null)
                    from.SendMessage(messagefaim);
                if (messagesoif != null)
                    from.SendMessage(messagesoif);

                from.SendMessage(String.Format("Fatigue: {0} / 1000", from.Fatigue));

                //from.SendMessage("Fatigue: {0}/1000", from.Fatigue);
            }
        }

        private class FaimSoifTimer : Timer
        {
            private Mobile m;

            public FaimSoifTimer(Mobile from)
                : base(TimeSpan.FromHours(1.5))
            {
                m = from;
            }

            protected override void OnTick()
            {
                string messagefaim = GetFaim(m, false);
                string messagesoif = GetSoif(m, false);

                if (messagefaim != null)
                    m.SendMessage(messagefaim);
                if (messagesoif != null)
                    m.SendMessage(messagesoif);
            }
        }

        public static string GetFaim(Mobile from, bool command)
        {
            string message = null;

            if (from.Hunger >= 16)
            {
                if (command)
                    message = "Votre personnage n'a pas faim.";
                else
                    message = null;
            }
            else if (from.Hunger >= 12)
                message = "Votre personnage a legerement faim.";
            else if (from.Hunger >= 8)
                message = "Votre personnage a faim.";
            else if (from.Hunger >= 4)
                message = "Votre personnage a tres faim.";
            else if (from.Hunger >= 0)
                message = "Votre personnage meurt de faim.";

            return message;
        }

        public static string GetSoif(Mobile from, bool command)
        {
            string message = null;

            if (from.Thirst >= 16)
            {
                if (command)
                    message = "Votre personnage n'a pas soif.";
                else
                    message = null;
            }
            else if (from.Thirst >= 12)
                message = "Votre personnage a legerement soif.";
            else if (from.Thirst >= 8)
                message = "Votre personnage a soif.";
            else if (from.Thirst >= 4)
                message = "Votre personnage a extremement soif.";
            else if (from.Thirst >= 0)
                message = "Votre personnage meurt de soif.";

            return message;
        }
    }
}
