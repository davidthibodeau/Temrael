using System;
using Server.Network;
using Server.Mobiles;

namespace Server
{
    public class CustomStatusWindow
    {
        public static void Initialize()
        {
            PacketHandlers.Register(0x11, 66, true, new OnPacketReceive(RequestSkillsAndStatsGump));
            PacketHandlers.Register6017(0x11, 66, true, new OnPacketReceive(RequestSkillsAndStatsGump));
        }
        public static void RequestSkillsAndStatsGump(NetState state, PacketReader pvSrc)
        {
            Console.WriteLine("Test");
        }
    }
}