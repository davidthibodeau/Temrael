using System;
using Server;
using Server.Gumps;
using Server.Network;


namespace Server.Systemes.Geopolitique
{
    public class TresorierGump : Gump
    {
        Tresorier tresorier;
        int page;

        public TresorierGump(Tresorier tr, Mobile from, int page)
            : base(0, 0)
        {
            tresorier = tr;
            this.page = page;
            
            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);
            AddBackground(31, 48, 416, 520, 9250);
            AddBackground(39, 56, 400, 504, 3500);
            AddLabel(206, 75, 1301, @"Trésorier");
            
            AddLabel(81, 110, 1301, @"Etablissement :");
            AddLabel(210, 110, 1301, tresorier.Etablissement);
            AddButton(383, 109, 4005, 248, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);

            AddLabel(81, 140, 1301, @"Gestionnaire :");
            AddLabel(210, 140, 1301, tresorier.Gestionnaire.GetNameUseBy(from));
            AddButton(383, 139, 4005, 248, (int)Buttons.ChangerType, GumpButtonType.Reply, 0);
            
            AddLabel(81, 170, 1301, @"Fonds :");
            AddLabel(210, 170, 1301, tresorier.Fonds.ToString());
            AddButton(383, 169, 4005, 248, (int)Buttons.ModifierFonds, GumpButtonType.Reply, 0);

            if(tresorier.Terre != null)
            AddLabel(68, 200, 1301, @"Fonds partagés pour la terre de " + tresorier.Terre.Nom);
            
            AddLabel(82, 240, 1301, @"Employés :");

            int basey = 271;
            for (int i = 0; i < tresorier.EmployeCount; i++)
            {
                if (i >= (page + 1) * 5)
                    break;
                if (i < page * 5)
                    continue;

                int j = i % 5;
                AddLabel(60, basey + j * 30, 1301, tresorier[i].Nom.GetNameUseBy(from));
                AddLabel(200, basey + j * 30, 1301, tresorier[i].Titre);
                AddLabel(303, basey + j * 30, 1301, tresorier[i].Paie.ToString());
                AddButton(387, basey + j * 30 - 1, 4005, 4006, 100 + i, GumpButtonType.Reply, 0);
            }

            AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Page, 0);
            AddButton(61, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Page, 0);
            AddButton(293, 439, 4005, 4006, (int)Buttons.AjouterEmploye, GumpButtonType.Reply, 0);
            AddLabel(148, 440, 1301, @"Ajouter un employé");
            AddImageTiled(67, 471, 342, 3, 96);
            AddImage(61, 462, 95);
            AddImage(408, 462, 97);
            AddButton(387, 270, 4005, 248, (int)Buttons.VoirTresorerie, GumpButtonType.Reply, 0);
            AddLabel(99, 515, 1301, @"Afficher le journal des événements");
            AddButton(330, 514, 4011, 4012, (int)Buttons.AfficherJournal, GumpButtonType.Reply, 0);
            AddLabel(210, 485, 1301, @"Afficher la terre");
            AddButton(330, 484, 4005, 4006, (int)Buttons.AfficherTerre, GumpButtonType.Reply, 0);
        }

        public enum Buttons
        {
            AjouterEmploye,
            AfficherJournal,
            AfficherTerre,
            NextPage,
            PreviousPage,
            ChangerNom,
            ChangerType,
            ModifierFonds,
            VoirTresorerie,
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch(info.ButtonID)
            {
                case (int)Buttons.AjouterEmploye:
                    //ajouter employer target
					break;
				
				case (int)Buttons.AfficherJournal:
				{
                    //not implemented
					break;
				}
				case (int)Buttons.AfficherTerre:
				{
                    from.SendGump(new GeopolGump(from, tresorier.Terre));
					break;
				}
				case (int)Buttons.NextPage:
				{
                    from.SendGump(new TresorierGump(tresorier, from, page + 1));
					break;
				}
				case (int)Buttons.PreviousPage:
				{
                    from.SendGump(new TresorierGump(tresorier, from, page - 1));
					break;
				}
				case (int)Buttons.ChangerNom:
				{

					break;
				}
				case (int)Buttons.ChangerType:
				{

					break;
				}
				case (int)Buttons.ModifierFonds:
				{

					break;
				}
				case (int)Buttons.VoirTresorerie:
				{

					break;
				}

            }
        }
    }
}
