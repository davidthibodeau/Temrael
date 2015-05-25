using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Items;
using Server.Commands;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Misc.PVP.Gumps
{
    public class PVPGumpCreation : GumpTemrael
    {
        Mobile m_From;
        PVPEvent m_Pvpevent;

        int x = 50;
        int y = 50;

        int line = 0;
        int scale = 25;

        int NbLignes = 0;

        const int NbMapModeMax = 10;

        public PVPGumpCreation(Mobile from, PVPStone stone)
            : this(from, new PVPEvent(stone))
        {
        }

        public PVPGumpCreation(Mobile from, PVPEvent pvpevent)
            : base("", 0, 0)
        {
            m_From = from;
            m_Pvpevent = pvpevent;

            from.CloseGump(typeof(PVPGumpCreation));

            if (m_Pvpevent != null)
            {
                AddPage(0);

                TrouverNbLignes();

                AddBackground(0, 0, 450, 100 + (NbLignes * scale), 5054); // Taille du background dépendant du nombre de lignes.

                SetEvent();
            }
        }

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * NbMapModeMax);
        }

        // Une modification à cette fonction risque d'en amener une chez SetEvent. Faire attention.
        private void TrouverNbLignes()
        {
            // Nom du combat.
            if (m_Pvpevent.nom == "")
            {
                NbLignes = 2 + 1 + 1; // Entête + textbox + suivant.
            }
            // Choix de map.
            else if (m_Pvpevent.map == null)
            {
                NbLignes = PVPMap.MapList.Count + 2; // Nb de map possible + entête.
            }
            // Choix du genre d'équipes
            else if (m_Pvpevent.teams == null)
            {
                NbLignes = PVPTeamArrangement.TeamArrangementList.Count + 2; // Nb possible + entête.
            }
            // Choix de mode.
            else if (m_Pvpevent.mode == null)
            {
                NbLignes = PVPMode.ModeList.Count + 2; // Nb possible + entête.
            }
            // Choix du nombre d'équipes.
            else if (m_Pvpevent.teams.Count == 0 && m_Pvpevent.teams.NbMaxEquipes != 0)
            {
                NbLignes = 2 + 1 + 1; // Entête + textbox + suivant.
            }
            // Choix de date.
            else if (m_Pvpevent.debutEvent <= DateTime.Now)
            {
                NbLignes = 2 + 2 + 1; // Entête + textbox + suivant.
            }
            // Résumé et confirmation.
            else
            {
                NbLignes = 2 + 8; // Entête + textbox.
            }
        }

        // Une modification à cette fonction risque d'en amener une chez TrouverNbLignes. Faire attention.
        private void SetEvent()
        {
            AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "PVP" + "</h3>", false, false);
            line += 2;

            // Nom du combat.
            if (m_Pvpevent.nom == "")
            {
                AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Nom du combat : " + "</h3>", false, false);
                AddTextEntry(x + 150, y + (line * scale), 450, 20, 0, 0, m_Pvpevent.nom);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(7, 0), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 400, 20, "<h3> Suivant </h3>", false, false);
                line++;
            }
            // Choix de map.
            else if (m_Pvpevent.map == null)
            {
                int cpt = 0;
                foreach (PVPMap map in PVPMap.MapList)
                {
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(1, cpt), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>" + map.Name + "</h3>", false, false);
                    line++;
                    cpt++;
                }
            }
            // Choix du genre d'équipes
            else if (m_Pvpevent.teams == null)
            {
                int cpt = 0;
                foreach (Type mode in PVPTeamArrangement.TeamArrangementList.Keys)
                {
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(2, cpt), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>" + PVPTeamArrangement.TeamArrangementList[mode] + "</h3>", false, false);
                    line++;

                    cpt++;
                }
            }
            // Choix de mode.
            else if (m_Pvpevent.mode == null)
            {
                int cpt = 0;
                foreach (Type mode in PVPMode.ModeList.Keys)
                {
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(3, cpt), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>" + PVPMode.ModeList[mode] + "</h3>", false, false);
                    line++;

                    cpt++;
                }
            }
            // Choix du nombre d'équipes.
            else if (m_Pvpevent.teams.Count == 0 && m_Pvpevent.teams.NbMaxEquipes != 0)
            {
                AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Nombre d'équipes (1 à " + m_Pvpevent.map.GetNbSpawnPoints() + ") : " + "</h3>", false, false);
                AddTextEntry(x + 185, y + (line * scale), 450, 20, 0, 4, m_Pvpevent.teams.Count.ToString());
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(7, 0), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 400, 20, "<h3> Suivant </h3>", false, false);
                line++;
            }
            // Choix de date.
            else if (m_Pvpevent.debutEvent <= DateTime.Now)
            {
                line--;
                AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Format :", false, false);
                AddHtml(x + 155, y + (line * scale), 450, 20, "<h3>" + "aaaa-mm-jj_hh:mm:ss", false, false);
                line++;
                AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Date du combat : " + "</h3>", false, false);
                AddTextEntry(x + 155, y + (line * scale), 450, 20, 0, 5, m_Pvpevent.debutEvent.ToString());
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(7, 0), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 400, 20, "<h3> Suivant </h3>", false, false);
                line++;
            }
            // Résumé et confirmation.
            else
            {
                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(6, 1), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Nom </h3>", false, false);
                AddHtml(x + 150, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.nom + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(6, 2), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Date </h3>", false, false);
                AddHtml(x + 150, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.debutEvent.ToString() + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(6, 3), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Map </h3>", false, false);
                AddHtml(x + 150, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.map.Name + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(6, 4), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Team Arr. </h3>", false, false);
                AddHtml(x + 150, y + (line * scale), 450, 20, "<h3>" + PVPTeamArrangement.TeamArrangementList[m_Pvpevent.teams.GetType()] + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(6, 5), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Mode </h3>", false, false);
                AddHtml(x + 150, y + (line * scale), 450, 20, "<h3>" + PVPMode.ModeList[m_Pvpevent.mode.GetType()] + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(6, 6), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Team Count </h3>", false, false);
                AddHtml(x + 150, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.teams.Count + "</h3>", false, false);
                line += 3;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(6, 0), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 400, 20, "<h3> Commencer l'événement ! </h3>", false, false);
            }
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % NbMapModeMax;
            int index = buttonID / NbMapModeMax;

            Console.WriteLine(buttonID + " " + type + " " + index);


            if (buttonID == -1)
            {
                m_Pvpevent.StopEvent();
                return;
            }

            // 0 Nom
            TextRelay relay = info.GetTextEntry(0);
            if (relay != null)
            {
                if (relay.Text != null)
                {
                    m_Pvpevent.nom = relay.Text;
                }
            }

            // 1 Map
            if(type == 1)
            {
                m_Pvpevent.SetMapByID(index);
            }

            // 2 Teams

            if (type == 2)
            {
                m_Pvpevent.SetTeamByID(index);
            }

            // 3 Mode
            if(type == 3)
            {
                m_Pvpevent.SetModeByID(index);
            }

            // 4 Teams
            relay = info.GetTextEntry(4);
            if (relay != null)
            {
                if (relay.Text != null)
                {
                    int value = 0;
                    if (int.TryParse(relay.Text, out value))
                    {
                        if (value > 0 && value <= m_Pvpevent.map.GetNbSpawnPoints())
                        {
                            m_Pvpevent.teams.SetNbEquipe(value);
                        }
                    }
                }
            }

            // 5 Date
            relay = info.GetTextEntry(5);
            if (relay != null)
            {
                if (relay.Text != null)
                {
                    DateTime time;
                    if (DateTime.TryParse(relay.Text, out time))
                    {
                        m_Pvpevent.debutEvent = time;
                    }
                }
            }

            // 6 Résumé.
            if (type == 6)
            {
                switch (index)
                {
                    case 0: // Confirmation des settings de l'evenement.
                        {
                            if (m_Pvpevent.PrepareEvent())
                            {
                                m_From.CloseGump(typeof(PVPGumpCreation));
                                return;
                            }
                            else
                            {
                                m_From.SendMessage("Il y a un bug dans le gump de PVP, merci de le rapporter à l'équipe !");
                            }
                            break;
                        }
                    case 1:
                        {
                            m_Pvpevent.nom = "";
                            break;
                        }
                    case 2:
                        {
                            m_Pvpevent.debutEvent = DateTime.Now;
                            break;
                        }
                    case 3:
                        {
                            m_Pvpevent.map = null;
                            break;
                        }
                    case 4:
                        {
                            m_Pvpevent.teams = null;
                            break;
                        }
                    case 5:
                        {
                            m_Pvpevent.mode = null;
                            break;
                        }
                    case 6:
                        {
                            m_Pvpevent.teams.SetNbEquipe(0);
                            break;
                        }
                }
            }

            // Bouton #6 Fait un refresh de la page.

            m_From.SendGump(new PVPGumpCreation((Mobile)m_From, m_Pvpevent));
        }
    }
}
