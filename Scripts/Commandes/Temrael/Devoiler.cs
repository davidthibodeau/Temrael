using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class DevoilerIdentity
    {
        public static void Initialize()
        {
            CommandSystem.Register("Devoiler", AccessLevel.Player, new CommandEventHandler(Devoiler_OnCommand));
        }

        [Usage("Devoiler")]
        [Description("Dévoiler votre présence.")]
        public static void Devoiler_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                PlayerMobile from = (PlayerMobile)e.Mobile;

                from.PlaySound(0x228);
                from.Hidden = false;
                from.SendMessage("Vous dévoilez votre présence.");
            }
        }
    }
}
