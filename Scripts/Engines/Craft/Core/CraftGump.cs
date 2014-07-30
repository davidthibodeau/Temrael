using System;
using System.Collections;
using System.Collections.Generic;
using Server.Gumps;
using Server.Network;
using Server.Items;

namespace Server.Engines.Craft
{
    public class CraftGump : Gump
    {
        private Mobile m_From;
        private CraftSystem m_CraftSystem;
        private BaseTool m_Tool;

        private CraftPage m_Page;

        private const int LabelHue = 0x480;
        private const int LabelColor = 0x7FFF;
        private const int FontColor = 0xFFFFFF;

        private int maxItemPerPage = 30;

        private enum CraftPage
        {
            None,
            PickResource,
            PickResource2
        }

        /*public CraftGump( Mobile from, CraftSystem craftSystem, BaseTool tool ): this( from, craftSystem, -1, -1, tool, null )
        {
        }*/

        public CraftGump(Mobile from, CraftSystem craftSystem, BaseTool tool, object notice)
            : this(from, craftSystem, tool, notice, CraftPage.None)
        {
        }

        private CraftGump(Mobile from, CraftSystem craftSystem, BaseTool tool, object notice, CraftPage page)
            : base(40, 40)
        {
            m_From = from;
            m_CraftSystem = craftSystem;
            m_Tool = tool;
            m_Page = page;


            CraftContext context = craftSystem.GetContext(from);

            from.CloseGump(typeof(CraftGump));
            from.CloseGump(typeof(CraftGumpItem));

            AddPage(0);

            AddBackground(0, 0, 830, 537, 5054);
            AddImageTiled(10, 10, 810, 22, 2624);
            AddImageTiled(10, 37, 200, 350, 2624);
            AddImageTiled(215, 37, 605, 350, 2624);
            AddImageTiled(10, 392, 150, 45, 2624);
            AddImageTiled(165, 392, 655, 45, 2624);
            AddImageTiled(10, 442, 810, 85, 2624);
            AddAlphaRegion(10, 10, 810, 517);

            if (craftSystem.GumpTitleNumber > 0)
                AddHtmlLocalized(10, 12, 510, 20, craftSystem.GumpTitleNumber, LabelColor, false, false);
            else
                //	AddHtml( 10, 12, 510, 20, craftSystem.GumpTitleString, false, false );
                AddHtml(10, 12, 500, 20, "<h3><basefont color=#FFFFFF>" + craftSystem.GumpTitleString + "<basefont></h3>", false, false);

            //AddHtmlLocalized( 10, 37, 200, 22, 1044010, LabelColor, false, false ); // <CENTER>CATEGORIES</CENTER>
            //AddHtmlLocalized( 215, 37, 305, 22, 1044011, LabelColor, false, false ); // <CENTER>SELECTIONS</CENTER>
            //AddHtmlLocalized( 10, 302, 150, 25, 1044012, LabelColor, false, false ); // <CENTER>NOTICES</CENTER>

            AddHtml(13, 37, 200, 20, "<h3><basefont color=#FFFFFF>Catégories<basefont></h3>", false, false);
            AddHtml(218, 37, 200, 20, "<h3><basefont color=#FFFFFF>Sélections<basefont></h3>", false, false);
            AddHtml(13, 402, 200, 20, "<h3><basefont color=#FFFFFF>Message<basefont></h3>", false, false);

            AddButton(15, 502, 4017, 4019, 0, GumpButtonType.Reply, 0);
            //AddHtmlLocalized( 50, 405, 150, 18, 1011441, LabelColor, false, false ); // EXIT
            AddHtml(50, 502, 200, 20, "<h3><basefont color=#FFFFFF>Quitter<basefont></h3>", false, false);

            AddButton(650, 482, 4005, 4007, GetButtonID(6, 2), GumpButtonType.Reply, 0);
            //AddHtmlLocalized( 305, 405, 150, 18, 1044013, LabelColor, false, false ); // MAKE LAST
            AddHtml(685, 485, 200, 20, "<h3><basefont color=#FFFFFF>Refaire<basefont></h3>", false, false);

            // Mark option
            if (craftSystem.MarkOption)
            {
                AddButton(650, 462, 4005, 4007, GetButtonID(6, 6), GumpButtonType.Reply, 0);
                //AddHtmlLocalized( 305, 365, 150, 18, 1044017 + (context == null ? 0 : (int)context.MarkOption), LabelColor, false, false ); // MARK ITEM
                if (context.MarkOption == CraftMarkOption.DoNotMark)
                    AddHtml(685, 465, 200, 20, "<h3><basefont color=#FFFFFF>Marquer<basefont></h3>", false, false);
                else
                    AddHtml(685, 465, 200, 20, "<h3><basefont color=#FFFFFF>Ne Pas Marquer<basefont></h3>", false, false);
            }
            // ****************************************

            // Resmelt option
            if (craftSystem.Resmelt)
            {
                AddButton(15, 442, 4005, 4007, GetButtonID(6, 1), GumpButtonType.Reply, 0);
                //AddHtmlLocalized( 50, 345, 150, 18, 1044259, LabelColor, false, false ); // SMELT ITEM
                AddHtml(50, 445, 150, 20, "<h3><basefont color=#FFFFFF>Fondre<basefont></h3>", false, false);
            }
            // ****************************************

            // Repair option
            if (craftSystem.Repair)
            {
                AddButton(650, 442, 4005, 4007, GetButtonID(6, 5), GumpButtonType.Reply, 0);
                //AddHtmlLocalized( 305, 345, 150, 18, 1044260, LabelColor, false, false ); // REPAIR ITEM
                AddHtml(685, 445, 200, 20, "<h3><basefont color=#FFFFFF>Réparer<basefont></h3>", false, false);
            }
            // ****************************************

            // Enhance option
            //if ( craftSystem.CanEnhance )
            //{
            //	AddButton( 270, 402, 4005, 4007, GetButtonID( 6, 8 ), GumpButtonType.Reply, 0 );
            //	AddHtmlLocalized( 305, 405, 150, 18, 1061001, LabelColor, false, false ); // ENHANCE ITEM
            //}
            // ****************************************

            if (notice is int && (int)notice > 0)
                AddHtmlLocalized(170, 395, 350, 40, (int)notice, LabelColor, false, false);
            else if (notice is string)
                //	AddHtml( 170, 295, 350, 40, String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", FontColor, notice ), false, false );
                AddHtml(170, 345, 350, 40, "<h3><basefont color=#FFFFFF>" + notice + "<basefont></h3>", false, false);

            // If the system has more than one resource
            if (craftSystem.CraftSubRes.Init)
            {
                string nameString = craftSystem.CraftSubRes.NameString;
                int nameNumber = craftSystem.CraftSubRes.NameNumber;

                int resIndex = (context == null ? -1 : context.LastResourceIndex);

                Type resourceType = craftSystem.CraftSubRes.ResType;

                if (resIndex > -1)
                {
                    CraftSubRes subResource = craftSystem.CraftSubRes.GetAt(resIndex);

                    nameString = subResource.NameString;
                    nameNumber = subResource.NameNumber;
                    resourceType = subResource.ItemType;
                }

                int resourceCount = 0;

                if (from.Backpack != null)
                {
                    Item[] items = from.Backpack.FindItemsByType(resourceType, true);

                    for (int i = 0; i < items.Length; ++i)
                        resourceCount += items[i].Amount;
                }

                AddButton(15, 442, 4005, 4007, GetButtonID(6, 0), GumpButtonType.Reply, 0);

                if (nameNumber > 0)
                    AddHtmlLocalized(50, 445, 250, 18, nameNumber, resourceCount.ToString(), LabelColor, false, false);
                else
                    //AddLabel( 50, 362, LabelHue, String.Format( "{0} ({1} Available)", nameString, resourceCount ) );
                    AddHtml(50, 442, 450, 40, "<h3><basefont color=#FFFFFF>" + nameString + " " + resourceCount + "<basefont></h3>", false, false);
            }
            // ****************************************

            // If the system has more than one resource type
            if ( craftSystem.CraftSubRes2.Init )
            {
                string nameString = craftSystem.CraftSubRes2.NameString;
                int nameNumber = craftSystem.CraftSubRes2.NameNumber;

                int resIndex = ( context == null ? -1 : context.LastResourceIndex2 );

                Type resourceType = craftSystem.CraftSubRes2.ResType;

                if ( resIndex > -1 )
                {
                    CraftSubRes subResource = craftSystem.CraftSubRes2.GetAt( resIndex );

                    nameString = subResource.NameString;
                    nameNumber = subResource.NameNumber;
                    resourceType = subResource.ItemType;
                }

                int resourceCount = 0;

                if ( from.Backpack != null )
                {
                    Item[] items = from.Backpack.FindItemsByType( resourceType, true );

                    for ( int i = 0; i < items.Length; ++i )
                        resourceCount += items[i].Amount;
                }

                AddButton(15, 462, 4005, 4007, GetButtonID(6, 7), GumpButtonType.Reply, 0);

                if ( nameNumber > 0 )
                    AddHtmlLocalized(50, 465, 250, 18, nameNumber, resourceCount.ToString(), LabelColor, false, false);
                else
                    //AddLabel( 50, 385, LabelHue, String.Format( "{0} ({1} Available)", nameString, resourceCount ) );
                    AddHtml(50, 462, 450, 40, "<h3><basefont color=#FFFFFF>" + nameString + " " + resourceCount + "<basefont></h3>", false, false);
            }
            // ****************************************

            CreateGroupList();

            if (page == CraftPage.PickResource)
                CreateResList(false, from);
            else if (page == CraftPage.PickResource2)
                CreateResList(true, from);
            else if (context != null && context.LastGroupIndex > -1)
                CreateItemList(context.LastGroupIndex);
        }

