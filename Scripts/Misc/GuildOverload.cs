using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;
using Server.Multis;
using Server.Engines.Help;
using Server.ContextMenus;
using Server.Spells;
using Server.Commands;
using Server.Gumps.Fiche;

namespace scripts.Quests
{
    class GuildOverload
    {
        public static void Initialize()
        {
            EventSink.GuildGumpRequest += new GuildGumpRequestHandler(EventSink_GuildGumpRequest);
        }

        public static void EventSink_GuildGumpRequest(GuildGumpRequestArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                PlayerMobile requester = (PlayerMobile)e.Mobile;
                // etc. Call your own Gump here, etc.   
                if (!requester.HasGump(typeof(FicheRaceGump)))
                {
                    requester.SendGump(new FicheRaceGump(requester));
                }
            }
        }
    }
}