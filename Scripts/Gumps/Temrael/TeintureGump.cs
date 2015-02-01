using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Spells;
using System.Collections;
using Server.Misc;

namespace Server.Gumps
{
    public enum TeintureTabs
    {
        Baies,
        Nature,
        Ocean,
        Cendre,
        Cerise,
        Sable
    }
    class TeintureGump : Gump
    {
        private Mobile m_From;
        DyeTub m_tub;
        //Server.Gumps.CreationGump.PaperPreviewItem m_previewItem;
        //CreationGump m_gump;

        public TeintureGump(Mobile from, TeintureTabs tab, DyeTub tub)
            : base(0, 0)
        {
            m_From = from;
            m_tub = tub;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(80, 72, 420, 500, 3600);
            AddBackground(90, 82, 400, 480, 9200);
            AddBackground(100, 92, 380, 460, 3500);
            AddBackground(115, 335, 350, 200, 9300);

            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            AddImage(125, 110, 95);
            AddImage(132, 119, 96);
            AddImage(268, 119, 96);
            AddImage(445, 110, 97);

            AddImage(125, 350, 95);
            AddImage(132, 359, 96);
            AddImage(268, 359, 96);
            AddImage(445, 359, 97);

            AddImage(275, 345, 503);
            AddImage(284, 354, 505);
            AddImage(284, 440, 507);
            AddImage(275, 540, 504);

            AddButton(122, 382, 2117, 2118, 1, GumpButtonType.Reply, 0);
            AddButton(122, 422, 2117, 2118, 2, GumpButtonType.Reply, 0);
            AddButton(122, 462, 2117, 2118, 3, GumpButtonType.Reply, 0);

            AddButton(292, 382, 2117, 2118, 4, GumpButtonType.Reply, 0);
            AddButton(292, 422, 2117, 2118, 5, GumpButtonType.Reply, 0);
            AddButton(292, 462, 2117, 2118, 6, GumpButtonType.Reply, 0);

            AddHtml(250, 105, 200, 20, "<h3><basefont color=#025a>Teintures<basefont></h3>", false, false);

            AddHtml(140, 380, 200, 20, "<h3><basefont color=#42638C>Baies<basefont></h3>", false, false);
            AddHtml(140, 420, 200, 20, "<h3><basefont color=#637B5A>Nature<basefont></h3>", false, false);
            AddHtml(140, 460, 200, 20, "<h3><basefont color=#7BA5BD>Ocean<basefont></h3>", false, false);

            AddHtml(155, 510, 200, 20, "<h3><basefont color=#5A4A31>Derniere Couleure<basefont></h3>", false, false);
            AddButton(120, 510, 4005, 4007, 7, GumpButtonType.Reply, 0);

            AddHtml(310, 380, 200, 20, "<h3><basefont color=#666666>Cendre<basefont></h3>", false, false);
            AddHtml(310, 420, 200, 20, "<h3><basefont color=#A55A6B>Cerise<basefont></h3>", false, false);
            AddHtml(310, 460, 200, 20, "<h3><basefont color=#A55A6B>Sable<basefont></h3>", false, false);

            AddHtml(380, 510, 200, 20, "<h3><basefont color=#5A4A31>Fermer<basefont></h3>", false, false);
            AddButton(430, 510, 4017, 4019, 8, GumpButtonType.Reply, 0);

            switch (tab)
            {
                case TeintureTabs.Baies:
                    AddButton(120, 140, 570, 570, 9, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 571, 571, 10, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 572, 572, 11, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 573, 573, 12, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 574, 574, 13, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 575, 575, 14, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 576, 576, 15, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 577, 577, 16, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 578, 578, 17, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 579, 579, 18, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 580, 580, 19, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 581, 581, 20, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 582, 582, 21, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 583, 583, 22, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 584, 584, 23, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 585, 585, 24, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 586, 586, 25, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 587, 587, 26, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 588, 588, 27, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 589, 589, 28, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Cendre:
                    AddButton(120, 140, 590, 590, 29, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 591, 591, 30, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 592, 592, 31, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 593, 593, 32, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 594, 594, 33, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 595, 595, 34, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 596, 596, 35, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 597, 597, 36, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 598, 598, 37, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 599, 599, 38, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 600, 600, 39, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 601, 601, 40, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 602, 602, 41, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 603, 603, 42, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 604, 604, 43, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 605, 605, 44, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 606, 606, 45, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 607, 607, 46, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 608, 608, 47, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 609, 609, 48, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Cerise:
                    AddButton(120, 140, 610, 610, 49, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 611, 611, 50, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 612, 612, 51, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 613, 613, 52, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 614, 614, 53, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 615, 615, 54, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 616, 616, 55, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 617, 617, 56, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 618, 618, 57, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 619, 619, 58, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 620, 620, 59, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 621, 621, 60, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 622, 622, 61, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 623, 623, 62, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 624, 624, 63, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 625, 625, 64, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 626, 626, 65, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 627, 627, 66, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 628, 628, 67, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 629, 629, 68, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Nature:
                    AddButton(120, 140, 630, 630, 69, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 631, 631, 70, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 632, 632, 71, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 633, 633, 72, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 634, 634, 73, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 635, 635, 74, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 636, 636, 75, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 637, 637, 76, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 638, 638, 77, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 639, 639, 78, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 640, 640, 79, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 641, 641, 80, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 642, 642, 81, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 643, 643, 82, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 644, 644, 83, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 645, 645, 84, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 646, 646, 85, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 647, 647, 86, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 648, 648, 87, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 649, 649, 88, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Ocean:
                    AddButton(120, 140, 654, 654, 89, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 655, 655, 90, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 656, 656, 91, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 657, 657, 92, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 658, 658, 93, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 659, 659, 94, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 660, 660, 95, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 661, 661, 96, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 662, 662, 97, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 663, 663, 98, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 664, 664, 99, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 665, 665, 100, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 666, 666, 101, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 667, 667, 102, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 668, 668, 103, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 669, 669, 104, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 670, 670, 105, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 671, 671, 106, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 672, 672, 107, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 673, 673, 108, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Sable:
                    AddButton(120, 140, 674, 674, 109, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 675, 675, 110, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 676, 676, 111, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 677, 677, 112, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 678, 678, 113, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 679, 679, 114, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 680, 680, 115, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 681, 681, 116, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 682, 682, 117, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 683, 683, 118, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 684, 684, 119, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 685, 685, 120, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 686, 686, 121, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 687, 687, 122, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 688, 688, 123, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 689, 689, 124, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 690, 690, 125, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 691, 691, 126, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 692, 692, 127, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 693, 693, 128, GumpButtonType.Reply, 0);
                    break;
                default: break;
            }
        }
        /*public TeintureGump(Mobile from, TeintureTabs tab, Item item, Server.Gumps.CreationGump.PaperPreviewItem previewItem, CreationGump gump)
            : base(0, 0)
        {
            m_From = from;
            m_item = item;
            m_previewItem = previewItem;
            m_gump = gump;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddBackground(80, 72, 420, 500, 3600);
            AddBackground(90, 82, 400, 480, 9200);
            AddBackground(100, 92, 380, 460, 3500);
            AddBackground(115, 335, 350, 200, 9300);

            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            AddImage(125, 110, 95);
            AddImage(132, 119, 96);
            AddImage(268, 119, 96);
            AddImage(445, 110, 97);

            AddImage(125, 350, 95);
            AddImage(132, 359, 96);
            AddImage(268, 359, 96);
            AddImage(445, 350, 97);

            AddImage(275, 345, 503);
            AddImage(284, 354, 505);
            AddImage(284, 440, 507);
            AddImage(275, 540, 504);

            AddButton(122, 382, 2117, 2118, 1, GumpButtonType.Reply, 0);
            AddButton(122, 422, 2117, 2118, 2, GumpButtonType.Reply, 0);
            AddButton(122, 462, 2117, 2118, 3, GumpButtonType.Reply, 0);

            AddButton(292, 382, 2117, 2118, 4, GumpButtonType.Reply, 0);
            AddButton(292, 422, 2117, 2118, 5, GumpButtonType.Reply, 0);
            AddButton(292, 462, 2117, 2118, 6, GumpButtonType.Reply, 0);

            AddHtml(250, 105, 200, 20, "<h3><basefont color=#025a>Teintures<basefont></h3>", false, false);

            AddHtml(140, 380, 200, 20, "<h3><basefont color=#42638C>Baies<basefont></h3>", false, false);
            AddHtml(140, 420, 200, 20, "<h3><basefont color=#637B5A>Nature<basefont></h3>", false, false);
            AddHtml(140, 460, 200, 20, "<h3><basefont color=#7BA5BD>Ocean<basefont></h3>", false, false);

            AddHtml(155, 510, 200, 20, "<h3><basefont color=#5A4A31>Derniere Couleure<basefont></h3>", false, false);
            AddButton(120, 510, 4005, 4007, 7, GumpButtonType.Reply, 0);

            AddHtml(310, 380, 200, 20, "<h3><basefont color=#666666>Cendre<basefont></h3>", false, false);
            AddHtml(310, 420, 200, 20, "<h3><basefont color=#A55A6B>Cerise<basefont></h3>", false, false);
            AddHtml(310, 460, 200, 20, "<h3><basefont color=#A55A6B>Sable<basefont></h3>", false, false);

            AddHtml(380, 510, 200, 20, "<h3><basefont color=#5A4A31>Fermer<basefont></h3>", false, false);
            AddButton(430, 510, 4017, 4019, 8, GumpButtonType.Reply, 0);

            switch (tab)
            {
                case TeintureTabs.Baies:
                    AddButton(120, 140, 570, 570, 9, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 571, 571, 10, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 572, 572, 11, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 573, 573, 12, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 574, 574, 13, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 575, 575, 14, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 576, 576, 15, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 577, 577, 16, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 578, 578, 17, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 579, 579, 18, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 580, 580, 19, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 581, 581, 20, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 582, 582, 21, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 583, 583, 22, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 584, 584, 23, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 585, 585, 24, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 586, 586, 25, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 587, 587, 26, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 588, 588, 27, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 589, 589, 28, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Cendre:
                    AddButton(120, 140, 590, 590, 29, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 591, 591, 30, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 592, 592, 31, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 593, 593, 32, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 594, 594, 33, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 595, 595, 34, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 596, 596, 35, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 597, 597, 36, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 598, 598, 37, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 599, 599, 38, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 600, 600, 39, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 601, 601, 40, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 602, 602, 41, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 603, 603, 42, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 604, 604, 43, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 605, 605, 44, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 606, 606, 45, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 607, 607, 46, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 608, 608, 47, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 609, 609, 48, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Cerise:
                    AddButton(120, 140, 610, 610, 49, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 611, 611, 50, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 612, 612, 51, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 613, 613, 52, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 614, 614, 53, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 615, 615, 54, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 616, 616, 55, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 617, 617, 56, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 618, 618, 57, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 619, 619, 58, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 620, 620, 59, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 621, 621, 60, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 622, 622, 61, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 623, 623, 62, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 624, 624, 63, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 625, 625, 64, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 626, 626, 65, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 627, 627, 66, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 628, 628, 67, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 629, 629, 68, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Nature:
                    AddButton(120, 140, 630, 630, 69, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 631, 631, 70, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 632, 632, 71, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 633, 633, 72, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 634, 634, 73, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 635, 635, 74, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 636, 636, 75, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 637, 637, 76, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 638, 638, 77, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 639, 639, 78, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 640, 640, 79, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 641, 641, 80, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 642, 642, 81, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 643, 643, 82, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 644, 644, 83, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 645, 645, 84, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 646, 646, 85, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 647, 647, 86, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 648, 648, 87, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 649, 649, 88, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Ocean:
                    AddButton(120, 140, 654, 654, 89, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 655, 655, 90, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 656, 656, 91, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 657, 657, 92, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 658, 658, 93, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 659, 659, 94, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 660, 660, 95, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 661, 661, 96, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 662, 662, 97, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 663, 663, 98, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 664, 664, 99, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 665, 665, 100, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 666, 666, 101, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 667, 667, 102, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 668, 668, 103, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 669, 669, 104, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 670, 670, 105, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 671, 671, 106, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 672, 672, 107, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 673, 673, 108, GumpButtonType.Reply, 0);
                    break;
                case TeintureTabs.Sable:
                    AddButton(120, 140, 674, 674, 109, GumpButtonType.Reply, 0);
                    AddButton(149, 140, 675, 675, 110, GumpButtonType.Reply, 0);
                    AddButton(168, 140, 676, 676, 111, GumpButtonType.Reply, 0);
                    AddButton(187, 140, 677, 677, 112, GumpButtonType.Reply, 0);
                    AddButton(206, 140, 678, 678, 113, GumpButtonType.Reply, 0);

                    AddButton(346, 140, 679, 679, 114, GumpButtonType.Reply, 0);
                    AddButton(375, 140, 680, 680, 115, GumpButtonType.Reply, 0);
                    AddButton(394, 140, 681, 681, 116, GumpButtonType.Reply, 0);
                    AddButton(413, 140, 682, 682, 117, GumpButtonType.Reply, 0);
                    AddButton(432, 140, 683, 683, 118, GumpButtonType.Reply, 0);

                    AddButton(120, 250, 684, 684, 119, GumpButtonType.Reply, 0);
                    AddButton(149, 250, 685, 685, 120, GumpButtonType.Reply, 0);
                    AddButton(168, 250, 686, 686, 121, GumpButtonType.Reply, 0);
                    AddButton(187, 250, 687, 687, 122, GumpButtonType.Reply, 0);
                    AddButton(206, 250, 688, 688, 123, GumpButtonType.Reply, 0);

                    AddButton(346, 250, 689, 689, 124, GumpButtonType.Reply, 0);
                    AddButton(375, 250, 690, 690, 125, GumpButtonType.Reply, 0);
                    AddButton(394, 250, 691, 691, 126, GumpButtonType.Reply, 0);
                    AddButton(413, 250, 692, 692, 127, GumpButtonType.Reply, 0);
                    AddButton(432, 250, 693, 693, 128, GumpButtonType.Reply, 0);
                    break;
                default: break;
            }
        }*/
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            if (m_tub != null)
            {
                switch (info.ButtonID)
                {
                    case 1:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Baies, m_tub));
                        break;
                    case 2:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Nature, m_tub));
                        break;
                    case 3:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Ocean, m_tub));
                        break;
                    case 4:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Cendre, m_tub));
                        break;
                    case 5:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Cerise, m_tub));
                        break;
                    case 6:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Sable, m_tub));
                        break;
                    case 7:
                        if (!(from is PlayerMobile))
                            from.SendGump(new TeintureGump(from, TeintureTabs.Baies, m_tub));
                        else if (m_tub.Redyable)
                        {
                            m_tub.Hue = ((PlayerMobile)from).LastTeinture;

                            from.SendGump(new TeintureGump(from, TeintureTabs.Baies, m_tub));
                        }
                        else
                        {
                            from.SendMessage("That dye tub may not be redyed.");
                            from.SendGump(new TeintureGump(from, TeintureTabs.Baies, m_tub));
                        }
                        break;
                    case 8:
                        break;
                    case 9:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04DE;
                            ((PlayerMobile)from).LastTeinture = 0x04DE;
                        }
                        break;
                    case 10:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04E0;
                            ((PlayerMobile)from).LastTeinture = 0x04E0;
                        }
                        break;
                    case 11:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04E2;
                            ((PlayerMobile)from).LastTeinture = 0x04E2;
                        }
                        break;
                    case 12:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04E4;
                            ((PlayerMobile)from).LastTeinture = 0x04E4;
                        }
                        break;
                    case 13:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04E6;
                            ((PlayerMobile)from).LastTeinture = 0x04E6;
                        }
                        break;
                    case 14:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04D5;
                            ((PlayerMobile)from).LastTeinture = 0x04D5;
                        }
                        break;
                    case 15:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04D8;
                            ((PlayerMobile)from).LastTeinture = 0x04D8;
                        }
                        break;
                    case 16:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04DA;
                            ((PlayerMobile)from).LastTeinture = 0x04DA;
                        }
                        break;
                    case 17:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04DB;
                            ((PlayerMobile)from).LastTeinture = 0x04DB;
                        }
                        break;
                    case 18:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04DD;
                            ((PlayerMobile)from).LastTeinture = 0x04DD;
                        }
                        break;
                    case 19:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04CC;
                            ((PlayerMobile)from).LastTeinture = 0x04CC;
                        }
                        break;
                    case 20:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04CE;
                            ((PlayerMobile)from).LastTeinture = 0x04CE;
                        }
                        break;
                    case 21:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04CF;
                            ((PlayerMobile)from).LastTeinture = 0x04CF;
                        }
                        break;
                    case 22:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04D2;
                            ((PlayerMobile)from).LastTeinture = 0x04D2;
                        }
                        break;
                    case 23:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04D4;
                            ((PlayerMobile)from).LastTeinture = 0x04D4;
                        }
                        break;
                    case 24:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04C3;
                            ((PlayerMobile)from).LastTeinture = 0x04C3;
                        }
                        break;
                    case 26:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04C7;
                            ((PlayerMobile)from).LastTeinture = 0x04C7;
                        }
                        break;
                    case 27:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04C9;
                            ((PlayerMobile)from).LastTeinture = 0x04C9;
                        }
                        break;
                    case 28:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04CB;
                            ((PlayerMobile)from).LastTeinture = 0x04CB;
                        }
                        break;
                    case 29:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x076C;
                            ((PlayerMobile)from).LastTeinture = 0x076C;
                        }
                        break;
                    case 30:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x076E;
                            ((PlayerMobile)from).LastTeinture = 0x076E;
                        }
                        break;
                    case 31:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0770;
                            ((PlayerMobile)from).LastTeinture = 0x0770;
                        }
                        break;
                    case 32:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0772;
                            ((PlayerMobile)from).LastTeinture = 0x0772;
                        }
                        break;
                    case 33:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0774;
                            ((PlayerMobile)from).LastTeinture = 0x0774;
                        }
                        break;
                    case 34:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0763;
                            ((PlayerMobile)from).LastTeinture = 0x0763;
                        }
                        break;
                    case 35:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0766;
                            ((PlayerMobile)from).LastTeinture = 0x0766;
                        }
                        break;
                    case 36:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0768;
                            ((PlayerMobile)from).LastTeinture = 0x0768;
                        }
                        break;
                    case 37:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0769;
                            ((PlayerMobile)from).LastTeinture = 0x0769;
                        }
                        break;
                    case 38:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x076B;
                            ((PlayerMobile)from).LastTeinture = 0x076B;
                        }
                        break;
                    case 39:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0967;
                            ((PlayerMobile)from).LastTeinture = 0x0967;
                        }
                        break;
                    case 40:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0968;
                            ((PlayerMobile)from).LastTeinture = 0x0968;
                        }
                        break;
                    case 41:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0969;
                            ((PlayerMobile)from).LastTeinture = 0x0969;
                        }
                        break;
                    case 42:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x096A;
                            ((PlayerMobile)from).LastTeinture = 0x096A;
                        }
                        break;
                    case 43:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x096C;
                            ((PlayerMobile)from).LastTeinture = 0x096C;
                        }
                        break;
                    case 44:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0;
                            ((PlayerMobile)from).LastTeinture = 0x0;
                        }
                        break;
                    case 45:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x08FD;
                            ((PlayerMobile)from).LastTeinture = 0x08FD;
                        }
                        break;
                    case 46:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x08FE;
                            ((PlayerMobile)from).LastTeinture = 0x08FE;
                        }
                        break;
                    case 47:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0900;
                            ((PlayerMobile)from).LastTeinture = 0x0900;
                        }
                        break;
                    case 48:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0902;
                            ((PlayerMobile)from).LastTeinture = 0x0902;
                        }
                        break;
                    case 49:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x04BA;
                            ((PlayerMobile)from).LastTeinture = 0x04BA;
                        }
                        break;
                    case 50:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0642;
                            ((PlayerMobile)from).LastTeinture = 0x0642;
                        }
                        break;
                    case 51:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0646;
                            ((PlayerMobile)from).LastTeinture = 0x0646;
                        }
                        break;
                    case 52:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0647;
                            ((PlayerMobile)from).LastTeinture = 0x0647;
                        }
                        break;
                    case 53:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0649;
                            ((PlayerMobile)from).LastTeinture = 0x0649;
                        }
                        break;
                    case 54:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0653;
                            ((PlayerMobile)from).LastTeinture = 0x0653;
                        }
                        break;
                    case 55:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0655;
                            ((PlayerMobile)from).LastTeinture = 0x0655;
                        }
                        break;
                    case 56:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0656;
                            ((PlayerMobile)from).LastTeinture = 0x0656;
                        }
                        break;
                    case 57:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0659;
                            ((PlayerMobile)from).LastTeinture = 0x0659;
                        }
                        break;
                    case 58:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x065B;
                            ((PlayerMobile)from).LastTeinture = 0x065B;
                        }
                        break;
                    case 59:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x065C;
                            ((PlayerMobile)from).LastTeinture = 0x065C;
                        }
                        break;
                    case 60:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x065E;
                            ((PlayerMobile)from).LastTeinture = 0x065E;
                        }
                        break;
                    case 61:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0660;
                            ((PlayerMobile)from).LastTeinture = 0x0660;
                        }
                        break;
                    case 62:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0662;
                            ((PlayerMobile)from).LastTeinture = 0x0662;
                        }
                        break;
                    case 63:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0664;
                            ((PlayerMobile)from).LastTeinture = 0x0664;
                        }
                        break;
                    case 64:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0665;
                            ((PlayerMobile)from).LastTeinture = 0x0665;
                        }
                        break;
                    case 65:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0666;
                            ((PlayerMobile)from).LastTeinture = 0x0666;
                        }
                        break;
                    case 66:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0668;
                            ((PlayerMobile)from).LastTeinture = 0x0668;
                        }
                        break;
                    case 67:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x066B;
                            ((PlayerMobile)from).LastTeinture = 0x066B;
                        }
                        break;
                    case 68:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x066D;
                            ((PlayerMobile)from).LastTeinture = 0x066D;
                        }
                        break;
                    case 69:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0594;
                            ((PlayerMobile)from).LastTeinture = 0x0594;
                        }
                        break;
                    case 70:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0595;
                            ((PlayerMobile)from).LastTeinture = 0x0595;
                        }
                        break;
                    case 71:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0596;
                            ((PlayerMobile)from).LastTeinture = 0x0596;
                        }
                        break;
                    case 72:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0599;
                            ((PlayerMobile)from).LastTeinture = 0x0599;
                        }
                        break;
                    case 73:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x059B;
                            ((PlayerMobile)from).LastTeinture = 0x059B;
                        }
                        break;
                    case 74:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x059D;
                            ((PlayerMobile)from).LastTeinture = 0x059D;
                        }
                        break;
                    case 75:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x059E;
                            ((PlayerMobile)from).LastTeinture = 0x059E;
                        }
                        break;
                    case 76:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x05A0;
                            ((PlayerMobile)from).LastTeinture = 0x05A0;
                        }
                        break;
                    case 77:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x05A2;
                            ((PlayerMobile)from).LastTeinture = 0x05A2;
                        }
                        break;
                    case 78:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x05A5;
                            ((PlayerMobile)from).LastTeinture = 0x05A5;
                        }
                        break;
                    case 79:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x089F;
                            ((PlayerMobile)from).LastTeinture = 0x089F;
                        }
                        break;
                    case 80:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x08A0;
                            ((PlayerMobile)from).LastTeinture = 0x08A0;
                        }
                        break;
                    case 81:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x08A1;
                            ((PlayerMobile)from).LastTeinture = 0x08A1;
                        }
                        break;
                    case 82:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x08A3;
                            ((PlayerMobile)from).LastTeinture = 0x08A3;
                        }
                        break;
                    case 83:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x07D6;
                            ((PlayerMobile)from).LastTeinture = 0x07D6;
                        }
                        break;
                    case 84:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0582;
                            ((PlayerMobile)from).LastTeinture = 0x0582;
                        }
                        break;
                    case 85:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0585;
                            ((PlayerMobile)from).LastTeinture = 0x0585;
                        }
                        break;
                    case 86:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x058F;
                            ((PlayerMobile)from).LastTeinture = 0x058F;
                        }
                        break;
                    case 87:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0591;
                            ((PlayerMobile)from).LastTeinture = 0x0591;
                        }
                        break;
                    case 88:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0593;
                            ((PlayerMobile)from).LastTeinture = 0x0593;
                        }
                        break;
                    case 89:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0527;
                            ((PlayerMobile)from).LastTeinture = 0x0527;
                        }
                        break;
                    case 90:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0524;
                            ((PlayerMobile)from).LastTeinture = 0x0524;
                        }
                        break;
                    case 91:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x052D;
                            ((PlayerMobile)from).LastTeinture = 0x052D;
                        }
                        break;
                    case 92:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0526;
                            ((PlayerMobile)from).LastTeinture = 0x0526;
                        }
                        break;
                    case 93:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x052F;
                            ((PlayerMobile)from).LastTeinture = 0x052F;
                        }
                        break;
                    case 94:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0530;
                            ((PlayerMobile)from).LastTeinture = 0x0530;
                        }
                        break;
                    case 95:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0531;
                            ((PlayerMobile)from).LastTeinture = 0x0531;
                        }
                        break;
                    case 96:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0533;
                            ((PlayerMobile)from).LastTeinture = 0x0533;
                        }
                        break;
                    case 97:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0536;
                            ((PlayerMobile)from).LastTeinture = 0x0536;
                        }
                        break;
                    case 98:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0538;
                            ((PlayerMobile)from).LastTeinture = 0x0538;
                        }
                        break;
                    case 99:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0539;
                            ((PlayerMobile)from).LastTeinture = 0x0539;
                        }
                        break;
                    case 100:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x053B;
                            ((PlayerMobile)from).LastTeinture = 0x053B;
                        }
                        break;
                    case 101:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x053D;
                            ((PlayerMobile)from).LastTeinture = 0x053D;
                        }
                        break;
                    case 102:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x053F;
                            ((PlayerMobile)from).LastTeinture = 0x053F;
                        }
                        break;
                    case 103:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0541;
                            ((PlayerMobile)from).LastTeinture = 0x0541;
                        }
                        break;
                    case 104:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0542;
                            ((PlayerMobile)from).LastTeinture = 0x0542;
                        }
                        break;
                    case 105:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0543;
                            ((PlayerMobile)from).LastTeinture = 0x0543;
                        }
                        break;
                    case 106:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0545;
                            ((PlayerMobile)from).LastTeinture = 0x0545;
                        }
                        break;
                    case 107:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0548;
                            ((PlayerMobile)from).LastTeinture = 0x0548;
                        }
                        break;
                    case 108:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x054A;
                            ((PlayerMobile)from).LastTeinture = 0x054A;
                        }
                        break;
                    case 109:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0751;
                            ((PlayerMobile)from).LastTeinture = 0x0751;
                        }
                        break;
                    case 110:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0753;
                            ((PlayerMobile)from).LastTeinture = 0x0753;
                        }
                        break;
                    case 111:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0755;
                            ((PlayerMobile)from).LastTeinture = 0x0755;
                        }
                        break;
                    case 112:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0757;
                            ((PlayerMobile)from).LastTeinture = 0x0757;
                        }
                        break;
                    case 113:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0759;
                            ((PlayerMobile)from).LastTeinture = 0x0759;
                        }
                        break;
                    case 114:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x06B7;
                            ((PlayerMobile)from).LastTeinture = 0x06B7;
                        }
                        break;
                    case 115:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0467;
                            ((PlayerMobile)from).LastTeinture = 0x0467;
                        }
                        break;
                    case 116:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0469;
                            ((PlayerMobile)from).LastTeinture = 0x0469;
                        }
                        break;
                    case 117:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x046B;
                            ((PlayerMobile)from).LastTeinture = 0x046B;
                        }
                        break;
                    case 118:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x046D;
                            ((PlayerMobile)from).LastTeinture = 0x046D;
                        }
                        break;
                    case 119:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x045E;
                            ((PlayerMobile)from).LastTeinture = 0x045E;
                        }
                        break;
                    case 120:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0460;
                            ((PlayerMobile)from).LastTeinture = 0x0460;
                        }
                        break;
                    case 121:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0462;
                            ((PlayerMobile)from).LastTeinture = 0x0462;
                        }
                        break;
                    case 122:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0464;
                            ((PlayerMobile)from).LastTeinture = 0x0464;
                        }
                        break;
                    case 123:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x046A;
                            ((PlayerMobile)from).LastTeinture = 0x046A;
                        }
                        break;
                    case 124:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0903;
                            ((PlayerMobile)from).LastTeinture = 0x0903;
                        }
                        break;
                    case 125:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x096E;
                            ((PlayerMobile)from).LastTeinture = 0x096E;
                        }
                        break;
                    case 126:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0905;
                            ((PlayerMobile)from).LastTeinture = 0x0905;
                        }
                        break;
                    case 127:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0970;
                            ((PlayerMobile)from).LastTeinture = 0x0970;
                        }
                        break;
                    case 128:
                        if (from is PlayerMobile)
                        {
                            if (m_tub.Redyable)
                                m_tub.Hue = 0x0972;
                            ((PlayerMobile)from).LastTeinture = 0x0972;
                        }
                        break;
                    default: break;
                }
            }
            /*else
            {
                switch (info.ButtonID)
                {
                    case 1:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Baies, m_item, m_previewItem, m_gump));
                        break;
                    case 2:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Nature, m_item, m_previewItem, m_gump));
                        break;
                    case 3:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Ocean, m_item, m_previewItem, m_gump));
                        break;
                    case 4:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Cendre, m_item, m_previewItem, m_gump));
                        break;
                    case 5:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Cerise, m_item, m_previewItem, m_gump));
                        break;
                    case 6:
                        from.SendGump(new TeintureGump(from, TeintureTabs.Sable, m_item, m_previewItem, m_gump));
                        break;
                    case 7:
                        if (from is PlayerMobile)
                        {
                            if (((PlayerMobile)from).LastTeinture != null)
                            {
                                m_item.Hue = ((PlayerMobile)from).LastTeinture;
                                m_previewItem.Hue = ((PlayerMobile)from).LastTeinture;
                                from.SendGump(m_gump);
                            }
                            else
                            {
                                from.SendGump(new TeintureGump(from, TeintureTabs.Baies, m_item, m_previewItem, m_gump));
                                from.SendMessage("Vous n'avez pas de derniere teinture enregistre !");
                            }
                        }
                        else
                            from.SendGump(new TeintureGump(from, TeintureTabs.Baies, m_item, m_previewItem, m_gump));
                        break;
                    case 8:
                        from.SendGump(m_gump);
                        break;
                    case 9:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04DE;
                            m_previewItem.Hue = 0x04DE;
                            ((PlayerMobile)from).LastTeinture = 0x04DE;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 10:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04E0;
                            m_previewItem.Hue = 0x04E0;
                            ((PlayerMobile)from).LastTeinture = 0x04E0;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 11:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04E2;
                            m_previewItem.Hue = 0x04E2;
                            ((PlayerMobile)from).LastTeinture = 0x04E2;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 12:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04E4;
                            m_previewItem.Hue = 0x04E4;
                            ((PlayerMobile)from).LastTeinture = 0x04E4;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 13:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04E6;
                            m_previewItem.Hue = 0x04E6;
                            ((PlayerMobile)from).LastTeinture = 0x04E6;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 14:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04D5;
                            m_previewItem.Hue = 0x04D5;
                            ((PlayerMobile)from).LastTeinture = 0x04D5;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 15:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04D8;
                            m_previewItem.Hue = 0x04D8;
                            ((PlayerMobile)from).LastTeinture = 0x04D8;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 16:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04DA;
                            m_previewItem.Hue = 0x04DA;
                            ((PlayerMobile)from).LastTeinture = 0x04DA;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 17:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04DB;
                            m_previewItem.Hue = 0x04DB;
                            ((PlayerMobile)from).LastTeinture = 0x04DB;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 18:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04DD;
                            m_previewItem.Hue = 0x04DD;
                            ((PlayerMobile)from).LastTeinture = 0x04DD;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 19:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04CC;
                            m_previewItem.Hue = 0x04CC;
                            ((PlayerMobile)from).LastTeinture = 0x04CC;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 20:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04CE;
                            m_previewItem.Hue = 0x04CE;
                            ((PlayerMobile)from).LastTeinture = 0x04CE;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 21:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04CF;
                            m_previewItem.Hue = 0x04CF;
                            ((PlayerMobile)from).LastTeinture = 0x04CF;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 22:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04D2;
                            m_previewItem.Hue = 0x04D2;
                            ((PlayerMobile)from).LastTeinture = 0x04D2;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 23:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04D4;
                            m_previewItem.Hue = 0x04D4;
                            ((PlayerMobile)from).LastTeinture = 0x04D4;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 24:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04C3;
                            m_previewItem.Hue = 0x04C3;
                            ((PlayerMobile)from).LastTeinture = 0x04C3;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 26:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04C7;
                            m_previewItem.Hue = 0x04C7;
                            ((PlayerMobile)from).LastTeinture = 0x04C7;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 27:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04C9;
                            m_previewItem.Hue = 0x04C9;
                            ((PlayerMobile)from).LastTeinture = 0x04C9;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 28:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04CB;
                            m_previewItem.Hue = 0x04CB;
                            ((PlayerMobile)from).LastTeinture = 0x04CB;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 29:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x076C;
                            m_previewItem.Hue = 0x076C;
                            ((PlayerMobile)from).LastTeinture = 0x076C;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 30:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x076E;
                            m_previewItem.Hue = 0x076E;
                            ((PlayerMobile)from).LastTeinture = 0x076E;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 31:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0770;
                            m_previewItem.Hue = 0x0770;
                            ((PlayerMobile)from).LastTeinture = 0x0770;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 32:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0772;
                            m_previewItem.Hue = 0x0772;
                            ((PlayerMobile)from).LastTeinture = 0x0772;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 33:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0774;
                            m_previewItem.Hue = 0x0774;
                            ((PlayerMobile)from).LastTeinture = 0x0774;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 34:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0763;
                            m_previewItem.Hue = 0x0763;
                            ((PlayerMobile)from).LastTeinture = 0x0763;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 35:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0766;
                            m_previewItem.Hue = 0x0766;
                            ((PlayerMobile)from).LastTeinture = 0x0766;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 36:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0768;
                            m_previewItem.Hue = 0x0768;
                            ((PlayerMobile)from).LastTeinture = 0x0768;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 37:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0769;
                            m_previewItem.Hue = 0x0769;
                            ((PlayerMobile)from).LastTeinture = 0x0769;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 38:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x076B;
                            m_previewItem.Hue = 0x076B;
                            ((PlayerMobile)from).LastTeinture = 0x076B;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 39:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0967;
                            m_previewItem.Hue = 0x0967;
                            ((PlayerMobile)from).LastTeinture = 0x0967;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 40:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0968;
                            m_previewItem.Hue = 0x0968;
                            ((PlayerMobile)from).LastTeinture = 0x0968;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 41:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0969;
                            m_previewItem.Hue = 0x0969;
                            ((PlayerMobile)from).LastTeinture = 0x0969;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 42:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x096A;
                            m_previewItem.Hue = 0x096A;
                            ((PlayerMobile)from).LastTeinture = 0x096A;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 43:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x096C;
                            m_previewItem.Hue = 0x096C;
                            ((PlayerMobile)from).LastTeinture = 0x096C;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 44:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0;
                            m_previewItem.Hue = 0x0;
                            ((PlayerMobile)from).LastTeinture = 0x0;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 45:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x08FD;
                            m_previewItem.Hue = 0x08FD;
                            ((PlayerMobile)from).LastTeinture = 0x08FD;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 46:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x08FE;
                            m_previewItem.Hue = 0x08FE;
                            ((PlayerMobile)from).LastTeinture = 0x08FE;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 47:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0900;
                            m_previewItem.Hue = 0x0900;
                            ((PlayerMobile)from).LastTeinture = 0x0900;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 48:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0902;
                            m_previewItem.Hue = 0x0902;
                            ((PlayerMobile)from).LastTeinture = 0x0902;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 49:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x04BA;
                            m_previewItem.Hue = 0x04BA;
                            ((PlayerMobile)from).LastTeinture = 0x04BA;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 50:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0642;
                            m_previewItem.Hue = 0x0642;
                            ((PlayerMobile)from).LastTeinture = 0x0642;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 51:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0646;
                            m_previewItem.Hue = 0x0646;
                            ((PlayerMobile)from).LastTeinture = 0x0646;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 52:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0647;
                            m_previewItem.Hue = 0x0647;
                            ((PlayerMobile)from).LastTeinture = 0x0647;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 53:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0649;
                            m_previewItem.Hue = 0x0649;
                            ((PlayerMobile)from).LastTeinture = 0x0649;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 54:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0653;
                            m_previewItem.Hue = 0x0653;
                            ((PlayerMobile)from).LastTeinture = 0x0653;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 55:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0655;
                            m_previewItem.Hue = 0x0655;
                            ((PlayerMobile)from).LastTeinture = 0x0655;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 56:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0656;
                            m_previewItem.Hue = 0x0656;
                            ((PlayerMobile)from).LastTeinture = 0x0656;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 57:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0659;
                            m_previewItem.Hue = 0x0659;
                            ((PlayerMobile)from).LastTeinture = 0x0659;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 58:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x065B;
                            m_previewItem.Hue = 0x065B;
                            ((PlayerMobile)from).LastTeinture = 0x065B;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 59:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x065C;
                            m_previewItem.Hue = 0x065C;
                            ((PlayerMobile)from).LastTeinture = 0x065C;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 60:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x065E;
                            m_previewItem.Hue = 0x065E;
                            ((PlayerMobile)from).LastTeinture = 0x065E;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 61:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0660;
                            m_previewItem.Hue = 0x0660;
                            ((PlayerMobile)from).LastTeinture = 0x0660;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 62:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0662;
                            m_previewItem.Hue = 0x0662;
                            ((PlayerMobile)from).LastTeinture = 0x0662;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 63:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0664;
                            m_previewItem.Hue = 0x0664;
                            ((PlayerMobile)from).LastTeinture = 0x0664;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 64:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0665;
                            m_previewItem.Hue = 0x0665;
                            ((PlayerMobile)from).LastTeinture = 0x0665;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 65:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0666;
                            m_previewItem.Hue = 0x0666;
                            ((PlayerMobile)from).LastTeinture = 0x0666;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 66:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0668;
                            m_previewItem.Hue = 0x0668;
                            ((PlayerMobile)from).LastTeinture = 0x0668;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 67:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x066B;
                            m_previewItem.Hue = 0x066B;
                            ((PlayerMobile)from).LastTeinture = 0x066B;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 68:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x066D;
                            m_previewItem.Hue = 0x066D;
                            ((PlayerMobile)from).LastTeinture = 0x066D;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 69:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0594;
                            m_previewItem.Hue = 0x0594;
                            ((PlayerMobile)from).LastTeinture = 0x0594;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 70:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0595;
                            m_previewItem.Hue = 0x0595;
                            ((PlayerMobile)from).LastTeinture = 0x0595;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 71:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0596;
                            m_previewItem.Hue = 0x0596;
                            ((PlayerMobile)from).LastTeinture = 0x0596;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 72:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0599;
                            m_previewItem.Hue = 0x0599;
                            ((PlayerMobile)from).LastTeinture = 0x0599;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 73:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x059B;
                            m_previewItem.Hue = 0x059B;
                            ((PlayerMobile)from).LastTeinture = 0x059B;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 74:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x059D;
                            m_previewItem.Hue = 0x059D;
                            ((PlayerMobile)from).LastTeinture = 0x059D;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 75:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x059E;
                            m_previewItem.Hue = 0x059E;
                            ((PlayerMobile)from).LastTeinture = 0x059E;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 76:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x05A0;
                            m_previewItem.Hue = 0x05A0;
                            ((PlayerMobile)from).LastTeinture = 0x05A0;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 77:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x05A2;
                            m_previewItem.Hue = 0x05A2;
                            ((PlayerMobile)from).LastTeinture = 0x05A2;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 78:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x05A5;
                            m_previewItem.Hue = 0x05A5;
                            ((PlayerMobile)from).LastTeinture = 0x05A5;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 79:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x089F;
                            m_previewItem.Hue = 0x089F;
                            ((PlayerMobile)from).LastTeinture = 0x089F;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 80:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x08A0;
                            m_previewItem.Hue = 0x08A0;
                            ((PlayerMobile)from).LastTeinture = 0x08A0;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 81:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x08A1;
                            m_previewItem.Hue = 0x08A1;
                            ((PlayerMobile)from).LastTeinture = 0x08A1;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 82:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x08A3;
                            m_previewItem.Hue = 0x08A3;
                            ((PlayerMobile)from).LastTeinture = 0x08A3;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 83:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x07D6;
                            m_previewItem.Hue = 0x07D6;
                            ((PlayerMobile)from).LastTeinture = 0x07D6;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 84:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0582;
                            m_previewItem.Hue = 0x0582;
                            ((PlayerMobile)from).LastTeinture = 0x0582;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 85:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0585;
                            m_previewItem.Hue = 0x0585;
                            ((PlayerMobile)from).LastTeinture = 0x0585;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 86:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x058F;
                            m_previewItem.Hue = 0x058F;
                            ((PlayerMobile)from).LastTeinture = 0x058F;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 87:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0591;
                            m_previewItem.Hue = 0x0591;
                            ((PlayerMobile)from).LastTeinture = 0x0591;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 88:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0593;
                            m_previewItem.Hue = 0x0593;
                            ((PlayerMobile)from).LastTeinture = 0x0593;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 89:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0527;
                            m_previewItem.Hue = 0x0527;
                            ((PlayerMobile)from).LastTeinture = 0x0527;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 90:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0524;
                            m_previewItem.Hue = 0x0524;
                            ((PlayerMobile)from).LastTeinture = 0x0524;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 91:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x052D;
                            m_previewItem.Hue = 0x052D;
                            ((PlayerMobile)from).LastTeinture = 0x052D;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 92:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0526;
                            m_previewItem.Hue = 0x0526;
                            ((PlayerMobile)from).LastTeinture = 0x0526;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 93:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x052F;
                            m_previewItem.Hue = 0x052F;
                            ((PlayerMobile)from).LastTeinture = 0x052F;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 94:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0530;
                            m_previewItem.Hue = 0x0530;
                            ((PlayerMobile)from).LastTeinture = 0x0530;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 95:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0531;
                            m_previewItem.Hue = 0x0531;
                            ((PlayerMobile)from).LastTeinture = 0x0531;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 96:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0533;
                            m_previewItem.Hue = 0x0533;
                            ((PlayerMobile)from).LastTeinture = 0x0533;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 97:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0536;
                            m_previewItem.Hue = 0x0536;
                            ((PlayerMobile)from).LastTeinture = 0x0536;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 98:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0538;
                            m_previewItem.Hue = 0x0538;
                            ((PlayerMobile)from).LastTeinture = 0x0538;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 99:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0539;
                            m_previewItem.Hue = 0x0539;
                            ((PlayerMobile)from).LastTeinture = 0x0539;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 100:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x053B;
                            m_previewItem.Hue = 0x053B;
                            ((PlayerMobile)from).LastTeinture = 0x053B;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 101:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x053D;
                            m_previewItem.Hue = 0x053D;
                            ((PlayerMobile)from).LastTeinture = 0x053D;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 102:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x053F;
                            m_previewItem.Hue = 0x053F;
                            ((PlayerMobile)from).LastTeinture = 0x053F;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 103:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0541;
                            m_previewItem.Hue = 0x0541;
                            ((PlayerMobile)from).LastTeinture = 0x0541;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 104:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0542;
                            m_previewItem.Hue = 0x0542;
                            ((PlayerMobile)from).LastTeinture = 0x0542;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 105:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0543;
                            m_previewItem.Hue = 0x0543;
                            ((PlayerMobile)from).LastTeinture = 0x0543;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 106:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0545;
                            m_previewItem.Hue = 0x0545;
                            ((PlayerMobile)from).LastTeinture = 0x0545;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 107:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0548;
                            m_previewItem.Hue = 0x0548;
                            ((PlayerMobile)from).LastTeinture = 0x0548;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 108:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x054A;
                            m_previewItem.Hue = 0x054A;
                            ((PlayerMobile)from).LastTeinture = 0x054A;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 109:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0751;
                            m_previewItem.Hue = 0x0751;
                            ((PlayerMobile)from).LastTeinture = 0x0751;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 110:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0753;
                            m_previewItem.Hue = 0x0753;
                            ((PlayerMobile)from).LastTeinture = 0x0753;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 111:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0755;
                            m_previewItem.Hue = 0x0755;
                            ((PlayerMobile)from).LastTeinture = 0x0755;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 112:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0757;
                            m_previewItem.Hue = 0x0757;
                            ((PlayerMobile)from).LastTeinture = 0x0757;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 113:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0759;
                            m_previewItem.Hue = 0x0759;
                            ((PlayerMobile)from).LastTeinture = 0x0759;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 114:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x06B7;
                            m_previewItem.Hue = 0x06B7;
                            ((PlayerMobile)from).LastTeinture = 0x06B7;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 115:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0467;
                            m_previewItem.Hue = 0x0467;
                            ((PlayerMobile)from).LastTeinture = 0x0467;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 116:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0469;
                            m_previewItem.Hue = 0x0469;
                            ((PlayerMobile)from).LastTeinture = 0x0469;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 117:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x046B;
                            m_previewItem.Hue = 0x046B;
                            ((PlayerMobile)from).LastTeinture = 0x046B;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 118:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x046D;
                            m_previewItem.Hue = 0x046D;
                            ((PlayerMobile)from).LastTeinture = 0x046D;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 119:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x045E;
                            m_previewItem.Hue = 0x045E;
                            ((PlayerMobile)from).LastTeinture = 0x045E;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 120:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0460;
                            m_previewItem.Hue = 0x0460;
                            ((PlayerMobile)from).LastTeinture = 0x0460;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 121:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0462;
                            m_previewItem.Hue = 0x0462;
                            ((PlayerMobile)from).LastTeinture = 0x0462;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 122:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0464;
                            m_previewItem.Hue = 0x0464;
                            ((PlayerMobile)from).LastTeinture = 0x0464;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 123:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x046A;
                            m_previewItem.Hue = 0x046A;
                            ((PlayerMobile)from).LastTeinture = 0x046A;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 124:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0903;
                            m_previewItem.Hue = 0x0903;
                            ((PlayerMobile)from).LastTeinture = 0x0903;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 125:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x096E;
                            m_previewItem.Hue = 0x096E;
                            ((PlayerMobile)from).LastTeinture = 0x096E;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 126:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0905;
                            m_previewItem.Hue = 0x0905;
                            ((PlayerMobile)from).LastTeinture = 0x0905;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 127:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0970;
                            m_previewItem.Hue = 0x0970;
                            ((PlayerMobile)from).LastTeinture = 0x0970;
                            from.SendGump(m_gump);
                        }
                        break;
                    case 128:
                        if (from is PlayerMobile)
                        {
                            m_item.Hue = 0x0972;
                            m_previewItem.Hue = 0x0972;
                            ((PlayerMobile)from).LastTeinture = 0x0972;
                            from.SendGump(m_gump);
                        }
                        break;
                    default: break;
                }
            }*/
        }
    }
}
