using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class RevealTitle
    {
        public static void Initialize()
        {
            CommandSystem.Register("Titre", AccessLevel.Player, new CommandEventHandler(RevealTitle_OnCommand));
        }

        [Usage("Titre")]
        [Description("Permet de cacher ou non son titre du paperdoll.")]
        public static void RevealTitle_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is TMobile)
            {
                TMobile from = (TMobile)e.Mobile;

                if (from.RevealTitle == true)
                {
                    from.RevealTitle = false;
                    from.SendMessage("Vous cachez votre titre");
                }
                else
                {
                    from.RevealTitle = true;
                    from.SendMessage("Vous revelez votre titre");
                }
            }
        }
    }
}
