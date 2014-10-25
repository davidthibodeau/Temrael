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
    public class FicheRaceGump : GumpTemrael
    {
        private TMobile m_from;

        public FicheRaceGump(TMobile from)
            : base("Race", 560, 622)
        {
            m_from = from;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1178, 1, false);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, true);
            x += space;
            AddMenuItem(x, y, 1194, 4, true);
            x += space;
            AddMenuItem(x, y, 1196, 5, true);
            x += space;
            AddMenuItem(x, y, 1222, 6, true);
            x += space;
            AddMenuItem(x, y, 1191, 7, true);

            x = XBase;
            y = YBase;

            /*Race*/
            if (from.Race != null)
            {
                Race race = from.Race;
                AddButton(x, y + line * scale, 8, race.Image);
                //AddTooltip(race.Tooltip);
                
                line += 13;
                AddButton(x, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 50, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Informations<basefont></h3>", false, false);

                line = 1;
                AddSection(x + 220, y + line * scale, 300, 100, "Description", race.Description);

                line += 7;

                AddSection(x + 220, y + line * scale, 300, 80, "Évolution");
                line += 2;
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Expérience : ", from.XP));
                ++line;
                AddButton(x + 237, y + line * scale, 2117, 2118, 10, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Niveau : ", from.Niveau));
                ++line;
                AddButton(x + 237, y + line * scale, 2117, 2118, 11, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Reset", (from.FreeReset == true ? " (1 Gratuit)" : " (0 Gratuit)")));




            }
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
                    from.SendGump(new FicheRacesInfoGump(from));
                    break;
                case 10:
                    if (XP.CanEvolve((TMobile)from))
                        XP.Evolve((TMobile)from);
                    from.SendGump(new FicheRaceGump(from));
                    break;
                case 11:
                    from.SendGump(new FicheResetMessageGump(from));
                    break;
            }
        }
    }
}
