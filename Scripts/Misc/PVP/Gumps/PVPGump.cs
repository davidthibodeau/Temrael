using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Commands;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Misc.PVP.Gumps
{
    public class PVPGump : GumpTemrael
    {
        ScriptMobile m_From;
        PVPStone m_Stone;

        int x = 50;
        int y = 50;

        int line = 0;
        int scale = 25;
        const int columnScale = 50;

        const int NbEventParPage = 10;

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * NbEventParPage);
        }

        public PVPGump(ScriptMobile from, PVPStone stone)
            : base("", 0, 0)
        {
            m_From = from;
            m_Stone = stone;

            m_From.CloseGump(typeof(PVPGump));

            AddBackground(0, 0, 400, 130, 5054);

            // Rejoindre un Event.
            AddButton(x, y + (line * scale), 0xFAE, 0xFB0, 1, GumpButtonType.Reply, 0);
            AddHtml(x + 100, y + (line * scale), 150, 20, "<h3> Rejoindre un event </h3>", false, false);

            line++;

            // Creer un Event.
            AddButton(x, y + (line * scale), 0xFAE, 0xFB0, 2, GumpButtonType.Reply, 0);
            AddHtml(x + 100, y + (line * scale), 150, 20, "<h3> Créer un event </h3>", false, false);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1: // Rejoindre
                    {
                        sender.Mobile.SendGump(new PVPGumpJoin((ScriptMobile)sender.Mobile));
                        break;
                    }
                case 2: // Creer
                    {
                        sender.Mobile.SendGump(new PVPGumpCreation((ScriptMobile)sender.Mobile, m_Stone));
                        break;
                    }
            }
        }
    }
}
