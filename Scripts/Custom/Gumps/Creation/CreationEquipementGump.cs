using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class CreationEquipementGump : GumpTemrael
    {
        private static List<PaperPreviewItem> m_gumpList = new List<PaperPreviewItem>();

        public CreationEquipementGump(TMobile from)
            : base("Équipement", 560, 622)
        {
            int x = XBase;
            int y = YBase;
            int line = 2;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 80;

            x += space;
            AddMenuItem(x, y, 1193, 2, true);
            x += space;
            AddMenuItem(x, y, 1190, 3, true);
            x += space;
            x += space;
            AddMenuItem(x, y, 1188, 4, false);
            x += space;
            AddMenuItem(x, y, 1224, 6, true);
            x += space;
            AddMenuItem(x, y, 1182, 7, true);

            x = XBase;
            y = YBase;

            AddBackground(100, 150, 180, 200, 2620);

            if (from is TMobile)
            {
                switch (from.Creation.race)
                {
                    case Races.Capiceen:
                        if (from.Creation.hue == 0)
                            from.Creation.hue = 1023;

                        if (from.Female)
                            AddImage(95, 110, 13, from.Creation.hue);
                        else
                            AddImage(95, 110, 12, from.Creation.hue);
                        AddButton(x + 55, y - 1, 449, 449, 9, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 29, y - 1, 450, 450, 10, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 48, y - 1, 451, 451, 11, GumpButtonType.Reply, 0);
                        break;
                    case Races.Orcish:
                        if (from.Creation.hue == 0)
                            from.Creation.hue = 1446;

                        if (from.Female)
                            AddImage(95, 110, 60908, from.Creation.hue);
                        else
                            AddImage(95, 110, 50908, from.Creation.hue);
                        AddButton(x + 55, y - 1, 458, 458, 12, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 29, y - 1, 459, 459, 13, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 48, y - 1, 460, 460, 14, GumpButtonType.Reply, 0);
                        break;
                    case Races.Elfe:
                        if (from.Creation.hue == 0)
                            from.Creation.hue = 1023;

                        if (from.Female)
                            AddImage(95, 110, 61027, from.Creation.hue);
                        else
                            AddImage(95, 110, 51027, from.Creation.hue);
                        AddButton(x + 55, y - 1, 449, 449, 15, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 29, y - 1, 450, 450, 16, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 48, y - 1, 451, 451, 17, GumpButtonType.Reply, 0);
                        break;
                    case Races.Nordique:
                        if (from.Creation.hue == 0)
                            from.Creation.hue = 1023;

                        if (from.Female)
                            AddImage(95, 110, 61106, from.Creation.hue);
                        else
                            AddImage(95, 110, 51106, from.Creation.hue);
                        AddButton(x + 55, y - 1, 449, 449, 9, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 29, y - 1, 450, 450, 10, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 48, y - 1, 451, 451, 11, GumpButtonType.Reply, 0);
                        break;
                    case Races.ElfeNoir:
                        if (from.Creation.hue == 0)
                            from.Creation.hue = 2410;

                        if (from.Female)
                        {
                            AddImage(95, 110, 13, from.Creation.hue);
                            AddImage(95, 110, 61029, from.Creation.hue);
                        }
                        else
                        {
                            AddImage(95, 110, 12, from.Creation.hue);
                            AddImage(95, 110, 51029, from.Creation.hue);
                        }
                        AddButton(x + 55, y - 1, 455, 455, 18, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 29, y - 1, 456, 456, 19, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 48, y - 1, 457, 457, 20, GumpButtonType.Reply, 0);
                        break;
                    case Races.Nain:
                        if (from.Creation.hue == 0)
                            from.Creation.hue = 1054;

                        if (from.Female)
                            AddImage(95, 110, 61033, from.Creation.hue);
                        else
                            AddImage(95, 110, 51033, from.Creation.hue);
                        AddButton(x + 55, y - 1, 461, 461, 21, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 29, y - 1, 462, 462, 22, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 48, y - 1, 463, 463, 23, GumpButtonType.Reply, 0);
                        break;
                    case Races.Nomade:
                        if (from.Creation.hue == 0)
                            from.Creation.hue = 1044;

                        if (from.Female)
                            AddImage(95, 110, 13, from.Creation.hue);
                        else
                            AddImage(95, 110, 12, from.Creation.hue);
                        AddButton(x + 55, y - 1, 452, 452, 24, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 29, y - 1, 453, 453, 25, GumpButtonType.Reply, 0);
                        AddButton(x + 55 + 48, y - 1, 454, 454, 26, GumpButtonType.Reply, 0);
                        break;
                    case Races.Tieffelin:
                        if (from.Female)
                        {
                            AddImage(95, 110, 60681, 0);
                            AddImage(95, 110, 61001, 0);
                            AddImage(95, 110, 61000, 0);
                        }
                        else
                        {
                            AddImage(95, 110, 50681, 0);
                            AddImage(95, 110, 51001, 0);
                            AddImage(95, 110, 51000, 0);
                        }
                        break;
                    case Races.Aasimar:
                        if (from.Female)
                        {
                            AddImage(95, 110, 60997, 0);
                        }
                        else
                        {
                            AddImage(95, 110, 50997, 0);
                        }
                        break;
                    case Races.Aucun:
                        break;
                }
            }

            if (from.Creation.race == Races.Tieffelin || from.Creation.race == Races.Aasimar)
            {
                AddSection(x + 300, y + line * scale, 200, 120, "Race Secrète");
                ++line;
                ++line;

                AddButton(x + 320, y + line * scale, 0x4b9, 0x4bA, 27, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 335, y + line * scale, DefaultHtmlLength, "Capicéen");
                ++line;
                AddButton(x + 320, y + line * scale, 0x4b9, 0x4bA, 28, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 335, y + line * scale, DefaultHtmlLength, "Nomade");
                ++line;
                AddButton(x + 320, y + line * scale, 0x4b9, 0x4bA, 29, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 335, y + line * scale, DefaultHtmlLength, "Nordique");
                ++line;
            }

            /*for (int i = 0; i < m_gumpList.Count; i++)
            {
                AddImage(155, 110, m_gumpList[i].GumpID, m_gumpList[i].Hue);
            }*/

            //AddBackground(140, 0, 585, 393, 5054);
            AddBackground(100, 350, 545, 298, 3500);
            AddBackground(295, 386, 337, 225, 3000);
            AddHtml(123, 365, 565, 18, "<h3><basefont color=#025a>Équipement de Départ<basefont></h3>", false, false); // <center>VENDOR CUSTOMIZATION MENU</center>
            AddHtml(150, 611, 150, 18, "<h3><basefont color=#025a>Ajouter<basefont></h3>", false, false); // OKAY
            AddButton(115, 610, 4005, 4007, 8, GumpButtonType.Reply, 0);
            //AddHtmlLocalized(450, 615, 150, 18, 1011012, false, false); // CANCEL
            //AddButton(415, 615, 4005, 4007, 0, GumpButtonType.Reply, 0);

            y = 385;
            Races race = Races.Aucun;
            if (from.Creation.race == Races.Tieffelin || from.Creation.race == Races.Aasimar)
                race = from.Creation.secrete;
            else
                race = from.Creation.race;
            for (int i = 0; i < Categories.Length; i++)
            {
                CustomCategory cat = (CustomCategory)Categories[i];

                if (((cat.Race == race) || cat.Race == Races.Aucun) && (cat.Archetype == from.Creation.classe || cat.Archetype == ClasseType.None))
                {
                    AddHtml(110, y, 150, 25, "<h3><basefont color=#025a>" + cat.Name + "<basefont></h3>", true, false);
                    AddButton(260, y, 4005, 4007, 0, GumpButtonType.Page, i + 1);
                    y += 25;


                }
            }

            for (int i = 0; i < Categories.Length; i++)
            {
                CustomCategory cat = (CustomCategory)Categories[i];
                AddPage(i + 1);

                if (((cat.Race == race) || cat.Race == Races.Aucun) && (cat.Archetype == from.Creation.classe || cat.Archetype == ClasseType.None))
                {
                    for (int c = 0; c < cat.Entries.Length; c++)
                    {
                        CustomItem entry = (CustomItem)cat.Entries[c];
                        x = 298 + (c % 3) * 129;
                        y = 388 + (c / 3) * 67;

                        AddHtml(x, y, 100, entry.LongText ? 36 : 18, "<h3><basefont color=#5A4A31>" + entry.Name + "<basefont></h3>", false, false);

                        if (entry.ArtNumber != 0)
                            AddItem(x + 20, y + 25, entry.ArtNumber);

                        AddRadio(x, y + (entry.LongText ? 40 : 20), 210, 211, false, (c << 8) + i);
                    }
                }

                /*if (cat.CanDye)
                {
                    AddHtml(385, 585, 100, 18, "<h3><basefont color=#5A4A31>Couleur<basefont></h3>", false, false); // Color
                    AddRadio(437, 585, 210, 211, false, 100 + i);
                }

                AddHtml(510, 585, 100, 18, "<h3><basefont color=#5A4A31>Supprimer<basefont></h3>", false, false); // Remove
                AddRadio(586, 585, 210, 211, false, 200 + i);*/
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 2:
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 3:
                    if (from.Creation.race != Races.Aucun)
                    {
                        from.SendGump(new CreationClasseGump(from));
                    }
                    else
                    {
                        goto case 2;
                    }
                    break;
                case 4:
                    if (from.Creation.classe != ClasseType.None)
                    {
                        from.SendGump(new CreationEquipementGump(from));
                    }
                    else
                    {
                        goto case 3;
                    }
                    break;
                case 6:
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 7:
                    from.SendGump(new CreationOverviewGump(from));
                    break;
                case 8:
                    if (info.Switches.Length > 0)
                    {
                        int cnum = info.Switches[0];
                        int cat = cnum % 256;
                        int ent = cnum >> 8;

                        if (cat < Categories.Length && cat >= 0)
                        {
                            if (ent < Categories[cat].Entries.Length && ent >= 0)
                            {
                                Item item = from.FindItemOnLayer(Categories[cat].Layer);

                                if (item != null)
                                    item.Delete();

                                List<Item> items = from.Items;

                                for (int i = 0; item == null && i < items.Count; ++i)
                                {
                                    Item checkitem = items[i];
                                    Type type = checkitem.GetType();

                                    for (int j = 0; item == null && j < Categories[cat].Entries.Length; ++j)
                                    {
                                        if (type == Categories[cat].Entries[j].Type)
                                            item = checkitem;
                                    }
                                }

                                if (item != null)
                                    item.Delete();

                                if (Categories[cat].Layer == Layer.FacialHair)
                                {
                                    if (from.Female)
                                        from.SendLocalizedMessage(1010639); // You cannot place facial hair on a woman!
                                    else
                                        from.FacialHairItemID = Categories[cat].Entries[ent].ItemID;
                                }
                                else if (Categories[cat].Layer == Layer.Hair)
                                    from.HairItemID = Categories[cat].Entries[ent].ItemID;

                                else
                                {
                                    item = Categories[cat].Entries[ent].Create();

                                    if (item != null)
                                    {
                                        item.Layer = Categories[cat].Layer;

                                        if (!from.EquipItem(item))
                                        {
                                            item.Delete();
                                        }
                                        else
                                        {
                                            if ((from.Female) && (Categories[cat].Entries[ent].FemaleGump))
                                                m_gumpList.Add(new PaperPreviewItem((Categories[cat].Entries[ent].GumpID + 10000), item.Serial));
                                            else
                                                m_gumpList.Add(new PaperPreviewItem(Categories[cat].Entries[ent].GumpID, item.Serial));
                                        }
                                    }
                                }
                                from.SendGump(new CreationEquipementGump(from));
                            }
                        }
                        else
                        {
                            cat -= 100;

                            if (cat < 100)
                            {
                                if (cat < Categories.Length && cat >= 0)
                                {
                                    Item item = null;

                                    List<Item> items = from.Items;

                                    for (int i = 0; item == null && i < items.Count; ++i)
                                    {
                                        Item checkitem = items[i];
                                        Type type = checkitem.GetType();

                                        for (int j = 0; item == null && j < Categories[cat].Entries.Length; ++j)
                                        {
                                            if (type == Categories[cat].Entries[j].Type)
                                                item = checkitem;
                                        }
                                    }

                                    PaperPreviewItem previewItem = null;

                                    for (int i = 0; i < m_gumpList.Count; i++)
                                    {
                                        if (m_gumpList[i].Serial == item.Serial)
                                            previewItem = m_gumpList[i];
                                    }

                                    /*if ((item != null) && (previewItem != null))
                                    {
                                        from.SendGump(new TeintureGump(from, TeintureTabs.Baies, item, previewItem, this));
                                        //new PVHuePicker( item, from ).SendTo( sender );
                                    }
                                    else
                                    {
                                        from.SendGump(new CreationGump(from));
                                    }*/

                                    from.SendGump(new CreationEquipementGump(from));
                                }
                            }
                            else
                            {
                                cat -= 100;

                                if (cat < Categories.Length && cat >= 0)
                                {
                                    Item item = null;

                                    List<Item> items = from.Items;

                                    for (int i = 0; item == null && i < items.Count; ++i)
                                    {
                                        Item checkitem = items[i];
                                        Type type = checkitem.GetType();

                                        for (int j = 0; item == null && j < Categories[cat].Entries.Length; ++j)
                                        {
                                            if (type == Categories[cat].Entries[j].Type)
                                            {
                                                item = checkitem;
                                            }
                                            if (m_gumpList.Contains(new PaperPreviewItem(Categories[cat].Entries[j].GumpID, item.Serial, item.Hue)))
                                            {
                                                m_gumpList.Remove(new PaperPreviewItem(Categories[cat].Entries[j].GumpID, item.Serial, item.Hue));
                                            }
                                        }

                                    }

                                    if (item != null)
                                        item.Delete();

                                    from.SendGump(new CreationEquipementGump(from));
                                }
                            }
                        }
                    }
                    break;
                    case 9:
                        from.Creation.hue = 1023;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 10:
                        from.Creation.hue = 1002;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 11:
                        from.Creation.hue = 1013;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 12:
                        from.Creation.hue = 1446;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 13:
                        from.Creation.hue = 2207;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 14:
                        from.Creation.hue = 1437;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 15:
                        from.Creation.hue = 1023;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 16:
                        from.Creation.hue = 1011;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 17:
                        from.Creation.hue = 1002;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 18:
                        from.Creation.hue = 2410;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 19:
                        from.Creation.hue = 2412;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 20:
                        from.Creation.hue = 1908;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 21:
                        from.Creation.hue = 1054;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 22:
                        from.Creation.hue = 1052;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 23:
                        from.Creation.hue = 1057;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 24:
                        from.Creation.hue = 1044;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 25:
                        from.Creation.hue = 1142;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 26:
                        from.Creation.hue = 1881;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 27:
                        from.Creation.secrete = Races.Capiceen;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 28:
                        from.Creation.secrete = Races.Nomade;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
                    case 29:
                        from.Creation.secrete = Races.Nordique;
                        from.SendGump(new CreationEquipementGump(from));
                        break;
            }
        }

        private class CustomItem
        {
            private Type m_Type;
            private int m_ItemID;
            private string m_Name;
            private int m_ArtNum;
            private bool m_LongText;
            private int m_GumpID;
            private bool m_femaleGump;

            /*public CustomItem(int itemID, string name)
                : this(null, itemID, name, 0, false)
            {
            }

            public CustomItem(int itemID, string name, bool longText)
                : this(null, itemID, name, 0, longText)
            {
            }

            public CustomItem(Type type, string name)
                : this(type, name, 0)
            {
            }*/

            public CustomItem(Type type, string name, int art, int GumpID)
                : this(type, 0, name, art, false, GumpID, false)
            {
            }

            public CustomItem(Type type, int itemID, string name, int art, bool longText, int gumpID)
                : this(type, itemID, name, art, longText, gumpID, false)
            {
                /*m_Type = type;
                m_ItemID = itemID;
                m_Name = name;
                m_ArtNum = art;
                m_LongText = longText;
                m_GumpID = gumpID;*/
            }

            public CustomItem(Type type, int itemID, string name, int art, bool longText, int gumpID, bool femaleGump)
            {
                m_Type = type;
                m_ItemID = itemID;
                m_Name = name;
                m_ArtNum = art;
                m_LongText = longText;
                m_GumpID = gumpID;
                m_femaleGump = femaleGump;
            }

            public Item Create()
            {
                if (m_Type == null)
                    return null;

                Item i = null;

                try
                {
                    ConstructorInfo ctor = m_Type.GetConstructor(new Type[0]);
                    if (ctor != null)
                        i = ctor.Invoke(null) as Item;
                }
                catch
                {
                }

                return i;
            }

            public Type Type { get { return m_Type; } }
            public int ItemID { get { return m_ItemID; } }
            public string Name { get { return m_Name; } }
            public int ArtNumber { get { return m_ArtNum; } }
            public bool LongText { get { return m_LongText; } }
            public int GumpID { get { return m_GumpID; } }
            public bool FemaleGump { get { return m_femaleGump; } }
        }

        private class CustomCategory
        {
            private CustomItem[] m_Entries;
            private Layer m_Layer;
            private bool m_CanDye;
            private string m_Name;
            private Races m_Race;
            private ClasseType m_Archetype;

            public CustomCategory(Layer layer, string name, bool canDye, Races race, ClasseType archetype, CustomItem[] items)
            {
                m_Entries = items;
                m_CanDye = canDye;
                m_Layer = layer;
                m_Name = name;
                m_Race = race;
                m_Archetype = archetype;
            }

            public bool CanDye { get { return m_CanDye; } }
            public CustomItem[] Entries { get { return m_Entries; } }
            public Layer Layer { get { return m_Layer; } }
            public string Name { get { return m_Name; } }
            public Races Race { get { return m_Race; } }
            public ClasseType Archetype { get { return m_Archetype; } }
        }
        public class PaperPreviewItem
        {
            private int m_hue;
            private int m_gumpID;
            private Serial m_serial;

            public PaperPreviewItem(int gumpID, Serial serial, int hue)
            {
                m_hue = hue;
                m_gumpID = gumpID;
                m_serial = serial;
            }

            public PaperPreviewItem(int gumpID, Serial serial)
                : this(gumpID, serial, 0)
            {
            }

            public int Hue { get { return m_hue; } set { m_hue = value; } }
            public int GumpID { get { return m_gumpID; } }
            public int Serial { get { return m_serial; } }
        }

        private static CustomCategory[] Categories = new CustomCategory[]{
             /*
             * 
             * Humain
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Capiceen, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeOrdinaire ), 		"Robe", 0x27D3, 0 ),
                new CustomItem( typeof( RobeDomestique ), 		"Robe Domestique", 0x27A5, 0 ),
                new CustomItem( typeof( RobeACeinture ), 		"Robe à Ceinture", 0x3156, 0 ),
                new CustomItem( typeof( RobeFleurit ), 		    "Robe Fleurit", 0x2799, 0 ),
                new CustomItem( typeof( RobeBourgeoise ), 		"Robe Bourgeoise", 0x27AA, 0 ),
                new CustomItem( typeof( RobeGrande ), 		    "Grande Robe", 0x3158, 0 ),
                new CustomItem( typeof( RobeLarge ), 		    "Large Robe", 0x27A8, 0 ),
                new CustomItem( typeof( FancyDress ), 		    "Robe Décoré", 0x1F00, 0 ),
                new CustomItem( typeof( Robetrainante ), 		"Robe Trainante", 0x27A9, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Capiceen, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Chandail ), 		"Chandail", 0x277E, 0 ),
				new CustomItem( typeof( FancyShirt ),		"Chandail", 0x1EFD, 0 ),
				new CustomItem( typeof( ChandailNoble ), 	"Chandail Noble", 0x2775, 0 ),

				new CustomItem( typeof( ChemiseLongue ),	"Chemise Longue", 0x2753, 0 ),
				new CustomItem( typeof( ChemiseNoble ),	    "Chemise Noble", 0x274A, 0 ),

				new CustomItem( typeof( DoubletBouton ),	"Doublet", 0x2760, 0 ),

                new CustomItem( typeof( TuniquePage ),	    "Tunique Page", 0x2749, 0 ),
                new CustomItem( typeof( TuniqueNoble ),	    "Tunique Noble", 0x2758, 0 ),

                new CustomItem( typeof( TabarLong ),		"Tabar Long", 0x2777, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Capiceen, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		"Toge", 0x1F03, 0 ),
				new CustomItem( typeof( TogeSoutane ),	"Toge Soutane", 0x278F, 0 ),
				new CustomItem( typeof( TogePelerin ), 	"Toge de Pèlerin", 0x2797, 0 ),
				new CustomItem( typeof( TogeDiciple ),	"Toge Monial", 0x2796, 0 ),
                new CustomItem( typeof( ManteauLong ),	"Manteau", 0x2789, 0 ),
				new CustomItem( typeof( Veston ),		"Veston", 0x275F, 0 ),
				new CustomItem( typeof( Veste ),	    "Veste", 0x277A, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Capiceen, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
                new CustomItem( typeof( SouliersBoucles ),	"Souliers Bouclés", 0x2733, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( Bottes ),		    "Bottes Simples", 0x2732, 0 ),
                new CustomItem( typeof( BottesBoucles ),    "Bottes Bouclés", 0x2731, 0 ),
                new CustomItem( typeof( BottesNoble ),      "Bottes Noble", 0x2731, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Capiceen, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		"Cap", 5444, 0 ),
				new CustomItem( typeof( Bandana ), 		"Bandeau", 5440, 0 ),
				new CustomItem( typeof( Bonnet ),	    "Bonnet", 0x1719, 0 ),
				new CustomItem( typeof( TricorneHat ),	"Tricorne", 0x171B, 0 ),
				new CustomItem( typeof( Cap ),			"Cap", 0x1715, 0 ),
				new CustomItem( typeof( ChapeauPlume ),	"Chapeau a Plume", 0x272D, 0 ),
                new CustomItem( typeof( ChapeauCourt ),	"Chapeau Noble", 0x272C, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Capiceen, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( LongPants ),	    "Pantalons Longs", 0x1539, 0 ),
				new CustomItem( typeof( Pantalons ), 	    "Pantalons", 0x273B, 0 ),
				new CustomItem( typeof( PantalonsLongs ),	"Pantalons Larges", 0x273E, 0 ),
                new CustomItem( typeof( PantalonsMoulant ),	"Pantalons Moulants", 0x273F, 0 ),
                new CustomItem( typeof( PantalonsArmure ),	"Pantalons Armurés", 0x273C, 0 ),

                new CustomItem( typeof( Jupe ),	        "Jupe", 0x2741, 0 ),
                new CustomItem( typeof( JupeLongue ),	"Jupe Longue", 0x2743, 0 ),
                new CustomItem( typeof( JupeAmple ),	"Jupe Ample", 0x2744, 0 ),
                new CustomItem( typeof( JupeNoble ),	"Jupe Noble", 0x3176, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Capiceen, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( CapeCourte ),		"Cape Courte", 0x271D, 0 ),
                new CustomItem( typeof( Cloak ),		    "Cape", 5397, 0 ),
                new CustomItem( typeof( CapeDecore ),		"Cape Décoré", 0x2716, 0 ),
                new CustomItem( typeof( CapeTrainee ),		"Cape Trainée", 0x271A, 0 ),
                new CustomItem( typeof( CapeNoble ),		"Cape Noble", 0x2712, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Capiceen, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( BodySash ),		            "Ceinture de Torse", 0x1541, 0 ),
                new CustomItem( typeof( FullApron ),		        "Tablier", 0x153d, 0 ),
                new CustomItem( typeof( CeintureBoucle ),		    "Ceinture", 0x2663, 0 ),
                new CustomItem( typeof( CeintureCuir ),		        "Ceinture", 0x2661, 0 ),
                new CustomItem( typeof( Fourreau ),		            "Fourreau", 0x2667, 0 ),
                new CustomItem( typeof( FourreauSabre ),		    "Fourreau", 0x2672, 0 ),
                new CustomItem( typeof( SacocheHerboriste ),		"Sacoche", 0x2679, 0 ),
                new CustomItem( typeof( Pardessus ),		        "Pardessus", 0x2683, 0 ),
                new CustomItem( typeof( FoulardNoble ),		        "Foulard", 0x268A, 0 )
			} ),

             /*
             * 
             * Nordique
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Nordique, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeSoubrette ), 		"Robe Simple", 0x27CB, 0 ),
                new CustomItem( typeof( RobeBohemienne ), 		"Robe Bohémienne", 0x27BF, 0 ),
                new CustomItem( typeof( RobeServeuse ), 		"Robe Serveuse", 0x27A3, 0 ),
                new CustomItem( typeof( RobeAubergiste ), 		"Robe d'Aubergiste", 0x27C8, 0 ),
                new CustomItem( typeof( RobeCorsetAmple ), 		"Robe à Corset", 0x2BDB, 0 ),
                new CustomItem( typeof( RobeCharmante ), 		"Robe Charmante", 0x27C3, 0 ),
                new CustomItem( typeof( RobeDore ), 		    "Robe Doré", 0x2BDC, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Nordique, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Chandail ), 		    "Chandail", 0x277E, 0 ),
				new CustomItem( typeof( ChandailSoutienGorge ),	"Soutien Gorge", 0x2774, 0 ),
				new CustomItem( typeof( ChandailCombat ), 	    "Chandail de Combat", 0x317F, 0 ),

				new CustomItem( typeof( Chemiselacee ),		"Chemise Lacée", 0x2751, 0 ),

				new CustomItem( typeof( Doublet ),	        "Doublet", 0x1F7B, 0 ),

				new CustomItem( typeof( Tunic ),	        "Tunique", 0x1FA1, 0 ),
                new CustomItem( typeof( TuniquePaysanne ),	"Tunique", 0x274E, 0 ),
                new CustomItem( typeof( TuniqueAmple ),	    "Tunique Ample", 0x275E, 0 ),

                new CustomItem( typeof( TabarCourt ),	    "Tabar", 0x2752, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Nordique, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Toge", 0x1F03, 0 ),
				new CustomItem( typeof( TogeSoutane ),	    "Soutane", 0x278F, 0 ),
				new CustomItem( typeof( TogeVoyage ), 	    "Toge de Voyage", 0x278E, 0 ),
				new CustomItem( typeof( TogeArchiMage ),    "Toge Archi Mage", 0x2B78, 0 ),
				new CustomItem( typeof( ManteauPardessus ),	"Manteau", 0x2786, 0 ),
				new CustomItem( typeof( ManteauTabar ),	    "Manteau d'Arme", 0x2787, 0 ),
				new CustomItem( typeof( VesteCuir ),	    "Veste de Cuir", 0x317B, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Nordique, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),		    "Sandales", 0x170D, 0 ),
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( BottesBoucles ),    "Bottes Bouclés", 0x2731, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 ),
                new CustomItem( typeof( BottesFourrure ),   "Bottes Fourrure", 0x2734, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Nordique, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		"Cap", 5444, 0 ),
				new CustomItem( typeof( Bandana ), 		"Bandeau", 5440, 0 ),
				new CustomItem( typeof( ChapeauLoup ),	"Tete de Loup", 0x2730, 0 ),
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Nordique, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( LongPants ),	        "Pantalons Longs", 0x1539, 0 ),
                new CustomItem( typeof( PantalonsNordique ),    "Pantalons Nordique", 0x273A, 0 ),
                new CustomItem( typeof( PantalonsLongs ),       "Pantalons Amples", 0x273E, 0 ),
                new CustomItem( typeof( PantalonsArmure ),      "Pantalons Armuré", 0x273C, 0 ),

				new CustomItem( typeof( Kilt ), 		"Kilt", 0x1537, 0 ),
                new CustomItem( typeof( TuniqueKilt ), 	"Long Kilt", 0x274F, 0 ),

                new CustomItem( typeof( Skirt ),		"Jupe Simple", 0x1516, 0 ),
				new CustomItem( typeof( Jupe ),		    "Jupe", 0x2741, 0 ),
                new CustomItem( typeof( JupeGrande ),	"Grande Jupe", 0x315C, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Nordique, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),		    "Cape", 5397, 0 ),
                new CustomItem( typeof( CapeVoyage ),		"Cape Voyage", 0x2713, 0 ),
                new CustomItem( typeof( CapeBarbare ),		"Cape Barbare", 0x2717, 0 ),
                new CustomItem( typeof( CapeNordique ),		"Cape Nordique", 0x2722, 0 ),
                new CustomItem( typeof( CapeEpauliere ),	"Cape Epaule", 0x271C, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Nordique, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( CeintureTorseGrande ),		"Ceinture de Torse", 0x264D, 0 ),
                new CustomItem( typeof( TablierBarbare ),		    "Tablier", 0x275B, 0 ),
                new CustomItem( typeof( CeinturePendante ),		    "Ceinture", 0x2660, 0 ),
                new CustomItem( typeof( CeintureNordique ),		    "Ceinture", 0x2662, 0 ),
                new CustomItem( typeof( FourreauDos ),		        "Fourreau", 0x266B, 0 ),
                new CustomItem( typeof( Fourreau ),		            "Fourreau", 0x2667, 0 ),
                new CustomItem( typeof( SacocheAventure ),		    "Sacoche", 0x267B, 0 ),
                new CustomItem( typeof( PardessusBarbare ),		    "Pardessus", 0x2684, 0 ),
                new CustomItem( typeof( FoulardProtecteur ),		"Foulard", 0x268B, 0 )
			} ),

             /*
             * 
             * Nomade
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Nomade, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeBohemienne ), 		"Robe Bohémienne", 0x27BF, 0 ),
                new CustomItem( typeof( RobeGitane ), 		    "Robe Gitane", 0x27C6, 0 ),
                new CustomItem( typeof( RobeFleurit ), 		    "Robe Fleurit", 0x2799, 0 ),
                new CustomItem( typeof( RobeOrient ), 		    "Robe d'Orient", 0x2BE3, 0 ),
                new CustomItem( typeof( RobeOrientale ), 		"Robe Orientale", 0x27C1, 0 ),
                new CustomItem( typeof( RobeBourgeoise ), 		"Robe Bourgeoise", 0x27AA, 0 ),
                new CustomItem( typeof( RobeACorset ), 		    "Robe à Corset", 0x27CE, 0 ),
                new CustomItem( typeof( RobeCourte ), 		    "Robe Courte", 0x27D0, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Nomade, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( SoutienGorge ), 	"Soutien Gorge", 0x312C, 0 ),
				new CustomItem( typeof( Chandail ),		    "Chandail", 0x277E, 0 ),
				new CustomItem( typeof( ChandailMarin ), 	"Chandail de Marin", 0x2759, 0 ),

				new CustomItem( typeof( ChemiseOrient ),    "Chemise d'Orient", 0x316D, 0 ),
				new CustomItem( typeof( ChemiseGaine ),	    "Chemise à Gaine", 0x274B, 0 ),

				new CustomItem( typeof( CorsetPetit ),	    "Corset", 0x2754, 0 ),

                new CustomItem( typeof( Tunic ),	        "Tunique", 0x1FA1, 0 ),
                new CustomItem( typeof( Tunique ),	        "Tunique Simple", 0x2776, 0 ),
                new CustomItem( typeof( TuniquePirate ),	"Tunique Corsaire", 0x2BE1, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Nomade, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Toge", 0x1F03, 0 ),
				new CustomItem( typeof( TogeOrient ),	    "Toge d'Orient", 0x2BE0, 0 ),
				new CustomItem( typeof( TogeNomade ), 	    "Toge de Nomade", 0x3165, 0 ),
				new CustomItem( typeof( TogeVoyage ),	    "Toge de Voyage", 0x278E, 0 ),
				new CustomItem( typeof( ManteauPardessus ),	"Manteau", 0x2786, 0 ),
				new CustomItem( typeof( VesteLourde ),	    "Veste", 0x277B, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Nomade, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),		    "Sandales", 0x170D, 0 ),
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
				new CustomItem( typeof( Geta ),		        "Geta", 0x2682, 0 ),
                new CustomItem( typeof( Bottes ),           "Bottes", 0x2732, 0 ),
                new CustomItem( typeof( BottesBoucles ),    "Bottes Bouclés", 0x2731, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Nomade, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		    "Cap", 0x1544, 0 ),
				new CustomItem( typeof( Turban ), 		    "Turban", 0x26AF, 0 ),
				new CustomItem( typeof( TurbanLong ),	    "Long Turban", 0x26B0, 0 ),
				new CustomItem( typeof( TurbanFeminin ),	"Turban Féminin", 0x2BE4, 0 ),
				new CustomItem( typeof( TurbanProtecteur ),	"Turban Protecteur", 0x3157, 0 ),
				new CustomItem( typeof( TurbanVoile ),	    "Turban Voilé", 0x2BE4, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Nomade, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( LongPants ),	    "Pantalons Longs", 0x1539, 0 ),
                new CustomItem( typeof( PantalonsOrient ),	"Pantalons d'Orient", 0x3179, 0 ),
                new CustomItem( typeof( PantalonsNomade ),	"Pantalons de Nomade", 0x2BDF, 0 ),
                new CustomItem( typeof( PantalonsLongs ),	"Pantalons Amples", 0x273E, 0 ),

				new CustomItem( typeof( Hakama ),		    "Hakama", 0x279A, 0 ),
                new CustomItem( typeof( JupeNomade ),		"Jupe Nomade", 0x3181, 0 ),
                new CustomItem( typeof( JupeOrient ),		"Jupe d'Orient", 0x2BE6, 0 ),
                new CustomItem( typeof( JupeDecore ),		"Jupe Décoré", 0x3174, 0 ),
                new CustomItem( typeof( JupeOuverte ),		"Jupe Ouverte", 0x3173, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Nomade, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),		"Cape", 5397, 0 ),
                new CustomItem( typeof( CapeVoyage ),	"Cape Voyage", 0x2713, 0 ),
                new CustomItem( typeof( CapeCapuche ),	"Cape Capuche", 0x2714, 0 ),
                new CustomItem( typeof( CapeCol ),		"Cape a Col", 0x271F, 0 ),
                new CustomItem( typeof( CapeCagoule ),	"Cape Cagoule", 0x2715, 0 ),
                new CustomItem( typeof( CapeFeminine ),	"Cape Femme", 0x2721, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Nomade, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( BodySash ),		            "Ceinture de Torse", 0x1541, 0 ),
                new CustomItem( typeof( HalfApron ),		        "Tablier", 0x153b, 0 ),
                new CustomItem( typeof( Ceinture ),		            "Ceinture", 0x2666, 0 ),
                new CustomItem( typeof( CeintureBoucle ),		    "Ceinture", 0x2663, 0 ),
                new CustomItem( typeof( Carquois ),		            "Carquois", 0x2668, 0 ),
                new CustomItem( typeof( FourreauDecouvert ),		"Fourreau", 0x266D, 0 ),
                new CustomItem( typeof( SacocheRoublard ),		    "Sacoche", 0x267A, 0 ),
                new CustomItem( typeof( Bracer ),		            "Bracer", 0x2687, 0 ),
                new CustomItem( typeof( FoulardProtecteur ),		"Foulard", 0x268B, 0 )
			} ),

             /*
             * 
             * Nain
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Nain, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobePetite ), 		"Petite Robe", 0x27CC, 0 ),
                new CustomItem( typeof( RobeGamine ), 		"Robe de Gamine", 0x27D4, 0 ),
                new CustomItem( typeof( RobeEnfantine ), 	"Robe Enfantine", 0x27CD, 0 ),
                new CustomItem( typeof( RobeDomestique ), 	"Robe de Domestique", 0x27A5, 0 ),
                new CustomItem( typeof( RobeServante ), 	"Robe de Servante", 0x27A1, 0 ),
                new CustomItem( typeof( RobeElegante ), 	"Robe Élégante", 0x27AD, 0 ),
                new CustomItem( typeof( RobeSeduisante ), 	"Robe Séduisante", 0x27AF, 0 ),
                new CustomItem( typeof( RobeAmple ), 		"Robe Ample", 0x27A7, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Nain, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Shirt ), 	        "Chandail Court", 0x1517, 0 ),
				new CustomItem( typeof( FancyShirt ),		"Chandail", 0x1EFD, 0 ),
				new CustomItem( typeof( ChandailFeminin ), 	"Chandail", 0x2761, 0 ),

				new CustomItem( typeof( Chemiselacee ),		"Chemise Lacée", 0x2751, 0 ),
				new CustomItem( typeof( ChemiseBourgeoise), "Chemise Bourgeoise", 0x2783, 0 ),

				new CustomItem( typeof( CorsetOuvert ),	    "Corset", 0x3172, 0 ),

                new CustomItem( typeof( DoubletAmple ),	    "Doublet", 0x2746, 0 ),

                new CustomItem( typeof( TuniquePaysanne ),	"Tunique", 0x274E, 0 ),
                new CustomItem( typeof( TuniqueBourgeoise ),"Tunique Ample", 0x2779, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Nain, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Toge", 0x1F03, 0 ),
				new CustomItem( typeof( TogeDecore ),	    "Toge Décoré", 0x2791, 0 ),
				new CustomItem( typeof( TogeAmple ), 	    "Toge Ample", 0x278C, 0 ),
				new CustomItem( typeof( TogeArchiMage ),	"Toge Mage", 0x2B78, 0 ),
				new CustomItem( typeof( ManteauCourt ),	    "Manteau", 0x278A, 0 ),
				new CustomItem( typeof( Veston ),	        "Veston", 0x275F, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Nain, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),		    "Sandales", 0x170D, 0 ),
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
                new CustomItem( typeof( SouliersBoucles ),  "Souliers Bouclés", 0x2733, 0 ),
                new CustomItem( typeof( BottesPetites ),    "Petites Bottes", 0x2736, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( Bottes ),           "Bottes Simples", 0x2732, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Nain, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( FloppyHat ),	"Chapeau", 0x1713, 0 ),
				new CustomItem( typeof( WideBrimHat ),	"Chapeau", 0x1714, 0 ),
				new CustomItem( typeof( Cap ),			"Cap", 0x1715, 0 ),
				new CustomItem( typeof( TallStrawHat ),	"Chapeau", 0x1716, 0 ),
                new CustomItem( typeof( FloppyHat ),	"Chapeau", 0x1713, 0 ),
                new CustomItem( typeof( StrawHat ),	    "Chapeau", 0x1717, 0 ),
                new CustomItem( typeof( TallStrawHat ),	"Chapeau", 0x1716, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Nain, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( ShortPants ),	    "Pantalons Courts", 0x152E, 0 ),
                new CustomItem( typeof( Pantalons ),	    "Pantalons Simples", 0x273B, 0 ),
                new CustomItem( typeof( PantalonsCourts ),	"Pantalons Amples", 0x273D, 0 ),
                new CustomItem( typeof( PantalonsArmure ),	"Pantalons Armuré", 0x273C, 0 ),
				
				new CustomItem( typeof( Jupette ),		"Jupette", 0x2740, 0 ),
                new CustomItem( typeof( JupeCourte ),   "Jupe Courte", 0x3168, 0 ),
                new CustomItem( typeof( JupeLongue ),   "Jupe Longue", 0x2743, 0 ),
                new CustomItem( typeof( JupeAmple ),    "Jupe Ample", 0x2744, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Nain, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( CapeCourte ),	"Cape Courte", 0x271D, 0 ),
                new CustomItem( typeof( Cloak ),		"Cape", 5397, 0 ),
                new CustomItem( typeof( CapeVoyage ),	"Cape Voyage", 0x2713, 0 ),
                new CustomItem( typeof( CapeSolide ),	"Cape Attaché", 0x271B, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Nain, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cocarde ),		            "Ceinture de Torse", 0x267C, 0 ),
                new CustomItem( typeof( FullApron ),		        "Tablier", 0x153d, 0 ),
                new CustomItem( typeof( Bourse ),		            "Bourse", 0x2665, 0 ),
                new CustomItem( typeof( CeintureBourse ),		    "Ceinture", 0x2664, 0 ),
                new CustomItem( typeof( Fourreau ),		            "Fourreau", 0x2667, 0 ),
                new CustomItem( typeof( FourreauDague ),		    "Fourreau", 0x266C, 0 ),
                new CustomItem( typeof( SacocheHerboriste ),		"Sacoche", 0x2679, 0 ),
                new CustomItem( typeof( Pardessus ),		        "Pardessus", 0x2683, 0 ),
                new CustomItem( typeof( Foulard ),		            "Foulard", 0x2689, 0 )
			} ),

             /*
             * 
             * Elfe
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Elfe, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeDemoiselle ), 		"Robe de Demoiselle", 0x2798, 0 ),
                new CustomItem( typeof( RobeAttrayante ), 		"Robe Attrayante", 0x27CF, 0 ),
                new CustomItem( typeof( RobeNymph ), 		    "Robe de Nymph", 0x2BDE, 0 ),
                new CustomItem( typeof( RobeElfique ), 		    "Robe Elfique", 0x27C4, 0 ),
                new CustomItem( typeof( RobeAmpleElfique ), 	"Robe Ample", 0x279C, 0 ),
                new CustomItem( typeof( RobeElfe ), 		    "Robe d'Elfe", 0x279B, 0 ),
                new CustomItem( typeof( RobeDentelle ), 		"Robe de Dentelle", 0x27A6, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Elfe, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Chandail ), 	    "Chandail", 0x277E, 0 ),
				new CustomItem( typeof( FancyShirt ),		"Chandail", 0x1EFD, 0 ),

				new CustomItem( typeof( ChemiseElfique ),   "Chemise Elfique", 0x275D, 0 ),
				new CustomItem( typeof( ChemiseAmple ),     "Chemise Ample", 0x2745, 0 ),

                new CustomItem( typeof( Doublet ),	        "Doublet", 0x1F7B, 0 ),
                new CustomItem( typeof( DoubletAmple ),	    "Doublet Ample", 0x2746, 0 ),

                new CustomItem( typeof( Tunic ),	        "Tunique", 0x1FA1, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Elfe, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Toge", 0x1F03, 0 ),
				new CustomItem( typeof( TogeElfique ),		"Toge Elfe", 0x2895, 0 ),
				new CustomItem( typeof( TogeHautElfe ), 	"Toge Haut Elfe", 0x2BD9, 0 ),
				new CustomItem( typeof( TogeArchiMage ),	"Toge Mage", 0x2B78, 0 ),
				new CustomItem( typeof( ManteauRaye ),		"Manteau", 0x2785, 0 ),
				new CustomItem( typeof( Veston ),	        "Veston", 0x275F, 0 ),
				new CustomItem( typeof( Veste ),	        "Veste", 0x277A, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Elfe, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),		    "Sandales", 0x170D, 0 ),
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( Bottes ),		    "Bottes Simples", 0x2732, 0 ),
                new CustomItem( typeof( BottesBoucles ),    "Bottes Bouclés", 0x2731, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Elfe, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		"Cap", 5444, 0 ),
				new CustomItem( typeof( Bandana ), 		"Bandeau", 5440, 0 ),
				new CustomItem( typeof( FeatheredHat ),	"Chapeau a Plume", 0x171A, 0 ),
				new CustomItem( typeof( WideBrimHat ),	"Chapeau", 5908, 0 ),
				new CustomItem( typeof( Cap ),			"Cap", 5909, 0 ),
				new CustomItem( typeof( TallStrawHat ),	"Chapeau", 5910, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Elfe, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( LongPants ),	    "Pantalons Longs", 0x1539, 0 ),
                new CustomItem( typeof( Pantalons ),	    "Pantalons Simples", 0x273B, 0 ),
                new CustomItem( typeof( PantalonsLongs ),	"Pantalons Amples", 0x273E, 0 ),

				new CustomItem( typeof( Hakama ),		"Hakama", 0x279A, 0 ),
                new CustomItem( typeof( JupeLongue ),	"Jupe Longue", 0x2743, 0 ),
                new CustomItem( typeof( JupeAPans ),	"Jupe à Pans", 0x3175, 0 ),
                new CustomItem( typeof( JupeAmple ),	"Jupe Ample", 0x2744, 0 ),
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Elfe, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),		"Cape", 5397, 0 ),
                new CustomItem( typeof( CapeCol ),		"Cape a Col", 0x271F, 0 ),
                new CustomItem( typeof( CapeDecore ),	"Cape Decoré", 0x2716, 0 ),
                new CustomItem( typeof( CapeLongue ),	"Cape Longue", 0x2719, 0 ),
                new CustomItem( typeof( Voile ),		"Voile", 0x2681, 0 ),
                new CustomItem( typeof( CapeFeminine ),	"Cape Feminine", 0x2721, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Elfe, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( BodySash ),		            "Ceinture de Torse", 0x1541, 0 ),
                new CustomItem( typeof( FullApron ),		        "Tablier", 0x153d, 0 ),
                new CustomItem( typeof( CeinturePendante ),		    "Ceinture", 0x2660, 0 ),
                new CustomItem( typeof( CeintureLongue ),		    "Ceinture", 0x264A, 0 ),
                new CustomItem( typeof( Carquois ),		            "Carquois", 0x2668, 0 ),
                new CustomItem( typeof( FourreauEpee ),		        "Fourreau", 0x2671, 0 ),
                new CustomItem( typeof( SacocheCeinture ),		    "Sacoche", 0x2678, 0 ),
                new CustomItem( typeof( Plume ),		            "Plume", 0x268C, 0 ),
                new CustomItem( typeof( FoulardNoble ),		        "Foulard", 0x268A, 0 )
			} ),

             /*
             * 
             * Elfe Noir
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeElfeNoir ), 		    "Robe Antique", 0x2BE7, 0 ),
                new CustomItem( typeof( RobeSoubrette ), 		"Robe", 0x27CB, 0 ),
                new CustomItem( typeof( RobeBohemienne ), 		"Robe Bohémienne", 0x27BF, 0 ),
                new CustomItem( typeof( RobeACeinture ), 		"Robe à Ceinture", 0x3156, 0 ),
                new CustomItem( typeof( RobeSobre ), 		    "Robe Sobre", 0x27AB, 0 ),
                new CustomItem( typeof( RobeAmusante ), 		"Robe Amusante", 0x27AC, 0 ),
                new CustomItem( typeof( RobeElfeNoir ), 		"Robe d'Alfar", 0x27A0, 0 ),
                new CustomItem( typeof( RobeSombre ), 		    "Robe Sombre", 0x27A4, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Chandail ), 	    "Chandail", 0x277E, 0 ),

				new CustomItem( typeof( ChemiseElfique ),   "Chemise Elfique", 0x275D, 0 ),

				new CustomItem( typeof( Doublet ),          "Doublet", 0x1F7B, 0 ),
                new CustomItem( typeof( DoubletFeminin ),	"Doublet Sombre", 0x2748, 0 ),
                new CustomItem( typeof( DoubletArmure ),	"Doublet Armuré", 0x2756, 0 ),

                new CustomItem( typeof( Tunic ),	        "Tunique", 0x1FA1, 0 ),
                new CustomItem( typeof( TuniquePaysanne ),	"Tunique Simple", 0x274E, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Toge", 0x1F03, 0 ),
				new CustomItem( typeof( TogeVoyage ),	    "Tunique", 0x278E, 0 ),
				new CustomItem( typeof( TogeDrow ), 	    "Tunique de Fol", 0x2896, 0 ),
				new CustomItem( typeof( ManteauPardessus ),	"Cocarde", 0x2786, 0 ),
				new CustomItem( typeof( Veston ),		    "Veston", 0x275F, 0 ),
				new CustomItem( typeof( Veste ),	        "Veste", 0x277A, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),		    "Sandales", 0x170D, 0 ),
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
                new CustomItem( typeof( SouliersBoucles ),	"Souliers Bouclés", 0x2733, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( Bottes ),		    "Bottes Simples", 0x2732, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		"Cap", 5444, 0 ),
				new CustomItem( typeof( Bandana ), 		"Bandeau", 5440, 0 ),
				new CustomItem( typeof( Cap ),			"Cap", 5909, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( PantalonsDechires ),    "Pantalons Déchirés", 0x2738, 0 ),
                new CustomItem( typeof( LongPants ),	        "Pantalons Longs", 0x1539, 0 ),
                new CustomItem( typeof( Pantalons ),	        "Pantalons Simples", 0x273B, 0 ),
                new CustomItem( typeof( PantalonsMoulant ),	    "Pantalons Moulant", 0x273F, 0 ),

				new CustomItem( typeof( Skirt ),		    "Jupe", 0x1516, 0 ),
                new CustomItem( typeof( JupeOuverte ),		"Jupe Ouverte", 0x3173, 0 ),
                new CustomItem( typeof( JupeDecore ),		"Jupe Décoré", 0x3174, 0 ),
                new CustomItem( typeof( JupeLongue ),		"Jupe Longue", 0x2743, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),		"Cape", 5397, 0 ),
                new CustomItem( typeof( CapeVoyage ),	"Cape Voyage", 0x2713, 0 ),
                new CustomItem( typeof( CapeCapuche ),	"Cape Capuche", 0x2714, 0 ),
                new CustomItem( typeof( CapeLongue ),	"Cape Longue", 0x2719, 0 ),
                new CustomItem( typeof( CapeCagoule ),	"Cape Cagoule", 0x2715, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.ElfeNoir, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( BodySash ),		            "Ceinture de Torse", 0x1541, 0 ),
                new CustomItem( typeof( HalfApron ),		        "Tablier", 0x153b, 0 ),
                new CustomItem( typeof( CeintureCuir ),		        "Ceinture", 0x2661, 0 ),
                new CustomItem( typeof( CeintureLongue ),		    "Ceinture", 0x264A, 0 ),
                new CustomItem( typeof( Carquois ),		            "Carquois", 0x2668, 0 ),
                new CustomItem( typeof( FourreauDague ),		    "Fourreau", 0x266C, 0 ),
                new CustomItem( typeof( SacocheRoublard ),		    "Sacoche", 0x267A, 0 ),
                new CustomItem( typeof( Pardessus ),		        "Plume", 0x2683, 0 ),
                new CustomItem( typeof( Cagoule ),		            "Cagoule", 0x26A2, 0 )
			} ),

             /*
             * 
             * Orcish
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Orcish, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeDechire ), 		"Robe Déchiré", 0x27D2, 0 ),
                new CustomItem( typeof( RobeDomestique ), 	"Robe de Domestique", 0x27A5, 0 ),
                new CustomItem( typeof( RobeBohemienne ), 	"Robe Bohémienne", 0x27BF, 0 ),
                new CustomItem( typeof( RobeOrcish ), 		"Robe Orcish", 0x27C2, 0 ),
                new CustomItem( typeof( RobeServante ), 	"Robe de Servante", 0x27A1, 0 ),
                new CustomItem( typeof( RobeSobre ), 		"Robe Sobre", 0x27AB, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Orcish, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Chandail ), 	    "Chandail", 0x277E, 0 ),
				new CustomItem( typeof( ChandailCombat ),   "Chandail de Combat", 0x317F, 0 ),

				new CustomItem( typeof( Corset ),          "Corset", 0x2754, 0 ),

                new CustomItem( typeof( DoubletArmure ),	"Doublet Armuré", 0x2756, 0 ),

                new CustomItem( typeof( Tunic ),	        "Tunique", 0x1FA1, 0 ),
                new CustomItem( typeof( TuniquePaysanne ),	"Tunique Simple", 0x274E, 0 ),
                new CustomItem( typeof( Tunique ),	        "Tunique Ample", 0x2776, 0 ),
                new CustomItem( typeof( TuniqueAmple ),	    "Tunique Longue", 0x275E, 0 ),

                new CustomItem( typeof( Surcoat ),	        "Surcot", 0x1FFD, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Orcish, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Toge", 0x1F03, 0 ),
				new CustomItem( typeof( Toge ),		        "Toge Mage", 0x2792, 0 ),
				new CustomItem( typeof( TogeVoyage ), 	    "Toge de Voyage", 0x278E, 0 ),
				new CustomItem( typeof( ManteauPardessus ),	"Manteau", 0x2786, 0 ),
				new CustomItem( typeof( VestePoil ),		"Veste", 0x317B, 0 ),
				new CustomItem( typeof( VesteLourde ),	    "Veste", 0x277B, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Orcish, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),		    "Sandales", 0x170D, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( Bottes ),		    "Bottes Simples", 0x2732, 0 ),
                new CustomItem( typeof( BottesFourrure ),	"Bottes Fourrure", 0x2734, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Orcish, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		"Cap", 5444, 0 ),
				new CustomItem( typeof( Bandana ), 		"Bandeau", 5440, 0 ),
				new CustomItem( typeof( ChapeauLoup ),	"Tete de Loup", 0x2730, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Orcish, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( PantalonsPauvre ),	"Pantalons Pauvre", 0x2739, 0 ),
                new CustomItem( typeof( PantalonsLongs ),	"Pantalons Long", 0x273E, 0 ),
                new CustomItem( typeof( PantalonsCuir ),	"Pantalons de Cuir", 0x3177, 0 ),
                new CustomItem( typeof( PantalonsArmure ),	"Pantalons Long", 0x273C, 0 ),

				new CustomItem( typeof( Kilt ), 		"Kilt", 0x1537, 0 ),

				new CustomItem( typeof( JupeCourteBarbare ),	"Jupe Barbare", 0x2728, 0 ),
                new CustomItem( typeof( JupeCuir ),	            "Jupe Cuir", 0x312B, 0 ),
                new CustomItem( typeof( JupeOrcish ),	        "Jupe Orcish", 0x315D, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Orcish, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),		"Cape", 5397, 0 ),
                new CustomItem( typeof( CapeVoyage ),	"Cape de Voyage", 0x2713, 0 ),
                new CustomItem( typeof( CapeBarbare ),	"Cape Barbare", 0x2717, 0 ),
                new CustomItem( typeof( CapeEpauliere ),"Cape Epaulière", 0x271C, 0 ),
                new CustomItem( typeof( CapeFourrure ),	"Cape Fourrure", 0x2720, 0 ),
                new CustomItem( typeof( CapePoil ),		"Cape de Poil", 0x3180, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Orcish, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( CeintureTorseGrande ),		"Ceinture de Torse", 0x264D, 0 ),
                new CustomItem( typeof( TablierBarbare ),		    "Tablier", 0x275B, 0 ),
                new CustomItem( typeof( CeinturePauvre ),		    "Ceinture", 0x265F, 0 ),
                new CustomItem( typeof( CeintureCuir ),		        "Ceinture", 0x2661, 0 ),
                new CustomItem( typeof( Fourreau ),		            "Fourreau", 0x2667, 0 ),
                new CustomItem( typeof( FourreauDos ),		        "Fourreau", 0x266B, 0 ),
                new CustomItem( typeof( PardessusBarbare ),		    "Pardessus", 0x2684, 0 ),
                new CustomItem( typeof( EpauliereBarbare ),		    "Epaulière", 0x2685, 0 ),
                new CustomItem( typeof( CagouleCuir ),		        "Cagoule", 0x26AE, 0 )
			} ),

             /*
             * 
             * Tieffelin
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeOrdinaire ), 		"Robe Ordinaire", 0x27D3, 0 ),
                new CustomItem( typeof( RobeDomestique ), 		"Robe de Domestique", 0x27A5, 0 ),
                new CustomItem( typeof( RobeACeinture ), 		"Robe à Ceinture", 0x3156, 0 ),
                new CustomItem( typeof( RobeSobre ), 		    "Robe Sobre", 0x27AB, 0 ),
                new CustomItem( typeof( RobeAraignee ), 		"Robe Araignée", 0x27C5, 0 ),
                new CustomItem( typeof( RobeAraneide ), 		"Robe Aranéide", 0x27AE, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Chandail ), 	    "Chandail", 0x277E, 0 ),

                new CustomItem( typeof( ChemiseReligieuse ),"Chemise Religieuse", 0x275C, 0 ),
                new CustomItem( typeof( Chemiselacee ), 	"Chemise Lacée", 0x2751, 0 ),

                new CustomItem( typeof( CorsetAmple ),	    "Corset Ample", 0x2784, 0 ),

				new CustomItem( typeof( Doublet ),          "Doublet", 0x1F7B, 0 ),
                new CustomItem( typeof( DoubletFeminin ),	"Doublet Sombre", 0x2748, 0 ),

                new CustomItem( typeof( Tunic ),	        "Tunique", 0x1FA1, 0 ),
                new CustomItem( typeof( TuniquePaysanne ),	"Tunique Simple", 0x274E, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Toge", 0x1F03, 0 ),
				new CustomItem( typeof( Toge ),		        "Toge Mage", 0x2792, 0 ),
				new CustomItem( typeof( TogeGoetie ), 	    "Toge Necro", 0x2794, 0 ),
				new CustomItem( typeof( TogeDrow ),		    "Toge ElfeNoir", 0x2896, 0 ),
				new CustomItem( typeof( TogeMystique ),	    "Toge Mystique", 0x278D, 0 ),
				new CustomItem( typeof( TogeArchiMage ),    "Toge Arch", 0x2B78, 0 ),
				new CustomItem( typeof( ManteauPardessus ),	"Manteau", 0x2786, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
                new CustomItem( typeof( SouliersBoucles ),	"Souliers Bouclés", 0x2733, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( BottesBoucles ),	"Bottes Bouclés", 0x2731, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		"Cap", 5444, 0 ),
				new CustomItem( typeof( Bandana ), 		"Bandeau", 5440, 0 ),
				new CustomItem( typeof( FloppyHat ),	"Chapeau", 5907, 0 ),
				new CustomItem( typeof( WideBrimHat ),	"Chapeau", 5908, 0 ),
				new CustomItem( typeof( Cap ),			"Cap", 5909, 0 ),
                new CustomItem( typeof( FeatheredHat ), "Chapeau a Plumes", 0x171A, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( LongPants ),	    "Pantalons Longs", 0x1539, 0 ),
                new CustomItem( typeof( Pantalons ),	    "Pantalons", 0x273B, 0 ),
                new CustomItem( typeof( PantalonsArmure ),	"Pantalons Armuré", 0x273C, 0 ),

				new CustomItem( typeof( Skirt ),		    "Jupe", 0x1516, 0 ),
                new CustomItem( typeof( JupeOuverte ),		"Jupe Ouverte", 0x3173, 0 ),
                new CustomItem( typeof( JupeAmple ),		"Jupe Ample", 0x2744, 0 ),
                new CustomItem( typeof( JupeLongue ),		"Jupe Longue", 0x2743, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),		"Cape", 5397, 0 ),
                new CustomItem( typeof( CapeCapuche ),	"Cape à Capuche", 0x2714, 0 ),
                new CustomItem( typeof( CapeCol ),		"Cape à Col", 0x271F, 0 ),
                new CustomItem( typeof( CapeColLong ),	"Cape à Col Long", 0x2718, 0 ),
                new CustomItem( typeof( CapeEpauliere ),"Cape Épaulière", 0x271C, 0 ),
                new CustomItem( typeof( CapeCagoule ),	"Cape à Cagoule", 0x2715, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Tieffelin, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( BodySash ),		            "Ceinture de Torse", 0x1541, 0 ),
                new CustomItem( typeof( HalfApron ),		        "Tablier", 0x153b, 0 ),
                new CustomItem( typeof( CeintureBoucle ),		    "Ceinture", 0x2663, 0 ),
                new CustomItem( typeof( CeintureLongue ),		    "Ceinture", 0x264A, 0 ),
                new CustomItem( typeof( Fourreau ),		            "Fourreau", 0x2667, 0 ),
                new CustomItem( typeof( FourreauDague ),		    "Fourreau", 0x266C, 0 ),
                new CustomItem( typeof( SacocheRoublard ),		    "Sacoche", 0x267A, 0 ),
                new CustomItem( typeof( Foulard ),		            "Foulard", 0x2689, 0 ),
                new CustomItem( typeof( FoulardProtecteur ),	    "Foulard", 0x268B, 0 )
			} ),

             /*
             * 
             * Aasimar
             * 
             */

			new CustomCategory( Layer.InnerTorso, "Robes", true, Races.Aasimar, ClasseType.None, new CustomItem[]{// Upper Torso
				new CustomItem( typeof( RobeSimple ), 		"Robe Simple", 0x27CA, 0 ),
                new CustomItem( typeof( RobeSansManches ), 	"Robe Sans Manches", 0x279A, 0 ),
                new CustomItem( typeof( RobeAubergiste ), 	"Robe d'Aubergiste", 0x27C8, 0 ),
                new CustomItem( typeof( RobeOrne ), 		"Robe Orné", 0x3164, 0 ),
                new CustomItem( typeof( RobeGrande ), 		"Grande Robe", 0x3158, 0 ),
                new CustomItem( typeof( RobeDore ), 		"Robe Doré", 0x2BDC, 0 )
			} ),

			new CustomCategory( Layer.MiddleTorso, "Tuniques", true, Races.Aasimar, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Chandail ), 	    "Chandail", 0x277E, 0 ),

                new CustomItem( typeof( ChemiseCol ), 	    "Chemise à Col", 0x2747, 0 ),
                new CustomItem( typeof( ChemiseReligieuse ),"Chemise Religieuse", 0x275C, 0 ),

				new CustomItem( typeof( Doublet ),          "Doublet", 0x1F7B, 0 ),
                new CustomItem( typeof( DoubletArmure ),	"Doublet Armuré", 0x2756, 0 ),

                new CustomItem( typeof( Tunic ),	        "Tunique", 0x1FA1, 0 ),
                new CustomItem( typeof( TuniquePaysanne ),	"Tunique Simple", 0x274E, 0 )
			} ),

            new CustomCategory( Layer.OuterTorso, "Manteau & Toges", true, Races.Aasimar, ClasseType.None, new CustomItem[]{//Over chest
				new CustomItem( typeof( Robe ), 		    "Doublet", 0x1F03, 0 ),
				new CustomItem( typeof( TogeArchiMage ),	"Toge Mage", 0x2B78, 0 ),
				new CustomItem( typeof( TogeFeminine ), 	"Toge Pretre", 0x2793, 0 ),
				new CustomItem( typeof( ManteauPardessus ),	"Manteau", 0x2786, 0 ),
				new CustomItem( typeof( ManteauRaye ),		"Manteau", 0x2785, 0 ),
				new CustomItem( typeof( Veston ),	        "Veston", 0x275F, 0 ),
				new CustomItem( typeof( Veste ),	        "Veste", 0x277A, 0 )
			} ),

			new CustomCategory( Layer.Shoes, "Chaussures", true, Races.Aasimar, ClasseType.None, new CustomItem[]{//Footwear
				new CustomItem( typeof( Sandals ),		    "Sandales", 0x170D, 0 ),
				new CustomItem( typeof( Shoes ),		    "Souliers", 0x170F, 0 ),
				new CustomItem( typeof( Boots ),		    "Bottes", 0x170B, 0 ),
                new CustomItem( typeof( Bottes ),		    "Bottes Simples", 0x2732, 0 ),
                new CustomItem( typeof( BottesBoucles ),	"Bottes Bouclés", 0x2731, 0 ),
				new CustomItem( typeof( ThighBoots ),	    "Longues Bottes", 0x1711, 0 )
			} ),

			new CustomCategory( Layer.Helm, "Feutres", true, Races.Aasimar, ClasseType.None, new CustomItem[]{//Hats
				new CustomItem( typeof( SkullCap ),		"Cap", 5444, 0 ),
				new CustomItem( typeof( Bandana ), 		"Bandeau", 5440, 0 ),
				new CustomItem( typeof( Cap ),			"Cap", 5909, 0 )
			} ),

			new CustomCategory( Layer.Pants, "Pantalons & Jupes", true, Races.Aasimar, ClasseType.None, new CustomItem[]{ //Lower Torso
				new CustomItem( typeof( LongPants ),	    "Pantalons Longs", 0x1539, 0 ),
                new CustomItem( typeof( Pantalons ),	    "Pantalons Simples", 0x273B, 0 ),
                new CustomItem( typeof( PantalonsLongs ),	"Pantalons Amples", 0x273E, 0 ),
                new CustomItem( typeof( PantalonsArmure ),	"Pantalons Armuré", 0x273C, 0 ),

				new CustomItem( typeof( Hakama ),		"Hakama", 0x279A, 0 ),
                new CustomItem( typeof( JupeOuverte ),	"Jupe Ouverte", 0x3173, 0 ),
                new CustomItem( typeof( JupeDecore ),	"Jupe Décoré", 0x3174, 0 ),
                new CustomItem( typeof( JupeAPans ),	"Jupe à Pans", 0x3175, 0 )
			} ),

			new CustomCategory( Layer.Cloak, "Capes", true, Races.Aasimar, ClasseType.None, new CustomItem[]{ // Back
				new CustomItem( typeof( Cloak ),		"Cape", 5397, 0 ),
                new CustomItem( typeof( CapeSolide ),	"Cape Solide", 0x271B, 0 ),
                new CustomItem( typeof( CapeEpauliere ),"Cape Épaulière", 0x271C, 0 ),
                new CustomItem( typeof( CapeLongue ),	"Cape Longue", 0x2719, 0 ),
                new CustomItem( typeof( CapeNoble ),	"Cape Noble", 0x2712, 0 ),
                new CustomItem( typeof( Voile ),		"Voile", 0x2681, 0 )
			} ),

            new CustomCategory( Layer.Waist, "Accessoires", true, Races.Aasimar, ClasseType.None, new CustomItem[]{ // Back
			    new CustomItem( typeof( BodySash ),		            "Ceinture de Torse", 0x1541, 0 ),
                new CustomItem( typeof( HalfApron ),		        "Tablier", 0x153b, 0 ),
                new CustomItem( typeof( CeintureBoucle ),		    "Ceinture", 0x2663, 0 ),
                new CustomItem( typeof( CeintureNordique ),		    "Ceinture", 0x2662, 0 ),
                new CustomItem( typeof( Fourreau ),		            "Fourreau", 0x2667, 0 ),
                new CustomItem( typeof( FourreauSabre ),		    "Fourreau", 0x2672, 0 ),
                new CustomItem( typeof( SacocheHerboriste ),		"Sacoche", 0x2679, 0 ),
                new CustomItem( typeof( BandeauAveugle ),		    "Bandeau", 0x2674, 0 ),
                new CustomItem( typeof( FoulardNoble ),	            "Foulard", 0x268A, 0 )
			} ),

            /*
             * 
             * Armes & Outils
             * 
             */

			new CustomCategory( Layer.FirstValid, "Armes", false, Races.Aucun, ClasseType.Guerrier, new CustomItem[]{//Held items
				new CustomItem( typeof( Torch ),		"Torche", 3940, 0 ),
				new CustomItem( typeof( Broadsword ),	"Épée", 3936, 0 ),
                new CustomItem( typeof( Arc ),	        "Arc", 0x2D24, 0 ),
                new CustomItem( typeof( Hachette ),	    "Hachette", 0x2B14, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Armes", false, Races.Aucun, ClasseType.Barbare, new CustomItem[]{//Held items
				new CustomItem( typeof( Torch ),		"Torche", 3940, 0 ),
				new CustomItem( typeof( Broadsword ),	"Épée", 3936, 0 ),
                new CustomItem( typeof( Arc ),	        "Arc", 0x2D24, 0 ),
                new CustomItem( typeof( Hachette ),	    "Hachette", 0x2B14, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Armes", false, Races.Aucun, ClasseType.Archer, new CustomItem[]{//Held items
				new CustomItem( typeof( Torch ),		"Torche", 3940, 0 ),
				new CustomItem( typeof( Broadsword ),	"Épée", 3936, 0 ),
                new CustomItem( typeof( Arc ),	        "Arc", 0x2D24, 0 ),
                new CustomItem( typeof( Hachette ),	    "Hachette", 0x2B14, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Armes", false, Races.Aucun, ClasseType.Cavalier, new CustomItem[]{//Held items
				new CustomItem( typeof( Torch ),		"Torche", 3940, 0 ),
				new CustomItem( typeof( Broadsword ),	"Épée", 3936, 0 ),
                new CustomItem( typeof( Arc ),	        "Arc", 0x2D24, 0 ),
                new CustomItem( typeof( Hachette ),	    "Hachette", 0x2B14, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Armes", false, Races.Aucun, ClasseType.Duelliste, new CustomItem[]{//Held items
				new CustomItem( typeof( Torch ),		"Torche", 3940, 0 ),
				new CustomItem( typeof( Broadsword ),	"Épée", 3936, 0 ),
                new CustomItem( typeof( Arc ),	        "Arc", 0x2D24, 0 ),
                new CustomItem( typeof( Hachette ),	    "Hachette", 0x2B14, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Armes", false, Races.Aucun, ClasseType.Protecteur, new CustomItem[]{//Held items
				new CustomItem( typeof( Torch ),		"Torche", 3940, 0 ),
				new CustomItem( typeof( Broadsword ),	"Épée", 3936, 0 ),
                new CustomItem( typeof( Arc ),	        "Arc", 0x2D24, 0 ),
                new CustomItem( typeof( Hachette ),	    "Hachette", 0x2B14, 0 ),
                new CustomItem( typeof( MetalShield ),	"Bouclier", 0x1B7B, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Instruments", false, Races.Aucun, ClasseType.Espion, new CustomItem[]{//Held items
                new CustomItem( typeof( Lute ),		    "Lute", 0xEB3, 0 ),
                new CustomItem( typeof( Tambourine ),   "Tambourine", 0xE9D, 0 ),
                new CustomItem( typeof( Fleuret ),      "Fleuret", 0x2994, 0 ),
                new CustomItem( typeof( Buckler ),      "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Instruments", false, Races.Aucun, ClasseType.Rodeur, new CustomItem[]{//Held items
                new CustomItem( typeof( Lute ),		    "Lute", 0xEB3, 0 ),
                new CustomItem( typeof( Tambourine ),   "Tambourine", 0xE9D, 0 ),
                new CustomItem( typeof( Fleuret ),      "Fleuret", 0x2994, 0 ),
                new CustomItem( typeof( Buckler ),      "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Instruments", false, Races.Aucun, ClasseType.Assassin, new CustomItem[]{//Held items
                new CustomItem( typeof( Lute ),		    "Lute", 0xEB3, 0 ),
                new CustomItem( typeof( Tambourine ),   "Tambourine", 0xE9D, 0 ),
                new CustomItem( typeof( Fleuret ),      "Fleuret", 0x2994, 0 ),
                new CustomItem( typeof( Buckler ),      "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Instruments", false, Races.Aucun, ClasseType.Voleur, new CustomItem[]{//Held items
                new CustomItem( typeof( Lute ),		    "Lute", 0xEB3, 0 ),
                new CustomItem( typeof( Tambourine ),   "Tambourine", 0xE9D, 0 ),
                new CustomItem( typeof( Fleuret ),      "Fleuret", 0x2994, 0 ),
                new CustomItem( typeof( Buckler ),      "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Instruments", false, Races.Aucun, ClasseType.Barde, new CustomItem[]{//Held items
                new CustomItem( typeof( Lute ),		    "Lute", 0xEB3, 0 ),
                new CustomItem( typeof( Tambourine ),   "Tambourine", 0xE9D, 0 ),
                new CustomItem( typeof( Fleuret ),      "Fleuret", 0x2994, 0 ),
                new CustomItem( typeof( Buckler ),      "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Grimoire", false, Races.Aucun, ClasseType.Magicien, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ), "Grimoire", 3643, 0 ),
                //new CustomItem( typeof( Runebook ),     "Manuscrit", 0x22C5, 0 ),
                new CustomItem( typeof( GnarledStaff ), "Baton", 5113, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Grimoire", false, Races.Aucun, ClasseType.Sorcier, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ), "Grimoire", 3643, 0 ),
                //new CustomItem( typeof( Runebook ),     "Manuscrit", 0x22C5, 0 ),
                new CustomItem( typeof( GnarledStaff ), "Baton", 5113, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Grimoire", false, Races.Aucun, ClasseType.Necromancien, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ), "Grimoire", 3643, 0 ),
                //new CustomItem( typeof( Runebook ),     "Manuscrit", 0x22C5, 0 ),
                new CustomItem( typeof( GnarledStaff ), "Baton", 5113, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Grimoire", false, Races.Aucun, ClasseType.Illusioniste, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ), "Grimoire", 3643, 0 ),
                //new CustomItem( typeof( Runebook ),     "Manuscrit", 0x22C5, 0 ),
                new CustomItem( typeof( GnarledStaff ), "Baton", 5113, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Grimoire", false, Races.Aucun, ClasseType.Conjurateur, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ), "Grimoire", 3643, 0 ),
                //new CustomItem( typeof( Runebook ),     "Manuscrit", 0x22C5, 0 ),
                new CustomItem( typeof( GnarledStaff ), "Baton", 5113, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Équipement", false, Races.Aucun, ClasseType.Pretre, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ),       "Grimoire", 3643, 0 ),
                new CustomItem( typeof( Astoria ),	          "Épée", 0x315E, 0 ),
                new CustomItem( typeof( Buckler ),            "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Équipement", false, Races.Aucun, ClasseType.Paladin, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ),       "Grimoire", 3643, 0 ),
                new CustomItem( typeof( Astoria ),	          "Épée", 0x315E, 0 ),
                new CustomItem( typeof( Buckler ),            "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Équipement", false, Races.Aucun, ClasseType.PaladinDechu, new CustomItem[]{//Held items
				new CustomItem( typeof( NewSpellbook ),       "Grimoire", 3643, 0 ),
                new CustomItem( typeof( Astoria ),	          "Épée", 0x315E, 0 ),
                new CustomItem( typeof( Buckler ),            "Bouclier", 0x1B73, 0 )
			} ),

            new CustomCategory( Layer.FirstValid, "Outils", false, Races.Aucun, ClasseType.Artisan, new CustomItem[]{//Held items
				new CustomItem( typeof( FishingPole ), 	"Canne à Peche", 3520, 0 ),
				new CustomItem( typeof( Pickaxe ),		"Pioche", 3717, 0 ),
				new CustomItem( typeof( Pitchfork ),	"Fourche", 3720, 0 ),
				new CustomItem( typeof( Cleaver ),		"Couteau", 3778, 0 ),
				new CustomItem( typeof( SmithHammer ),	"Marteau", 5091, 0 ),
				new CustomItem( typeof( Saw ),          "Scie", 4148, 0 ),
                new CustomItem( typeof( SewingKit ),    "Kit de Couture", 0xF9D, 0 ),
                new CustomItem( typeof( Shovel ),       "Pelle", 0xF39, 0 ),
                new CustomItem( typeof( MortarPestle ), "Mortar", 0xE9B, 0 )
			} ),
		};

        private class PVHuePicker : HuePicker
        {
            private Item m_Item;
            private TMobile m_Mob;

            public PVHuePicker(Item item, TMobile from)
                : base((item.Layer == Layer.Hair || item.Layer == Layer.FacialHair) ? 0xFAB : item.ItemID)
            {
                m_Item = item;
                m_Mob = from;
            }

            public override void OnResponse(int hue)
            {
                if (m_Item.Deleted)
                    return;

                for (int i = 0; i < m_gumpList.Count; i++)
                {
                    if (m_gumpList[i].Serial == m_Item.Serial)
                        m_gumpList[i].Hue = hue;
                }

                m_Item.Hue = hue;
                //m_Mob.SendGump(new CreationGump(m_Mob));
            }
        }
    }
}
