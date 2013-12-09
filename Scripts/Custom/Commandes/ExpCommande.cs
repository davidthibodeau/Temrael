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
            CommandSystem.Register("Exp", AccessLevel.GameMaster, new CommandEventHandler(Exp_OnCommand));
        }

        [Usage("Exp")]
        [Description("Permet de connaître son nombre de points d'expériences.")]
        public static void Exp_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            from.SendMessage("Vous avez présentement : " + from.XP + " points d'expériences.");

            /*if (from is TMobile)
            {
                from.Target = new CotationTarget();
            }*/
        }
    }
}
