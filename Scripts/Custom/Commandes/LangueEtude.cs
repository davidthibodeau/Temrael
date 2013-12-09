using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    class LangueEtude
    {
        public static void Initialize()
        {
            CommandSystem.Register("LangueEtude", AccessLevel.Player, new CommandEventHandler(LangueEtude_OnCommand));
        }

        [Usage("LangueEtude")]
        [Description("Permet d'apprendre des langues")]
        public static void LangueEtude_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                from.SendGump(new GumpLanguage((TMobile)from, true));
            }
        }
    }
}
