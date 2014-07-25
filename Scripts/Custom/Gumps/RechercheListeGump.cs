using System;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Server;
using Server.Items;
using Server.Prompts;
using Server.Network;
using Server.Accounting;
using Server.Commands;
using Server.Mobiles;
using Server.Misc;

namespace Server.Gumps
{
    public class RechercheListeGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("Recherche", AccessLevel.Administrator, new CommandEventHandler(AccountList_OnCommand));
        }

        [Usage("Recherche")]
        [Aliases("Recherche")]
        [Description("Lists all accounts/clients/IPs.")]
        private static void AccountList_OnCommand(CommandEventArgs e)
        {
            e.Mobile.SendGump(new RechercheListeGump(e.Mobile));
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

        private const int EntryWidth = 600;
        private const int EntryCount = 15;

        private const int searchSection = 100;

        private const int TotalWidth = OffsetSize + EntryWidth + OffsetSize + SetWidth + OffsetSize;
        private const int TotalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (EntryCount + 1)) + searchSection;

        private const int BackWidth = BorderSize + TotalWidth + BorderSize;
        private const int BackHeight = BorderSize + TotalHeight + BorderSize;

        private Mobile m_Owner;
        private ArrayList c_Characters;
        private ArrayList c_Accounts;
        private int m_Page;

        private class InternalComparer : IComparer
        {
            public static readonly IComparer Instance = new InternalComparer();

            public InternalComparer()
            {
            }

            public int Compare(object x, object y)
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return -1;
                else if (y == null)
                    return 1;

                Account a = x as Account;
                Account b = y as Account;

                if (a == null || b == null)
                    throw new ArgumentException();

                if (a.AccessLevel > b.AccessLevel)
                    return -1;
                else if (a.AccessLevel < b.AccessLevel)
                    return 1;
                else
                    return Insensitive.Compare(a.Username, b.Username);
            }
        }

        public RechercheListeGump(Mobile owner)
            : this(owner, BuildListCharacters(), BuildListAccounts(), 0)
        {
        }

        public RechercheListeGump(Mobile owner, ArrayList list_characters, ArrayList list_accounts, int page)
            : base(GumpOffsetX, GumpOffsetY)
        {
            owner.CloseGump(typeof(RechercheListeGump));

            m_Owner = owner;
            c_Characters = list_characters;
            c_Accounts = list_accounts;

            Initialize(page);
        }

        public static ArrayList BuildListCharacters()
        {
            ArrayList list_characters = new ArrayList();
            string result;

            foreach (Account acct in Accounts.GetAccounts())
            {
                for (int i = 0; i < acct.Length; ++i)
                {
                    if (acct[i] != null){
                        result = "Account: " + acct.Username + "  Nom: " + acct[i] + "  IP: ";

                        for (int j = 0; j < acct.LoginIPs.Length; ++j)
                            result = result + acct.LoginIPs[j] + ", ";
                        list_characters.Add(result);
                    }
                }
            }

            return list_characters;
        }

        public static ArrayList BuildListAccounts()
        {
            return new ArrayList((ICollection)Accounts.GetAccounts());
        }

        public void Initialize(int page)
        {
            m_Page = page;

            int count = c_Characters.Count - (page * EntryCount);

            if (count < 0)
                count = 0;
            else if (count > EntryCount)
                count = EntryCount;

            int totalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (count + 1)) + searchSection;

            AddPage(0);

            AddBackground(0, 0, BackWidth, BorderSize + totalHeight + BorderSize, BackGumpID);
            AddImageTiled(BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), totalHeight, OffsetGumpID);

            int x = BorderSize + OffsetSize;
            int y = BorderSize + OffsetSize;

            int emptyWidth = TotalWidth - PrevWidth - NextWidth - (OffsetSize * 4) - (OldStyle ? SetWidth + OffsetSize : 0);

            if (!OldStyle)
                AddImageTiled(x - (OldStyle ? OffsetSize : 0), y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0), EntryHeight, EntryGumpID);

            AddHtml(x + TextOffsetX, y, 200, 20, String.Format("<h3><basefont color=#5A4A31>Page {0} de {1} ({2})<basefont></h3>", page + 1, (c_Characters.Count + EntryCount - 1) / EntryCount, c_Characters.Count), false, false);

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

            if ((page + 1) * EntryCount < c_Characters.Count)
            {
                AddButton(x + NextOffsetX, y + NextOffsetY, NextButtonID1, NextButtonID2, 2, GumpButtonType.Reply, 1);

                if (NextLabel)
                    AddHtml(x + NextLabelOffsetX, y + NextLabelOffsetY, 200, 20, "<h3><basefont color=#5A4A31>Suivant<basefont></h3>", false, false);
            }

            for (int i = 0, index = page * EntryCount; i < EntryCount && index < c_Characters.Count; ++i, ++index)
            {
                if (c_Characters[index] != null)
                {
                    x = BorderSize + OffsetSize;
                    y += EntryHeight + OffsetSize;

                    AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
                    AddHtml(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, "<h3><basefont color=#025a>" + c_Characters[index] + "<basefont></h3>", false, false);

                    x += EntryWidth + OffsetSize;

                    if (SetGumpID != 0)
                        AddImageTiled(x, y, SetWidth, EntryHeight, SetGumpID);
                }
            }

            x = BorderSize + OffsetSize;
            y += 2*(EntryHeight + OffsetSize);

            AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
            AddHtml(x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, "<h3><basefont color=#025a>" + "Rechercher des noms de compte, des noms de personnage ou des adresses IP" + "<basefont></h3>", false, false);
            y += EntryHeight + OffsetSize;

            AddImageTiled(x, y, EntryWidth, EntryHeight, EntryGumpID);
            AddTextEntry(x, y, EntryWidth, EntryHeight, 602, 0, "");
            y += EntryHeight + OffsetSize;

            AddButton(x + TextOffsetX, y, 0xF7, 0xF7, 3, GumpButtonType.Reply, 0);

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
                            from.SendGump(new RechercheListeGump(from, c_Characters, c_Accounts, m_Page - 1));

                        break;
                    }
                case 2: // Next
                    {
                        if ((m_Page + 1) * EntryCount < c_Characters.Count)
                            from.SendGump(new RechercheListeGump(from, c_Characters, c_Accounts, m_Page + 1));

                        break;
                    }

                case 3: // Search
                    {
                        TextRelay entry = info.GetTextEntry(0);
                        string text = (entry == null ? "" : entry.Text.Trim());
                        ArrayList newList = new ArrayList();
                        from.SendMessage("Recherche en cours pour : " + text);

                        foreach (string item in c_Characters)
                        {
                            if (item.Contains(text))
                                newList.Add(item);
                        }

                        from.SendMessage("Résultat:");
                        for (int i = 0; i < newList.Count; i++)
                            from.SendMessage("Résultat: " + newList[i]);

                        break;
                    }
            }
        }
    }
}