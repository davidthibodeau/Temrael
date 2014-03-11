using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Prompts;
using Server.Mobiles;
using Server.Targeting;


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
            AddButton(383, 109, 4005, 4006, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);

            AddLabel(81, 140, 1301, @"Gestionnaire :");
            if(tresorier.Gestionnaire != null)
                AddLabel(210, 140, 1301, tresorier.Gestionnaire.GetNameUseBy(from));
            AddButton(383, 139, 4005, 4006, (int)Buttons.ChangerGestionnaire, GumpButtonType.Reply, 0);
            
            AddLabel(81, 170, 1301, @"Fonds :");
            AddLabel(210, 170, 1301, tresorier.Fonds.ToString("N", Geopolitique.NFI));
            AddButton(383, 169, 4005, 4006, (int)Buttons.ModifierFonds, GumpButtonType.Reply, 0);

            if(tresorier.Terre != null && tresorier.Terre.TresorierCount > 1)
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
                AddLabel(60, basey + j * 30, 1301, tresorier[i].Nom);
                AddLabel(200, basey + j * 30, 1301, tresorier[i].Titre);
                AddLabel(303, basey + j * 30, 1301, tresorier[i].Paie.ToString("N", Geopolitique.NFI));
                AddButton(387, basey + j * 30 - 1, 4005, 4006, 100 + i, GumpButtonType.Reply, 0);
            }

            if((page + 1) * 5 < tresorier.EmployeCount)
                AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Page, 0);
            if(page > 0)
                AddButton(61, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Page, 0);
            
            AddButton(293, 439, 4005, 4006, (int)Buttons.AjouterEmploye, GumpButtonType.Reply, 0);
            AddLabel(148, 440, 1301, @"Ajouter un employé");
            AddImageTiled(67, 471, 342, 3, 96);
            AddImage(61, 462, 95);
            AddImage(408, 462, 97);
            AddLabel(99, 515, 1301, @"Afficher le journal des événements");
            AddButton(330, 514, 4011, 4012, (int)Buttons.AfficherJournal, GumpButtonType.Reply, 0);
            AddLabel(207, 485, 1301, @"Afficher la terre");
            AddButton(330, 484, 4005, 4006, (int)Buttons.AfficherTerre, GumpButtonType.Reply, 0);
        }

        public enum Buttons
        {
            AjouterEmploye = 1,
            AfficherJournal,
            AfficherTerre,
            NextPage,
            PreviousPage,
            ChangerNom,
            ChangerGestionnaire,
            ModifierFonds,
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            int button = info.ButtonID;
            switch(button)
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
                    from.SendGump(new GeopolGump(from, tresorier.Terre));
					break;

				case (int)Buttons.NextPage:
                    from.SendGump(new TresorierGump(tresorier, from, page + 1));
					break;

				case (int)Buttons.PreviousPage:
                    from.SendGump(new TresorierGump(tresorier, from, page - 1));
					break;

				case (int)Buttons.ChangerNom:
                    from.SendMessage("Quel nom voulez-vous donner à notre organisation?");
                    from.Prompt = new ModifierNomPrompt(tresorier);
					break;

				case (int)Buttons.ChangerGestionnaire:
				{
                    if (from.AccessLevel == AccessLevel.Player && from != tresorier.Gestionnaire)
                        break;
                    from.SendMessage("Veuillez choisir le nouveau gestionnaire");
                    if (from == tresorier.Gestionnaire)
                        from.SendMessage("Veuillez prendre note que vous perdrez vos pouvoirs de gestionnaire.");
                    from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(ChangerGestionnaire_OnTarget));
					break;
				}
				case (int)Buttons.ModifierFonds:
				{

					break;
				}
            }
            if (button >= 100 && button < 100 + tresorier.EmployeCount)
            {
                
            }
            
        }

        private void ChangerGestionnaire_OnTarget(Mobile from, object targeted)
        {
            if (targeted is TMobile)
            {
                tresorier.Gestionnaire = (TMobile)targeted;
                from.SendMessage("Le changement fut fait.");
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(ChangerGestionnaire_OnTarget));
            }
        }

        private class ModifierNomPrompt : Prompt
        {
            private Tresorier t;

            public ModifierNomPrompt(Tresorier t)
            { 
                this.t = t; 
            }

            public override void OnResponse(Mobile from, string text)
            {
                t.Etablissement = text;
                from.SendGump(new TresorierGump(t, from, 0));
            }

            public override void OnCancel(Mobile from)
            {
                from.SendGump(new TresorierGump(t, from, 0));
            }
        }

        private class ModifierFondsPrompt : Prompt
        {
            private Tresorier t;

            public ModifierFondsPrompt(Tresorier t)
            {
                this.t = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int amount;
                if (Int32.TryParse(text, out amount))
                {
                    if (amount > 0)
                        t.AjoutFonds(from, amount);
                    else
                        t.RetraitFonds(from, -amount);
                }
                //t.PrivateOverheadMessage(MessageType.Regular, 0x3B2, false,
                //    "Je n'ai pas compris le montant que vous désirer ajouter ou retirer.", from.NetState);
                
            }
        }
    }
}
