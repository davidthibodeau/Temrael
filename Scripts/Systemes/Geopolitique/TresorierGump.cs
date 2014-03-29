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
            if (from.AccessLevel > AccessLevel.Player)
            {
                AddBackground(31, 48, 416, 520, 9250);
                AddBackground(39, 56, 400, 504, 3500);
                if (tr.Terre == null)
                {
                    AddLabel(170, 485, 1301, @"Attacher à une terre");
                    AddButton(330, 484, 4017, 4018, (int)Buttons.AttacherTerre, GumpButtonType.Reply, 0);
                }
                else
                {
                    AddLabel(207, 485, 1301, @"Afficher la terre");
                    AddButton(330, 484, 4005, 4006, (int)Buttons.AfficherTerre, GumpButtonType.Reply, 0);
                }

                AddLabel(99, 515, 1301, @"Afficher le journal des événements");
                AddButton(330, 514, 4011, 4012, (int)Buttons.AfficherJournal, GumpButtonType.Reply, 0);
            }
            else
            {
                AddBackground(31, 48, 416, 490, 9250);
                AddBackground(39, 56, 400, 474, 3500);
                AddLabel(99, 485, 1301, @"Afficher le journal des événements");
                AddButton(330, 484, 4011, 4012, (int)Buttons.AfficherJournal, GumpButtonType.Reply, 0);
            }

            AddLabel(206, 75, 1301, @"Trésorier");

            AddLabel(81, 110, 1301, @"Etablissement :");
            AddLabel(210, 110, 1301, tresorier.Etablissement);
            AddButton(383, 109, 4005, 4006, (int)Buttons.ChangerNom, GumpButtonType.Reply, 0);

            AddLabel(81, 140, 1301, @"Gestionnaire :");
            AddLabel(210, 140, 1301, tresorier.NomGestionnaire);
            AddButton(383, 139, 4005, 4006, (int)Buttons.ChangerGestionnaire, GumpButtonType.Reply, 0);

            AddLabel(81, 170, 1301, @"Fonds :");
            AddLabel(210, 170, 1301, tresorier.Fonds.ToString("N", Geopolitique.NFI));
            AddButton(343, 169, 4014, 4015, (int)Buttons.RetirerFonds, GumpButtonType.Reply, 0);
            AddButton(383, 169, 4005, 4006, (int)Buttons.AjouterFonds, GumpButtonType.Reply, 0);

            if (tresorier.Terre != null && tresorier.Terre.TresorierCount > 1)
                AddLabel(68, 200, 1301, @"Fonds partagés pour la terre de " + tresorier.Terre.Nom);

            AddLabel(82, 240, 1301, @"Employés :");

            int basey = 271;
            int k = 0;
            for (int i = 0; i < tresorier.EmployeCount; i++)
            {
                if (tresorier[i].Removed)
                    continue;
                if (k >= (page + 1) * 5)
                    break;
                if (k < page * 5)
                    continue;

                int j = k % 5;
                AddLabel(60, basey + j * 30, 1301, tresorier[k].Nom);
                AddLabel(200, basey + j * 30, 1301, tresorier[k].Titre);
                AddLabel(303, basey + j * 30, 1301, tresorier[k].Paie.ToString("N", Geopolitique.NFI));
                AddButton(387, basey + j * 30 - 1, 4005, 4006, 100 + i, GumpButtonType.Reply, 0);
                k++;
            }

            if ((page + 1) * 5 < tresorier.EmployeCount)
                AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Page, 0);
            if (page > 0)
                AddButton(61, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Page, 0);

            AddButton(293, 439, 4005, 4006, (int)Buttons.AjouterEmploye, GumpButtonType.Reply, 0);
            AddLabel(148, 440, 1301, @"Ajouter un employé");
            AddImageTiled(67, 471, 342, 3, 96);
            AddImage(61, 462, 95);
            AddImage(408, 462, 97);

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
            AjouterFonds,
            RetirerFonds,
            AttacherTerre,
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            int button = info.ButtonID;
            switch (button)
            {
                case (int)Buttons.AjouterEmploye:
                    tresorier.ReponseAuGump(from, "Veuillez indiquer l'employé que vous désirez ajouter au registre.");
                    from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AjouterEmploye_OnTarget));
                    break;

                case (int)Buttons.AfficherJournal:
                    {
                        //not implemented
                        break;
                    }
                case (int)Buttons.AfficherTerre:
                    if(from.AccessLevel > AccessLevel.Player)
                        from.SendGump(new GeopolGump(tresorier.Terre));
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
                    if (from.AccessLevel == AccessLevel.Player && from != tresorier.Gestionnaire)
                        break;
                    tresorier.ReponseAuGump(from, "Veuillez choisir le nouveau gestionnaire");
                    if (from == tresorier.Gestionnaire)
                        from.SendMessage("Veuillez prendre note que vous perdrez vos pouvoirs de gestionnaire.");
                    from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(ChangerGestionnaire_OnTarget));
                    break;

                case (int)Buttons.AjouterFonds:
                    tresorier.ReponseAuGump(from, "Combien désirez-vous ajouter?");
                    from.Prompt = new ModifierFondsPrompt(tresorier, true);
                    break;

                case (int)Buttons.RetirerFonds:
                    tresorier.ReponseAuGump(from, "Combien désirez-vous retirer?");
                    from.Prompt = new ModifierFondsPrompt(tresorier, false);
                    break;

                case (int)Buttons.AttacherTerre:
                    if (from.AccessLevel > AccessLevel.Player)
                    {
                        from.SendMessage("Veuillez choisir la nouvelle terre pour ce trésorier");
                        from.SendGump(new AttacherTerreGump(tresorier, Geopolitique.geopolitique, 0));
                    }
                    break;

            }
            if (button >= 100 && button < 100 + tresorier.EmployeCount)
            {
                if (!tresorier[button - 100].Removed)
                    from.SendGump(new EmployeGump(tresorier, tresorier[button - 100], true));
            }

        }

        private void ChangerGestionnaire_OnTarget(Mobile from, object targeted)
        {
            if (targeted is TMobile)
            {
                tresorier.ReponseAuGump(from, "Quel est le nom de ce nouveau gestionnaire?");
                from.Prompt = new NomGestionnairePrompt(tresorier, (Mobile)targeted);
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(ChangerGestionnaire_OnTarget));
            }
        }

        private class NomGestionnairePrompt : Prompt
        {
            private Tresorier tresorier;
            private Mobile gestionnaire;

            public NomGestionnairePrompt(Tresorier t, Mobile gest)
            {
                tresorier = t;
                gestionnaire = gest;
            }

            public override void OnResponse(Mobile from, string text)
            {
                tresorier.Gestionnaire = gestionnaire;
                tresorier.NomGestionnaire = text;
                tresorier.ReponseAuGump(from, "Le changement fut fait.");
            }

            public override void OnCancel(Mobile from)
            {
                tresorier.ReponseAuGump(from, "Le changement fut annulé");
                from.SendGump(new TresorierGump(tresorier, from, 0));
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
            private bool ajout;

            public ModifierFondsPrompt(Tresorier t, bool ajout)
            {
                this.t = t;
                this.ajout = ajout;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int amount;
                if (Int32.TryParse(text, out amount))
                {
                    if (ajout)
                        t.AjoutFonds(from, amount);
                    else
                        t.RetraitFonds(from, amount);
                    from.SendGump(new TresorierGump(t, from, 0));
                }
                else
                {
                    t.ReponseAuGump(from, String.Format("Je n'ai pas compris le montant que vous désirez {0}.",
                                                        ajout ? "ajouter" : "retirer"));
                    from.Prompt = new ModifierFondsPrompt(t, ajout);
                }
            }
        }


        private void AjouterEmploye_OnTarget(Mobile from, object targeted)
        {
            if (targeted is Mobile)
            {
                tresorier.ReponseAuGump(from, "Quel est le nom de ce nouvel employé?");
                from.Prompt = new NomEmployePrompt(tresorier, targeted as Mobile);
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AjouterEmploye_OnTarget));
            }
        }

        private class NomEmployePrompt : Prompt
        {
            private Tresorier tresorier;
            private Mobile employe;

            public NomEmployePrompt(Tresorier t, Mobile e)
            {
                tresorier = t;
                employe = e;
            }

            public override void OnResponse(Mobile from, string text)
            {
                tresorier.ReponseAuGump(from, "Quel est son titre?");
                from.Prompt = new TitreEmployePrompt(tresorier, employe, text);
            }

            public override void OnCancel(Mobile from)
            {
                tresorier.ReponseAuGump(from, "L'employé ne fut pas ajouté au registre.");
                from.SendGump(new TresorierGump(tresorier, from, 0));
            }
        }

        private class TitreEmployePrompt : Prompt
        {
            private Tresorier tresorier;
            private Mobile employe;
            private string nomEmploye;

            public TitreEmployePrompt(Tresorier t, Mobile e, string nom)
            {
                tresorier = t;
                employe = e;
                nomEmploye = nom;
            }

            public override void OnResponse(Mobile from, string text)
            {
                tresorier.ReponseAuGump(from, "Quel est le montant de sa paie mensuelle?");
                from.Prompt = new PaieEmployePrompt(tresorier, employe, nomEmploye, text);
            }

            public override void OnCancel(Mobile from)
            {
                tresorier.ReponseAuGump(from, "L'employé ne fut pas ajouté au registre.");
                from.SendGump(new TresorierGump(tresorier, from, 0));
            }
        }

        private class PaieEmployePrompt : Prompt
        {
            private Tresorier tresorier;
            private Mobile employe;
            private string nomEmploye;
            private string titreEmploye;

            public PaieEmployePrompt(Tresorier t, Mobile e, string nom, string titre)
            {
                tresorier = t;
                employe = e;
                nomEmploye = nom;
                titreEmploye = titre;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int montant;
                if (Int32.TryParse(text, out montant))
                {
                    tresorier.ReponseAuGump(from, "L'employé fut  ajouté au registre.");
                    tresorier.AddEmploye(employe, nomEmploye, titreEmploye, montant);
                    from.SendGump(new TresorierGump(tresorier, from, 0));
                }
                else
                {
                    from.SendMessage("Vous devez indiquer un nombre.");
                    from.Prompt = new PaieEmployePrompt(tresorier, employe, nomEmploye, titreEmploye);
                }
            }

            public override void OnCancel(Mobile from)
            {
                tresorier.ReponseAuGump(from, "L'employé ne fut pas ajouté au registre.");
                from.SendGump(new TresorierGump(tresorier, from, 0));
            }

        }

        private class AttacherTerreGump : Gump
        {

            private Tresorier tresorier;
            private Categorie cat;

            private int page;

            public AttacherTerreGump(Tresorier tr, Categorie ct, int page)
                : base(0, 0)
            {
                tresorier = tr;
                cat = ct;
                this.page = page;

                this.Closable = true;
                this.Disposable = true;
                this.Dragable = true;
                this.Resizable = false;

                AddPage(0);
                AddBackground(31, 48, 416, 440, 9250);
                AddBackground(39, 56, 400, 424, 3500);

                AddLabel(174, 75, 1301, cat.Nom == "" ? @"Rentes et Géopolitique" : cat.Nom);

                if (cat.Parent != null)
                {
                    AddButton(72, 99, 4014, 4015, (int)Buttons.MenuPrecedent, GumpButtonType.Reply, 0);
                    AddLabel(108, 100, 1301, @"Menu Précédent");
                }

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

                if (page < maxpages)
                    AddButton(402, 418, 5601, 5605, (int)Buttons.NextPage, GumpButtonType.Reply, 0);
                if (page > 0)
                    AddButton(59, 418, 5603, 5607, (int)Buttons.PreviousPage, GumpButtonType.Reply, 0);

            }

            public enum Buttons
            {
                MenuPrecedent = 1,
                NextPage,
                PreviousPage,
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                int b = info.ButtonID;
                Mobile from = sender.Mobile;

                if (b == (int)Buttons.MenuPrecedent)
                    from.SendGump(new AttacherTerreGump(tresorier, cat.Parent, 0));
                else if (b == (int)Buttons.NextPage)
                    from.SendGump(new AttacherTerreGump(tresorier, cat, page + 1));
                else if (b == (int)Buttons.PreviousPage)
                    from.SendGump(new AttacherTerreGump(tresorier, cat, page - 1));
                else if (b >= 100 && b < 100 + cat.CategoriesCount)
                    from.SendGump(new AttacherTerreGump(tresorier, cat.CategorieParIndex(b - 100), 0));
                else if (b >= 200 && b < 200 + cat.TerresCount)
                {
                    tresorier.Terre = cat.TerreParIndex(b - 200);
                    from.SendGump(new TresorierGump(tresorier, from, 0));
                }
            }
        }
    }
}
