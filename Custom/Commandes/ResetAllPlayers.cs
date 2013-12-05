using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Commands;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Scripts.Commands
{
    class ResetAllPlayers
    {
        public static void Initialize()
        {
            CommandSystem.Register("ResetAllPlayers", AccessLevel.Administrator, new CommandEventHandler(ResetAllPlayer_OnCommand));
        }

        [Usage("ResetAllPlayers")]
        [Description("Reset all Skills & PA")]
        public static void ResetAllPlayer_OnCommand(CommandEventArgs e)
        {
            foreach(Mobile m in World.Mobiles.Values)
            {
                if( m is TMobile )
                {
                    TMobile player = m as TMobile;

                    player.FreeReset = true;
                 
                }
            }
        }
    }
}
