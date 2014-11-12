using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using Server.Engines.Langues;
using Server.Engines.Evolution;

namespace Server.Gumps
{
    public class FicheCommandesGump : GumpTemrael
    {
        private PlayerMobile m_from;
        private int m_chevelurePage;
        private int m_barbePage;
        private int m_tatooPage;
        private const int CheveluresPages = 9;
        private const int BarbesPages = 3;
        private const int TatooPages = 2;

        public FicheCommandesGump(PlayerMobile from)
            : this(from, 0, 0, 0)
        {
        }

        public FicheCommandesGump(PlayerMobile from, int chevelurePage, int barbePage, int tatooPage)
            : base("Commandes & Accessoires", 560, 622)
        {

            m_chevelurePage = chevelurePage;
            m_barbePage = barbePage;
            m_tatooPage = tatooPage;

            m_from = from;

            int x = XBase;
            int y = YBase;

            y = 650;
            x = 90;
            int space = 80;
            int line = 0;
            int scale = 20;

            AddMenuItem(x, y, 1178, 1, true);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, true);
            x += space;
            AddMenuItem(x, y, 1194, 4, true);
            x += space;
            AddMenuItem(x, y, 1196, 5, true);
            x += space;
            AddMenuItem(x, y, 1221, 6, true);
            x += space;
            AddMenuItem(x, y, 1191, 7, false);

            x = XBase;
            y = YBase;

            AddBackground(515, 145, 95, 132, 2620);
            AddButton(520, 150, 1440, 1440, 7, GumpButtonType.Reply, 0);
            AddTooltip(3001045);

            //AddBackground(545, 325, 95, 132, 2620);
            //AddButton(550, 330, 1439, 1439, 7, GumpButtonType.Reply, 0);
            //AddTooltip(3001045);

            AddBackground(515, 495, 95, 132, 2620);
            AddButton(520, 500, 1441, 1441, 7, GumpButtonType.Reply, 0);
            AddTooltip(3001045);

            AddHtml(105, 115, 200, 20, "<h3><basefont color=#5A4A31>Commandes<basefont></h3>", false, false);
            AddBackground(102, 135, 400, 150, 3500);
            AddImage(95, 120, 95);
            AddImage(102, 129, 96);
            AddImage(202, 129, 96);
            AddImage(322, 129, 96);
            AddImage(500, 120, 97);

            y = 152;
            x = 120;
            line = 0;

            AddButton(x, y, 2117, 2118, 9, GumpButtonType.Reply, 0);
            AddHtml(x + 18, y - 2, 200, 20, "<h3><basefont color=#5A4A31>Langue<basefont></h3>", false, false);
            line++;
            AddButton(x, y + line * scale, 2117, 2118, 10, GumpButtonType.Reply, 0);
            AddHtml(x + 18, y + line * scale - 2, 200, 20, "<h3><basefont color=#5A4A31>Étude des Langues<basefont></h3>", false, false);
            line++;
            AddButton(x, y + line * scale, 2117, 2118, 11, GumpButtonType.Reply, 0);
            AddHtml(x + 18, y + line * scale - 2, 200, 20, "<h3><basefont color=#5A4A31>Exp<basefont></h3>", false, false);
            line++;
            AddButton(x, y + line * scale, 2117, 2118, 13, GumpButtonType.Reply, 0);
            AddHtml(x + 18, y + line * scale - 2, 200, 20, "<h3><basefont color=#5A4A31>Météo<basefont></h3>", false, false);
            line++;
            AddButton(x, y + line * scale, 2117, 2118, 14, GumpButtonType.Reply, 0);
            AddHtml(x + 18, y + line * scale - 2, 190, 20, "<h3><basefont color=#5A4A31>Décoration<basefont></h3>", false, false);
            line++;
            AddButton(x, y + line * scale, 2117, 2118, 21, GumpButtonType.Reply, 0);
            AddHtml(x + 18, y + line * scale - 2, 190, 20, "<h3><basefont color=#5A4A31>Niveau<basefont></h3>", false, false);

            AddHtml(105, 295, 200, 20, "<h3><basefont color=#5A4A31>Chevelures & Barbes<basefont></h3>", false, false);
            AddBackground(102, 315, 267, 150, 3500);
            AddBackground(369, 315, 267, 150, 3500);
            AddImage(95, 300, 95);
            AddImage(102, 309, 96);
            AddImage(202, 309, 96);
            AddImage(322, 309, 96);
            AddImage(405, 309, 96);
            AddImage(460, 309, 96);
            AddImage(635, 300, 97);

            bool second = false;