        public void CreateResList(bool opt, Mobile from)
        {
            CraftSubResCol res = (opt ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes);

            for (int i = 0; i < res.Count; ++i)
            {
                int index = i % maxItemPerPage;

                CraftSubRes subResource = res.GetAt(i);

                if (index == 0)
                {
                    if (i > 0)
                        AddButton(485, 360, 4005, 4007, 0, GumpButtonType.Page, (i / maxItemPerPage) + 1);

                    AddPage((i / maxItemPerPage) + 1);

                    if (i > 0)
                        AddButton(455, 360, 4014, 4015, 0, GumpButtonType.Page, (i / maxItemPerPage));

                    CraftContext context = m_CraftSystem.GetContext(m_From);

                    //AddButton( 220, 260, 4005, 4007, GetButtonID( 6, 4 ), GumpButtonType.Reply, 0 );
                    //AddHtmlLocalized( 255, 263, 200, 18, (context == null || !context.DoNotColor) ? 1061591 : 1061590, LabelColor, false, false );
                }

                int resourceCount = 0;

                if (from.Backpack != null)
                {
                    Item[] items = from.Backpack.FindItemsByType(subResource.ItemType, true);

                    for (int j = 0; j < items.Length; ++j)
                        resourceCount += items[j].Amount;
                }

                AddButton(220, 60 + (index * 20), 4005, 4007, GetButtonID(5, i), GumpButtonType.Reply, 0);

                if (subResource.NameNumber > 0)
                    AddHtmlLocalized(255, 63 + (index * 20), 250, 18, subResource.NameNumber, resourceCount.ToString(), LabelColor, false, false);
                else
                    //AddLabel( 255, 60 + ( index * 20 ), LabelHue, String.Format( "{0} ({1})", subResource.NameString, resourceCount ) );
                    AddHtml(255, 60 + (index * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + subResource.NameString + " [" + resourceCount + "]" + "<basefont></h3>", false, false);
            }
        }

        public void CreateMakeLastList()
        {
            CraftContext context = m_CraftSystem.GetContext(m_From);

            if (context == null)
                return;

            List<CraftItem> items = context.Items;

            if (items.Count > 0)
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    int index = i % maxItemPerPage;

                    CraftItem craftItem = items[i];

                    if (index == 0)
                    {
                        if (i > 0)
                        {
                            AddButton(370, 360, 4005, 4007, 0, GumpButtonType.Page, (i / maxItemPerPage) + 1);
                            //AddHtmlLocalized( 405, 263, 100, 18, 1044045, LabelColor, false, false ); // NEXT PAGE
                            AddHtml(405, 263, 200, 20, "<h3><basefont color=#FFFFFF>Page Suivante<basefont></h3>", false, false);
                        }

                        AddPage((i / maxItemPerPage) + 1);

                        if (i > 0)
                        {
                            AddButton(220, 360, 4014, 4015, 0, GumpButtonType.Page, (i / maxItemPerPage));
                            //AddHtmlLocalized( 255, 263, 100, 18, 1044044, LabelColor, false, false ); // PREV PAGE
                            AddHtml(255, 363, 200, 20, "<h3><basefont color=#FFFFFF>Page Précédante<basefont></h3>", false, false);
                        }
                    }

                    AddButton(220, 60 + (index * 20), 4005, 4007, GetButtonID(3, i), GumpButtonType.Reply, 0);

                    if (craftItem.NameNumber > 0)
                        AddHtmlLocalized(255, 63 + (index * 20), 220, 18, craftItem.NameNumber, LabelColor, false, false);
                    else
                        //AddLabel( 255, 60 + (index * 20), LabelHue, craftItem.NameString );
                        AddHtml(255, 60 + (index * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + craftItem.NameString + "<basefont></h3>", false, false);

                    AddButton(480, 60 + (index * 20), 4011, 4012, GetButtonID(4, i), GumpButtonType.Reply, 0);
                }
            }
            else
            {
                // NOTE: This is not as OSI; it is an intentional difference

                AddHtml(230, 62, 400, 20, "<h3><basefont color=#FFFFFF>Vous n'avez encore rien fait.<basefont></h3>", false, false);

                //AddHtmlLocalized( 230, 62, 200, 22, 1044165, LabelColor, false, false ); // You haven't made anything yet.
            }
        }

