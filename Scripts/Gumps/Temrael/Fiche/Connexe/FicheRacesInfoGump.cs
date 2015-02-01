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

namespace Server.Gumps.Fiche
{
    public class FicheRacesInfoGump : BaseFicheGump
    {
        private Race m_Race;

        public FicheRacesInfoGump(PlayerMobile from)
            : this(from, from.Race)
        {
        }

        public FicheRacesInfoGump(PlayerMobile from, Race race)
            : base(from, "Race & Alignement", 560, 622, 1)
        {
            m_Race = race;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            AddTitre(x + 360, y + line * scale, 190, "Races");
            ++line;
            for (int i = 1; i < 8; i++)
            {
                AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, Race.GetRaceInstance(i).Name);
                ++line;
            }

            if (race != null)
            {
                int linetmp = line;

                line = 0;
                if (race.Image != -1)
                {
                    AddButton(x, y + line * scale, 8, race.Image);
                    AddTooltip(race.Tooltip);
                }

                line = linetmp;
                AddSection(x + 260, y + line * scale, 275, 170, race.Name, race.Description);

                line = 12;
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

            if (info.ButtonID >= 50)
            {
                from.SendGump(new FicheRacesInfoGump(from, Race.GetRaceInstance(info.ButtonID - 50)));
            }
        }
    }
}
