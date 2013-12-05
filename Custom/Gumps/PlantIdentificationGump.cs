using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class PlantIdentificationGump : GumpTemrael
    {
        private Mobile m_from;
        private BasePlant m_plant;

        public PlantIdentificationGump(Mobile from, BasePlant plant)
            : base("Plante", 400, 220)
        {
            m_from = from;
            m_plant = plant;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            x = 90;

            AddItem(x + 5, y + (line * scale) + 12, plant.ItemID);
            AddSection(x + 80, y + (line * scale) + 12, 300, 120, plant.Latin, plant.Description);

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                /*case 1:
                    from.SendGump(new FicheRaceGump(from));
                    break;*/
            }
        }
    }
}
