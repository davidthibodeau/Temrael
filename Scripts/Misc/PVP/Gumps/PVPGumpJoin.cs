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
    public class PVPGumpJoin : GumpTemrael
    {
        Mobile m_From;
        int m_page = 0;

        int x = 50;
        int y = 50;

        int line = 0;
        int scale = 25;
        const int columnScale = 50;

        const int NbEventParPage = 10;

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * NbEventParPage);
        }

        public PVPGumpJoin(Mobile from)
            : this(from, 0)
        {
        }

        private PVPGumpJoin(Mobile from, int page)
            : base("",0,0)
        {
            m_From = from;
            m_page = page;

            m_From.CloseGump(typeof(PVPGumpJoin));

            AddBackground(0, 0, 950, 735, 5054);

            int column = 1;

            AddHtml(400, y + (line * scale), 150, 20, "<h3>" + "Inscriptions" + "</h3>", false, false);
            AddHtml(750, y + (line * scale), 150, 20, "<h3>" + "Page : " + m_page.ToString() + "</h3>", false, false);
            line+=2;
            AddHtml(x + (column * columnScale), y + (line * scale), 150, 20, "<h3>" + "Nom" + "</h3>", false, false);
            column+= 3;
            AddHtml(x + (column * columnScale), y + (line * scale), 200, 20, "<h3>" + "Date" + "</h3>", false, false);
            column += 4;
            AddHtml(x + (column * columnScale), y + (line * scale), 150, 20, "<h3>" + "Map" + "</h3>", false, false);
            column += 3;
            AddHtml(x + (column * columnScale), y + (line * scale), 100, 20, "<h3>" + "Mode" + "</h3>", false, false);
            column += 2;
            AddHtml(x + (column * columnScale), y + (line * scale), 100, 20, "<h3>" + "Joueurs" + "</h3>", false, false);
            column += 2;
            AddHtml(x + (column * columnScale), y + (line * scale), 100, 20, "<h3>" + "État" + "</h3>", false, false);
            line++;
            AddImageTiled(15, y + (line * scale), 930, 3, 96);
            line++;

            PVPEvent m_Pvpevent;
            for (int i = 0; i < NbEventParPage; ++i)
            {
                column = 0;
                try
                {
                    m_Pvpevent = (PVPEvent)PVPEvent.m_InstancesList[(page * NbEventParPage) + i];
                }
                catch (Exception)
                {
                    line += ((2* (NbEventParPage - i))-1);
                    break;
                }

                if (m_Pvpevent.EstInscrit(m_From))
                {
                    // Bouton inscrit.
                    AddButton(x + (column * columnScale), y + (line * scale), 0xFB7, 0xFB9, GetButtonID(1,i), GumpButtonType.Reply, 0);
                }
                else
                {
                    // Bouton non inscrit.
                    AddButton(x + (column * columnScale), y + (line * scale), 0xFB1, 0xFB3, GetButtonID(2,i), GumpButtonType.Reply, 0);
                }
                column++;

                // Marquage des infos relatif au PVPEvent.
                //Nom
                AddHtml(x + (column * columnScale), y + (line * scale), 150, 20, "<h3>" + m_Pvpevent.nom + "</h3>", false, false);
                column += 3;
                //Date
                AddHtml(x + (column * columnScale), y + (line * scale), 200, 20, "<h3>" + m_Pvpevent.debutEvent.ToString() + "</h3>", false, false);
                column += 4;
                //Map
                AddHtml(x + (column * columnScale), y + (line * scale), 150, 20, "<h3>" + m_Pvpevent.map.Name + "</h3>", false, false);
                column += 3;
                //Mode
                AddHtml(x + (column * columnScale), y + (line * scale), 100, 20, "<h3>" + m_Pvpevent.mode.GetType().Name + "</h3>", false, false);
                column += 2;
                //Joueurs
                AddHtml(x + (column * columnScale), y + (line * scale), 100, 20, "<h3>" + m_Pvpevent.TotalJoueursInscrit() + "</h3>", false, false);
                // État
                column += 2;
                AddHtml(x + (column * columnScale), y + (line * scale), 100, 20, "<h3>" + m_Pvpevent.state.ToString() + "</h3>", false, false);

                line++;
                if (i != NbEventParPage - 1)
                {
                    AddImageTiled(50, y + (line * scale), 800, 3, 96);
                    line++;
                }
            }

            line++;
            AddImageTiled(15, y + (line * scale), 930, 3, 96);
            line++;

            // Bouton pour rafraîchir.
            AddButton(100, y + (line * scale), 0xFB1, 0xFB3, GetButtonID(3, 0), GumpButtonType.Reply, 0);
            AddHtml(150, y + (line * scale), 150, 20, "<h3> Rafraîchir </h3>", false, false);

            // Page precedente
            AddHtml(600, y + (line * scale), 150, 20, "<h3> Precedent </h3>", false, false);
            AddButton(690, y + (line * scale), 0xFAE, 0xFB0, GetButtonID(4, 0), GumpButtonType.Reply, 0);
            // Page suivante
            AddButton(715, y + (line * scale), 0xFA5, 0xFA7, GetButtonID(5, 0), GumpButtonType.Reply, 0);
            AddHtml(755, y + (line * scale), 150, 20, "<h3> Suivant </h3>", false, false);
        }



        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % NbEventParPage;
            int index = buttonID / NbEventParPage;

            if (buttonID == -1)
            {
                return;
            }

            switch(type)
            {
                case 1: // Se desinscrire
                    {
                        ((PVPEvent)PVPEvent.m_InstancesList[(m_page * NbEventParPage) + index]).Desinscrire(sender.Mobile);
                        break;
                    }
                case 2: // S'inscrire
                    {
                        m_From.SendMessage("Vous pouvez choisir un numero d'équipe ( entre 0 et " + (((PVPEvent)PVPEvent.m_InstancesList[(m_page * NbEventParPage) + (int)index]).teams.Count - 1).ToString() + " ) :");
                        m_From.BeginPrompt(new PromptStateCallback(PromptCallBack),index);
                        break;
                    }
                /*case 3: // Rafraichir la page
                    {

                    }*/
                case 4: // Page precedente
                    {
                        try
                        {
                            if (PVPEvent.m_InstancesList[(m_page - 1) * NbEventParPage] != null)
                            {
                                m_page--;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    }
                case 5: // Page suivante
                    {
                        try
                        {
                            if (PVPEvent.m_InstancesList[(m_page + 1) * NbEventParPage] != null)
                            {
                                m_page++;
                            }
                        }
                        catch (Exception)
                        {
                        }
                        break;
                    }
            }

            m_From.SendGump(new PVPGumpJoin((Mobile)m_From, m_page));
        }

        private void PromptCallBack(Mobile m, String s, object index)
        {
            int result = 0;
            if(int.TryParse(s, out result))
            {
                ((PVPEvent)PVPEvent.m_InstancesList[(m_page * NbEventParPage) + (int)index]).Inscrire(m, result);
            }
            else
            {
                m.SendMessage("Nombre invalide.");
            }

            m_From.SendGump(new PVPGumpJoin((Mobile)m_From, m_page));
        }
    }
}
