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
    public class FicheAptitudeInfoGump : GumpTemrael
    {
        private TMobile m_from;
        private Aptitude m_aptitude;
        private ClasseBranche m_categ;
        private int m_pageCateg;
        private int m_pageAptitude;

        public FicheAptitudeInfoGump(TMobile from, Aptitude aptitude)
            : this(from, aptitude, 0, 0, ClasseBranche.Aucun)
        {
        }

        public FicheAptitudeInfoGump(TMobile from, Aptitude aptitude, int pageCateg, int pageDon, ClasseBranche categ)
            : base("Aptitudes", 560, 622)
        {
            m_from = from;
            m_aptitude = aptitude;
            m_pageCateg = pageCateg;
            m_pageAptitude = pageDon;
            m_categ = categ;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1178, 1, true);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, true);
            x += space;
            AddMenuItem(x, y, 1194, 4, false);
            x += space;
            AddMenuItem(x, y, 1196, 5, true);
            x += space;
            AddMenuItem(x, y, 1222, 6, true);
            x += space;
            AddMenuItem(x, y, 1191, 7, true);

            x = XBase;
            y = YBase;

        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.SendGump(new FicheRaceGump(from));
                    break;
                case 2:
                    from.SendGump(new FicheClasseGump(from));
                    break;
                case 3:
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 4:
                    from.SendGump(new FicheCompetencesGump(from));
                    break;
                case 5:
                    from.SendGump(new FicheStatistiquesGump(from));
                    break;
                case 6:
                    from.SendGump(new FicheStatutsGump(from));
                    break;
                case 7:
                    from.SendGump(new FicheCommandesGump(from));
                    break;
                case 8:
                    from.SendGump(new FicheAptitudeInfoGump(from, m_aptitude, m_pageCateg - 1, m_pageAptitude, m_categ));
                    break;
                case 9:
                    from.SendGump(new FicheAptitudeInfoGump(from, m_aptitude, m_pageCateg + 1, m_pageAptitude, m_categ));
                    break;
                case 10:
                    from.SendGump(new FicheAptitudeInfoGump(from, m_aptitude, m_pageCateg, m_pageAptitude - 1, m_categ));
                    break;
                case 11:
                    from.SendGump(new FicheAptitudeInfoGump(from, m_aptitude, m_pageCateg, m_pageAptitude + 1, m_categ));
                    break;
            }

            if (info.ButtonID >= 500)
            {
                from.SendGump(new FicheAptitudeInfoGump(from, (Aptitude)info.ButtonID - 500, m_pageCateg, m_pageAptitude, m_categ));
                return;
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new FicheAptitudeInfoGump(from, m_aptitude, m_pageCateg, 0, (ClasseBranche)info.ButtonID - 50));
                return;
            }
        }
    }
}
