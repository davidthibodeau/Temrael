using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using Server.Engines.Races;

namespace Server.Gumps
{
    public class FicheStatutsGump : GumpTemrael
    {
        private TMobile m_from;

        public FicheStatutsGump(TMobile from)
            : base("Statuts", 560, 622)
        {
            m_from = from;

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
            AddMenuItem(x, y, 1194, 4, true);
            x += space;
            AddMenuItem(x, y, 1196, 5, true);
            x += space;
            AddMenuItem(x, y, 1222, 6, false);
            x += space;
            AddMenuItem(x, y, 1191, 7, true);

            x = XBase;
            y = YBase;

            AddBackground(x, y + line * scale, 180, 200, 2620);

            Race race = from.Race;


            if (race is Capiceen)
            {
                if (from.Female)
                    AddImage(x - 5, (y + line * scale) - 40, 13);
                else
                    AddImage(x - 5, (y + line * scale) - 40, 12);
            }
            else if (race is Orcish)
            {
                if (from.Female)
                    AddImage(x - 5, (y + line * scale) - 40, 60908);
                else
                    AddImage(x - 5, (y + line * scale) - 40, 50908);
            }
            else if (race is Elfe)
            {
                if (from.Female)
                    AddImage(x - 5, (y + line * scale) - 40, 61027);
                else
                    AddImage(x - 5, (y + line * scale) - 40, 51027);
            }
            else if (race is Nordique)
            {
                if (from.Female)
                    AddImage(x - 5, (y + line * scale) - 40, 61106);
                else
                    AddImage(x - 5, (y + line * scale) - 40, 51106);
            }
            else if (race is Alfar)
            {
                if (from.Female)
                {
                    AddImage(x - 5, (y + line * scale) - 40, 13, 1900);
                    AddImage(x - 5, (y + line * scale) - 40, 61029, 1900);
                }
                else
                {
                    AddImage(x - 5, (y + line * scale) - 40, 12, 1900);
                    AddImage(x - 5, (y + line * scale) - 40, 51029, 1900);
                }
            }
            //case Race.MortVivant:
            //    /*switch (from.MortEvo)
            //    {
            //        case MortEvo.Zombie:
            //            AddImage(155, 110, 51107);
            //            break;
            //        case MortEvo.Squelette:
            //            AddImage(155, 110, 51108);
            //            break;
            //        case MortEvo.Spectre:
            //            AddImage(155, 110, 51110);
            //            break;
            //        case MortEvo.Esprit:
            //            AddImage(155, 110, 51113);
            //            break;
            //        case MortEvo.Ombre:
            //            AddImage(155, 110, 51111);
            //            break;
            //        case MortEvo.Aucune:
            //            AddImage(155, 110, 51107);
            //            break;
            //    }*/
            //    break;
            else if (race is Nain)
            {
                if (from.Female)
                    AddImage(x - 5, (y + line * scale) - 40, 61033);
                else
                    AddImage(x - 5, (y + line * scale) - 40, 51033);
            }
            else if (race is Nomade)
            {
                if (from.Female)
                    AddImage(x - 5, (y + line * scale) - 40, 13, 2416);
                else
                    AddImage(x - 5, (y + line * scale) - 40, 12, 2416);
            }
            //case Race.Tieffelin:
            //    if (from.Female)
            //    {
            //        AddImage(x - 5, (y + line * scale) - 40, 60681);
            //        AddImage(x - 5, (y + line * scale) - 40, 61001);
            //        AddImage(x - 5, (y + line * scale) - 40, 61000);
            //    }
            //    else
            //    {
            //        AddImage(x - 5, (y + line * scale) - 40, 50681);
            //        AddImage(x - 5, (y + line * scale) - 40, 51001);
            //        AddImage(x - 5, (y + line * scale) - 40, 51000);
            //    }
            //    break;
            //case Race.Aasimar:
            //    if (from.Female)
            //    {
            //        AddImage(x - 5, (y + line * scale) - 40, 60997);
            //    }
            //    else
            //    {
            //        AddImage(x - 5, (y + line * scale) - 40, 50997);
            //    }


            /*//Bras
            AddHtml(181, 195, 200, 20, "<h3><basefont color=#5A4A31>Bras<basefont></h3>", false, false);
            AddImageTiled(175, 185, 43, 12, 509);
            AddImageTiled(175, 185, (from.Hits / 100) * 43, 12, 508);
            //Jambes
            AddHtml(267, 310, 200, 20, "<h3><basefont color=#5A4A31>Jambes<basefont></h3>", false, false);
            AddImageTiled(265, 300, 43, 12, 509);
            AddImageTiled(265, 300, (from.Hits / 100) * 43, 12, 508);
            //Buste
            AddHtml(266, 175, 200, 20, "<h3><basefont color=#5A4A31>Buste<basefont></h3>", false, false);
            AddImageTiled(260, 165, 43, 12, 509);
            AddImageTiled(260, 165, (from.Hits / 100) * 43, 12, 508);*/

            int xTmp = x;

            x+= 200;
            AddSection(x, y + line * scale, 310, 130, "Blessures");
            line += 10;

            x = xTmp;
            AddSection(x, y + line * scale, 400, 60, "Maladies");
            AddBackground(x + 420, y + line * scale, 95, 132, 2620);
            AddButton(x + 425, (y + line * scale) + 5, 1443, 1443, 0, GumpButtonType.Reply, 0);
            AddTooltip(3001044);
            line += 6;

            //AddSection(x, y + line * scale, 400, 60, "Fatigue", new string[] { String.Format("Fatigue: {0} / 1000", from.Fatigue) + "<basefont></h3>" });
            AddBackground(x + 420, y + line * scale, 95, 132, 2620);
            AddButton(x + 425, (y + line * scale) + 5, 1444, 1444, 0, GumpButtonType.Reply, 0);
            AddTooltip(3001042);
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
            }
        }
    }
}
