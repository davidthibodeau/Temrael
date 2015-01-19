using System;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Engines.Evolution
{
    public class CotesGump : Gump
    {
        private int page;
        private PlayerMobile mobile;

        public CotesGump(PlayerMobile pm, int page) : base(50, 50)
        {
            this.page = page;

            Closable=true;
            Disposable=true;
            Dragable=true;
            Resizable=false;

            AddPage(0);
            AddBackground(31, 48, 416, 432, 9250);
            AddBackground(39, 56, 400, 417, 3500);
            AddLabel(174, 78, 1301, @"Historique de cotes de " + pm.Name);
            AddButton(285, 430, 4005, 4006, 1, GumpButtonType.Reply, 0);
            AddLabel(185, 431, 1301, @"Ajouter cote");

            Cotes cotes = pm.Experience.Cotes;

            int basey = 110;
            for (int i = 0; i < cotes.Count; i++)
            {
                if (i >= (page + 1) * 10)
                    break;
                if (i < page * 10)
                    continue;
                RaisonCote cote = cotes[i];
                AddLabel(80, basey + (i % 10) * 30, 1301, cote.Auteur.ToString());
                AddLabel(160, basey + (i % 10) * 30, 1301, cote.Timestamp.ToString());
                AddLabel(270, basey + (i % 10) * 30, 1301, cote.Message);
                //AddButton(383, basey + (i % 10) * 30 - 1, 4005, 4006, i + 10, GumpButtonType.Reply, 0);

            }
            AddButton(402, 411, 5601, 5605, 2, GumpButtonType.Reply, 0);
            AddButton(61, 410, 5603, 5607, 3, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile m = sender.Mobile;
            switch(info.ButtonID)
            {
                case 1:

                    break;

                case 2:
                    m.SendGump(new CotesGump(mobile, page + 1));
                    break;

                case 3:
                    m.SendGump(new CotesGump(mobile, page - 1));
                    break;
            }
        }
    }
}

