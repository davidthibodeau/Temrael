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
    public class RegIdentificationGump : GumpTemrael
    {
        private Mobile m_from;
        private BasePlantReagent m_reg;

        public RegIdentificationGump(Mobile from, BasePlantReagent reg)
            : base("Ingrédient", 400, 220)
        {
            m_from = from;
            m_reg = reg;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            x = 90;

            AddItem(x + 5, y + (line * scale) + 12, reg.ItemID);
            AddSection(x + 80, y + (line * scale) + 12, 300, 120, reg.Name, reg.Description);

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            PlayerMobile from = (PlayerMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            //switch (info.ButtonID)
            //{
            //    /*case 1:
            //        from.SendGump(new FicheRaceGump(from));
            //        break;*/
            //}
        }
    }
}