            for (int i = 0; i < 6; i++)
            {
                if (i + (m_chevelurePage * 6) < m_Chevelures.Length)
                {
                    if (!second)
                    {
                        AddButton(120 + (i * 40), 332, 2117, 2118, m_Chevelures[i + (m_chevelurePage * 6)], GumpButtonType.Reply, 0);
                        AddItem(120 + (i * 40) + 20, 330, m_Chevelures[i + (m_chevelurePage * 6)]);
                        second = true;
                    }
                    else
                    {
                        AddButton(120 + ((i - 1) * 40), 382, 2117, 2118, m_Chevelures[i + (m_chevelurePage * 6)], GumpButtonType.Reply, 0);
                        AddItem(120 + ((i - 1) * 40) + 20, 380, m_Chevelures[i + (m_chevelurePage * 6)]);
                        second = false;
                    }
                }
            }

            second = false;

            for (int i = 0; i < 6; i++)
            {
                if (i + (m_barbePage * 6) < m_Barbes.Length)
                {
                    if (!second)
                    {
                        AddButton(387 + (i * 40), 332, 2117, 2118, m_Barbes[i + (m_barbePage * 6)], GumpButtonType.Reply, 0);
                        AddItem(387 + (i * 40) + 20, 330, m_Barbes[i + (m_barbePage * 6)]);
                        second = true;
                    }
                    else
                    {
                        AddButton(387 + ((i - 1) * 40), 382, 2117, 2118, m_Barbes[i + (m_barbePage * 6)], GumpButtonType.Reply, 0);
                        AddItem(387 + ((i - 1) * 40) + 20, 380, m_Barbes[i + (m_barbePage * 6)]);
                        second = false;
                    }
                }
            }

            AddHtml(160, 425, 150, 18, "<h3><basefont color=#025a>Précédent<basefont></h3>", false, false);
            AddButton(125, 425, 4014, 4016, 15, GumpButtonType.Reply, 0);
            AddHtml(260, 425, 150, 18, "<h3><basefont color=#025a>Suivant<basefont></h3>", false, false);
            AddButton(315, 425, 4005, 4007, 16, GumpButtonType.Reply, 0);

            AddHtml(430, 425, 150, 18, "<h3><basefont color=#025a>Précédent<basefont></h3>", false, false);
            AddButton(395, 425, 4014, 4016, 17, GumpButtonType.Reply, 0);
            AddHtml(530, 425, 150, 18, "<h3><basefont color=#025a>Suivant<basefont></h3>", false, false);
            AddButton(580, 425, 4005, 4007, 18, GumpButtonType.Reply, 0);

            AddHtml(105, 470, 200, 20, "<h3><basefont color=#5A4A31>Tatoos<basefont></h3>", false, false);
            AddBackground(102, 490, 400, 150, 3500);
            AddImage(95, 475, 95);
            AddImage(102, 484, 96);
            AddImage(202, 484, 96);
            AddImage(322, 484, 96);
            AddImage(500, 475, 97);

            second = false;

            for (int i = 0; i < 10; i++)
            {
                if (i + (m_tatooPage * 10) < m_Tatoos.Length)
                {
                    if (!second)
                    {
                        AddButton(120 + (i * 35), 507, 2117, 2118, m_Tatoos[i + (m_tatooPage * 10)], GumpButtonType.Reply, 0);
                        AddItem(120 + (i * 35) + 20, 505, m_Tatoos[i + (m_tatooPage * 10)]);
                        second = true;
                    }
                    else
                    {
                        AddButton(120 + ((i - 1) * 35), 557, 2117, 2118, m_Tatoos[i + (m_tatooPage * 10)], GumpButtonType.Reply, 0);
                        AddItem(120 + ((i - 1) * 35) + 20, 555, m_Tatoos[i + (m_tatooPage * 10)]);
                        second = false;
                    }
                }
            }

            AddHtml(160, 600, 150, 18, "<h3><basefont color=#025a>Précédent<basefont></h3>", false, false);
            AddButton(125, 600, 4014, 4016, 19, GumpButtonType.Reply, 0);