        public void CreateItemList(int selectedGroup)
        {
            int numberOfPage = 0;

            if (selectedGroup == 501) // 501 : Last 10
            {
                CreateMakeLastList();
                return;
            }

            CraftGroupCol craftGroupCol = m_CraftSystem.CraftGroups;
            CraftGroup craftGroup = craftGroupCol.GetAt(selectedGroup);
            CraftItemCol craftItemCol = craftGroup.CraftItems;

            for (int i = 0; i < craftItemCol.Count; ++i)
            {
                int index = i % maxItemPerPage;

                CraftItem craftItem = craftItemCol.GetAt(i);

                if (index == 0)
                {
                    if (i > 0)
                    {
                        AddButton(780, 360, 4005, 4007, 0, GumpButtonType.Page, (i / maxItemPerPage) + 1);
                        //AddHtmlLocalized( 405, 263, 100, 18, 1044045, LabelColor, false, false ); // NEXT PAGE
                        AddHtml(655, 363, 200, 20, "<h3><basefont color=#FFFFFF>Page Suivante<basefont></h3>", false, false);
                    }

                    AddPage((i / maxItemPerPage) + 1);
                    numberOfPage++;

                    if (i > 0)
                    {
                        AddButton(220, 360, 4014, 4015, 0, GumpButtonType.Page, (i / maxItemPerPage));
                        //AddHtmlLocalized( 255, 263, 100, 18, 1044044, LabelColor, false, false ); // PREV PAGE
                        AddHtml(255, 363, 200, 20, "<h3><basefont color=#FFFFFF>Page Précédante<basefont></h3>", false, false);
                    }
                }

                if (i < (maxItemPerPage / 2 + ((numberOfPage - 1) * maxItemPerPage)))
                {
                    AddButton(220, 60 + (index * 20), 4005, 4007, GetButtonID(1, i), GumpButtonType.Reply, 0);

                    if (craftItem.NameNumber > 0)
                        AddHtmlLocalized(255, 63 + (index * 20), 220, 18, craftItem.NameNumber, LabelColor, false, false);
                    else
                        //AddLabel( 255, 60 + (index * 20), LabelHue, craftItem.NameString );
                        AddHtml(255, 60 + (index * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + (i + 1) + ". " + craftItem.NameString + "<basefont></h3>", false, false);

                    AddButton(480, 60 + (index * 20), 4011, 4012, GetButtonID(2, i), GumpButtonType.Reply, 0);
                }
                else
                {
                    AddButton(520, 60 + ((index - maxItemPerPage / 2) * 20), 4005, 4007, GetButtonID(1, i), GumpButtonType.Reply, 0);

                    if (craftItem.NameNumber > 0)
                        AddHtmlLocalized(555, 63 + ((index - maxItemPerPage / 2) * 20), 220, 18, craftItem.NameNumber, LabelColor, false, false);
                    else
                        //AddLabel( 255, 60 + (index * 20), LabelHue, craftItem.NameString );
                        AddHtml(555, 60 + ((index - maxItemPerPage / 2) * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + (i + 1) + ". " + craftItem.NameString + "<basefont></h3>", false, false);

                    AddButton(780, 60 + ((index - maxItemPerPage / 2) * 20), 4011, 4012, GetButtonID(2, i), GumpButtonType.Reply, 0);
                }
            }
        }

        public int CreateGroupList()
        {
            CraftGroupCol craftGroupCol = m_CraftSystem.CraftGroups;

            AddButton(15, 60, 4005, 4007, GetButtonID(6, 3), GumpButtonType.Reply, 0);
            //AddHtmlLocalized( 50, 63, 150, 18, 1044014, LabelColor, false, false ); // LAST TEN
            AddHtml(50, 63, 300, 20, "<h3><basefont color=#FFFFFF>Dernier Objets<basefont></h3>", false, false);

            for (int i = 0; i < craftGroupCol.Count; i++)
            {
                CraftGroup craftGroup = craftGroupCol.GetAt(i);

                AddButton(15, 80 + (i * 20), 4005, 4007, GetButtonID(0, i), GumpButtonType.Reply, 0);

                if (craftGroup.NameNumber > 0)
                    AddHtmlLocalized(50, 83 + (i * 20), 150, 18, craftGroup.NameNumber, LabelColor, false, false);
                else
                    //AddLabel( 50, 80 + (i * 20), LabelHue, craftGroup.NameString );
                    AddHtml(50, 80 + (i * 20), 200, 20, "<h3><basefont color=#FFFFFF>" + craftGroup.NameString + "<basefont></h3>", false, false);
            }

            return craftGroupCol.Count;
        }

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * 7);
        }

