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
    public class CreationClasseGump : GumpTemrael
    {
        private TMobile m_from;
        private ClasseType m_classeType;
        private int m_page;

        public CreationClasseGump(TMobile from)
            : this(from, from.Creation.classe, 0)
        {
        }

        public CreationClasseGump(TMobile from, ClasseType classeType, int page)
            : base("Classe", 560, 622)
        {
            m_from = from;
            m_classeType = classeType;
            m_page = page;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
            int lineMax = 4;

            y = 650;
            x = 90;
            int space = 70;

            AddCreationMenuItem(x, y, 1193, 2, true);
            x += space;
            AddCreationMenuItem(x, y, 1190, 3, false);
            x += space;
            AddCreationMenuItem(x, y, 1188, 4, true);
            x += space;
            AddCreationMenuItem(x, y, 1224, 6, true);
            x += space;
            AddCreationMenuItem(x, y, 1182, 7, true);

            x = XBase;
            y = YBase;



            if (page > 0)
                AddButton(x + 360, y + line * scale, 4014, 4015, 9, GumpButtonType.Reply, 0);
            if (page < (int)ClasseType.Maximum / lineMax)
                AddButton(x + 515, y + line * scale, 4005, 4006, 10, GumpButtonType.Reply, 0);
            ++line;

        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 2:
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 3:
                    if (from.Creation.race != Races.Aucun)
                    {
                        from.SendGump(new CreationClasseGump(from));
                    }
                    else
                    {
                        goto case 2;
                    }
                    break;
                case 4:
                    if (from.Creation.classe != ClasseType.None)
                    {
                        from.SendGump(new CreationEquipementGump(from));
                    }
                    else
                    {
                        goto case 3;
                    }
                    break;
                case 6:
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 7:
                    from.SendGump(new CreationOverviewGump(from));
                    break;
                case 8:
                    from.Creation.classe = m_classeType;
                    from.SendGump(new CreationEquipementGump(from));
                    break;
                case 9:
                    from.SendGump(new CreationClasseGump(from, m_classeType, m_page - 1));
                    break;
                case 10:
                    from.SendGump(new CreationClasseGump(from, m_classeType, m_page + 1));
                    break;
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new CreationClasseGump(from, (ClasseType)(info.ButtonID - 50), m_page));
            }
        }
    }
}
