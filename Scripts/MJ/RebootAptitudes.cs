using System;
using System.IO;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Commands;
using Server.Targeting;

namespace Server
{
    public class RebootAptitudes
    {
        public static void Initialize()
        {
            CommandSystem.Register("ForceReset", AccessLevel.Batisseur, new CommandEventHandler(ForceReset_OnCommand));
        }

        public static void ForceReset_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            from.SendMessage("Veuillez choisir le joueur que vous désirez reset.");
            from.Target = new ResetTarget();
        }

        private class ResetTarget : Target
        {
            public ResetTarget() : base(-1, false, TargetFlags.None) 
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is PlayerMobile)
                {
                    PlayerMobile tm = targeted as PlayerMobile;
                    if (from.AccessLevel > tm.AccessLevel)
                    {
                        //tm.Reset(true);
                    }
                    else
                    {
                        from.SendMessage("Ceci n'est pas accessible.");
                    }
                }
                else
                {
                    from.SendMessage("Vous devez choisir un joueur.");
                }
            }
        }
    }
}
