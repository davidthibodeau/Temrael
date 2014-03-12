using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Prompts;
using Server.Systemes.Geopolitique.Log;
using Server.Targeting;

namespace Server.Systemes.Geopolitique
{
    // Généré avec GumpStudio.
    public class GeopolGump : Gump
    {
        private Mobile caller;
        private Categorie cat;
        private Terre terre;
        private int page;

        public GeopolGump(Mobile from, Categorie ct)
            : this(from, ct, 0)
        {
        }

        public GeopolGump(Mobile from, Categorie ct, int page) : base(0, 0)
        {
            caller = from;
            cat = ct;
            this.page = page;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			AddBackground(31, 48, 416, 520, 9250);
			AddBackground(39, 56, 400, 504, 3500);
			AddLabel(174, 75, 1301, @"Rentes et Géopolitique");

            if (cat.Parent != null)
            {
                AddButton(72, 99, 4014, 4015, (int)Buttons.MenuPrecedent, GumpButtonType.Reply, 0);
                AddLabel(108, 100, 1301, @"Menu Précédent");
            }

			AddButton(209, 440, 4005, 4006, (int)Buttons.AjouterCategorie, GumpButtonType.Reply, 0);
			AddLabel(64, 441, 1301, @"Ajouter une catégorie");
			AddButton(381, 440, 4005, 4006, (int)Buttons.AjouterTerre, GumpButtonType.Reply, 0);
			AddLabel(261, 441, 1301, @"Ajouter une terre");

            AddImageTiled(67, 472, 342, 3, 96);
			AddImage(61, 463, 95);
			AddImage(408, 463, 97);
			AddLabel(99, 516, 1301, @"Afficher le journal des événements");
			AddButton(330, 515, 4011, 4012, (int)Buttons.AfficherJournal, GumpButtonType.Reply, 0);
			AddLabel(209, 486, 1301, @"Gérer les rentes");
            AddButton(330, 485, 4005, 4006, (int)Buttons.GererRentes, GumpButtonType.Reply, 0);

            int maxpages = (cat.CategoriesCount + cat.TerresCount) / 10;
            int i = -1;
            int basey = 123;
            int offset = 0;
            foreach (Categorie c in cat.Categories())
            {
                i++;
                if (i < page * 10) continue;
                if ((page + 1) * 10 < i) break; 
                AddLabel(86, basey + offset * 30 + 1, 1301, c.Nom);
                AddButton(354, basey + offset * 30, 4005, 4006, 100 + i, GumpButtonType.Reply, 0);
                offset = (offset + 1) % 10;
            }
            if (i == -1)
                i = 0;
            int j = -1;
            foreach (Terre t in cat.Terres())
            {
                j++;
                if (i + j < page * 10) continue;
                if ((page + 1) * 10 < i + j) break;
                AddLabel(86, basey + offset * 30 + 1, 1301, t.Nom);
                AddButton(354, basey + offset * 30, 4011, 4012, 200 + j, GumpButtonType.Reply, 0);
                offset = (offset + 1) % 10;
            }

            if(page < maxpages)
                AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Reply, 0);
            if (page > 0)
                AddButton(59, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Reply, 0);
        }

        public GeopolGump(Mobile from, Terre t)
            : this(from, t, 0)
        {
        }

