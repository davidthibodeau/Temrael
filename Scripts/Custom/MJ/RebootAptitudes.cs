using System;
using System.IO;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Commands;

namespace Server
{
    public class RebootAptitudes
    {
        public static void Initialize()
        {
            CommandSystem.Register("RebootAptitudes", AccessLevel.Owner, new CommandEventHandler(RebootAptitudes_OnCommand));
        }

        public static void RebootAptitudes_OnCommand(CommandEventArgs e)
        {

            foreach (NetState state in NetState.Instances)
            {
                Mobile m = state.Mobile;

                if (m != null && m is TMobile)
                {
                    TMobile pm = (TMobile)m;

                    pm.Aptitudes.Reset();
                }
            }
        }
    }
}
