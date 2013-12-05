using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class Decoration
    {
        public static void Initialize()
        {
            CommandSystem.Register("Decoration", AccessLevel.Player, new CommandEventHandler(Decoration_OnCommand));
        }

        [Usage("Decoration")]
        [Description("Permet l'acces aux joueurs de plusieurs commandes de decoration.")]
        public static void Decoration_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                from.SendGump(new DecorationGump((Mobile)from));
            }
        }
    }
}
