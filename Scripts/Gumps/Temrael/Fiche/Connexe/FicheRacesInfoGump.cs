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
    public class FicheRacesInfoGump : GumpTemrael
    {
        private TMobile m_from;
        private Race m_Races;

        public FicheRacesInfoGump(TMobile from)
            : this(from, from.Races)
        {
        }

        public FicheRacesInfoGump(TMobile from, Race Races)
            : base("Race & Alignement", 560, 622)
        {
            m_from = from;
            m_Races = Races;

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

            AddTitre(x + 360, y + line * scale, 190, "Races");
            ++line;
            for (int i = 0; i < (int)Race.Maximum; i++)
            {
                if ((Race)(i) != Race.MortVivant)
                {
                    AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                    AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, ((Race)i).ToString());
                    ++line;
                }
            }

            if (Races != Race.Aucun)
            {
                BaseRace race = RaceManager.getRace(Races);

                int linetmp = line;

                line = 0;
                AddButton(x, y + line * scale, 8, race.Image);
                AddTooltip(race.Tooltip);

                line = linetmp;
                AddSection(x + 260, y + line * scale, 275, 170, race.Name, race.Description);

                line = 12;

                string bonus = race.BonusDescr;

                AddSection(x, y + line * scale, 250, 160, "Bonus Raciaux", bonus);
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
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new FicheRacesInfoGump(from, (Race)(info.ButtonID - 50)));
            }
        }
    }
}