        public GeopolGump(Mobile from, Terre t, int page) : base (0, 0)
        {
            caller = from;
            terre = t;
            this.page = page;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			AddBackground(31, 48, 416, 520, 9250);
			AddBackground(39, 56, 400, 504, 3500);
			AddLabel(174, 75, 1301, @"Rentes et Géopolitique");

            AddLabel(81, 110, 1301, @"Nom :");
            AddLabel(220, 110, 1301, t.Nom);
            AddButton(383, 109, 4005, 4006, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);
			AddLabel(81, 140, 1301, @"Type :");
            AddLabel(220, 140, 1301, t.Type.Nom);
            AddButton(383, 139, 4005, 4006, (int)Buttons.ChangerType, GumpButtonType.Reply, 0);
            AddLabel(81, 170, 1301, @"Rente mensuelle :");
            AddLabel(220, 170, 1301, t.Rente.ToString("N", Geopolitique.NFI));
            //AddButton(383, 169, 4005, 4006, (int)Buttons.ModifierRentes, GumpButtonType.Reply, 0);
			AddLabel(82, 200, 1301, @"Fonds :");
            AddLabel(220, 200, 1301, t.Fonds.ToString("N", Geopolitique.NFI));
			AddButton(383, 199, 4005, 4006, (int)Buttons.ModifierFonds, GumpButtonType.Reply, 0);

            if(terre.TresorierCount == 0)
                AddLabel(82, 240, 1301, @"Il n'y a pas de trésoriers installés.");
            else if(terre.TresorierCount == 1)
                AddLabel(82, 240, 1301, @"Il y a 1 trésorier installé :");
            else
                AddLabel(82, 240, 1301, @"Il y a " + terre.TresorierCount + " trésoriers installés :");

            //int maxpages = (terre.TresorierCount) / 5;
            int i = -1;
            int basey = 270;
            int offset = 0;
            foreach (Tresorier tr in terre.Tresoriers())
            {
                i++;
                if (i < page * 5) continue;
                if ((page + 1) * 5 < i) break; 
                AddLabel(68, basey + offset * 30 + 1, 1301, tr.Description);
                AddLabel(241, basey + offset * 30 + 1, 1301, tr.Location.ToString());
                AddButton(379, basey + offset * 30, 4005, 4006, 300 + i, GumpButtonType.Reply, 0);
                offset = (offset + 1) % 5;
            }

            AddButton(293, 439, 4005, 4006, (int)Buttons.AjouterTresorier, GumpButtonType.Reply, 0);
			AddLabel(148, 440, 1301, @"Ajouter un trésorier");

            AddImageTiled(67, 472, 342, 3, 96);
			AddImage(61, 463, 95);
			AddImage(408, 463, 97);
			AddLabel(99, 516, 1301, @"Afficher le journal des événements");
			AddButton(330, 515, 4011, 4012, (int)Buttons.AfficherJournal, GumpButtonType.Reply, 0);
			AddLabel(141, 486, 1301, @"Afficher la liste des terres");
            AddButton(330, 485, 4005, 4006, (int)Buttons.RetourCategorie, GumpButtonType.Reply, 0);

            if((page + 1) * 5 < terre.TresorierCount)
                AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Page, 0);
            if(page > 0)
                AddButton(61, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Page, 0);
        }

        public enum Buttons
        {
            AjouterCategorie = 1,
            AjouterTerre,
            AfficherJournal,
            GererRentes,
            NextPage,
            PreviousPage,
            MenuPrecedent,

            AjouterTresorier,
            RetourCategorie,
			ChangerNom,
			ChangerType,
			ModifierRentes,
			ModifierFonds,

        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
            int button = info.ButtonID;
            switch(button)
            {
                case (int)Buttons.AjouterCategorie:
                    if (cat == null) break;
                    if (cat.CategoriesCount > 15)
                    {
                        from.SendMessage("Vous ne pouvez avoir plus de 16 catégories sous une même catégorie.");
                        from.SendGump(new GeopolGump(from, cat));
                        break;
                    }
                    from.SendMessage("Entrez le nom de la catégorie que vous désirez créer.");
                    from.Prompt = new GeopolPrompt(cat, GeopolPrompt.CatOuTerre.Categorie);
                    break;

				case (int)Buttons.AjouterTerre:
                    if (cat == null) break;
                    if (cat.TerresCount > 255)
                    {
                        from.SendMessage("Vous ne pouvez pas avoir plus de 256 terres sous une même catégorie.");
                    }
                    from.SendMessage("Entrez le nom de la terre que vous désirez créer.");
                    from.Prompt = new GeopolPrompt(cat, GeopolPrompt.CatOuTerre.Terre);
					break;

				case (int)Buttons.AfficherJournal:
                    FunctionNonImplementee(from);
					break;

				case (int)Buttons.GererRentes:
                    from.SendGump(new GererRentesGump());
					break;

				case (int)Buttons.NextPage:
                    if (cat != null) //C'est un ou l'autre
                        from.SendGump(new GeopolGump(from, cat, page + 1));
                    else if (terre != null)
                        from.SendGump(new GeopolGump(from, terre, page + 1));
					break;

				case (int)Buttons.PreviousPage:
                    if (cat != null) //C'est un ou l'autre
                        from.SendGump(new GeopolGump(from, cat, page - 1));
                    else if (terre != null)
                        from.SendGump(new GeopolGump(from, terre, page - 1));
					break;
	
				case (int)Buttons.MenuPrecedent:
                    if (cat != null)
                    {
                        if (cat.Parent != null)
                            from.SendGump(new GeopolGump(from, cat.Parent));
                    }
                    break;

                case (int)Buttons.AjouterTresorier:
                    if (terre == null) break;
                    from.SendMessage("Entrez une description pour le trésorier que vous désirez créer.");
                    from.Prompt = new TresorierPrompt(terre);
					break;

                case (int)Buttons.RetourCategorie:
                    if (terre != null)
                    {
                        from.SendGump(new GeopolGump(from, terre.Parent));
                    }
                    break;
           
                case (int)Buttons.ChangerNom:
                    if (terre != null)
                    {
                        from.SendMessage("Veuillez entrer le nouveau nom pour la terre.");
                        from.Prompt = new RenommerTerrePrompt(terre);
                    }
                    break;

                case (int)Buttons.ModifierFonds:
                    if (terre != null)
                    {
                        from.SendMessage("Veuillez indiquer quel montant la terre doit avoir.");
                        from.Prompt = new ModifierFondsPrompt(terre);
                    }
                    break;

                //case (int)Buttons.ModifierRentes:

                //    break;

                case (int)Buttons.ChangerType:
                    if (terre != null)
                        from.SendGump(new ChoisirTypeGump(terre, 0));
                    break;
            }

            if (cat != null && button >= 100 && button < 100 + cat.CategoriesCount)
            {
                from.SendGump(new GeopolGump(from, cat.CategorieParIndex(button - 100)));
            }
            if (cat != null && button >= 200 && button < 200 + cat.TerresCount)
            {
                from.SendGump(new GeopolGump(from, cat.TerreParIndex(button - 200)));
            }
            if (terre != null && button >= 300 && button < 300 + terre.TresorierCount)
            {
                from.SendGump(new TresorierGump(terre.TresorierParIndex(button - 300), from, 0));
            }
        }

        private void FunctionNonImplementee(Mobile from)
        {
            from.SendMessage("Cette commande n'est pas encore fonctionnelle.");
            if (cat != null)
                from.SendGump(new GeopolGump(from, cat, page));
            else if (terre != null)
                from.SendGump(new GeopolGump(from, terre, page));
        }

        private class GeopolPrompt : Prompt
        {
            public enum CatOuTerre { Categorie, Terre }

            private CatOuTerre choix;
            private Categorie parent;

            public GeopolPrompt(Categorie p, CatOuTerre e)
            {
                parent = p;
                choix = e;
            }

            public override void OnResponse(Mobile from, string text)
            {
                switch (choix)
                {
                    case CatOuTerre.Categorie:
                        Categorie c = new Categorie(parent, text);
                        parent.AjouterCategorie(c);
                        Geopolitique.journal.AjouterEntry(new CreerCategorieEntry(from, c));
                        from.SendGump(new GeopolGump(from, c));
                        break;
                    case CatOuTerre.Terre:
                        Terre t = new Terre(parent, text);
                        parent.AjouterTerre(t);
                        Geopolitique.journal.AjouterEntry(new CreerTerreEntry(from, t));
                        from.SendGump(new GeopolGump(from, t));
                        break;
                }
            }
        }

        private class RenommerTerrePrompt : Prompt
        {
            private Terre terre;

            public RenommerTerrePrompt(Terre t)
            {
                terre = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                terre.Nom = text;
                from.SendGump(new GeopolGump(from, terre));
            }
        }

        private class ModifierFondsPrompt : Prompt
        {
            private Terre terre;

            public ModifierFondsPrompt(Terre t)
            {
                terre = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int fonds;
                if (Int32.TryParse(text, out fonds))
                {
                    terre.Fonds = fonds;
                    from.SendGump(new GeopolGump(from, terre));
                }
                else
                {
                    from.SendMessage("Veuillez entrer un nombre.");
                    from.Prompt = new ModifierFondsPrompt(terre);
                }
            }
        }

        private class TresorierPrompt : Prompt
        {

            private Terre parent;

            public TresorierPrompt(Terre p)
            {
                parent = p;
            }

            public override void OnResponse(Mobile from, string text)
            {
                from.SendMessage("Veuillez indiquer où vous désirer placer le trésorier.");
                from.Target = new PlacerTresorierTarget(text, parent);
                //from.SendGump(new TresorierGump(t, from, 0));
            }

            public override void OnCancel(Mobile from)
            {
                from.SendGump(new GeopolGump(from, parent));
            }
        }

        private class PlacerTresorierTarget : Target
        {
            private string tresorier;
            private Terre parent;

            public PlacerTresorierTarget(string t, Terre p) : base( 12, true, TargetFlags.None )
            {
                tresorier = t;
                parent = p;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                IPoint3D p = targeted as IPoint3D;

                if (p != null)
                {
                    Tresorier t = new Tresorier(tresorier, parent, new Point3D(p));
                    parent.AjouterTresorier(t);
                    Geopolitique.journal.AjouterEntry(new CreerTresorierEntry(from, t));
                    from.SendGump(new TresorierGump(t, from, 0));
                }
            }
            protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
            {
                from.SendMessage("La création du trésorier fut annulée.");
                from.SendGump(new GeopolGump(from, parent));
            }
        }

        private class ChoisirTypeGump : Gump
        {
            Terre terre;
            int page;

            public ChoisirTypeGump(Terre t, int page)
                : base(0, 0)
            {
                terre = t;
                this.page = page;

                this.Closable = true;
                this.Disposable = true;
                this.Dragable = true;
                this.Resizable = false;

                AddPage(0);
                AddBackground(31, 48, 416, 401, 9250);
                AddBackground(39, 56, 400, 386, 3500);
                AddLabel(174, 78, 1301, String.Format("String pour la terre de {0}", t.Nom));

                int basey = 110;
                int offset = 0;

                if(page == 0)
                {
                    AddLabel(81, 110, 1301, @"(Pas de type)");
                    AddLabel(270, 110, 1301, @"0");
                    AddButton(383, 109, 4005, 248, 99, GumpButtonType.Reply, 0);
                    offset = 1;
                }

                for (int i = 0; i < Geopolitique.types.Count; i++)
                {
                    if (i + 1 < page * 10) continue;
                    if ((page + 1) * 10 < i + 1) break;

                    AddLabel(81, basey + offset * 30, 1301, Geopolitique.types[i].Nom);
                    AddLabel(270, basey + offset * 30, 1301, Geopolitique.types[i].Rente.ToString("N", Geopolitique.NFI));
                    AddButton(383, basey + offset * 30 - 1, 4005, 248, 100 + i, GumpButtonType.Reply, 0);

                    offset = (offset + 1) % 10;
                }

                if((page + 1) * 10 < Geopolitique.types.Count)
                    AddButton(402, 402, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Reply, 0);
                if(page > 0)
                    AddButton(61, 401, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                Mobile from = sender.Mobile;

                int button = info.ButtonID;
                if (button == (int)Buttons.NextPage)
                    from.SendGump(new ChoisirTypeGump(terre, page+1));
                else if (button == (int)Buttons.PreviousPage)
                    from.SendGump(new ChoisirTypeGump(terre, page-1));

                else if (button >= 99 && button < 100 + Geopolitique.types.Count)
                {
                    if (button == 99)
                        terre.Type = TypeTerre.Empty;
                    else
                    {
                        terre.Type = Geopolitique.types[button - 100];
                    }
                    from.SendGump(new GeopolGump(from, terre));
                }
                
            }
        }
    }
}
