using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using Server.Engines.Races;

namespace Server.Gumps.Creation
{
    public class CreationRaceGump : BaseCreationGump
    {
        private enum ChoixRace { Aucune = 0, Capiceen = 1, Nordique, Nomade, Alfar, Elfe, Orcish, Nain, Aasimar, Tieffelin }

        private ChoixRace m_Race;

        public CreationRaceGump(PlayerMobile from)
            : this(from, ChoixRace.Aucune)
        {
        }

        private CreationRaceGump(PlayerMobile from, ChoixRace race)
            : base(from, "Race", 560, 622, 1)
        {
            m_Race = race;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            AddTitre(x + 360, y + line * scale, 190, "Races");
            ++line;
            for (int i = 1; i < 8; i++)
            {
                AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, Race.GetRaceInstance(i).Name);
                ++line;
            }

            AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, 58, GumpButtonType.Reply, 0);
            AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, "Aasimar");
            ++line;

            AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, 59, GumpButtonType.Reply, 0);
            AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, "Tieffelin");
            ++line;


            if (race != ChoixRace.Aucune)
            {
                int linetmp = line;

                line = 0;

                if (race == ChoixRace.Aasimar)
                {
                    AddImage(x, y + line * scale, 428);
                    AddTooltip(3006428);
                    line = linetmp;
                    AddSection(x + 260, y + line * scale, 275, 170, "Aasimar",
                        "Vous êtes descendants de ces terres où tout le monde souhaite mettre "
                        + "les pieds, ou l'âme. Là où, lorsque vous posez vos yeux d'argent ou "
                        + "d'or blanc sur les gens qui vous entoure, vous ne percevez qu'un délicat "
                        + "mélange de crainte et d'admiration. Ils vous observent, ils vous jugent et, "
                        + "dans votre dos peut-être, pour les moins futés d'entre eux, ils vous prient. "
                        + "Il y a des livres entiers sur vos ancêtres, ces mêmes livres qui animent la "
                        + "ferveur des prêtres du royaume.");

                    AddHtml(x, 560, 240, 40,
                        "<h3><basefont color=#025a>Choisissez une race secrète et une couleur de peau pour celle-ci:<basefont></h3>", false, false);

                    AddHtml(x + 50, 600, 100, 20, "<h3><basefont color=#025a>Capicéen<basefont></h3>", false, false);
                    Race r = new Capiceen(0);
                    int[] hues = r.HueGumps;
                    AddButton(x + 40, 615, 181, hues[0]);
                    AddButton(x + 40 + 29, 615, 182, hues[1]);
                    AddButton(x + 40 + 48, 615, 183, hues[2]);

                    AddHtml(x + 242, 600, 100, 20, "<h3><basefont color=#025a>Nomade<basefont></h3>", false, false);
                    r = new Nomade(0);
                    hues = r.HueGumps;
                    AddButton(x + 230, 615, 381, hues[0]);
                    AddButton(x + 230 + 29, 615, 382, hues[1]);
                    AddButton(x + 230 + 48, 615, 383, hues[2]);

                    AddHtml(x + 430, 600, 100, 20, "<h3><basefont color=#025a>Nordique<basefont></h3>", false, false);
                    r = new Nordique(0);
                    hues = r.HueGumps;
                    AddButton(x + 421, 615, 281, hues[0]);
                    AddButton(x + 421 + 29, 615, 282, hues[1]);
                    AddButton(x + 421 + 48, 615, 283, hues[2]);

                }
                else if (race == ChoixRace.Tieffelin)
                {
                    AddImage(x, y + line * scale, 447);
                    AddTooltip(3996426);
                    line = linetmp;
                    AddSection(x + 260, y + line * scale, 275, 170, "Tieffelin",
                        "Vous êtes nés là où personne n'a osé mettre les pieds. Là où, "
                        + "lorsque vous levez vos yeux vers le Nord, vous voyez, comme horizon, "
                        + "une large construction militaire d'où vous devinez milles yeux posés "
                        + "sur vous et les vôtres. Ils vous guettent. Ils vous veillent, ils vous "
                        + "craignent de cette crainte qui anime le cœur des Inquisiteurs. Il n'y a "
                        + "qu'une seule légende à propos de ces terres où vous habitez, légende "
                        + "effroyable qui peuple les nuits d'enfants et d'adultes. Cette légende, c'est vous.");

                    AddHtml(x, 560, 240, 40,
                        "<h3><basefont color=#025a>Choisissez une race secrète et une couleur de peau pour celle-ci:<basefont></h3>", false, false);

                    AddHtml(x + 50, 600, 100, 20, "<h3><basefont color=#025a>Capicéen<basefont></h3>", false, false);
                    Race r = new Capiceen(0);
                    int[] hues = r.HueGumps;
                    AddButton(x + 40, 615, 191, hues[0]);
                    AddButton(x + 40 + 29, 615, 192, hues[1]);
                    AddButton(x + 40 + 48, 615, 193, hues[2]);

                    AddHtml(x + 242, 600, 100, 20, "<h3><basefont color=#025a>Nomade<basefont></h3>", false, false);
                    r = new Nomade(0);
                    hues = r.HueGumps;
                    AddButton(x + 230, 615, 391, hues[0]);
                    AddButton(x + 230 + 29, 615, 392, hues[1]);
                    AddButton(x + 230 + 48, 615, 393, hues[2]);

                    AddHtml(x + 430, 600, 100, 20, "<h3><basefont color=#025a>Nordique<basefont></h3>", false, false);
                    r = new Nordique(0);
                    hues = r.HueGumps;
                    AddButton(x + 421, 615, 291, hues[0]);
                    AddButton(x + 421 + 29, 615, 292, hues[1]);
                    AddButton(x + 421 + 48, 615, 293, hues[2]); 
                }
                else
                {
                    Race r = Race.GetRaceInstance((int)race);

                    AddImage(x, y + line * scale, r.Image);
                    AddTooltip(r.Tooltip);
                    line = linetmp;
                    AddSection(x + 260, y + line * scale, 275, 170, r.Name, r.Description);

                    AddHtml(x, 605, 500, 20,
                        "<h3><basefont color=#025a>Confirmez votre choix en sélectionnant une couleur de peau:<basefont></h3>", false, false);

                    int[] hues = r.HueGumps;
                    AddButton(x + 430, 602, (int)race * 100 + 1, hues[0]);
                    AddButton(x + 430 + 29, 602, (int)race * 100 + 2, hues[1]);
                    AddButton(x + 430 + 48, 602, (int)race * 100 + 3, hues[2]);
                }
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

            if (info.ButtonID >= 50 && info.ButtonID < 60)
            {
                from.SendGump(new CreationRaceGump(from, (ChoixRace)(info.ButtonID - 50)));
            }
            else
            {
                int race = info.ButtonID / 100;
                int hueid = info.ButtonID % 10;
                int hue = 0;
                switch (race)
                {
                    case 1: // Capiceen
                        hue = Capiceen.Hues[hueid];
                        if ((info.ButtonID % 100) / 10 == 8)
                            from.Race = new Capiceen(RaceSecrete.Aasimar, hue, 0);
                        else if ((info.ButtonID % 100) / 10 == 9)
                            from.Race = new Capiceen(RaceSecrete.Tieffelin, hue, 0);
                        else
                            from.Race = new Capiceen(hue);
                        break;

                    case 2: 
                        hue = Nordique.Hues[hueid];
                        if ((info.ButtonID % 100) / 10 == 8)
                            from.Race = new Nordique(RaceSecrete.Aasimar, hue, 0);
                        else if ((info.ButtonID % 100) / 10 == 9)
                            from.Race = new Nordique(RaceSecrete.Tieffelin, hue, 0);
                        else
                            from.Race = new Nordique(hue);
                        break;

                    case 3: 
                        hue = Nomade.Hues[hueid];
                        if ((info.ButtonID % 100) / 10 == 8)
                            from.Race = new Nomade(RaceSecrete.Aasimar, hue, 0);
                        else if ((info.ButtonID % 100) / 10 == 9)
                            from.Race = new Nomade(RaceSecrete.Tieffelin, hue, 0);
                        else
                            from.Race = new Nomade(hue);
                        break;

                    case 4:
                        from.Race = new Alfar(Alfar.Hues[hueid]);
                        break;

                    case 5:
                        from.Race = new Elfe(Elfe.Hues[hueid]);
                        break;

                    case 6:
                        from.Race = new Orcish(Orcish.Hues[hueid]);
                        break;

                    case 7:
                        from.Race = new Nain(Nain.Hues[hueid]);
                        break;
                }
            }
        }
        public void DeleteItemsOnChar(PlayerMobile from)
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
            item = from.FindItemOnLayer(Layer.OneHanded);
            if (item != null)
                item.Delete();
            item = from.FindItemOnLayer(Layer.TwoHanded);
            if (item != null)
                item.Delete();
        }
    }
}
