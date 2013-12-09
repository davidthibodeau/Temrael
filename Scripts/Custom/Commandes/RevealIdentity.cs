using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class RevealIdentity
    {
        public static void Initialize()
        {
            CommandSystem.Register("Foulard", AccessLevel.Player, new CommandEventHandler(RevealIdentity_OnCommand));
        }

        [Usage("Foulard")]
        [Description("Permet de cacher ou non son identite avec un foulard ou une cagoule.")]
        public static void RevealIdentity_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is TMobile)
            {
                TMobile from = (TMobile)e.Mobile;

                if (from.RevealIdentity == true)
                {
                    from.RevealIdentity = false;
                    from.SendMessage("Vous cachez votre identite avec le foulard.");
                }
                else
                {
                    from.RevealIdentity = true;
                    from.SendMessage("Vous revelez votre identite avec le foulard.");
                }
            }
        }
    }
}
