using Server.Gumps;
using Server.Network;
using Server.Prompts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Systemes.Geopolitique
{
    public class EmployeGump : Gump
    {
        private Employe employe;
        private Tresorier tresorier;
        private bool gestion;

        public EmployeGump(Tresorier t, Employe e, bool gestion)
            : base(0, 0)
        {
            employe = e;
            tresorier = t;
            this.gestion = gestion;

            this.Closable = true;
            this.Disposable = true;
            this.Dragable = true;
            this.Resizable = false;

            AddPage(0);
            AddBackground(31, 48, 416, 238, 9250);
            AddBackground(39, 56, 400, 222, 3500);
            AddLabel(176, 75, 1301, @"Fiche d'Employé");


            AddLabel(81, 110, 1301, @"Nom :");
            AddLabel(210, 110, 1301, e.Nom);
            if(gestion)
                AddButton(383, 109, 4005, 4006, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);
            AddLabel(81, 140, 1301, @"Titre :");
            AddLabel(210, 140, 1301, e.Titre);
            if(gestion)
                AddButton(383, 139, 4005, 4006, (int)Buttons.ChangerTitre, GumpButtonType.Reply, 0);
            AddLabel(81, 170, 1301, @"Paie mensuelle :");
            AddLabel(210, 170, 1301, e.Paie.ToString("N", Geopolitique.NFI));
            if(gestion)
                AddButton(383, 169, 4005, 4006, (int)Buttons.ModifierPaie, GumpButtonType.Reply, 0);

            AddLabel(82, 200, 1301, @"Dû non réclamé :");
            AddLabel(210, 200, 1301, e.Total.ToString("N", Geopolitique.NFI));
            AddButton(383, 199, 4005, 4006, (int)Buttons.ModifierDu, GumpButtonType.Reply, 0);

            if (gestion)
            {
                AddLabel(116, 230, 1301, @"Supprimer l'employé de la liste");
                AddButton(314, 229, 4005, 4006, (int)Buttons.SupprimerEmploye, GumpButtonType.Reply, 0);
            }
        }

        public enum Buttons
        {
            SupprimerEmploye = 1,
            ChangerNom,
            ChangerTitre,
            ModifierPaie,
            ModifierDu,
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (gestion)
            {
                switch (info.ButtonID)
                {
                    case 0:
                        from.SendGump(new TresorierGump(tresorier, from, 0));
                        break;

                    case (int)Buttons.SupprimerEmploye:

                        break;

                    case (int)Buttons.ChangerNom:
                        tresorier.ReponseAuGump(from, "Veuillez indiquer le nouveau nom à utiliser pour l'employé.");
                        from.Prompt = new ChangerNomPrompt(tresorier, employe);
                        break;

                    case (int)Buttons.ChangerTitre:
                            tresorier.ReponseAuGump(from, "Quel titre voulez-vous donner à " + employe.Nom + ".");
                            from.Prompt = new ChangerTitrePrompt(tresorier, employe);
                        break;

                    case (int)Buttons.ModifierPaie:

                        break;

                    case (int)Buttons.ModifierDu:

                        break;
                }
            }
            else if (info.ButtonID == (int)Buttons.ModifierDu)
            {
                //Prompt pour la reclamation du du.
            }
        }

        private class ChangerNomPrompt : Prompt
        {

            private Employe employe;
            private Tresorier tresorier;

            public ChangerNomPrompt(Tresorier t, Employe e)
            {
                employe = e;
                tresorier = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                employe.Nom = text;
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }

            public override void OnCancel(Mobile from)
            {
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }
        }

        private class ChangerTitrePrompt : Prompt
        {

            private Employe employe;
            private Tresorier tresorier;


            public ChangerTitrePrompt(Tresorier t, Employe e)
            {
                employe = e;
                tresorier = t;
            }

            public override void OnResponse(Mobile from, string text)
            {
                employe.Titre = text;
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }

            public override void OnCancel(Mobile from)
            {
                from.SendGump(new EmployeGump(tresorier, employe, true));
            }
        }
        
    }
}
