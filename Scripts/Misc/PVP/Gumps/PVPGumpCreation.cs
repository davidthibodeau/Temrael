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

namespace Server.Misc.PVP
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
                NbLignes = 2 + 1; // Entête + textbox.
            }
            // Choix de date.
            else if (m_Pvpevent.debutEvent <= DateTime.Now)
            {
                NbLignes = 2 + 1; // Entête + textbox.
            }
            // Choix de map.
            else if (m_Pvpevent.map == null)
            {
                NbLignes = PVPMap.MapList.Count + 2; // Nb de map possible + 1 Pour l'entête.
            }
            // Choix de mode.
            else if (m_Pvpevent.mode == null)
            {
                NbLignes = PVPMode.ModeList.Count + 2; // Nb de modes possible + 1 Pour l'entête.
            }
            // Choix du nombre d'équipes.
            else if (m_Pvpevent.teams.Count == 0)
            {
                NbLignes = 2 + 1; // Entête + textbox.
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
            }
            // Choix de date.
            else if (m_Pvpevent.debutEvent <= DateTime.Now)
            {
                AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Date du combat : " + "</h3>", false, false);
                AddTextEntry(x + 155, y + (line * scale), 450, 20, 0, 1, m_Pvpevent.debutEvent.ToString());
                line++;
            }
            // Choix de map.
            else if (m_Pvpevent.map == null)
            {
                int cpt = 0;
                foreach (PVPMap map in PVPMap.MapList)
                {
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(2, cpt), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>" + map.Name + "</h3>", false, false);
                    line++;
                    cpt++;
                }
            }
            // Choix de mode.
            else if (m_Pvpevent.mode == null)
            {
                int cpt = 0;
                foreach (Type mode in PVPMode.ModeList)
                {
                    AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(3, cpt), GumpButtonType.Reply, 0);
                    AddHtml(x + 35, y + (line * scale), 400, 20, "<h3>" + mode.Name + "</h3>", false, false);
                    line++;
                    cpt++;
                }
            }
            // Choix du nombre d'équipes.
            else if (m_Pvpevent.teams.Count == 0)
            {
                AddHtml(x, y + (line * scale), 450, 20, "<h3>" + "Nombre d'équipes (1 à " + m_Pvpevent.map.GetNbSpawnPoints() + ") : " + "</h3>", false, false);
                AddTextEntry(x + 185, y + (line * scale), 450, 20, 0, 4, m_Pvpevent.teams.Count.ToString());
                line++;
            }
            // Résumé et confirmation.
            else
            {
                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(5, 1), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Nom </h3>", false, false);
                AddHtml(x + 120, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.nom + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(5, 2), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Date </h3>", false, false);
                AddHtml(x + 120, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.debutEvent.ToString() + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(5, 3), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Map </h3>", false, false);
                AddHtml(x + 120, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.map.Name + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(5, 4), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Mode </h3>", false, false);
                AddHtml(x + 120, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.mode.GetType().Name + "</h3>", false, false);
                line++;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(5, 5), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 450, 20, "<h3> Teams </h3>", false, false);
                AddHtml(x + 120, y + (line * scale), 450, 20, "<h3>" + m_Pvpevent.teams.Count + "</h3>", false, false);
                line += 3;

                AddButton(x, y + (line * scale), 4005, 4007, GetButtonID(5, 0), GumpButtonType.Reply, 0);
                AddHtml(x + 35, y + (line * scale), 400, 20, "<h3> Commencer l'événement ! </h3>", false, false);
            }
        }


        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % NbMapModeMax;
            int index = buttonID / NbMapModeMax;


            // 0 Nom
            TextRelay relay = info.GetTextEntry(0);
            if (relay != null)
            {
                if (relay.Text != null)
                {
                    m_Pvpevent.nom = relay.Text;
                }
            }
            // 1 Date
            relay = info.GetTextEntry(1);
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

            // 2 Map
            if(type == 2)
            {
                m_Pvpevent.SetMap(index);
            }

            // 3 Mode
            if(type == 3)
            {
                m_Pvpevent.SetMode(index);
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
                            m_Pvpevent.SetNbEquipe(value);
                        }
                    }
                }
            }

            // 5 Résumé.
            if (type == 5)
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
                            m_Pvpevent.mode = null;
                            break;
                        }
                    case 5:
                        {
                            m_Pvpevent.SetNbEquipe(0);
                            break;
                        }
                }
            }

            m_From.SendGump(new PVPGumpCreation((Mobile)m_From, m_Pvpevent));
        }
    }
}