            AddHtml(390, 600, 150, 18, "<h3><basefont color=#025a>Suivant<basefont></h3>", false, false);
            AddButton(445, 600, 4005, 4007, 20, GumpButtonType.Reply, 0);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            PlayerMobile from = (PlayerMobile)sender.Mobile;

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
                    //Vemotes
                    break;
                case 9:
                    from.SendGump(new GumpLanguage(from, false));
                    break;
                case 10:
                    from.SendGump(new GumpLanguage(from, true));
                    break;
                case 11:
                    from.SendMessage(from.Experience.XP.ToString() + " points d'experiences");
                    break;
                case 12:
                    //Titre
                    break;
                case 13:
                    from.SendGump(new ConditionGump((Mobile)from));
                    break;
                case 14:
                    from.SendGump(new DecorationGump((Mobile)from));
                    break;
                case 15:
                    if (m_chevelurePage > 0)
                        from.SendGump(new FicheCommandesGump(from, --m_chevelurePage, m_barbePage, m_tatooPage));
                    else
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    break;
                case 16:
                    if (m_chevelurePage < CheveluresPages)
                        from.SendGump(new FicheCommandesGump(from, ++m_chevelurePage, m_barbePage, m_tatooPage));
                    else
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    break;
                case 17:
                    if (m_barbePage > 0)
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, --m_barbePage, m_tatooPage));
                    else
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    break;
                case 18:
                    if (m_barbePage < BarbesPages)
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, ++m_barbePage, m_tatooPage));
                    else
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    break;
                case 19:
                    if (m_tatooPage > 0)
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, --m_tatooPage));
                    else
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    break;
                case 20:
                    if (m_tatooPage < TatooPages)
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, ++m_tatooPage));
                    else
                        from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    break;
                case 21:
                    if (XP.CanEvolve((PlayerMobile)from))
                        XP.Evolve((PlayerMobile)from);
                    from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    break;
                case 11025:
                    if (from.FindItemOnLayer(Layer.Tatoo) != null)
                        if (from.FindItemOnLayer(Layer.Tatoo) is GenericTatoo)
                            from.FindItemOnLayer(Layer.Tatoo).Delete();
                    from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    return;
                case 12366:
                    from.HairItemID = 0;
                    from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    return;
                case 12367:
                    from.FacialHairItemID = 0;
                    from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                    return;
            }

            for (int i = 0; i < m_Chevelures.Length; i++)
            {
                if (m_Chevelures[i] == info.ButtonID)
                {
                    from.HairItemID = info.ButtonID;
                    from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                }
            }
            for (int i = 0; i < m_Barbes.Length; i++)
            {
                if (m_Barbes[i] == info.ButtonID)
                {
                    from.FacialHairItemID = info.ButtonID;
                    from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                }
            }
            for (int i = 0; i < m_Tatoos.Length; i++)
            {
                if (m_Tatoos[i] == info.ButtonID)
                {
                    GenericTatoo Tatoo = new GenericTatoo(info.ButtonID);
                    if (from.FindItemOnLayer(Layer.Tatoo) != null)
                        if (from.FindItemOnLayer(Layer.Tatoo) is GenericTatoo)
                            from.FindItemOnLayer(Layer.Tatoo).Delete();

                    if (!from.EquipItem(Tatoo))
                        Tatoo.Delete();
                    //from.FacialHairItemID = info.ButtonID;
                    from.SendGump(new FicheCommandesGump(from, m_chevelurePage, m_barbePage, m_tatooPage));
                }
            }
        }

        private int[] m_Chevelures = new int[]{
            //Manque ceux de base
            //43
               10197,
               10198,
               10200,
               10201,
               10202,
               10203,
               10204,
               10205,
               10206,
               10207,
               10209,
               10210,
               10211,
               10212,
               10213,
               10214,
               10215,
               10216,
               10219,
               10220,
               10221,
               10222,
               10223,
               10224,
               10225,
               10226,
               10227,
               10228,
               10229,
               10399,
               11122,
               11123,
               11124,
               11125,
               11126,
               11127,
               10291,
               10292,
               10293,
               10294,
               10295,
               10296,
               10297,
               10298,
               10299,
               8251,
               8252,
               8253,
               8260,
               8261,
               8262,
               8263,
               8264,
               8265,
               12366 //None
        };

        private int[] m_Barbes = new int[]{
            //Manque ceux de base
               10300,
               10301,
               10302,
               10303,
               10304,
               10305,
               10306,
               10307,
               10308,
               10309,
               10312,
               10313,
               10314,
               10315,
               8254,
               8255,
               8256,
               8257,
               8267,
               8268,
               8269,
               12367 //None
        };

        private int[] m_Tatoos = new int[]{
               5209,
               5210,
               5211,
               5212,
               5213,
               5214,
               5215,
               5216,
               5217,
               5218,
               5219,
               5220,
               5221,
               5222,
               5223,
               5224,
               5225,
               5226,
               5227,
               5228,
               12239,
               12240,
               12241,
               12242,
               12243,
               12251,
               12256,
               12257,
               11025 //None
        };
    }
}
