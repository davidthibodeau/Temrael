using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Gumps
{
    public class BotaniqueGump : Gump
    {
        private PlayerMobile m_From;
        private BaseBowl m_Bowl;

        public BotaniqueGump(PlayerMobile from, BaseBowl bowl) : base(0, 0)
        {
            m_From = from;
            m_Bowl = bowl;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //Background
            AddBackground(80, 72, 425, 225, 3600);

            //Lianes
            AddItem(80, 72, 3312);
            AddItem(80, 142, 3312);
            AddItem(80, 192, 3312);
            AddItem(480, 72, 3312);
            AddItem(480, 142, 3312);
            AddItem(480, 192, 3312);

            AddImage(257, 159, 1417);
            AddItem(254, 164, m_Bowl.Plant.ItemID);

            AddHtml(90, 85, 400, 20, "<center><h3><basefont color=#006600>" + BotaniqueSystem.GetPlantName(m_Bowl.Plant.PlantType) + "<basefont></h3></center>", false, false);

            //Coins
            AddImage(80, 75, 210);
            AddImage(80, 275, 210);
            AddImage(485, 75, 210);
            AddImage(485, 275, 210);
            AddHtml(85, 75, 200, 20, "<h3><basefont color=#006600>" + String.Format("{0}", m_Bowl.Plant.Reagent) + "<basefont></h3>", false, false);
            AddHtml(492, 75, 200, 20, "<h3><basefont color=#006600>" + String.Format("{0}", m_Bowl.Plant.Seed) + "<basefont></h3>", false, false);
            //AddItem(65, 225, 3555);
            AddButton(68, 275, 1898, 1898, 1, GumpButtonType.Reply, 0);
            AddButton(473, 273, 1899, 1899, 2, GumpButtonType.Reply, 0);
            //AddItem(273, 223, 5629);

            //Malus
            AddImage(105, 100, 212);
            //AddItem(93, 98, 2572);
            AddButton(93, 98, 1897, 1897, 3, GumpButtonType.Reply, 0);
            AddImage(105, 125, 212);
            AddItem(91, 127, 3973);
            AddHtml(128, 125, 200, 20, "<h3><basefont color=#006600>" + BotaniqueSystem.GetInsects(m_Bowl.Plant.Insects) + "<basefont></h3>", false, false);
            AddImage(105, 150, 212);
            AddItem(92, 152, 3350);
            AddHtml(128, 150, 200, 20, "<h3><basefont color=#006600>" + BotaniqueSystem.GetFungi(m_Bowl.Plant.Champignons) + "<basefont></h3>", false, false);
            AddImage(105, 175, 212);
            AddItem(93, 179, 6884);
            AddHtml(128, 175, 200, 20, "<h3><basefont color=#006600>" + BotaniqueSystem.GetPoison(m_Bowl.Plant.Poison) + "<basefont></h3>", false, false);
            AddImage(105, 200, 212);
            AddItem(89, 204, 5927);
            AddHtml(128, 200, 200, 20, "<h3><basefont color=#006600>" + BotaniqueSystem.GetDisease(m_Bowl.Plant.Disease) + "<basefont></h3>", false, false);

            //Bonus
            AddImage(455, 100, 212);
            //AddItem(238, 101, 4088);
            AddButton(438, 101, 1900, 1900, 4, GumpButtonType.Reply, 0);
            AddHtml(383, 100, 200, 20, "<h3><basefont color=#006600>" + BotaniqueSystem.GetStateOfHydration(m_Bowl.Plant.StateOfHydration) + "<basefont></h3>", false, false);
            AddImage(455, 125, 212);
            AddItem(440, 126, 3900);
            AddHtml(382, 125, 200, 20, "<h3><basefont color=#006600>" + BotaniqueSystem.GetEarthName(m_Bowl.EarthType) + "<basefont></h3>", false, false);
            AddImage(455, 150, 212);
            //AddItem(253, 156, 3922);
            AddButton(453, 156, 1901, 1901, 5, GumpButtonType.Reply, 0);
            AddHtml(383, 150, 200, 20, "<h3><basefont color=#006600>" + m_Bowl.Plant.Seed.ToString() + " Graines<basefont></h3>", false, false);
            AddImage(455, 175, 212);
            //AddItem(242, 176, 3334);
            AddButton(442, 176, 1902, 1902, 6, GumpButtonType.Reply, 0);
            AddHtml(383, 175, 200, 20, "<h3><basefont color=#006600>" + m_Bowl.Plant.Reagent.ToString() + " Fleurs<basefont></h3>", false, false);
            AddImage(455, 200, 212);
            //AddItem(242, 201, 3620);
            //AddButton(442, 201, 1903, 1903, 7, GumpButtonType.Reply, 0);
            switch (m_Bowl.Plant.StateOfGrowth)
            {
                case StateOfGrowth.Seed: AddItem(442, 201, 13066); break;
                case StateOfGrowth.Germ: AddItem(442, 201, 3150); break;
                case StateOfGrowth.Young: AddItem(442, 201, 13037); break;
                case StateOfGrowth.Mature: AddItem(442, 201, 13038); break;
                case StateOfGrowth.Deterioration: AddItem(442, 201, 3213); break;
                default: AddItem(442, 201, 13066); break;
            }
            AddItem(442, 201, 13066);
            AddHtml(383, 200, 200, 20, "<h3><basefont color=#006600>" + BotaniqueSystem.GetStateOfGrowth(m_Bowl.Plant.StateOfGrowth) + "<basefont></h3>", false, false);

            /*AddPage(0);

            AddBackground(65, 9, 323, 390, 9270);
            AddBackground(79, 23, 296, 29, 3000);

            AddImage(187, 79, 1417);
            AddItem(184, 84, m_Bowl.Plant.ItemID);

            AddLabel(196, 27, 2101, "Botanique");

            AddLabel(196, 55, 2101, BotaniqueSystem.GetPlantName(m_Bowl.Plant.PlantType));

            AddLabel(80, 166, 2101, "Pétales");
            AddLabel(80, 190, 2101, "Graines");
            AddLabel(80, 214, 2101, "Terre");
            AddLabel(80, 238, 2101, "État de croissance");
            AddLabel(80, 262, 2101, "Hydratation");
            AddLabel(80, 286, 2101, "Insectes");
            AddLabel(80, 310, 2101, "Maladie");
            AddLabel(80, 334, 2101, "Engrais");

            AddLabel(209, 166, 2101, String.Format(": {0} / {1}", m_Bowl.Plant.Reagent, m_Bowl.Plant.MaxReagent));
            AddButton(341, 165, 4014, 4016, 1, GumpButtonType.Reply, 0);

            AddLabel(209, 190, 2101, String.Format(": {0} / {1}", m_Bowl.Plant.Seed, m_Bowl.Plant.MaxSeed));
            AddButton(341, 189, 4014, 4016, 2, GumpButtonType.Reply, 0);

            AddLabel(209, 214, 2101, String.Format(": {0}", BotaniqueSystem.GetEarthName(m_Bowl.EarthType)));
            AddLabel(209, 238, 2101, String.Format(": {0}", BotaniqueSystem.GetStateOfGrowth(m_Bowl.Plant.StateOfGrowth)));

            AddLabel(209, 262, 2101, String.Format(": {0}", BotaniqueSystem.GetStateOfHydration(m_Bowl.Plant.StateOfHydration)));
            AddButton(341, 261, 4014, 4016, 3, GumpButtonType.Reply, 0);

            AddLabel(209, 286, 2101, String.Format(": {0}", BotaniqueSystem.GetInsects(m_Bowl.Plant.Insects)));

            if (m_Bowl.Plant.Insects != Insects.None)
                AddButton(341, 285, 4014, 4016, 4, GumpButtonType.Reply, 0);

            AddLabel(209, 310, 2101, String.Format(": {0}", BotaniqueSystem.GetDisease(m_Bowl.Plant.Disease)));

            if (m_Bowl.Plant.Disease != Disease.None)
                AddButton(341, 309, 4014, 4016, 5, GumpButtonType.Reply, 0);

            AddLabel(209, 334, 2101, String.Format(": {0}", BotaniqueSystem.GetManure(m_Bowl.Manure)));

            if (m_Bowl.Manure == Manure.None)
                AddButton(341, 333, 4014, 4016, 6, GumpButtonType.Reply, 0);

            AddLabel(262, 360, 2101, "Vider le pot");
            AddButton(341, 359, 4017, 4019, 7, GumpButtonType.Reply, 0);*/
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.SendMessage("Choisissez un poison pour la plante.");
                    from.Target = new PlantPoisonTarget(m_Bowl);
                    break;
                case 2:
                    if (m_Bowl.Plant.StateOfGrowth > StateOfGrowth.Seed)
                    {
                        m_Bowl.Plant.Movable = true;
                        from.AddToBackpack(m_Bowl.Plant);
                        m_Bowl.Plant.RemoveItem(m_Bowl.Plant);
                        from.SendMessage("Vous cueillez la plante.");
                    }
                    else
                    {
                        from.SendMessage("Il est trop tôt pour cueillir la fleur.");
                        from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                    }
                    break;
                case 3:
                    m_Bowl.Plant.RemoveItem(m_Bowl.Plant);
                    from.SendMessage("Vous détruisez la plante dans le pot.");
                    break;
                case 4:
                    from.SendMessage("Choisissez de l'eau pour la plante.");
                    from.Target = new PlantWaterTarget(m_Bowl);
                    break;
                    //Graines
                case 5:
                    m_Bowl.Plant.ExtractSeeds(from);
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                    break;
                    //Fleurs
                case 6:
                    m_Bowl.Plant.ExtractReagent(from);
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                    break;
                case 7:
                    from.Target = new PlantPotionTarget(m_Bowl);
                    break;
                default: break;
            }
        }

        class PlantPoisonTarget : Target
        {
            BaseBowl m_Bowl;

            public PlantPoisonTarget(BaseBowl bowl)
                : base(3, true, TargetFlags.None)
            {
                m_Bowl = bowl;
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is PoisonPotion)
                {
                    m_Bowl.Plant.Poison = PlantPoison.Empoisonnee;
                    ((Item)targeted).Delete();
                    from.SendMessage("Vous empoisonnez la plante !");
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                }
                else
                {
                    from.SendMessage("Vous devez choisir une potion de poison !");
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                }
            }
        }

        class PlantWaterTarget : Target
        {
            BaseBowl m_Bowl;

            public PlantWaterTarget(BaseBowl bowl)
                : base(3, true, TargetFlags.None)
            {
                m_Bowl = bowl;
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is BaseBeverage)
                {
                    ((BaseBeverage)targeted).Quantity -= 1;
                    m_Bowl.Plant.Hydrate(1);
                    from.SendMessage("Vous utilisez le beverage pour donner de l'eau a la plante.");
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                }
                else
                {
                    from.SendMessage("Vous devez choisir une boisson !");
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                }
            }
        }

        class PlantPotionTarget : Target
        {
            BaseBowl m_Bowl;

            public PlantPotionTarget(BaseBowl bowl)
                : base(3, true, TargetFlags.None)
            {
                m_Bowl = bowl;
                AllowNonlocal = true;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is HealPotion)
                {
                    ((Item)targeted).Delete();
                    m_Bowl.Plant.Poison = PlantPoison.None;
                    from.SendMessage("Vous soignez la plante !");
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                }
                else
                {
                    from.SendMessage("Vous devez pointez une potion de soins !");
                    from.SendGump(new BotaniqueGump((PlayerMobile)from, m_Bowl));
                }
            }
        }

        /*public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_Bowl.Deleted || !m_From.CheckAlive())
                return;

            if (m_Bowl.IsEmpty)
            {
                m_From.SendMessage("Le pot est vide.");
            }
            else if (!m_Bowl.HasPlant)
            {
                m_From.SendMessage("Il n'y a pas de plante dans ce pot.");
            }
            else
            {
                switch (info.ButtonID)
                {
                    case 2:
                        {
                            m_From.SendGump(new ConfirmTakingSeedGump(m_From, m_Bowl));
                            break;
                        }
                    case 7:
                        {
                            m_From.SendGump(new ConfirmEmptyGump(m_From, m_Bowl));
                            break;
                        }
                }
            }
        }

        public class ConfirmTakingSeedGump : Gump
        {
            private PlayerMobile m_From;
            private BaseBowl m_Bowl;

            public ConfirmTakingSeedGump(PlayerMobile from, BaseBowl bowl) : base(0, 0)
            {
                m_From = from;
                m_Bowl = bowl;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(83, 51, 278, 148, 9270);

                AddLabel(98, 64, 2101, "Combien de graine voulez-vous cueillir?");

                AddButton(159, 126, 2103, 2104, 1, GumpButtonType.Reply, 0);
                AddLabel(162, 101, 2101, "1");

                AddButton(194, 126, 2103, 2104, 2, GumpButtonType.Reply, 0);
                AddLabel(195, 101, 2101, "2");

                AddButton(229, 126, 2103, 2104, 3, GumpButtonType.Reply, 0);
                AddLabel(230, 101, 2101, "3");

                AddButton(264, 126, 2103, 2104, 4, GumpButtonType.Reply, 0);
                AddLabel(264, 101, 2101, "4");

                AddButton(157, 161, 4005, 4007, 0, GumpButtonType.Reply, 0);
                AddLabel(195, 163, 2101, "Je ne veux pas en cueillir");
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (m_Bowl.Deleted || !m_From.CheckAlive())
                    return;

                if (m_Bowl.IsEmpty)
                {
                    m_From.SendMessage("Le pot est vide.");
                }
                else if (!m_Bowl.HasPlant)
                {
                    m_From.SendMessage("Il n'y a pas de plante dans ce pot.");
                }
                else
                {
                    if (info.ButtonID >= 1 && info.ButtonID <= 4)
                    {
                        if (m_Bowl.Plant.StateOfGrowth == StateOfGrowth.Seed)
                            m_From.AddToBackpack(m_Bowl.Plant.GetSeed());
                        else if (m_Bowl.Plant.StateOfGrowth >= StateOfGrowth.Mature)
                            //m_From.AddToBackpack(m_Bowl.Plant.Dupe(1));
                            m_From.AddToBackpack(m_Bowl.Plant);

                        m_Bowl.Plant.Delete();
                        m_Bowl.Empty();

                        m_From.SendMessage(String.Format("Vous cueillez {0} graine{1}.", info.ButtonID, info.ButtonID == 1 ? "" : "s"));
                    }
                    else
                    {
                        m_From.SendMessage("Vous décidez de ne pas cueillir de graine.");
                        m_From.SendGump(new BotaniqueGump(m_From, m_Bowl));
                    }
                }
            }
        }

        public class ConfirmEmptyGump : Gump
        {
            private PlayerMobile m_From;
            private BaseBowl m_Bowl;

            public ConfirmEmptyGump(PlayerMobile from, BaseBowl bowl) : base(0, 0)
            {
                m_From = from;
                m_Bowl = bowl;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(83, 51, 278, 170, 9270);
                
                if (m_Bowl.Plant.StateOfGrowth == StateOfGrowth.Seed)
                {
                    AddLabel(98, 64, 2101, "Si vous videz la terre de ce pot, vous");
                    AddLabel(98, 86, 2101, "récupererez la graine.");
                }
                else if (m_Bowl.Plant.StateOfGrowth == StateOfGrowth.Germ)
                {
                    AddLabel(98, 64, 2101, "Si vous videz la terre de ce pot, vous");
                    AddLabel(98, 86, 2101, "perdrez votre plante puisqu'elle n'est pas");
                    AddLabel(98, 108, 2101, "assez développée.");
                }
                else if (m_Bowl.Plant.StateOfGrowth == StateOfGrowth.Young)
                {
                    AddLabel(98, 64, 2101, "Si vous videz la terre de ce pot, vous");
                    AddLabel(98, 86, 2101, "perdrez votre plante puisqu'elle n'est pas");
                    AddLabel(98, 108, 2101, "assez développée.");
                }
                else if (m_Bowl.Plant.StateOfGrowth >= StateOfGrowth.Mature)
                {
                    AddLabel(98, 64, 0, "Si vous videz la terre de ce pot, votre");
                    AddLabel(98, 86, 0, "plante cessera de produire des composantes");
                    AddLabel(98, 108, 0, "et des graines.");
                }

                AddLabel(98, 134, 2101, "Voulez-vous continuer?");

                AddButton(276, 184, 4005, 4007, 1, GumpButtonType.Reply, 0);
                AddLabel(314, 186, 2101, "Oui");

                AddButton(200, 184, 4005, 4007, 0, GumpButtonType.Reply, 0);
                AddLabel(238, 186, 2101, "Non");
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (m_Bowl.Deleted || !m_From.CheckAlive())
                    return;

                if (m_Bowl.IsEmpty)
                {
                    m_From.SendMessage("Le pot est vide.");
                }
                else if (!m_Bowl.HasPlant)
                {
                    m_From.SendMessage("Il n'y a pas de plante dans ce pot.");
                }
                else
                {
                    if (info.ButtonID == 1)
                    {
                        if (m_Bowl.Plant.StateOfGrowth == StateOfGrowth.Seed)
                            m_From.AddToBackpack(m_Bowl.Plant.GetSeed());
                        else if (m_Bowl.Plant.StateOfGrowth >= StateOfGrowth.Mature)
                            //m_From.AddToBackpack(m_Bowl.Plant.Dupe(1));
                            m_From.AddToBackpack(m_Bowl.Plant);

                        m_Bowl.Plant.Delete();
                        m_Bowl.Empty();

                        m_From.SendMessage("Vous videz le pot.");
                    }
                    else
                    {
                        m_From.SendMessage("Vous décidez de ne pas vider le pot.");
                        m_From.SendGump(new BotaniqueGump(m_From, m_Bowl));
                    }
                }
            }
        }*/
    }
}