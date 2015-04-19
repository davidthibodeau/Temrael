using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections;
using System.Collections.Generic;
using Server.Engines.Evolution;

namespace Server.Gumps.Fiche
{
    public class FicheCotesGump : BaseFicheGump
    {
        public FicheCotesGump(PlayerMobile from) : this(from, 0)
        {
        }

        public FicheCotesGump(PlayerMobile from, int page)
            : base(from, "Cotes et fioles", 560, 622, 4)
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 20;

            int space = 80;

            /*Statistiques*/
            line = 0;

            Cotes cotes = from.Experience.Cotes;

            for (int i = 0; i < cotes.Count; i++)
            {
                if (i >= (page + 1) * 10)
                    break;
                if (i < page * 10)
                    continue;
                RaisonCote cote = cotes[i];
                line++;
                AddHtmlTexte(x, y + line * scale, 200, cote.Timestamp.ToString());
                AddHtmlTexte(x + 200, y + line * scale, 350, 60, cote.Message);
                line++;
                line++;
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
        }
    }
}
