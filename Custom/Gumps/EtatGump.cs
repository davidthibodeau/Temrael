using System;
using Server;
using Server.Mobiles;

namespace Server.Gumps
{
    public class EtatGump : Gump
    {
        private Mobile m_From;

        public EtatGump(Mobile from)
            : base(0, 0)
        {
            m_From = from;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //BG
            AddBackground(80, 72, 454, 150, 2620);
            AddBackground(80, 78, 454, 20, 2620);

            AddBackground(84, 74, 448, 20, 9300);
            AddBackground(84, 96, 448, 122, 3600);

            AddHtml(300, 78, 200, 20, "<h3><basefont color=#025a>État<basefont></h3>", false, false);

            //Constitution
            AddBackground(98, 110, 60, 33, 9270);
            AddImage(108, 120, 1723);
            AddHtml(128, 118, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Str + "<basefont></h3>", false, false);

            //Dex
            AddBackground(98, 143, 60, 33, 9270);
            AddImage(108, 153, 1724);
            AddHtml(128, 151, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Dex + "<basefont></h3>", false, false);

            //Sagesse
            AddBackground(98, 176, 60, 33, 9270);
            AddImage(108, 186, 1729);
            AddHtml(128, 184, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);

            //PDV
            AddBackground(158, 110, 80, 33, 9270);
            AddImage(168, 120, 1731);
            AddHtml(188, 118, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Hits + "/" + m_From.HitsMax + "<basefont></h3>", false, false);

            //Stam
            AddBackground(158, 143, 80, 33, 9270);
            AddImage(168, 153, 1730);
            AddHtml(188, 151, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Stam + "/" + m_From.StamMax + "<basefont></h3>", false, false);

            //Piete
            AddBackground(158, 176, 80, 33, 9270);
            AddImage(168, 186, 1728);
            AddHtml(188, 184, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Mana + "/" + m_From.ManaMax + "<basefont></h3>", false, false);

            //Force
            AddBackground(238, 110, 60, 33, 9270);
            AddImage(248, 120, 1725);
            AddHtml(268, 118, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Str + "<basefont></h3>", false, false);

            //Intelligence
            AddBackground(238, 143, 60, 33, 9270);
            AddImage(248, 153, 1726);
            AddHtml(268, 151, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);

            //Charisme
            AddBackground(238, 176, 60, 33, 9270);
            AddImage(248, 186, 1727);
            AddHtml(268, 184, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);

            //Poid
            AddBackground(298, 110, 100, 33, 9270);
            AddImage(308, 120, 1735);
            AddHtml(328, 118, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.TotalWeight + "/" + m_From.MaxWeight + "<basefont></h3>", false, false);

            //EXP
            AddBackground(298, 143, 100, 33, 9270);
            AddImage(308, 153, 1734);
            AddHtml(328, 151, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Stam + "<basefont></h3>", false, false);

            //Compagnons
            AddBackground(298, 176, 100, 33, 9270);
            AddImage(308, 186, 1722);
            AddHtml(328, 184, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Followers + "/" + m_From.FollowersMax + "<basefont></h3>", false, false);

            //Dommages
            AddBackground(398, 110, 60, 33, 9270);
            AddImage(408, 120, 1733);
            AddHtml(428, 118, 200, 20, "<h3><basefont color=#5A4A31>" + "1d6" + "<basefont></h3>", false, false);

            //Parrage
            AddBackground(398, 143, 60, 33, 9270);
            AddImage(408, 153, 1736);
            AddHtml(428, 151, 200, 20, "<h3><basefont color=#5A4A31>" + "1d2" + "<basefont></h3>", false, false);

            //Poison
            AddBackground(398, 176, 60, 33, 9270);
            AddImage(408, 186, 1737);
            AddHtml(428, 184, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);

            //Resistances
            AddBackground(458, 110, 60, 99, 9270);
            AddImage(468, 120, 1721);
            AddHtml(488, 118, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);
            AddImage(468, 133, 1720);
            AddHtml(488, 131, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);
            AddImage(468, 146, 1719);
            AddHtml(488, 144, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);
            AddImage(468, 159, 1715);
            AddHtml(488, 157, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);
            AddImage(468, 172, 1717);
            AddHtml(488, 169, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);
            AddImage(468, 185, 1718);
            AddHtml(488, 183, 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Int + "<basefont></h3>", false, false);
        }
    }
}
