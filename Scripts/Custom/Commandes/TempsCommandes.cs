using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using System.Collections;

namespace Server.Scripts.Commands
{
    class HeureLocal
    {
        public static void Initialize()
        {
            CommandSystem.Register("HeureLocal", AccessLevel.Player, new CommandEventHandler(HeureLocal_OnCommand));
        }

        [Usage("HeureLocal")]
        [Description("Donne l'heure local du serveur.")]
        public static void HeureLocal_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            //DateTime time = new DateTime();

            from.SendMessage(DateTime.Now.ToString());
        }
    }
    class HeureQC
    {
        public static void Initialize()
        {
            CommandSystem.Register("HeureQC", AccessLevel.Player, new CommandEventHandler(HeureQC_OnCommand));
        }

        [Usage("HeureQC")]
        [Description("Donne l'heure du Quebec.")]
        public static void HeureQC_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            DateTime time = new DateTime();

            time = DateTime.Now;

            from.SendMessage("{0}", time);
        }
    }
    class HeureFR
    {
        public static void Initialize()
        {
            CommandSystem.Register("HeureFR", AccessLevel.Player, new CommandEventHandler(HeureFR_OnCommand));
        }

        [Usage("HeureFR")]
        [Description("Donne l'heure de la France.")]
        public static void HeureFR_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            DateTime time = new DateTime();

            time = DateTime.Now;

            from.SendMessage("{0}", time.AddHours(6.0));
        }
    }
}