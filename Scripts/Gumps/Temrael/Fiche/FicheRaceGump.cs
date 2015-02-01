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
using Server.Engines.Evolution;

namespace Server.Gumps.Fiche
{
    public class FicheRaceGump : BaseFicheGump
    {
        public FicheRaceGump(PlayerMobile from)
            : base(from, "Race", 560, 622, 1)
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            /*Race*/
            if (from.Race != null)
            {
                Race race = from.Race;
                if (race.Image != -1)
                    AddButton(x, y + line * scale, 8, race.Image);
                //AddTooltip(race.Tooltip);

                line += 13;
                AddButton(x, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 50, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Informations<basefont></h3>", false, false);

                line = 1;
                AddSection(x + 220, y + line * scale, 300, 100, "Description", race.Description);
            }
            line += 7;

            if (from.Experience != null)
            {
                AddSection(x + 220, y + line * scale, 300, 80, "Évolution");
                line += 2;
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Expérience : ", from.Experience.XP));
                ++line;
                AddButton(x + 237, y + line * scale, 2117, 2118, 10, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Niveau : ", from.Experience.Niveau));
                ++line;
                //AddButton(x + 237, y + line * scale, 2117, 2118, 11, GumpButtonType.Reply, 0);
                //AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Reset", (from.FreeReset == true ? " (1 Gratuit)" : " (0 Gratuit)")));
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            PlayerMobile from = (PlayerMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            if (info.ButtonID < 8)
            {
                base.OnResponse(sender, info);
                return;
            }

            switch (info.ButtonID)
            {
                case 8:
                    from.SendGump(new FicheRacesInfoGump(m_from));
                    break;
                case 10:
                    if (XP.CanEvolve((PlayerMobile)from))
                        XP.Evolve((PlayerMobile)from);
                    from.SendGump(new FicheRaceGump(from));
                    break;
                case 11:
                    from.SendGump(new FicheResetMessageGump(from));
                    break;
            }
        }
    }
}
