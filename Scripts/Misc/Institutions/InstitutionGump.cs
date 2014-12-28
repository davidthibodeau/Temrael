using System;
using System.Collections;
using System.Collections.Generic;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Commands;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Engines.Institutions
{
    public class Institution
    {
        public static void Initialize()
        {
            CommandSystem.Register("Institution", AccessLevel.Player, new CommandEventHandler(Institution_OnCommand));
        }

        [Usage("Institution")]
        [Description("Permet d'ouvrir le menu de gérance des institutions.")]
        public static void Institution_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from is PlayerMobile)
            {
                from.SendGump(new InstitutionGump((Mobile)from));
            }
        }
    }

    class InstitutionGump : GumpTemrael
    {
        // https://docs.google.com/drawings/d/1oLILHTfi4ERtvJFgqBu8g4X0pzkVz6jvDS58kewMROk/edit?usp=sharing

        /* Faire un gump qui permettrait aux joueurs de voir leur rang à l'intérieur de l'institution.
           Ainsi qu'un gump différent pour les GMs qui leur permettrait de rank up ou rank down un 
           joueur au sein de l'institution. Le gump devrait aussi donner l'option de pouvoir ouvrir
           un sac, dans lequel on pourrait mettre les items à duper.
         */

        private Mobile m_From;
        private int m_Page;

        private InstitutionHandler m_Institution;

        int x = 20;
        int y = 20;

        int line = 0;
        int scale = 25;

        public InstitutionGump(Mobile from)
            : this(from, 0)
        {
        }

        public InstitutionGump(Mobile from, int cur_page)
            : base("", 0, 0)
        {
            m_From = from;
            m_Page = cur_page;
            m_Institution = null;
            try
            {
                m_Institution = (InstitutionHandler)InstitutionHandler.m_InstancesList[m_Page];
            }
            catch( Exception ) // Outofbounds... etc.
            {
                m_Institution = null;
                m_From.SendMessage("Aucune institution existante.");
            }

            from.CloseGump(typeof(InstitutionGump));

            if (m_Institution != null)
            {
                AddPage(0);

                if (m_From.AccessLevel >= AccessLevel.Chroniqueur)
                    AddBackground(0, 0, 500, 550, 5054);
                else
                    AddBackground(0, 0, 500, 425, 5054);

                AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Gérance d'institution" + "</h3>", false, false);
                line++;

                if (m_From.AccessLevel >= AccessLevel.Chroniqueur)
                {
                    // En faire une boite de texte modifiable, avec m_Institution.Description comme string par défaut ?
                    AddSection(x, y + (line * scale), 450, 120, "<h3>Description<h3>", "");
                    AddTextEntry(x, y + (line * scale), 450, 120, 0, 0, m_Institution.Description);
                    line += 8;

                    // Bouton qui permet de modifier m_Institution.Description
                    //

                    AddHtml(x, y + (line * scale), 400, 20, "<h3>Rangs/Titres</h3>", false, false);
                    line++;

                    int cpt = 1;
                    foreach (string titre in m_Institution.RangTitre)
                    {
                        AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(0, 0), GumpButtonType.Reply, 0);
                        AddTextEntry(x + 35, y + (line * scale), 400, 20, 0, cpt, titre);
                        cpt++;
                        line++;
                    }

                    line++;
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(1, 0), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Augmenter le rang d’un joueur</h3>", false, false);
                    line++;
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(1, 1), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Diminuer le rang d’un joueur</h3>", false, false);
                    line++;
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(2, 0), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Ajouter un joueur</h3>", false, false);
                    line++;
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(2, 1), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Retirer un joueur</h3>", false, false);
                    line++;
                }
                else
                {
                    AddSection(x, y + (line * scale), 450, 120, "<h3>Description<h3>", m_Institution.Description);
                    line += 8;
                    AddHtml(x, y + (line * scale), 400, 20, "<h3>Rangs/Titres</h3>", false, false);
                    line++;

                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Votre titre/rang est: " + m_Institution.GetTitre( m_Institution.GetRank( m_From)) + "</h3>", false, false);
                    line++;
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(3, 0), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Je veux joindre l'institution</h3>", false, false);
                    line++;
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(3, 1), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Je veux quitter l'institution</h3>", false, false);
                    line++;
                }

                line++;
                AddButton(x, y + (line * scale), 4017, 4019, 0, GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Quitter</h3>", false, false);
            }
        }

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * 4);
        }

        private void AjouterMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                m_Institution.AjouterInstitution((Mobile)targeted);
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AjouterMobile_OnTarget));
            }
        }

        private void RetirerMobile_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                m_Institution.RetirerInstitution((Mobile)targeted);
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RetirerMobile_OnTarget));
            }
        }

        private void AugmenterRang_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                m_Institution.RankUp((Mobile)targeted);
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AugmenterRang_OnTarget));
            }
        }

        private void DiminuerRang_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                m_Institution.RankDown((Mobile)targeted);
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(DiminuerRang_OnTarget));
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (info.ButtonID <= 0)
                return; // Canceled

            int buttonID = info.ButtonID - 1;
            int type = buttonID % 4;
            int index = buttonID / 4;

            TextRelay relay = info.GetTextEntry(1);
            m_Institution.Description = relay.Text;

            int cpt = 1;
            foreach( string s in m_Institution.RangTitre)
            {
                TextRelay relay2 = info.GetTextEntry(cpt);
                s = relay2.Text;
                cpt++;
            }

            switch (type)
            {
                case 0: // Containers
                    {
                        m_From.SendMessage("N'a pas été scripté encore");
                        break;
                    }
                case 1: // Misc. buttons
                {
                    switch (index)
                    {
                        case 0: // Augmenter le rang d’un joueur
                            {
                                m_From.SendMessage("Augmenter le rang d’un joueur");
                                m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AugmenterRang_OnTarget));
                                break;
                            }
                        case 1: // Diminuer le rang d’un joueur
                            {
                                m_From.SendMessage("Diminuer le rang d’un joueur");
                                m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(DiminuerRang_OnTarget));
                                break;
                            }
                    }
                    break;
                }
                case 2: // Misc. buttons
                {
                    switch (index)
                    {
                        case 0: // Ajouter un mobile à la liste des joueurs dans l'institution.
                            {
                                m_From.SendMessage("Ajouter un joueur à la liste des joueurs dans l'institution.");
                                m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(AjouterMobile_OnTarget));
                                break;
                            }
                        case 1: // Retire un mobile de la liste des joueurs dans l'institution
                            {
                                m_From.SendMessage("Retirer un joueur de la liste des joueurs dans l'institution");
                                m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(RetirerMobile_OnTarget));
                                break;
                            }
                    }
                    break;
                }
                case 3: // Misc. buttons
                {
                    switch (index)
                    {
                        case 0: // Je veux joindre l'institution
                            {
                                m_From.SendMessage("Je veux joindre l'institution");
                                m_Institution.AjouterInstitution((Mobile)m_From);
                                break;
                            }
                        case 1: // Je veux quitter l'institution
                            {
                                m_From.SendMessage("Je veux quitter l'institution");
                                m_Institution.RetirerInstitution((Mobile)m_From);
                                break;
                            }
                    }
                    break;
                }
            }
            m_From.SendGump(new InstitutionGump((Mobile)m_From));
        }
    }
}
