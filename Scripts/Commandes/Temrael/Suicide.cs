using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;

namespace Server.Scripts.Commands
{
    public class Suicide
    {
        public static void Initialize()
        {
            CommandSystem.Register("Suicide", AccessLevel.Player, new CommandEventHandler(Suicide_OnCommand));
        }

        [Usage("Suicide")]
        [Description("Permet d'etre en mode suicide et de mourir definitivement a sa prochaine mort PVP ou PVM.")]
        public static void Suicide_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is TMobile)
            {
                TMobile tmob = (TMobile)from;

                if (tmob.MortEngine.Suicide == true)
                    tmob.MortEngine.Suicide = false;
                else
                    tmob.MortEngine.Suicide = true;

                tmob.SendMessage("Votre mode de suicide est a : " + (tmob.MortEngine.Suicide ? "ON" : "OFF"));
            }
        }
    }
}
