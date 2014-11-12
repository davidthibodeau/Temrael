using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
    class CompetenceSmallGump : Gump
    {
        private PlayerMobile m_From;
        private SkillCategory m_Tab;
        private bool m_ShowCaps;

        public CompetenceSmallGump(PlayerMobile from, SkillCategory tab, bool showCaps)
            : base(0, 0)
        {
            m_From = from;
            m_Tab = tab;
            m_ShowCaps = showCaps;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            AddButton(80, 72, 2105, 2105, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1: from.SendGump(new CompetenceGump(m_From, m_Tab, m_ShowCaps)); break;
                default: break;
            }
        }
    }
}
