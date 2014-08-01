using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;
using Server.Prompts;
using Server.ContextMenus;

namespace Server.Engines.Identities
{

    public class RenameEntry : ContextMenuEntry
    {
        private TMobile m_from;
        private TMobile m_target;

        public RenameEntry(TMobile from, TMobile target)
            : base(6097, -1)
        {
            m_from = from;
            m_target = target;
        }

        public override void OnClick()
        {
            m_from.Prompt = new RenamePrompt(m_from, m_target);
        }
    }

    public class RenamePrompt : Prompt
    {
        private TMobile m_target;
        private TMobile m_from;

        public RenamePrompt(TMobile from, TMobile target)
        {
            from.SendMessage("Entrez le nouveau nom que vous souhaitez attribuer au personnage:");
            m_target = target;
            m_from = from;
        }

        public override void OnResponse(Mobile from, string text)
        {
            if (m_target != null && !(m_target.Deleted))
                if (m_from.Alive && !(m_from.Deleted))
                    m_target.Identities.NewName(text, m_from);
        }
    }

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
                        to.Identities.NewName(entrytext, from);
                        from.SendMessage(entrytext);
                        from.CloseGump(typeof(RenameGump));
                        break;
                    }
                    //from.SendGump(new RenameGump((TMobile)from));
            }
        }
    }
}