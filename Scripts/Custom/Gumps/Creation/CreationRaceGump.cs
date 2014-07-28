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
    public class CreationRaceGump : GumpTemrael
    {
        private TMobile m_from;
        private Races m_Races;

        public CreationRaceGump(TMobile from)
            : this(from, from.Creation.race)
        {
        }

        public CreationRaceGump(TMobile from, Races Races)
            : base("Race", 560, 622)
        {
            m_from = from;
            m_Races = Races;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 70;

            AddCreationMenuItem(x, y, 1193, 2, false);
            x += space;
            AddCreationMenuItem(x, y, 1190, 3, true);
            x += space;
            AddCreationMenuItem(x, y, 1188, 4, true);
            x += space;
            AddCreationMenuItem(x, y, 1224, 6, true);
            x += space;
            AddCreationMenuItem(x, y, 1182, 7, true);

            x = XBase;
            y = YBase;

            AddTitre(x + 360, y + line * scale, 190, "Races");
            ++line;
            for (int i = 0; i < (int)Races.Maximum; i++)
            {
                if ((Races)(i) != Races.MortVivant)
                {
                    AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                    AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, ((Races)i).ToString());
                    ++line;
                }
            }


            if (Races != Races.Aucun)
            {
                BaseRace race = RaceManager.getRace(Races);

                int linetmp = line;

                line = 0;
                AddButton(x, y + line * scale, 8, race.Image);
                AddTooltip(race.Tooltip);

                line = linetmp;
                AddSection(x + 260, y + line * scale, 275, 170, race.Name, race.Description);
                line += 10;
                AddButton(470, 645, 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(520, 645 + 12, 200, 20, "<h3><basefont color=#025a>Confirmer<basefont></h3>", false, false);

                line = 12;

                string bonus = race.BonusDescr;

                AddSection(x, y + line * scale, 250, 160, "Bonus Raciaux", bonus);
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
                    DeleteItemsOnChar(from);
                    from.Creation.race = m_Races;
                    switch (from.Creation.race)
                    {
                        case Races.Capiceen:
                            from.Creation.hue = 1023;
                            break;
                        case Races.Orcish:
                            from.Creation.hue = 1446;
                            break;
                        case Races.Elfe:
                            from.Creation.hue = 1023;
                            break;
                        case Races.Nordique:
                            from.Creation.hue = 1023;
                            break;
                        case Races.ElfeNoir:
                            from.Creation.hue = 2410;
                            break;
                        case Races.Nain:
                            from.Creation.hue = 1054;
                            break;
                        case Races.Nomade:
                            from.Creation.hue = 1044;
                            break;
                        case Races.Tieffelin:
                            from.Creation.hue = 0;
                            break;
                        case Races.Aasimar:
                            from.Creation.hue = 0;
                            break;
                        case Races.Aucun:
                            break;
                    }
                    from.SendGump(new CreationClasseGump(from));
                    break;
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new CreationRaceGump(from, (Races)(info.ButtonID - 50)));
            }
        }
        public void DeleteItemsOnChar(TMobile from)
        {
            if (from.Backpack != null)
            {
                while (from.Backpack.Items.Count > 0)
                    ((Item)from.Backpack.Items[0]).Delete();
            }

            Item item;

            item = from.FindItemOnLayer(Layer.Arms);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Bracelet);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Cloak);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Earrings);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Gloves);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Helm);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.InnerLegs);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.InnerTorso);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.MiddleTorso);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Neck);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.OuterLegs);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.OuterTorso);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Pants);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Ring);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Shirt);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Shoes);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.Waist);
            if (item != null)
                item.Delete();
        }
    }
}
