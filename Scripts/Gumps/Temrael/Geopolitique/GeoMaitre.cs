using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
    public enum GeoTabs
    {
        Index,
        IndexConseillers,
        Militaire,
        Taxes,
        TaxesLocales,
        TaxesLiege,
        TaxesReligieuses,
        Population,
        PopulationSerfs,
        PopulationCitoyens,
        PopulationClerge,
        PopulationNoble,
        Religion,
        Revoltes,
        NouveauProjet
    }
    class GeoMaitre : Gump
    {
        private Mobile m_From;
        private GeoController m_item;
        private GeoTabs m_tab;

        public GeoMaitre(Mobile from, GeoController item, GeoTabs tab)
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

            int Or = 0;
            int Argent = 0;

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
                                    switch(m_item.Constructions[i].Level)
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

                    //Conseillers
                    AddBackground(130, 465, 320, 120, 9300);
                    AddHtml(145, 475, 200, 20, "<h1><basefont color=#025a>Conseillers<basefont></h1>", false, false);

                    AddImage(135, 480, 95);
                    AddImage(142, 489, 96);
                    AddImage(258, 489, 96);
                    AddImage(435, 480, 97);

                    AddHtml(305, 564, 200, 20, "<h3><basefont color=#5A4A31>Nouveau Conseiller<basefont></h3>", false, false);
                    AddButton(420, 560, 934, 934, 7, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.Militaire:
                    AddHtml(265, 195, 200, 20, "<h1><basefont color=#025a>Armée<basefont></h1>", false, false);

                    AddBackground(130, 230, 320, 165, 9300);

                    AddButton(440, 235, 1506, 1506, 8, GumpButtonType.Reply, 0);
                    AddButton(440, 260, 1500, 1500, 9, GumpButtonType.Reply, 0);
                    AddButton(440, 285, 1504, 1504, 10, GumpButtonType.Reply, 0);
                    AddButton(440, 310, 1503, 1503, 11, GumpButtonType.Reply, 0);
                    AddButton(440, 335, 1501, 1501, 12, GumpButtonType.Reply, 0);
                    AddButton(440, 360, 1502, 1502, 13, GumpButtonType.Reply, 0);
                    //AddButton(440, 385, 1505, 1505, 9, GumpButtonType.Reply, 1);

                    AddImage(150, 260, 1513);
                    AddHtml(190, 260, 200, 20, "<h3><basefont color=#025a>0<basefont></h1>", false, false);
                    AddImage(150, 300, 1514);
                    AddHtml(190, 300, 200, 20, "<h3><basefont color=#025a>0<basefont></h1>", false, false);
                    AddImage(150, 340, 1515);
                    AddHtml(190, 340, 200, 20, "<h3><basefont color=#025a>0<basefont></h1>", false, false);

                    AddButton(332, 233, 4008, 4010, 28, GumpButtonType.Reply, 0);
                    AddButton(332, 258, 4008, 4010, 29, GumpButtonType.Reply, 0);
                    AddButton(332, 283, 4008, 4010, 30, GumpButtonType.Reply, 0);
                    AddButton(332, 308, 4008, 4010, 31, GumpButtonType.Reply, 0);
                    AddButton(332, 333, 4008, 4010, 32, GumpButtonType.Reply, 0);
                    AddButton(332, 358, 4008, 4010, 33, GumpButtonType.Reply, 0);

                    AddBackground(360, 233, 80, 33, 9270);
                    AddTextEntry(369, 241, 50, 20, 0, 1, Convert.ToString(m_item.Armee.Sauvages));
                    AddBackground(360, 258, 80, 33, 9270);
                    AddTextEntry(369, 266, 50, 20, 0, 2, Convert.ToString(m_item.Armee.Archers));
                    AddBackground(360, 283, 80, 33, 9270);
                    AddTextEntry(369, 291, 50, 20, 0, 3, Convert.ToString(m_item.Armee.Hallebardiers));
                    AddBackground(360, 308, 80, 33, 9270);
                    AddTextEntry(369, 316, 50, 20, 0, 4, Convert.ToString(m_item.Armee.Fantassins));
                    AddBackground(360, 333, 80, 33, 9270);
                    AddTextEntry(369, 341, 50, 20, 0, 5, Convert.ToString(m_item.Armee.Cavaliers));
                    AddBackground(360, 358, 80, 33, 9270);
                    AddTextEntry(369, 366, 50, 20, 0, 6, Convert.ToString(m_item.Armee.Chevaliers));

                    AddBackground(210, 395, 165, 95, 2620);
                    AddImage(215, 400, 1508);

                    //AddHtml(145, 230, 200, 20, "<h1><basefont color=#025a>Miliciens<basefont></h1>", false, false);

                    //AddButton(380, 355, 9004, 9004, 10, GumpButtonType.Reply, 0);

                    AddHtml(150, 374, 200, 20, "<h3><basefont color=#5A4A31>Retour à la réserve<basefont></h3>", false, false);
                    AddButton(125, 370, 934, 934, 34, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.Taxes:
                    AddHtml(262, 195, 200, 20, "<h3><basefont color=#025a>Taxes<basefont></h3>", false, false);

                    //Locales
                    AddButton(170, 225, 932, 932, 14, GumpButtonType.Reply, 0);
                    AddBackground(132, 265, 100, 45, 83);
                    AddHtml(160, 280, 200, 20, "<h3><basefont color=#999999>Locales<basefont></h3>", false, false);

                    //Royales
                    AddButton(272, 225, 930, 930, 15, GumpButtonType.Reply, 0);
                    AddBackground(239, 265, 100, 45, 83);
                    AddHtml(272, 280, 200, 20, "<h3><basefont color=#999999>Liege<basefont></h3>", false, false);

                    //Religieuses
                    AddButton(382, 225, 931, 931, 16, GumpButtonType.Reply, 0);
                    AddBackground(347, 265, 100, 45, 83);
                    AddHtml(362, 280, 200, 20, "<h3><basefont color=#999999>Religieuses<basefont></h3>", false, false);

                    AddBackground(130, 325, 320, 160, 9300);
                    AddHtml(145, 335, 200, 20, "<h3><basefont color=#025a>Tresorerie<basefont></h3>", false, false);

                    AddImage(135, 340, 95);
                    AddImage(142, 349, 96);
                    AddImage(258, 349, 96);
                    AddImage(435, 340, 97);

                    AddItem(135, 360, 3820);
                    AddItem(135, 390, 3826);
                    AddItem(135, 420, 3823);

                    Argent = m_item.Tresorerie / 10;
                    Or = m_item.Tresorerie / 10;

                    AddBackground(175, 360, 80, 33, 9270);
                    AddTextEntry(184, 368, 50, 20, 0, 1, m_item.Tresorerie.ToString());
                    AddBackground(175, 390, 80, 33, 9270);
                    AddTextEntry(184, 398, 50, 20, 0, 2, Argent.ToString());
                    AddBackground(175, 420, 80, 33, 9270);
                    AddTextEntry(184, 428, 50, 20, 0, 3, Or.ToString());

                    AddHtml(305, 464, 200, 20, "<h3><basefont color=#5A4A31>Retirer les pieces<basefont></h3>", false, false);
                    AddButton(420, 460, 934, 934, 17, GumpButtonType.Reply, 0);


                    AddBackground(130, 485, 320, 100, 9300);
                    AddHtml(145, 495, 200, 20, "<h3><basefont color=#025a>Projet<basefont></h3>", false, false);

                    AddImage(135, 500, 95);
                    AddImage(142, 509, 96);
                    AddImage(258, 509, 96);
                    AddImage(435, 500, 97);

                    if (m_item.Projet != null)
                    {
                        switch (m_item.Projet.Construction)
                        {

                            default: break;
                        }
                    }

                    AddHtml(325, 564, 200, 20, "<h3><basefont color=#5A4A31>Nouveau Projet<basefont></h3>", false, false);
                    AddButton(420, 560, 934, 934, 35, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.Population:
                    AddHtml(250, 195, 200, 20, "<h3><basefont color=#025a>Population<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 120, 9300);

                    AddHtml(145, 235, 200, 20, "<h3><basefont color=#025a>Classes Sociales<basefont></h3>", false, false);

                    AddImage(135, 240, 95);
                    AddImage(142, 249, 96);
                    AddImage(258, 249, 96);
                    AddImage(435, 240, 97);

                    AddBackground(143, 260, 45, 55, 2620);
                    AddButton(148, 265, 926, 926, 18, GumpButtonType.Reply, 0);
                    AddHtml(147, 315, 200, 20, "<h3><basefont color=#5A4A31>Serfs<basefont></h3>", false, false);

                    AddBackground(228, 260, 45, 55, 2620);
                    AddButton(233, 265, 927, 927, 19, GumpButtonType.Reply, 0);
                    AddHtml(227, 315, 200, 20, "<h3><basefont color=#5A4A31>Citoyen<basefont></h3>", false, false);

                    AddBackground(308, 260, 45, 55, 2620);
                    AddButton(313, 265, 928, 928, 20, GumpButtonType.Reply, 0);
                    AddHtml(312, 315, 200, 20, "<h3><basefont color=#5A4A31>Clergé<basefont></h3>", false, false);

                    AddBackground(393, 260, 45, 55, 2620);
                    AddButton(398, 265, 929, 929, 21, GumpButtonType.Reply, 0);
                    AddHtml(398, 315, 200, 20, "<h3><basefont color=#5A4A31>Noble<basefont></h3>", false, false);

                    //Salaires
                    AddBackground(130, 345, 320, 150, 9300);

                    AddHtml(145, 355, 200, 20, "<h3><basefont color=#025a>Rentes & Salaires<basefont></h3>", false, false);

                    AddImage(135, 360, 95);
                    AddImage(142, 369, 96);
                    AddImage(258, 369, 96);
                    AddImage(435, 360, 97);

                    AddHtml(145, 380, 290, 80, "Vous pouvez donner un salaire à vos sujets ici. Celui-ci sera retiré de votre trésorerie à chaque semaine.", true, true);

                    //AddButton(400, 465, 9004, 9004, 10, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.Religion:
                    AddHtml(260, 195, 200, 20, "<h3><basefont color=#025a>Religion<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 160, 9300);
                    AddImage(232, 224, 931);
                    AddImage(320, 224, 931);
                    AddHtml(254, 240, 200, 20, "<h3><basefont color=#025a>Tresorerie<basefont></h3>", false, false);

                    AddImage(135, 245, 95);
                    AddImage(142, 254, 96);
                    AddImage(258, 254, 96);
                    AddImage(435, 245, 97);

                    AddItem(135, 260, 3820);
                    AddItem(135, 290, 3826);
                    AddItem(135, 320, 3823);

                    Argent = m_item.TresorerieReligion / 10;
                    Or = m_item.TresorerieReligion / 10;

                    AddBackground(175, 260, 80, 33, 9270);
                    AddTextEntry(184, 268, 50, 20, 0, 1, m_item.TresorerieReligion.ToString());
                    AddBackground(175, 290, 80, 33, 9270);
                    AddTextEntry(184, 298, 50, 20, 0, 2, Argent.ToString());
                    AddBackground(175, 320, 80, 33, 9270);
                    AddTextEntry(184, 328, 50, 20, 0, 3, Or.ToString());

                    AddHtml(305, 364, 200, 20, "<h3><basefont color=#5A4A31>Retirer les pieces<basefont></h3>", false, false);
                    AddButton(420, 360, 934, 934, 22, GumpButtonType.Reply, 0);

                    AddBackground(130, 390, 320, 130, 9300);
                    AddImage(232, 389, 931);
                    AddImage(320, 389, 931);
                    AddHtml(258, 405, 200, 20, "<h3><basefont color=#025a>Donations<basefont></h3>", false, false);

                    AddImage(135, 410, 95);
                    AddImage(142, 419, 96);
                    AddImage(258, 419, 96);
                    AddImage(435, 410, 97);

                    AddHtml(145, 430, 290, 80, "<h3>Toutes les donations sont ajoutés à la trésorerie automatiquement. Le personnage donnant l'or se verra récompenser avec de la piété.</h3>", true, true);
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
                case GeoTabs.IndexConseillers:
                    AddHtml(260, 195, 200, 20, "<h3><basefont color=#025a>Conseillers<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 250, 9300);

                    AddCheck(135, 230, 210, 211, false, 1);
                    AddHtml(155, 230, 200, 20, "<h3><basefont color=#5A4A31>Accès Militaire<basefont></h3>", false, false);
                    AddCheck(135, 250, 210, 211, false, 1);
                    AddHtml(155, 250, 200, 20, "<h3><basefont color=#5A4A31>Accès aux Taxes<basefont></h3>", false, false);
                    AddCheck(135, 270, 210, 211, false, 1);
                    AddHtml(155, 270, 200, 20, "<h3><basefont color=#5A4A31>Accès à la Population<basefont></h3>", false, false);
                    AddCheck(135, 290, 210, 211, false, 1);
                    AddHtml(155, 290, 200, 20, "<h3><basefont color=#5A4A31>Accès à la Religion<basefont></h3>", false, false);

                    AddHtml(272, 455, 200, 20, "<h3><basefont color=#5A4A31>Ajouter un conseiller<basefont></h3>", false, false);
                    AddButton(410, 455, 9004, 9004, 23, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.TaxesLocales:
                    AddHtml(262, 195, 200, 20, "<h3><basefont color=#025a>Taxes<basefont></h3>", false, false);

                    //Taille
                    AddBackground(130, 225, 320, 120, 9300);
                    AddImage(238, 224, 932);
                    AddHtml(275, 235, 200, 20, "<h3><basefont color=#025a>Taille<basefont></h3>", false, false);
                    AddImage(315, 224, 932);

                    //AddButton(195, 260, 95, 95, 10, GumpButtonType.Reply, 0);
                    //AddImage(202, 269, 96);
                    //AddButton(375, 260, 97, 97, 10, GumpButtonType.Reply, 0);

                    //AddImage(200, 262, 933);

                    AddHtml(135, 280, 320, 20, "<h3><basefont color=#5A4A31>Taxes basé sur la richesse du personnage.<basefont></h3>", false, false);
                    AddHtml(135, 300, 320, 20, "<h3><basefont color=#5A4A31>Les revenues iront à vous.<basefont></h3>", false, false);

                    int taille = 0;
                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        if (m_item.Citoyens[i].ClasseSociale == GeoClasses.Serfs || m_item.Citoyens[i].ClasseSociale == GeoClasses.Clercs)
                            taille += m_item.Citoyens[i].Taxe;
                    }

                    AddHtml(135, 320, 200, 20, "<h3><basefont color=#5A4A31>Redevance : 0 écus<basefont></h3>", false, false);
                    
                    //Aides
                    AddBackground(130, 345, 320, 120, 9300);
                    AddImage(242, 344, 932);
                    AddHtml(275, 355, 200, 20, "<h3><basefont color=#025a>Aides<basefont></h3>", false, false);
                    AddImage(314, 344, 932);

                    /*AddButton(195, 380, 95, 95, 10, GumpButtonType.Reply, 0);
                    AddImage(202, 389, 96);
                    AddButton(375, 380, 97, 97, 10, GumpButtonType.Reply, 0);

                    AddImage(200, 382, 933);*/

                    AddHtml(135, 400, 320, 20, "<h3><basefont color=#5A4A31>Tarifs sur l'import. Augemente avec les<basefont></h3>", false, false);
                    AddHtml(135, 420, 320, 20, "<h3><basefont color=#5A4A31>routes et les ports.<basefont></h3>", false, false);

                    AddHtml(135, 440, 200, 20, "<h3><basefont color=#5A4A31>Redevance : Additioné avec les octrois.<basefont></h3>", false, false);
                    
                    //Octroi
                    AddBackground(130, 465, 320, 120, 9300);
                    AddImage(238, 464, 932);
                    AddHtml(272, 475, 200, 20, "<h3><basefont color=#025a>Octroi<basefont></h3>", false, false);
                    AddImage(320, 464, 932);

                    /*AddButton(195, 500, 95, 95, 10, GumpButtonType.Reply, 0);
                    AddImage(202, 509, 96);
                    AddButton(375, 500, 97, 97, 10, GumpButtonType.Reply, 0);

                    AddImage(200, 502, 933);*/

                    AddHtml(135, 520, 320, 20, "<h3><basefont color=#5A4A31>Taxes payés au seigneur pour la vente de<basefont></h3>", false, false);
                    AddHtml(135, 540, 320, 20, "<h3><basefont color=#5A4A31>biens. Payés par les divers marchés.<basefont></h3>", false, false);

                    int aides = 0;
                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        if (m_item.Citoyens[i].ClasseSociale == GeoClasses.Bourgeois)
                            aides += m_item.Citoyens[i].Taxe;
                    }

                    AddHtml(135, 560, 200, 20, "<h3><basefont color=#5A4A31>Redevance : " + Convert.ToString(aides) + " écus<basefont></h3>", false, false);
                    break;
                case GeoTabs.TaxesLiege:
                    AddHtml(262, 195, 200, 20, "<h3><basefont color=#025a>Taxes<basefont></h3>", false, false);

                    //Taillon
                    AddBackground(130, 225, 320, 120, 9300);
                    AddImage(238, 224, 930);
                    AddHtml(268, 235, 200, 20, "<h3><basefont color=#025a>Taillon<basefont></h3>", false, false);
                    AddImage(315, 224, 930);

                    /*AddBackground(135, 260, 50, 20, 9270);
                    AddTextEntry(140, 260, 40, 20, 0x0, 1, "0");*/

                    /*AddButton(195, 260, 95, 95, 10, GumpButtonType.Reply, 0);
                    AddImage(202, 269, 96);
                    AddButton(375, 260, 97, 97, 10, GumpButtonType.Reply, 0);
                    
                    AddImage(200, 262, 933);*/

                    AddHtml(135, 280, 320, 20, "<h3><basefont color=#5A4A31>Taxes pour le maintient des forces militaires<basefont></h3>", false, false);
                    AddHtml(135, 300, 320, 20, "<h3><basefont color=#5A4A31>Les revenues iront à votre liege.<basefont></h3>", false, false);

                    int taillon = 0;
                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        if (m_item.Citoyens[i].ClasseSociale == GeoClasses.Nobles)
                            taillon += m_item.Citoyens[i].Taxe;
                    }

                    AddHtml(135, 320, 200, 20, "<h3><basefont color=#5A4A31>Redevance :" + Convert.ToString(taillon) + " écus<basefont></h3>", false, false);

                    //Traites
                    AddBackground(130, 345, 320, 120, 9300);
                    AddImage(238, 344, 930);
                    AddHtml(268, 355, 200, 20, "<h3><basefont color=#025a>Traites<basefont></h3>", false, false);
                    AddImage(319, 344, 930);

                    AddBackground(135, 380, 50, 20, 9270);
                    AddTextEntry(140, 380, 40, 20, 0x0, 1, "0");
                    AddButton(185, 380, 4005, 4007, 26, GumpButtonType.Reply, 0);

                    /*AddButton(195, 380, 95, 95, 10, GumpButtonType.Reply, 0);
                    AddImage(202, 389, 96);
                    AddButton(375, 380, 97, 97, 10, GumpButtonType.Reply, 0);

                    AddImage(200, 382, 933);*/

                    AddHtml(135, 400, 320, 20, "<h3><basefont color=#5A4A31>Taxes sur la circulation de biens dans le<basefont></h3>", false, false);
                    AddHtml(135, 420, 320, 20, "<h3><basefont color=#5A4A31>royaume.<basefont></h3>", false, false);

                    if (m_item.Liege != null)
                    {
                        AddHtml(135, 440, 200, 20, "<h3><basefont color=#5A4A31>Redevance :" + m_item.Liege.Traites + " écus<basefont></h3>", false, false);
                        AddButton(420, 440, 934, 934, 24, GumpButtonType.Reply, 0);
                        AddHtml(390, 440, 200, 20, "<h3><basefont color=#5A4A31>Payer<basefont></h3>", false, false);
                    }
                    
                    //Aide aux 4 cas
                    AddBackground(130, 465, 320, 120, 9300);
                    AddImage(208, 464, 930);
                    AddHtml(236, 475, 200, 20, "<h3><basefont color=#025a>Aide aux 4 cas<basefont></h3>", false, false);
                    AddImage(342, 464, 930);

                    AddBackground(135, 500, 50, 20, 9270);
                    AddTextEntry(140, 500, 40, 20, 0x0, 1, "0");
                    AddButton(185, 500, 4005, 4007, 27, GumpButtonType.Reply, 0);

                    //AddButton(195, 500, 95, 95, 10, GumpButtonType.Reply, 0);
                    //AddImage(202, 509, 96);
                    //AddButton(375, 500, 97, 97, 10, GumpButtonType.Reply, 0);

                    //AddImage(200, 502, 933);

                    AddHtml(135, 520, 320, 20, "<h3><basefont color=#5A4A31>Taxes payés à son liege en cas de mariage,<basefont></h3>", false, false);
                    AddHtml(135, 540, 320, 20, "<h3><basefont color=#5A4A31>aboudement, guerre ou rancons<basefont></h3>", false, false);

                    if (m_item.Liege != null)
                    {
                        AddHtml(135, 560, 560, 20, "<h3><basefont color=#5A4A31>Redevance :" + m_item.Liege.Aides4Cas + " écus<basefont></h3>", false, false);
                        AddButton(420, 560, 934, 934, 25, GumpButtonType.Reply, 0);
                        AddHtml(390, 560, 200, 20, "<h3><basefont color=#5A4A31>Payer<basefont></h3>", false, false);
                    }
                    break;
                case GeoTabs.TaxesReligieuses:
                    AddHtml(262, 195, 200, 20, "<h3><basefont color=#025a>Taxes<basefont></h3>", false, false);

                    //Dime
                    AddBackground(130, 225, 320, 120, 9300);
                    AddImage(244, 224, 931);
                    AddHtml(278, 235, 200, 20, "<h3><basefont color=#025a>Dîme<basefont></h3>", false, false);
                    AddImage(310, 224, 931);

                    /*AddButton(195, 260, 95, 95, 10, GumpButtonType.Reply, 0);
                    AddImage(202, 269, 96);
                    AddButton(375, 260, 97, 97, 10, GumpButtonType.Reply, 0);

                    AddImage(200, 262, 933);*/

                    AddHtml(135, 280, 320, 20, "<h3><basefont color=#5A4A31>Taxes sur les gains monétaires de chaque<basefont></h3>", false, false);
                    AddHtml(135, 300, 320, 20, "<h3><basefont color=#5A4A31>citoyen.<basefont></h3>", false, false);

                    int dime = 0;
                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        dime += m_item.Citoyens[i].Dime;
                    }

                    AddHtml(135, 320, 200, 20, "<h3><basefont color=#5A4A31>Redevance : " + Convert.ToString(dime) + " écus<basefont></h3>", false, false);

                    //Donations
                    AddBackground(130, 345, 320, 120, 9300);
                    AddImage(236, 344, 931);
                    AddHtml(263, 355, 200, 20, "<h3><basefont color=#025a>Donations<basefont></h3>", false, false);
                    AddImage(319, 344, 931);

                    //AddButton(195, 380, 95, 95, 10, GumpButtonType.Reply, 0);
                    //AddImage(202, 389, 96);
                    //AddButton(375, 380, 97, 97, 10, GumpButtonType.Reply, 0);

                    //AddImage(200, 382, 933);

                    AddHtml(135, 400, 320, 20, "<h3><basefont color=#5A4A31>Donations des citoyens faites à l'église.<basefont></h3>", false, false);

                    //AddHtml(135, 440, 200, 20, "<h3><basefont color=#5A4A31>Revenue : 0 écus<basefont></h3>", false, false);
                    break;
                case GeoTabs.PopulationSerfs:
                    AddHtml(265, 195, 200, 20, "<h3><basefont color=#025a>Serfs<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 250, 9300);

                    AddImage(135, 230, 95);
                    AddImage(142, 239, 96);
                    AddImage(258, 239, 96);
                    AddImage(435, 230, 97);

                    AddHtml(170, 225, 200, 20, "<h3><basefont color=#025a>Nom<basefont></h3>", false, false);
                    AddHtml(300, 225, 200, 20, "<h3><basefont color=#025a>Taille<basefont></h3>", false, false);
                    AddHtml(355, 225, 200, 20, "<h3><basefont color=#025a>Dîme<basefont></h3>", false, false);

                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        if (m_item.Citoyens[i].ClasseSociale == GeoClasses.Serfs)
                        {
                            AddButton(130, 255, 4002, 4004, (100 + i), GumpButtonType.Reply, 0);

                            //Rouge nom si pas payer
                            if (m_item.Citoyens[i].TaxePayer && m_item.Citoyens[i].DimePayer)
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#025a>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);
                            else
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#990000>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);

                            AddBackground(300, 255, 50, 20, 9270);
                            AddTextEntry(305, 255, 40, 20, 0x0, (100 + i), Convert.ToString(m_item.Citoyens[i].Taxe));
                            AddBackground(355, 255, 50, 20, 9270);
                            AddTextEntry(360, 255, 40, 20, 0x0, (200 + i), Convert.ToString(m_item.Citoyens[i].Dime));

                            AddButton(410, 255, 4011, 4013, (200 + i), GumpButtonType.Reply, 0);
                        }
                    }

                    AddHtml(300, 455, 200, 20, "<h3><basefont color=#5A4A31>Ajouter un serf<basefont></h3>", false, false);
                    AddButton(410, 455, 9004, 9004, 10, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.PopulationCitoyens:
                    AddHtml(262, 195, 200, 20, "<h3><basefont color=#025a>Citoyens<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 250, 9300);

                    AddImage(135, 230, 95);
                    AddImage(142, 239, 96);
                    AddImage(258, 239, 96);
                    AddImage(435, 230, 97);

                    AddHtml(170, 225, 200, 20, "<h3><basefont color=#025a>Nom<basefont></h3>", false, false);
                    AddHtml(300, 225, 200, 20, "<h3><basefont color=#025a>Octroi<basefont></h3>", false, false);
                    AddHtml(355, 225, 200, 20, "<h3><basefont color=#025a>Aides<basefont></h3>", false, false);

                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        if (m_item.Citoyens[i].ClasseSociale == GeoClasses.Bourgeois)
                        {
                            AddButton(130, 255, 4002, 4004, 100 + i, GumpButtonType.Reply, 0);
                            //Rouge nom si pas payer
                            if (m_item.Citoyens[i].TaxePayer && m_item.Citoyens[i].DimePayer)
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#025a>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);
                            else
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#990000>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);

                            AddBackground(300, 255, 50, 20, 9270);
                            AddTextEntry(305, 255, 40, 20, 0x0, 100 + i, Convert.ToString(m_item.Citoyens[i].Taxe));
                            AddBackground(355, 255, 50, 20, 9270);
                            AddTextEntry(360, 255, 40, 20, 0x0, 200 + i, Convert.ToString(m_item.Citoyens[i].Dime));

                            AddButton(410, 255, 4011, 4013, 200 + i, GumpButtonType.Reply, 0);
                        }
                    }

                    AddHtml(288, 455, 200, 20, "<h3><basefont color=#5A4A31>Ajouter un citoyen<basefont></h3>", false, false);
                    AddButton(410, 455, 9004, 9004, 10, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.PopulationClerge:
                    AddHtml(268, 195, 200, 20, "<h3><basefont color=#025a>Clergé<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 250, 9300);

                    AddImage(135, 230, 95);
                    AddImage(142, 239, 96);
                    AddImage(258, 239, 96);
                    AddImage(435, 230, 97);

                    AddHtml(170, 225, 200, 20, "<h3><basefont color=#025a>Nom<basefont></h3>", false, false);
                    AddHtml(300, 225, 200, 20, "<h3><basefont color=#025a>Taille<basefont></h3>", false, false);

                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        if (m_item.Citoyens[i].ClasseSociale == GeoClasses.Clercs)
                        {
                            AddButton(130, 255, 4002, 4004, 100 + i, GumpButtonType.Reply, 0);
                            //Rouge nom si pas payer
                            if (m_item.Citoyens[i].TaxePayer && m_item.Citoyens[i].DimePayer)
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#025a>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);
                            else
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#990000>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);

                            AddBackground(300, 255, 100, 20, 9270);
                            AddTextEntry(305, 255, 40, 20, 0x0, 100 + i, Convert.ToString(m_item.Citoyens[i].Taxe));

                            AddButton(410, 255, 4011, 4013, 200 + i, GumpButtonType.Reply, 0);
                        }
                    }

                    AddHtml(300, 455, 200, 20, "<h3><basefont color=#5A4A31>Ajouter un clerc<basefont></h3>", false, false);
                    AddButton(410, 455, 9004, 9004, 10, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.PopulationNoble:
                    AddHtml(273, 195, 200, 20, "<h3><basefont color=#025a>Noble<basefont></h3>", false, false);

                    AddBackground(130, 225, 320, 250, 9300);

                    AddImage(135, 230, 95);
                    AddImage(142, 239, 96);
                    AddImage(258, 239, 96);
                    AddImage(435, 230, 97);

                    AddHtml(170, 225, 200, 20, "<h3><basefont color=#025a>Nom<basefont></h3>", false, false);
                    AddHtml(300, 225, 200, 20, "<h3><basefont color=#025a>Taillon<basefont></h3>", false, false);

                    for (int i = 0; i < m_item.Citoyens.Count; i++)
                    {
                        if (m_item.Citoyens[i].ClasseSociale == GeoClasses.Nobles)
                        {
                            AddButton(130, 255, 4002, 4004, 100 + i, GumpButtonType.Reply, 0);
                            //Rouge nom si pas payer
                            if (m_item.Citoyens[i].TaxePayer && m_item.Citoyens[i].DimePayer)
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#025a>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);
                            else
                                AddHtml(170, 255, 200, 20, "<h3><basefont color=#990000>" + m_item.Citoyens[i].Mob.Name + "<basefont></h3>", false, false);

                            AddBackground(300, 255, 100, 20, 9270);
                            AddTextEntry(305, 255, 40, 20, 0x0, 100 + i, Convert.ToString(m_item.Citoyens[i].Taxe));

                            AddButton(410, 255, 4011, 4013, 200 + i, GumpButtonType.Reply, 0);
                        }
                    }

                    AddHtml(300, 455, 200, 20, "<h3><basefont color=#5A4A31>Ajouter un noble<basefont></h3>", false, false);
                    AddButton(410, 455, 9004, 9004, 10, GumpButtonType.Reply, 0);
                    break;
                case GeoTabs.NouveauProjet:
                    AddHtml(268, 195, 200, 20, "<h3><basefont color=#025a>Projet<basefont></h3>", false, false);
                    break;
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.AccessLevel < AccessLevel.Batisseur)
                if (from.Deleted || !from.Alive)
                    return;

            if (info.ButtonID >= 100)
            {
                int index = info.ButtonID - 100;

                m_item.Citoyens.Remove(m_item.Citoyens[index]);

                m_From.SendGump(new GeoMaitre(m_From, m_item, m_tab));
            }
            else if (info.ButtonID >= 200)
            {
                int index;

                switch (m_tab)
                {
                    case GeoTabs.PopulationSerfs:
                        int taille = Convert.ToInt32(info.TextEntries[info.ButtonID - 100]);
                        int dime = Convert.ToInt32(info.TextEntries[info.ButtonID]);
                        index = info.ButtonID - 200;

                        m_item.Citoyens[index].Taxe = taille;
                        m_item.Citoyens[index].Dime = dime;
                        break;
                    case GeoTabs.PopulationCitoyens:
                        int octroi = Convert.ToInt32(info.TextEntries[info.ButtonID - 100]);
                        int aides = Convert.ToInt32(info.TextEntries[info.ButtonID]);
                        index = info.ButtonID - 200;

                        m_item.Citoyens[index].Taxe = octroi + aides;
                        break;
                    case GeoTabs.PopulationClerge:
                        int taxe = Convert.ToInt32(info.TextEntries[info.ButtonID - 100]);

                        index = info.ButtonID - 200;

                        m_item.Citoyens[index].Taxe = taxe;
                        break;
                    case GeoTabs.PopulationNoble:
                        int taillon = Convert.ToInt32(info.TextEntries[info.ButtonID - 100]);

                        index = info.ButtonID - 200;

                        m_item.Citoyens[index].Taxe = taillon;
                        break;
                    default:
                        break;
                }
            }

            switch (info.ButtonID)
            {
                case 1:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Index));
                    break;
                case 2:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Militaire));
                    break;
                case 3:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Taxes));
                    break;
                case 4:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Population));
                    break;
                case 5:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Religion));
                    break;
                case 6:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Revoltes));
                    break;
                case 7:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.IndexConseillers));
                    break;
                case 8:
                    if (m_item.Armee.Sauvages > 0)
                    {
                        ArmyController controller = null;
                        foreach (Item i in m_From.Backpack.Items)
                        {
                            if (i is ArmyController)
                            {
                                controller = (ArmyController)i;
                            }
                        }
                        if (!(controller == null))
                        {
                            from.SendMessage("test");
                            PaysanNomadeGarde soldier = new PaysanNomadeGarde(m_item, controller);
                            soldier.MoveToWorld(m_From.Location, m_From.Map);
                            bool recruit = false;
                            //recruit = controller.GeoRecruit(from, soldier);
                            if (!(recruit))
                            {
                                soldier.Delete();
                            }
                            else
                            {
                                m_item.Armee.Sauvages -= 1;
                            }
                        }
                        else
                        {
                            controller = new ArmyController();
                            m_From.Backpack.AddItem(controller);
                            PaysanNomadeGarde soldier = new PaysanNomadeGarde(m_item, controller);
                            soldier.MoveToWorld(m_From.Location, m_From.Map);
                            bool recruit = false;
                            //recruit = controller.GeoRecruit(from, soldier);
                            if (!(recruit))
                                soldier.Delete();
                            else
                                m_item.Armee.Sauvages -= 1;
                        }
                    }
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Militaire));
                    break;
                case 14:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.TaxesLocales));
                    break;
                case 15:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.TaxesLiege));
                    break;
                case 16:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.TaxesReligieuses));
                    break;
                //Tresorerie Noble
                case 17:
                    break;
                case 18:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.PopulationSerfs));
                    break;
                case 19:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.PopulationCitoyens));
                    break;
                case 20:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.PopulationClerge));
                    break;
                case 21:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.PopulationNoble));
                    break;
                //Tresorerie Religion
                case 22:
                    break;
                //Nouveau Conseiller
                case 23:
                    break;
                //Payer les traites
                case 24:
                    break;
                //Payer l'aides aux 4 cas
                case 25:
                    break;
                //Set Traites
                case 26:
                    break;
                //Set Aides aux 4 cas
                case 27:
                    break;
                //Recrutement
                case 28:
                    if (m_item.Armee.Manpower > 0)
                    {
                        m_item.Armee.Sauvages += 1;
                        m_item.Armee.Manpower -= 1;
                        m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.Militaire));
                    }
                    break;
                //Retour de soldat
                case 34:
                    break;
                //Nouveau Projet
                case 35:
                    m_From.SendGump(new GeoMaitre(m_From, m_item, GeoTabs.NouveauProjet));
                    break;
                default:
                    break;
            }
        }
    }
}
