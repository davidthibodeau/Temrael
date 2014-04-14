using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Gumps
{
    public class RenameGump : Gump
    {
        public RenameGump(TMobile m)
            : base(0, 0)
        {
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;
            this.AddPage(0);
            this.AddBackground(0, 0, 454, 182, 9200);
            this.AddLabel(98, 14, 0, @"Entrez le nom de ce personnage :");
            this.AddTextEntry(89, 60, 200, 20, 0, 0, "");
            AddButton(345, 217, 0xF2, 0xF1, 0, GumpButtonType.Reply, 0);
            to = m;
        }

        public TMobile to;

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = (Mobile)sender.Mobile;

            switch (info.ButtonID)
            {
                case 0:
                    {
                        TextRelay entry = info.GetTextEntry(0);
                        string entrytext = (entry == null) ? "" : entry.Text;
                        to.NewName(entrytext, from);
                        from.SendMessage(entrytext);
                        from.CloseGump(typeof(RenameGump));
                        break;
                    }
                    //from.SendGump(new RenameGump((TMobile)from));
            }
        }
    }
}