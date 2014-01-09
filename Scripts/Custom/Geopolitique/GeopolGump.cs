using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Prompts;

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
			AddLabel(214, 486, 1301, @"Gérer les rentes");
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
            AddButton(383, 109, 4005, 248, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);
			AddLabel(81, 140, 1301, @"Type :");
            AddButton(383, 139, 4005, 248, (int)Buttons.ChangerType, GumpButtonType.Reply, 0);
            AddLabel(81, 170, 1301, @"Rente mensuelle :");
            AddButton(383, 169, 4005, 248, (int)Buttons.ModifierRentes, GumpButtonType.Reply, 0);
			AddLabel(82, 200, 1301, @"Fonds :");
			AddButton(383, 199, 4005, 248, (int)Buttons.ModifierFonds, GumpButtonType.Reply, 0);

            if(terre.TresorierCount == 0)
                AddLabel(82, 240, 1301, @"Il n'y a pas de trésoriers installés.");
            else 
                AddLabel(82, 240, 1301, @"Il y a " + terre.TresorierCount + " trésories installés :");

            int maxpages = (terre.TresorierCount) / 10;
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
			AddLabel(214, 486, 1301, @"Afficher la liste des terres");
            AddButton(330, 485, 4005, 4006, (int)Buttons.RetourCategorie, GumpButtonType.Reply, 0);

            AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Page, 0);
			AddButton(61, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Page, 0);
        }

        public enum Buttons
        {
            AjouterCategorie,
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

            switch(info.ButtonID)
            {
                case (int)Buttons.AjouterCategorie:
				{
                    if (cat == null) break;
                    from.SendMessage("Entrez le nom de la catégorie que vous désirez créer.");
                    from.Prompt = new GeopolPrompt(cat, GeopolPrompt.CatOuTerre.Categorie);
                    break;
				}
				case (int)Buttons.AjouterTerre:
				{
                    if (cat == null) break;
                    from.SendMessage("Entrez le nom de la terre que vous désirez créer.");
                    from.Prompt = new GeopolPrompt(cat, GeopolPrompt.CatOuTerre.Terre);
					break;
				}
				case (int)Buttons.AfficherJournal:
				{

					break;
				}
				case (int)Buttons.GererRentes:
				{

					break;
				}
				case (int)Buttons.NextPage:
				{
                    if (cat != null) //C'est un ou l'autre
                        from.SendGump(new GeopolGump(from, cat, page + 1));
                    else if (terre != null)
                        from.SendGump(new GeopolGump(from, terre, page + 1));
					break;
				}
				case (int)Buttons.PreviousPage:
				{
                    if (cat != null) //C'est un ou l'autre
                        from.SendGump(new GeopolGump(from, cat, page - 1));
                    else if (terre != null)
                        from.SendGump(new GeopolGump(from, terre, page - 1));
					break;
				}
	
				case (int)Buttons.MenuPrecedent:
                {
                    if (cat != null)
                    {
                        if (cat.Parent != null)
                            from.SendGump(new GeopolGump(from, cat.Parent));

                    }
                    else if (terre != null)
                    {
                        from.SendGump(new GeopolGump(from, terre.Parent));
                    }
					break;
				}

            }
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
                        from.SendGump(new GeopolGump(from, c));
                        break;
                    case CatOuTerre.Terre:
                        Terre t = new Terre(parent, text);
                        parent.AjouterTerre(t);
                        from.SendGump(new GeopolGump(from, t));
                        break;
                }
            }
        }
    }
}