        public void CraftItem(CraftItem item)
        {
            int num = m_CraftSystem.CanCraft(m_From, m_Tool, item.ItemType);

            if (num > 0)
            {
                m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, num));
            }
            else
            {
                Type type = null;

                CraftContext context = m_CraftSystem.GetContext(m_From);

                if (context != null)
                {
                    CraftSubResCol res = (item.UseSubRes2 ? m_CraftSystem.CraftSubRes2 : m_CraftSystem.CraftSubRes);
                    int resIndex = (item.UseSubRes2 ? context.LastResourceIndex2 : context.LastResourceIndex);

                    if (resIndex >= 0 && resIndex < res.Count)
                        type = res.GetAt(resIndex).ItemType;
                }

                m_CraftSystem.CreateItem(m_From, item.ItemType, type, m_Tool, item);
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID <= 0)
                return; // Canceled

            int buttonID = info.ButtonID - 1;
            int type = buttonID % 7;
            int index = buttonID / 7;

            CraftSystem system = m_CraftSystem;
            CraftGroupCol groups = system.CraftGroups;
            CraftContext context = system.GetContext(m_From);

            switch (type)
            {
                case 0: // Show group
                    {
                        if (context == null)
                            break;

                        if (index >= 0 && index < groups.Count)
                        {
                            context.LastGroupIndex = index;
                            m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));
                        }

