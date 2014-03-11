using Server.Gumps;
using Server.Network;
using Server.Prompts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Server.Systemes.Geopolitique
{
    class GererRentesGump : Gump
    {
        private int page;
        private int edit;

        public GererRentesGump() : this(-1, 0)
        {
        }

        public GererRentesGump(int edit, int page) : base( 0, 0 )
        {
            this.page = page;
            this.edit = edit;

            this.Closable=true;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;

			AddPage(0);
			AddBackground(31, 48, 416, 520, 9250);
			AddBackground(39, 56, 400, 504, 3500);

			AddLabel(154, 75, 1301, @"Gestion des types de terres");

            int basey = 123;
            int offset = 0;
            for (int i = 0; i < Geopolitique.types.Count; i++)
            {
                if (i < page * 10) continue;
                if ((page + 1) * 10 < i) break;

                if (i == edit)
                {
                    AddTextEntry(66, basey + offset * 30, 153, 20, 1301, 0, Geopolitique.types[i].Nom);
                    AddTextEntry(255, basey + offset * 30, 100, 20, 1301, 1, Geopolitique.types[i].Rente.ToString());
                    AddButton(383, basey + offset * 30, 4005, 4006, 100 + i, GumpButtonType.Reply, 0);   
                    //AddButton(343, basey + offset * 30 - 1, 4017, 4018, 200 + i, GumpButtonType.Reply, 0);
                }
                else
                {
                    AddLabel(66, basey + offset * 30, 1301, Geopolitique.types[i].Nom);
                    AddLabel(255, basey + offset * 30, 1301, Geopolitique.types[i].Rente.ToString("N", Geopolitique.NFI));
                    AddButton(383, basey + offset * 30, 4011, 4012, 100 + i, GumpButtonType.Reply, 0);   
                }
                
                offset = (offset + 1) % 10;
            }

			AddButton(306, 439, 4005, 4006, (int)Buttons.AjouterTypeTerre, GumpButtonType.Reply, 0);
			AddLabel(135, 440, 1301, @"Ajouter un type de terre");

            if((page + 1) * 10 < Geopolitique.types.Count)
                AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Reply, 0);

            if(page > 0)
                AddButton(59, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Reply, 0);

            AddImageTiled(67, 472, 342, 3, 96);
			AddImage(61, 463, 95);
			AddImage(408, 463, 97);

            AddLabel(99, 516, 1301, @"Afficher le journal des événements");
			AddButton(330, 515, 4011, 4012, (int)Buttons.AfficherJournal, GumpButtonType.Reply, 0);
			
			AddLabel(141, 486, 1301, @"Afficher la liste des terres");
            AddButton(330, 485, 4005, 4006, (int)Buttons.AfficherTerres, GumpButtonType.Reply, 0);

        }

        public enum Buttons
        {
            AjouterTypeTerre = 1,
            AfficherJournal,
            AfficherTerres,
            NextPage,
            PreviousPage,
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;
			TextRelay entry0 = info.GetTextEntry(0);
			string NomType = (entry0 == null ? "" : entry0.Text.Trim());
            TextRelay entry1 = info.GetTextEntry(1);
			string RenteType = (entry1 == null ? "" : entry1.Text.Trim());

            int button = info.ButtonID;
            switch(button)
            {
                case (int)Buttons.AjouterTypeTerre:
                    from.SendMessage("Veuillez entrer le nom du type de terre que vous désirez ajouter.");
                    from.Prompt = new NomTypePrompt();
					break;

				case (int)Buttons.AfficherJournal:
                    from.SendMessage("Cette commande n'est pas encore fonctionnelle.");
                    from.SendGump(new GererRentesGump(edit, page));
					break;

				case (int)Buttons.AfficherTerres:
				{
                    from.SendGump(new GeopolGump(from, Geopolitique.geopolitique));
					break;
				}
				case (int)Buttons.NextPage:
				{
                    from.SendGump(new GererRentesGump(edit, page+1));
					break;
				}
				case (int)Buttons.PreviousPage:
				{
                    from.SendGump(new GererRentesGump(edit, page-1));
					break;
				}
            }
            if (button >= 100 && button < 100 + Geopolitique.types.Count)
            {
                int i = button - 100;
                if (i == edit)
                {
                    int rente;
                    if (Int32.TryParse(RenteType, out rente))
                    {
                        Geopolitique.types[i].Rente = rente;
                        Geopolitique.types[i].Nom = NomType;
                        from.SendGump(new GererRentesGump(-1, page));
                    }
                    else
                    {
                        from.SendMessage("L'entrée n'a pas pu être modifiée puisque la rente n'était pas un nombre.");
                        from.SendGump(new GererRentesGump(edit, page));
                    }
                }
                else
                {
                    from.SendGump(new GererRentesGump(i, page));
                }
            }
            //if (button >= 200 && button < 200 + Geopolitique.types.Count)
            //{

            //}
            
        }
        private class NomTypePrompt : Prompt
        {
            public NomTypePrompt()
            {
            }

            public override void OnResponse(Mobile from, string text)
            {
                from.SendMessage("Veuillez entrer le montant mensuel pour ce type de terre.");
                from.Prompt = new RenteTypePrompt(text);
            }

            public override void OnCancel(Mobile from)
            {
                from.SendMessage("La création d'un nouveau type de terre est annulé.");
                from.SendGump(new GererRentesGump());
            }
        }

        private class RenteTypePrompt : Prompt
        {
            private string nom;

            public RenteTypePrompt(string nom)
            {
                this.nom = nom;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int rente;
                if (Int32.TryParse(text, out rente))
                {
                    from.SendMessage("Entrée créée");
                    Geopolitique.types.Add(new TypeTerre(nom, rente));
                    from.SendGump(new GererRentesGump());
                }
                else
                {
                    from.SendMessage("Vous devez entrer un nombre. Veuillez réessayer.");
                    from.Prompt = new RenteTypePrompt(nom);
                }
            }

            public override void OnCancel(Mobile from)
            {
                from.SendMessage("La création d'un nouveau type de terre est annulé.");
                from.SendGump(new GererRentesGump());
            }
        }
    }
}
