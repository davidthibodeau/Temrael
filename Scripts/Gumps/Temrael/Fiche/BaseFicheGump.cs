using Server.Mobiles;
using Server.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Gumps.Fiche
{
    public class BaseFicheGump : GumpTemrael
    {
        protected PlayerMobile m_from;

        public BaseFicheGump(PlayerMobile from, string fiche, int hauteur, int largeur, int onglet)
            : base(fiche, hauteur, largeur)
        {
            m_from = from;

            int y = 650;
            int x = 90;
            int line = 0;
            int scale = 25;

            int space = 80;

            AddMenuItem(x, y, 1178, 1, onglet == 1);
            x += space;
            AddMenuItem(x, y, 1196, 5, onglet == 5);
            //AddMenuItem(x, y, 1179, 2, onglet == 2);
            x += space;
            AddMenuItem(x, y, 1191, 7, onglet == 7);
            //AddMenuItem(x, y, 1180, 3, onglet == 3);
            x += space;
            AddMenuItem(x, y, 1193, 4, onglet == 4);
            x += space;
            x += space;
            //AddMenuItem(x, y, 1222, 6, onglet == 6);
            x += space;
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (m_from.Deleted || !m_from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.SendGump(new FicheRaceGump(m_from));
                    break;
                //case 2:
                //    from.SendGump(new FicheClasseGump(m_from));
                //    break;
                //case 3:
                //    from.SendGump(new FicheCaracteristiqueGump(m_from));
                //    break;
                case 4:
                    from.SendGump(new FicheCotesGump(m_from));
                    break;
                case 5:
                    from.SendGump(new FicheStatistiquesGump(m_from));
                    break;
                //case 6:
                //    from.SendGump(new FicheStatutsGump(m_from));
                //    break;
                case 7:
                    from.SendGump(new FicheCommandesGump(m_from));
                    break;
            }
        }
    }
}
