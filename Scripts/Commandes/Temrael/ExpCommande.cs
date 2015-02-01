using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;

namespace Server.Scripts.Commands
{
    class ExpCommande
    {
        public static void Initialize()
        {
            CommandSystem.Register("Exp", AccessLevel.Player, new CommandEventHandler(Exp_OnCommand));
        }

        [Usage("Exp")]
        [Description("Permet de connaître son nombre de points d'expériences.")]
        public static void Exp_OnCommand(CommandEventArgs e)
        {
            PlayerMobile from = e.Mobile as PlayerMobile;
            if (from == null)
                return;

            from.SendMessage("Vous avez présentement : " + from.Experience.XP + " points d'expériences.");
        }
    }
}
