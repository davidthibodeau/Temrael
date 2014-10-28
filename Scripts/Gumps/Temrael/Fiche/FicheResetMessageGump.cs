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
    public class FicheResetMessageGump : GumpTemrael
    {
        private TMobile m_from;

        public FicheResetMessageGump(TMobile from)
            : base("Reset", 340, 160)
        {
            m_from = from;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            x = 90;

            AddSection(x + 20, y + (line * scale) + 12, 300, 60, "Souhaitez vous reset votre perso ?");
            ++line;
            ++line;
            AddButton(x + 40, y + line * scale, 2117, 2118, 8, GumpButtonType.Reply, 0);
            AddHtmlTexte(x + 65, y + line * scale, DefaultHtmlLength, "Oui");
            ++line;
            AddButton(x + 40, y + line * scale, 2117, 2118, 9, GumpButtonType.Reply, 0);
            AddHtmlTexte(x + 65, y + line * scale, DefaultHtmlLength, "Non");
            
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
                    //from.Reset(false);

                    from.SendMessage("Votre personnage a reset ses informations.");
                    from.SendGump(new FicheRaceGump(from));
                    break;
                case 9:
                    from.SendGump(new FicheRaceGump(from));
                    break;
            }
        }
    }
}
