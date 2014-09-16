using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    class Meteo
    {
        public static void Initialize()
        {
            CommandSystem.Register("Meteo", AccessLevel.Player, new CommandEventHandler(Meteo_OnCommand));
        }

        [Usage("Meteo")]
        [Description("Permet l'acces aux donnes meteos.")]
        public static void Meteo_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                from.SendGump(new ConditionGump((Mobile)from));
            }
        }
    }
}
