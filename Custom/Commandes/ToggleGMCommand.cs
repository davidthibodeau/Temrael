using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;

namespace Server.Scripts.Commands
{
    class GMCommande
    {
        public static void Initialize()
        {
            CommandSystem.Register("GM", AccessLevel.Player, new CommandEventHandler(GM_OnCommand));
        }

        [Usage("GM")]
        [Description("Permet de switcher entre l'AccessLevel Player et GameMaster")]
        public static void GM_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            if (from.AccessLevel >= AccessLevel.GameMaster)
                from.AccessLevel = AccessLevel.Player;
            else if (from.Account.AccessLevel >= AccessLevel.GameMaster)
                from.AccessLevel = from.Account.AccessLevel;
            else
                from.SendMessage("Vous devez être GM pour utiliser cette commande");
        }
    }
}
