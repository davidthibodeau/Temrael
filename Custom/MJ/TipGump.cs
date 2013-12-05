using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
    public class TipGump : Gump
    {
        public string Center(string text)
        {
            return String.Format("<CENTER>{0}</CENTER>", text);
        }

        public string Color(string text, int color)
        {
            return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
        }

        private Mobile m_To;
        private Mobile m_From;
        private string m_Tip;
        private bool m_Page;

        public TipGump(Mobile to, Mobile from, string tip, bool page)
            : base(0, 0)
        {
            m_To = to;
            m_From = from;
            m_Tip = tip;
            m_Page = page;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            switch (m_Page)
            {
                case true:
                    {
                        AddButton(63, 63, 2507, 2507, 1, GumpButtonType.Reply, 0);
                        break;
                    }
                case false:
                    {
                        AddBackground(39, 42, 270, 281, 9380);

                        //AddHtml(64, 46, 223, 22, Color(Center(String.Format("{0} vous dit :", (m_From.AccessLevel >= AccessLevel.Counselor ? "Éq" : m_From.Name))), 0x000008), false, false);
                        AddHtml(64, 79, 220, 209, m_Tip, false, false);
                        break;
                    }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_To != null)
            {
                if (info.ButtonID == 1)
                    m_To.SendGump(new TipGump(m_To, m_From, m_Tip, false));
                else if (!m_Page)
                    m_To.SendGump(new TipGump(m_To, m_From, m_Tip, true));
            }
        }
    }
}