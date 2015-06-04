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
    public class PVPGumpPreparation : GumpTemrael
    {

        Mobile m_From;
        PVPEvent m_Pvpevent;
        List<Mobile> m_List;

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

        public PVPGumpPreparation(Mobile from, PVPEvent pvpevent, List<Mobile> list)
            : base("", 0, 0)
        {
            m_From = from;
            m_Pvpevent = pvpevent;
            m_List = list;

            m_From.CloseGump(typeof(PVPGumpPreparation));

            AddBackground(0, 0, 400, 155, 5054);

            AddHtml(x, y + (line * scale), 300, 20, "<h3>Voulez vous rejoindre l'event " + m_Pvpevent.nom + " ? </h3>", false, false);
            
            line++;

            AddButton(x, y + (line * scale), 0xFAE, 0xFB0, 1, GumpButtonType.Reply, 0);
            AddHtml(x + 50, y + (line * scale), 150, 20, "<h3> Oui. </h3>", false, false);

            line++;

            AddButton(x, y + (line * scale), 0xFAE, 0xFB0, 2, GumpButtonType.Reply, 0);
            AddHtml(x + 50, y + (line * scale), 150, 20, "<h3> Non, j'ai peur ! </h3>", false, false);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1: // Oui
                    {
                        m_Pvpevent.teams.Spawn(m_From);
                        m_List.Remove(m_From);
                        m_From.Frozen = true;
                        break;
                    }
                case 2: // Non
                    {
                        break;
                    }
                default:
                    {
                        m_From.SendGump(new PVPGumpPreparation(m_From, m_Pvpevent, m_List));
                        break;
                    }
            }
        }
    }
}
