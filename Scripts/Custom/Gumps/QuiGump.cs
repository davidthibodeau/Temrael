using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Commands;

namespace Server.Gumps
{
    public class QuiGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("Qui", AccessLevel.Player, new CommandEventHandler(WhoList_OnCommand));
            CommandSystem.Register("QuiListe", AccessLevel.Player, new CommandEventHandler(WhoList_OnCommand));
        }

        [Usage("WhoList")]
        [Aliases("Who")]
        [Description("Lists all connected clients.")]
        private static void WhoList_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new QuiGump(e.Mobile));
        }

        public static bool OldStyle = false;

        public const int GumpOffsetX = 30;
        public const int GumpOffsetY = 30;

        public const int TextHue = 0;
        public const int TextOffsetX = 2;

        public const int OffsetGumpID = 0x0A40;
        public const int HeaderGumpID = 0x0E14;
        public const int EntryGumpID = 0x0BBC;
        public const int BackGumpID = 0x13BE;
        public const int SetGumpID = 0x0E14;

        public const int SetWidth = 20;
        public const int SetOffsetX = 2, SetOffsetY = 2;
        public const int SetButtonID1 = 0x15E1;
        public const int SetButtonID2 = 0x15E5;

        public const int PrevWidth = 20;
        public const int PrevOffsetX = 2, PrevOffsetY = 2;
        public const int PrevButtonID1 = 0x15E1;
        public const int PrevButtonID2 = 0x15E5;

        public const int NextWidth = 20;
        public const int NextOffsetX = 2, NextOffsetY = 2;
        public const int NextButtonID1 = 0x15E1;
        public const int NextButtonID2 = 0x15E5;

        public const int OffsetSize = 1;

        public const int EntryHeight = 20;
        public const int BorderSize = 10;

        private static bool PrevLabel = false, NextLabel = false;

        private const int PrevLabelOffsetX = PrevWidth + 1;
        private const int PrevLabelOffsetY = 0;

        private const int NextLabelOffsetX = -29;
        private const int NextLabelOffsetY = 0;

        private const int EntryWidth = 180;
        private const int EntryCount = 15;

        private const int TotalWidth = OffsetSize + EntryWidth + OffsetSize + SetWidth + OffsetSize;
        private const int TotalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (EntryCount + 1));

        private const int BackWidth = BorderSize + TotalWidth + BorderSize;
        private const int BackHeight = BorderSize + TotalHeight + BorderSize;

        private Mobile m_Owner;
        private ArrayList m_Mobiles;
        private int m_Page;

        private class InternalComparer : IComparer
        {
            Mobile m_Owner;

            public InternalComparer(Mobile from)
            {
                m_Owner = from;
            }

            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return -1;
                else if (y == null)
                    return 1;

                Mobile a = x as Mobile;
                Mobile b = y as Mobile;

                if (a == null || b == null)
                    throw new ArgumentException();

                if (a.AccessLevel > b.AccessLevel)
                    return -1;
                else if (a.AccessLevel < b.AccessLevel)
                    return 1;
                else
                    return Insensitive.Compare(a.GetNameUseBy(m_Owner), b.GetNameUseBy(m_Owner));
            }
        }

        public QuiGump(Mobile owner)
            : this(owner, BuildList(owner), 0)
        {
        }

        public QuiGump(Mobile owner, ArrayList list, int page)
            : base(GumpOffsetX, GumpOffsetY)
        {
            owner.CloseGump(typeof(WhoGump));

            m_Owner = owner;
            m_Mobiles = list;

            Initialize(page);
        }

        public static ArrayList BuildList(Mobile owner)
        {
            ArrayList list = new ArrayList();
            List<NetState> states = NetState.Instances;

            for (int i = 0; i < states.Count; ++i)
            {
                Mobile m = ((NetState)states[i]).Mobile;

                if (m != null && (m == owner || !m.Hidden || owner.AccessLevel >= m.AccessLevel))
                    list.Add(m);
            }

            list.Sort(new InternalComparer(owner));

            return list;
        }

        public void Initialize(int page)
        {
            m_Page = page;

            int count = m_Mobiles.Count - (page * EntryCount);

            if (count < 0)
                count = 0;
            else if (count > EntryCount)
                count = EntryCount;

            int totalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (count + 1));

            AddPage(0);

            AddBackground(0, 0, BackWidth, BorderSize + totalHeight + BorderSize, BackGumpID);
            AddImageTiled(BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), totalHeight, OffsetGumpID);

            int x = BorderSize + OffsetSize;
            int y = BorderSize + OffsetSize;

            int emptyWidth = TotalWidth - PrevWidth - NextWidth - (OffsetSize * 4) - (OldStyle ? SetWidth + OffsetSize : 0);

            if (!OldStyle)
                AddImageTiled(x - (OldStyle ? OffsetSize : 0), y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0), EntryHeight, EntryGumpID);

            AddHtml(x + TextOffsetX, y, 200, 20, String.Format("<h3><basefont color=#5A4A31>Page {0} de {1} ({2})<basefont></h3>", page + 1, (m_Mobiles.Count + EntryCount - 1) / EntryCount, m_Mobiles.Count), false, false);
            AddButton(x + TextOffsetX + 131, y + 2, 0x5f9, 0x5f9, 3, GumpButtonType.Reply, 0);
            x += emptyWidth + OffsetSize;

            if (OldStyle)
                AddImageTiled(x, y, TotalWidth - (OffsetSize * 3) - SetWidth, EntryHeight, HeaderGumpID);
            else
                AddImageTiled(x, y, PrevWidth, EntryHeight, HeaderGumpID);

            if (page > 0)
            {
                AddButton(x + PrevOffsetX, y + PrevOffsetY, PrevButtonID1, PrevButtonID2, 1, GumpButtonType.Reply, 0);

                if (PrevLabel)
                    AddHtml(x + PrevLabelOffsetX, y + PrevLabelOffsetY, 200, 20, "<h3><basefont color=#5A4A31>Précedent<basefont></h3>", false, false);
            }

            x += PrevWidth + OffsetSize;

            if (!OldStyle)
                AddImageTiled(x, y, NextWidth, EntryHeight, HeaderGumpID);

            if ((page + 1) * EntryCount < m_Mobiles.Count)
            {
                AddButton(x + NextOffsetX, y + NextOffsetY, NextButtonID1, NextButtonID2, 2, GumpButtonType.Reply, 1);

                if (NextLabel)
                    AddHtml(x + NextLabelOffsetX, y + NextLabelOffsetY, 200, 20, "<h3><basefont color=#5A4A31>Suivant<basefont></h3>", false, false);
            }

            for (int i = 0, index = page * EntryCount; i < EntryCount && index < m_Mobiles.Count; ++i, ++index)
            {
                x = BorderSize + OffsetSize;
                y += EntryHeight + OffsetSize;

                Mobile m = (Mobile)m_Mobiles[index];

                AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
                AddHtml(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, "<h3><basefont color=#025a>" + (m.Deleted ? "(deleted)" : GetNameFor(m, m_Owner)) + "<basefont></h3>", false, false);
                //AddLabelCropped(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, GetHueFor(m), m.Deleted ? "(deleted)" : GetNameFor(m));

                x += EntryWidth + OffsetSize;

                if (SetGumpID != 0)
                    AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);

                if (m.NetState != null && !m.Deleted)
                    AddButton(x + SetOffsetX, y + SetOffsetY, SetButtonID1, SetButtonID2, i + 10, GumpButtonType.Reply, 0);
            }
        }

        private static string GetNameFor(Mobile m, Mobile m_Owner)
        {
            if (m is TMobile)
            {
                if (((TMobile)m).Races == Races.Tieffelin || ((TMobile)m).Races == Races.Aasimar)
                    return String.Format("{0}, {1}", m.GetNameUseBy(m_Owner), ((TMobile)m).RaceSecrete.ToString());
                else
                    return String.Format("{0}, {1}", m.GetNameUseBy(m_Owner), ((TMobile)m).Races.ToString());
            }
            else
            {
                return m.Name;
            }
        }

        private static int GetHueFor(Mobile m)
        {
            switch (m.AccessLevel)
            {
                case AccessLevel.Coordinateur: return 0x516;
                case AccessLevel.Chroniqueur: return 0x144;
                case AccessLevel.Batisseur: return 0x21;
                case AccessLevel.Counselor: return 0x2;
                case AccessLevel.Player:
                default:
                    {
                        /*if ( m.Kills >= 5 )
                            return 0x21;
                        else if ( m.Criminal )
                            return 0x3B1;*/

                        return 0x58;
                    }
            }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Mobile from = state.Mobile;

            switch (info.ButtonID)
            {
                case 0: // Closed
                    {
                        return;
                    }
                case 1: // Previous
                    {
                        if (m_Page > 0)
                            from.SendGump(new QuiGump(from, m_Mobiles, m_Page - 1));

                        break;
                    }
                case 2: // Next
                    {
                        if ((m_Page + 1) * EntryCount < m_Mobiles.Count)
                            from.SendGump(new QuiGump(from, m_Mobiles, m_Page + 1));

                        break;
                    }
                case 3: // Options
                    {
                        if(from is PlayerMobile)
                            from.SendGump(new QuiOptionsGump((PlayerMobile)from));
                        break;
                    }
                default:
                    {
                        int index = (m_Page * EntryCount) + (info.ButtonID - 10);

                        if (index >= m_Mobiles.Count)
                            return;
                        Mobile m = (Mobile)m_Mobiles[index];

                        if (index >= 0 && index < m_Mobiles.Count && m_Owner.AccessLevel >= m.AccessLevel)
                        {
                            if (m.Deleted)
                            {
                                from.SendMessage("Ce joueur a supprimé son personnage.");
                                from.SendGump(new QuiGump(from, m_Mobiles, m_Page));
                            }
                            else if (m.NetState == null)
                            {
                                from.SendMessage("Ce joueur n'est plus connecté en jeu.");
                                from.SendGump(new QuiGump(from, m_Mobiles, m_Page));
                            }
                            else
                            {
                                from.SendGump(new ClientGump(from, m.NetState));
                            }
                        }
                        else
                        {
                            from.SendMessage("Vous ne pouvez pas accéder à la fenêtre d'un maître de jeu.");
                            from.SendGump(new QuiGump(from, m_Mobiles, m_Page));
                        }

                        break;
                    }
            }
        }
    }

    public enum QuiOptions
    {
        All                = 0x000,
        SansAnonyme        = 0x001,
        SansIdentiteCachee = 0x010,
        SansAnonNiIC       = 0x011,
        SansConnus         = 0x100,
        SeulementIC        = 0x101,
        SeulementAnon      = 0x110,
        None               = 0x111
    }

    public class QuiOptionsGump : Gump
    {

        PlayerMobile owner;

        public QuiOptionsGump(PlayerMobile from) : base(30, 30)
        {
            owner = from;
            int q = (int)owner.QuiOptions;

			AddPage(0);
			AddBackground(39, 56, 350, 120, 3500);

            AddHtml(75, 75, 300, 50, "<h3><basefont color=#5A4A31>" + "Options de réception de messages privés" + "<basefont><h3>", false, false);

            if ((q & 0x001) == 0)
                AddButton(100, 100, 0x138a, 0x138b, 2, GumpButtonType.Reply, 0);
            else
                AddButton(100, 100, 0x138b, 0x138a, 2, GumpButtonType.Reply, 0);
            AddHtml(125, 99, 300, 50, "<h3><basefont color=#025a>" + "Bloquer les anonymes" + "<basefont><h3>", false, false);

            if ((q & 0x010) == 0)
                AddButton(100, 120, 0x138a, 0x138b, 3, GumpButtonType.Reply, 0);
            else
                AddButton(100, 120, 0x138b, 0x138a, 3, GumpButtonType.Reply, 0);
            AddHtml(125, 119, 300, 50, "<h3><basefont color=#025a>" + "Bloquer les identités cachées" + "<basefont><h3>", false, false);

            if ((q & 0x100) == 0)
                AddButton(100, 140, 0x138a, 0x138b, 4, GumpButtonType.Reply, 0);
            else
                AddButton(100, 140, 0x138b, 0x138a, 4, GumpButtonType.Reply, 0);
            AddHtml(125, 139, 300, 50, "<h3><basefont color=#025a>" + "Bloquer les gens renommés" + "<basefont><h3>", false, false);

        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID == 0)
            {
                owner.SendGump(new QuiGump(owner));
                return;
            }
            int q = (int)owner.QuiOptions;
            switch (info.ButtonID)
            {
                case 2: // Toggle Anonyme
                    owner.QuiOptions = (QuiOptions)((q | 0x001) & (~q | 0x110));
                    break;

                case 3: //Toggle Identite Cachee
                    owner.QuiOptions = (QuiOptions)((q | 0x010) & (~q | 0x101));
                    break;

                case 4: //Toggle Les personnes connues
                    owner.QuiOptions  = (QuiOptions)((q | 0x100) & (~q | 0x011));
                    break;
                    
            }
            owner.SendGump(new QuiOptionsGump(owner));
        }
    }
}