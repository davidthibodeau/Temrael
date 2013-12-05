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

namespace scripts.Quests
{
    class QuestOverload
    {
        public static void Initialize()
        {
            EventSink.QuestGumpRequest += new QuestGumpRequestHandler(EventSink_QuestGumpRequest);

        }

        public static void EventSink_QuestGumpRequest(QuestGumpRequestArgs e)
        {
            Mobile mob = e.Mobile;

            if (!mob.HasGump(typeof(QuiGump)))
            {
                mob.SendGump(new QuiGump(mob));
            }
            else
            {
                mob.CloseGump(typeof(QuiGump));
                mob.SendGump(new QuiGump(mob));
            }
        }
    }
}