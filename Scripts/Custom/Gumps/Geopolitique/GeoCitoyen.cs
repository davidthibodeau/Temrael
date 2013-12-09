using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
    class GeoCitoyen : Gump
    {
        private Mobile m_From;
        private GeoController m_item;
        private GeoTabs m_tab;
        private GeoMembre m_membre;

        public GeoCitoyen(Mobile from, GeoController item, GeoTabs tab, GeoMembre membre)
            : base(0, 0)
        {
            m_From = from;
            m_item = item;
            m_tab = tab;
            m_membre = membre;

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

            switch (tab)
            {
                case GeoTabs.Index:
                    AddHtml(258, 195, 200, 20, "<h1><basefont color=#025a>Aperçu<basefont></h1>", false, false);

                    //ECON//
                    //Edges
                    AddBackground(172, 224, 236, 242, 2620);
                    //Terrain
                    switch (m_item.Terrain)
                    {
                        case GeoTerrains.Colines:
                            AddImage(176, 230, 876);
                            break;
                        case GeoTerrains.Desert:
                            AddImage(176, 230, 874);
                            break;
                        case GeoTerrains.Foret:
                            AddImage(176, 230, 875);
                            break;
                        case GeoTerrains.Montagnes:
                            AddImage(176, 230, 877);
                            break;
                        case GeoTerrains.Plaine:
                            AddImage(176, 230, 878);
                            break;
                        case GeoTerrains.Marais:
                            AddImage(176, 230, 879);
                            break;
                        default:
                            AddImage(176, 230, 878);
                            break;
                    }
                    //Chateau
                    for (int i = 0; i < item.Constructions.Count; i++)
                    {
                        switch (m_item.Constructions[i].Construction)
                        {
                            case GeoBuildType.Castel:
                                {
                                    switch (m_item.Constructions[i].Level)
                                    {
                                        case (int)GeoChateaux.Fort:
                                            AddImage(280, 295, 899);
                                            break;
                                        case (int)GeoChateaux.Castel:
                                            AddImage(280, 295, 897);
                                            break;
                                        case (int)GeoChateaux.Forteresse:
                                            AddImage(280, 295, 896);
                                            break;
                                        case (int)GeoChateaux.Chateau:
                                            AddImage(280, 295, 895);
                                            break;
                                        case (int)GeoChateaux.Citadelle:
                                            AddImage(280, 295, 894);
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case GeoBuildType.Religion:
                                switch (m_item.Constructions[i].Level)
                                {
                                    case (int)GeoReligion.Chapelle:
                                        AddImage(349, 308, 888);
                                        break;
                                    case (int)GeoReligion.Eglise:
                                        AddImage(349, 308, 887);
                                        break;
                                    case (int)GeoReligion.Temple:
                                        AddImage(349, 308, 886);
                                        break;
                                    case (int)GeoReligion.Cathedrale:
                                        AddImage(349, 308, 885);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case GeoBuildType.Routes:
                                {
                                    switch (m_item.Constructions[i].Level)
                                    {
                                        case (int)GeoRoutes.Petite:
                                            AddImage(242, 364, 906);
                                            break;
                                        case (int)GeoRoutes.Grande:
                                            AddImage(242, 364, 906);
                                            AddImage(176, 305, 905);
                                            break;
                                        default: break;
                                    }
                                }
                                break;
                            case GeoBuildType.Mines:
                                switch (m_item.Constructions[i].Level)
                                {
                                    case (int)GeoMine.Petite:
                                        AddImage(242, 387, 908);
                                        break;
                                    case (int)GeoMine.Grande:
                                        AddImage(242, 387, 907);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case GeoBuildType.Port:
                                switch (m_item.Constructions[i].Level)
                                {
                                    case (int)GeoPort.Peche:
                                        AddImage(338, 394, 914);
                                        break;
                                    case (int)GeoPort.Petit:
                                        AddImage(338, 394, 913);
                                        break;
                                    case (int)GeoPort.Moyen:
                                        AddImage(338, 394, 912);
                                        break;
                                    case (int)GeoPort.Grand:
                                        AddImage(338, 394, 911);
                                        break;
                                    default: break;
                                }
                                break;
                            case GeoBuildType.Foresterie:
                                switch (m_item.Constructions[i].Level)
                                {
                                    case (int)GeoForesterie.Petite:
                                        AddImage(370, 369, 916);
                                        break;
                                    case (int)GeoForesterie.Grande:
                                        AddImage(370, 369, 915);
                                        break;
                                    default: break;
                                }
                                break;
                            case GeoBuildType.Muraille:
                                AddImage(176, 436, 904);
                                break;
                            case GeoBuildType.Entrainement:
                                AddImage(225, 317, 903);
                                break;
                            case GeoBuildType.Bibliotheque:
                                AddImage(381, 288, 901);
                                break;
                            case GeoBuildType.Tour:
                                AddImage(316, 292, 900);
                                break;
                            case GeoBuildType.Monastere:
                                AddImage(195, 292, 891);
                                break;
                            case GeoBuildType.Cimetiere:
                                AddImage(187, 337, 892);
                                break;
                            case GeoBuildType.Atelier:
                                AddImage(227, 366, 910);
                                break;
                            case GeoBuildType.Forge:
                                AddImage(210, 331, 909);
                                break;
                            case GeoBuildType.Ferme:
                                AddImage(267, 358, 920);
                                break;
                            case GeoBuildType.Taverne:
                                AddImage(275, 313, 883);
                                break;
                            case GeoBuildType.Teinturier:
                                AddImage(176, 406, 921);
                                break;
                            case GeoBuildType.Architecte:
                                AddImage(179, 359, 918);
                                break;
                            case GeoBuildType.Tisseur:
                                AddImage(272, 420, 919);
                                break;
                            case GeoBuildType.MoulinEau:
                                AddImage(201, 406, 923);
                                break;
                            case GeoBuildType.MoulinVent:
                                AddImage(318, 310, 924);
                                break;
                            case GeoBuildType.Theatre:
                                AddImage(216, 297, 925);
                                break;
                            case GeoBuildType.Tanneur:
                                AddImage(216, 297, 925);
                                break;
                            case GeoBuildType.Bordel:
                                AddImage(326, 420, 882);
                                break;
                            case GeoBuildType.Mercenaire:
                                AddImage(328, 346, 902);
                                break;
                            case GeoBuildType.Boucher:
                                AddImage(291, 331, 922);
                                break;
                            case GeoBuildType.Inventeur:
                                AddImage(197, 376, 917);
                                break;
                            case GeoBuildType.Copiste:
                                AddImage(304, 383, 881);
                                break;
                            case GeoBuildType.Artiste:
                                AddImage(298, 425, 880);
                                break;
                            case GeoBuildType.Court:
                                AddImage(233, 332, 893);
                                break;
                            //Quartier Riche ? Maison riche left
                            default: break;
                        }
                    }
                break;
                case GeoTabs.Taxes:
                    AddHtml(262, 195, 200, 20, "<h3><basefont color=#025a>Taxes<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 160, 9300);
                    AddHtml(145, 235, 200, 20, "<h3><basefont color=#025a>Payer ses Taxes<basefont></h3>", false, false);

                    AddImage(135, 240, 95);
                    AddImage(142, 249, 96);
                    AddImage(258, 249, 96);
                    AddImage(435, 240, 97);

                    switch (m_membre.ClasseSociale)
                    {
                        case GeoClasses.Serfs:
                            break;
                        case GeoClasses.Bourgeois:
                            break;
                        case GeoClasses.Clercs:
                            break;
                        case GeoClasses.Nobles:
                            break;
                        default: break;
                    }
                break;
                case GeoTabs.Revoltes:
                    AddHtml(145, 195, 200, 20, "<h3><basefont color=#025a>Révoltes<basefont></h3>", false, false);

                    AddBackground(130, 230, 320, 110, 9300);

                    AddBackground(143, 255, 45, 55, 2620);
                    AddImage(148, 260, 926);
                    AddHtml(160, 310, 200, 20, "<h3><basefont color=#5A4A31>0%<basefont></h3>", false, false);

                    AddBackground(228, 255, 45, 55, 2620);
                    AddImage(233, 260, 927);
                    AddHtml(245, 310, 200, 20, "<h3><basefont color=#5A4A31>0%<basefont></h3>", false, false);

                    AddBackground(308, 255, 45, 55, 2620);
                    AddImage(313, 260, 928);
                    AddHtml(325, 310, 200, 20, "<h3><basefont color=#5A4A31>0%<basefont></h3>", false, false);

                    AddBackground(393, 255, 45, 55, 2620);
                    AddImage(398, 260, 929);
                    AddHtml(410, 310, 200, 20, "<h3><basefont color=#5A4A31>0%<basefont></h3>", false, false);
                break;
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.AccessLevel < AccessLevel.GameMaster)
                if (from.Deleted || !from.Alive)
                    return;

            switch (info.ButtonID)
            {
                case 1:
                    m_From.SendGump(new GeoCitoyen(m_From, m_item, GeoTabs.Index, m_membre));
                    break;
                case 2:
                    m_From.SendGump(new GeoCitoyen(m_From, m_item, m_tab, m_membre));
                    break;
                case 3:
                    m_From.SendGump(new GeoCitoyen(m_From, m_item, GeoTabs.Taxes, m_membre));
                    break;
                case 4:
                    m_From.SendGump(new GeoCitoyen(m_From, m_item, m_tab, m_membre));
                    break;
                case 5:
                    m_From.SendGump(new GeoCitoyen(m_From, m_item, m_tab, m_membre));
                    break;
                case 6:
                    m_From.SendGump(new GeoCitoyen(m_From, m_item, GeoTabs.Revoltes, m_membre));
                    break;
                default: break;
            }
        }
    }
}
