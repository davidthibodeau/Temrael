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
    class InstitutionGump : GumpTemrael
    {
        // https://docs.google.com/drawings/d/1oLILHTfi4ERtvJFgqBu8g4X0pzkVz6jvDS58kewMROk/edit?usp=sharing

        /* Faire un gump qui permettrait aux joueurs de voir leur rang à l'intérieur de l'institution.
           Ainsi qu'un gump différent pour les GMs qui leur permettrait de rank up ou rank down un 
           joueur au sein de l'institution. Le gump devrait aussi donner l'option de pouvoir ouvrir
           un sac, dans lequel on pourrait mettre les items à duper.
         */

        private Mobile m_From;

        private InstitutionHandler m_Institution;

        int x = 20;
        int y = 20;

        int line = 0;
        int scale = 25;

        public InstitutionGump(Mobile from, InstitutionHandler handler)
            : base("", 0, 0)
        {
            m_From = from;
            m_Institution = handler;

            from.CloseGump(typeof(InstitutionGump));

            if (m_Institution != null)
            {
                AddPage(0);

                if (m_From.AccessLevel >= AccessLevel.Chroniqueur)
                    AddBackground(0, 0, 500, 525, 5054);
                else
                    AddBackground(0, 0, 500, 400, 5054);

                if (m_From.AccessLevel >= AccessLevel.Chroniqueur)
                {
                    AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Gérance d'institution : " + "</h3>", false, false);
                    AddTextEntry(x + 160, y + (line * scale), 450, 160, 0, 0, m_Institution.Titre);
                    line++;

                    AddHtml(x, y + (line * scale), 450, 20, "<h3>Description : <h3>", false, false);
                    line++;
                    AddTextEntry(x, y + (line * scale), 450, 160, 0, 1, m_Institution.Description);
                    line += 6;

                    AddHtml(x, y + (line * scale), 400, 20, "<h3>Rangs/Titres</h3>", false, false);
                    line++;

                    // Donne un bouton container et un text entry pour chaque rang. N'affiche pas le rang 0 qui est "Aucun titre".
                    int count = m_Institution.RangTitre.Count - 1;
                    for (int i = 1; i <= count; i++)
                    {
                        AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(0, i), GumpButtonType.Reply, 0);
                        AddTextEntry(x + 35, y + (line * scale), 400, 20, 0, i+1, m_Institution.RangTitre[i]);
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
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(3, 2), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Obtenir des infos sur un joueur</h3>", false, false);
                    line++;
                }
                else
                {
                    AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Institution : " + m_Institution.Titre + "</h3>", false, false);
                    line++;

                    AddSection(x, y + (line * scale), 450, 120, "<h3>Description<h3>", m_Institution.Description);
                    line += 8;

                    int rank = m_Institution.GetRank(m_From);
                    if (rank == -1)
                    {
                        AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Vous n'êtes pas membre de l'institution.</h3>", false, false);
                        line++;
                    }
                    else
                    {
                        AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Votre titre/rang est : " + m_Institution.GetTitre(m_Institution.GetRank(m_From)) + "</h3>", false, false);
                        line++;
                        AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Votre salaire est de : " + InstitutionHandler.GetSalaire(m_Institution.GetRank(m_From)) + " pièces d'or" + "</h3>", false, false);
                    }
                    line += 2;

                    if (rank == -1)
                    {
                        AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(3, 0), GumpButtonType.Reply, 0);
                        AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Je veux joindre l'institution</h3>", false, false);
                        line++;
                    }
                    else
                    {
                        AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(3, 1), GumpButtonType.Reply, 0);
                        AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>Je veux quitter l'institution</h3>", false, false);
                        line++;
                    }
                }
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
                from.SendMessage("Le joueur a été rajouté à l'institution.");
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
                from.SendMessage("Le joueur a été retiré de l'institution.");
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
                from.SendMessage("Son rang est maintenant : " + m_Institution.GetTitre(m_Institution.GetRank((Mobile)targeted)));
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
                from.SendMessage("Son rang est maintenant : " + m_Institution.GetTitre(m_Institution.GetRank((Mobile)targeted)));
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(DiminuerRang_OnTarget));
            }
        }

        private void Infos_OnTarget(Mobile from, object targeted)
        {
            if (targeted is PlayerMobile)
            {
                from.SendMessage("INSTITUTION : " + m_Institution.Titre);
                from.SendMessage("RANG : " + m_Institution.GetRank((Mobile)targeted));
                from.SendMessage("TITRE : " + m_Institution.GetTitre(m_Institution.GetRank((Mobile)targeted)));
                from.SendMessage("SALAIRE : " + InstitutionHandler.GetSalaire(m_Institution.GetRank((Mobile)targeted)));
            }
            else
            {
                from.SendMessage("Vous devez choisir un joueur");
                from.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(DiminuerRang_OnTarget));
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % 4;
            int index = buttonID / 4;

            // Update du titre.
            TextRelay relay = info.GetTextEntry(0);
            if (relay != null)
            {
                if (relay.Text != null)
                {
                    m_Institution.Titre = relay.Text;
                }
                else
                {
                    m_Institution.Titre = "";
                }
            }

            // Update de la description.
            relay = info.GetTextEntry(1);
            if (relay != null)
            {
                if (relay.Text != null)
                {
                    m_Institution.Description = relay.Text;
                }
                else
                {
                    m_Institution.Description = "";
                }
            }

            // Update des titres pour chaque rang.
            int count = m_Institution.RangTitre.Count-1;
            for (int i = 1; i <= count; i++)
            {
                TextRelay relay2 = info.GetTextEntry(i+1);

                if( relay2 != null)
                    m_Institution.RangTitre[i] = relay2.Text;
            }

            if (info.ButtonID <= 0)
                return; // Canceled

            switch (type)
            {
                case 0: // Containers
                    {
                        if (m_Institution.Containers[index] == null)
                        {
                            Bag b = new Bag();
                            b.Visible = false;
                            b.Map = m_Institution.Map;
                            b.Location = new Point3D(m_Institution.Location.X, m_Institution.Location.Y, m_Institution.Location.Z - 50); // Berk, mais le seul moyen que j'ai trouvé.

                            m_Institution.Containers[index] = b;
                        }

                        m_Institution.Containers[index].DisplayTo(m_From);
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
                                m_From.SendMessage("Vous joignez l'institution.");
                                m_Institution.AjouterInstitution((Mobile)m_From);
                                break;
                            }
                        case 1: // Je veux quitter l'institution
                            {
                                m_From.SendMessage("Vous quittez l'institution.");
                                m_Institution.RetirerInstitution((Mobile)m_From);
                                break;
                            }
                        case 2: // Infos
                            {
                                m_From.SendMessage("Obtenir des informations sur un joueur.");
                                m_From.BeginTarget(-1, false, TargetFlags.None, new TargetCallback(Infos_OnTarget));
                                break;
                            }
                    }
                    break;
                }
            }

            m_From.SendGump(new InstitutionGump((Mobile)m_From, m_Institution));
        }
    }
}