                        break;
                    }
                case 1: // Create item
                    {
                        if (context == null)
                            break;

                        int groupIndex = context.LastGroupIndex;

                        if (groupIndex >= 0 && groupIndex < groups.Count)
                        {
                            CraftGroup group = groups.GetAt(groupIndex);

                            if (index >= 0 && index < group.CraftItems.Count)
                                CraftItem(group.CraftItems.GetAt(index));
                        }

                        break;
                    }
                case 2: // Item details
                    {
                        if (context == null)
                            break;

                        int groupIndex = context.LastGroupIndex;

                        if (groupIndex >= 0 && groupIndex < groups.Count)
                        {
                            CraftGroup group = groups.GetAt(groupIndex);

                            if (index >= 0 && index < group.CraftItems.Count)
                                m_From.SendGump(new CraftGumpItem(m_From, system, group.CraftItems.GetAt(index), m_Tool));
                        }

                        break;
                    }
                case 3: // Create item (last 10)
                    {
                        if (context == null)
                            break;

                        List<CraftItem> lastTen = context.Items;

                        if (index >= 0 && index < lastTen.Count)
                            CraftItem(lastTen[index]);

                        break;
                    }
                case 4: // Item details (last 10)
                    {
                        if (context == null)
                            break;

                        List<CraftItem> lastTen = context.Items;

                        if (index >= 0 && index < lastTen.Count)
                            m_From.SendGump(new CraftGumpItem(m_From, system, lastTen[index], m_Tool));

                        break;
                    }
                case 5: // Resource selected
                    {
                        if (m_Page == CraftPage.PickResource && index >= 0 && index < system.CraftSubRes.Count)
                        {
                            int groupIndex = (context == null ? -1 : context.LastGroupIndex);

                            CraftSubRes res = system.CraftSubRes.GetAt(index);

                            if (m_From.Skills[system.MainSkill].Base < res.RequiredSkill)
                            {
                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, res.Message));
                            }
                            else
                            {
                                if (context != null)
                                    context.LastResourceIndex = index;

                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));
                            }
                        }
                        else if (m_Page == CraftPage.PickResource2 && index >= 0 && index < system.CraftSubRes2.Count)
                        {
                            int groupIndex = (context == null ? -1 : context.LastGroupIndex);

                            CraftSubRes res = system.CraftSubRes2.GetAt(index);

                            if (m_From.Skills[system.MainSkill].Base < res.RequiredSkill)
                            {
                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, res.Message));
                            }
                            else
                            {
                                if (context != null)
                                    context.LastResourceIndex2 = index;

                                m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));
                            }
                        }

                        break;
                    }
                case 6: // Misc. buttons
                    {
                        switch (index)
                        {
                            case 0: // Resource selection
                                {
                                    if (system.CraftSubRes.Init)
                                        m_From.SendGump(new CraftGump(m_From, system, m_Tool, null, CraftPage.PickResource));

                                    break;
                                }
                            case 1: // Smelt item
                                {
                                    if (system.Resmelt)
                                        Resmelt.Do(m_From, system, m_Tool);

                                    break;
                                }
                            case 2: // Make last
                                {
                                    if (context == null)
                                        break;

                                    CraftItem item = context.LastMade;

                                    if (item != null)
                                        CraftItem(item);
                                    else
                                        m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, 1044165, m_Page)); // You haven't made anything yet.

                                    break;
                                }
                            case 3: // Last 10
                                {
                                    if (context == null)
                                        break;

                                    context.LastGroupIndex = 501;
                                    m_From.SendGump(new CraftGump(m_From, system, m_Tool, null));

                                    break;
                                }
                            case 4: // Toggle use resource hue
                                {
                                    if (context == null)
                                        break;

                                    context.DoNotColor = !context.DoNotColor;

                                    m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, null, m_Page));

                                    break;
                                }
                            case 5: // Repair item
                                {
                                    if (system.Repair)
                                        Repair.Do(m_From, system, m_Tool);

                                    break;
                                }
                            case 6: // Toggle mark option
                                {
                                    if (context == null || !system.MarkOption)
                                        break;

                                    switch (context.MarkOption)
                                    {
                                        case CraftMarkOption.MarkItem: context.MarkOption = CraftMarkOption.DoNotMark; break;
                                        case CraftMarkOption.DoNotMark: context.MarkOption = CraftMarkOption.PromptForMark; break;
                                        case CraftMarkOption.PromptForMark: context.MarkOption = CraftMarkOption.MarkItem; break;
                                    }

                                    m_From.SendGump(new CraftGump(m_From, m_CraftSystem, m_Tool, null, m_Page));

                                    break;
                                }
                            case 7: // Resource selection 2
                                {
                                    if (system.CraftSubRes2.Init)
                                        m_From.SendGump(new CraftGump(m_From, system, m_Tool, null, CraftPage.PickResource2));

                                    break;
                                }
                            case 8: // Enhance item
                                {
                                    if (system.CanEnhance)
                                        Enhance.BeginTarget(m_From, system, m_Tool);

                                    break;
                                }
                        }

                        break;
                    }
            }
        }
    }
}