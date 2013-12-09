using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
    class GeoEtranger : Gump
    {
        private Mobile m_From;
        private GeoController m_item;
        private GeoTabs m_tab;

        public GeoEtranger(Mobile from, GeoController item, GeoTabs tab, bool spying)
            : base(0, 0)
        {
            m_From = from;
            m_item = item;
            m_tab = tab;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(80, 72, 420, 560, 3600);
            AddBackground(90, 82, 400, 540, 9200);
            AddBackground(100, 92, 380, 520, 3500);
            AddBackground(110, 102, 360, 500, 3600);

            AddBackground(130, 195, 320, 30, 9300);

            //Dragons
            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            //Titre
            AddImage(135, 200, 95);
            AddImage(142, 209, 96);
            AddImage(258, 209, 96);
            AddImage(435, 200, 97);

            //Menu
            AddButton(118, 100, 871, 871, 1, GumpButtonType.Reply, 0);
            AddButton(176, 100, 869, 869, 2, GumpButtonType.Reply, 0);
            AddButton(236, 100, 870, 870, 3, GumpButtonType.Reply, 0);
            AddButton(296, 100, 868, 868, 4, GumpButtonType.Reply, 0);
            AddButton(356, 100, 872, 872, 5, GumpButtonType.Reply, 0);
            AddButton(414, 100, 873, 873, 6, GumpButtonType.Reply, 0);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.AccessLevel < AccessLevel.GameMaster)
                if (from.Deleted || !from.Alive)
                    return;

            switch (info.ButtonID)
            {
                default: break;
            }
        }
    }
}
