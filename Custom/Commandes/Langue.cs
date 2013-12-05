using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    class Langue
    {
        public static void Initialize()
        {
            CommandSystem.Register("Langue", AccessLevel.Player, new CommandEventHandler(Langue_OnCommand));
        }

        [Usage("Langue")]
        [Description("Permet d'utiliser le système de languages.")]
        public static void Langue_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                from.SendGump(new GumpLanguage((TMobile)from, false));
            }
        }
    }
}
