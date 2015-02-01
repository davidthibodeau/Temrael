using Server.Mobiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Gumps.Creation
{
    public class BaseCreationGump : GumpTemrael
    {
        protected PlayerMobile m_from;

        public BaseCreationGump(PlayerMobile from, string fiche, int hauteur, int largeur, int onglet)
            : base(fiche, hauteur, largeur)
        {
            m_from = from;

            int y = 650;
            int x = 90;
            int space = 70;

            AddCreationMenuItem(x, y, 1193, 2, onglet == 1);
            x += space;
            AddCreationMenuItem(x, y, 1188, 4, onglet == 3);
            //AddCreationMenuItem(x, y, 1190, 3, onglet == 2);
            x += space;
            AddCreationMenuItem(x, y, 1182, 7, onglet == 5);
            x += space;
            //AddCreationMenuItem(x, y, 1224, 6, onglet == 4);
            x += space;

        }

        public override void OnResponse(Network.NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (m_from.Deleted || !m_from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 2:
                    from.SendGump(new CreationRaceGump(m_from));
                    break;
                case 4:
                    from.SendGump(new CreationEquipementGump(m_from));
                    break;
                case 7:
                    from.SendGump(new CreationOverviewGump(m_from));
                    break;
            }
        }
    }
}
