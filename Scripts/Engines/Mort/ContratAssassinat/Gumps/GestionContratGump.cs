using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Engines.Mort
{
    public class GestionContratGump : GumpTemrael
    {
        public static void Initialize()
        {
            CommandSystem.Register("GererContrat", AccessLevel.Player, new CommandEventHandler(GererContrat_OnCommand));
        }

        [Usage("GererContrat")]
        [Description("Permet de gérer les contrats que vous possédez.")]
        public static void GererContrat_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                e.Mobile.SendGump(new GestionContratGump((PlayerMobile)e.Mobile));
            }
        }

        PlayerMobile m_from;
        int m_page;

        int x = 50;
        int y = 50;

        int line = 0;
        int scale = 25;
        const int columnScale = 50;

        const int NbContratParPage = 10;

        public static int GetButtonID(int type, int index)
        {
            return 1 + type + (index * NbContratParPage);
        }

        public GestionContratGump(PlayerMobile from)
            : this(from, 0)
        {
        }

        public GestionContratGump(PlayerMobile from, int page)
            : base("", 0, 0)
        {
            m_from = from;
            m_page = page;

            m_from.CloseGump(typeof(GestionContratGump));

            AddBackground(0, 0, 380, 130 + (NbContratParPage * scale), 5054);

            int nb = 0;
            for (int i = 0; i < NbContratParPage && i < m_from.MortEngine.ContratListe.Count; ++i)
            {
                nb = (m_page * NbContratParPage) + i;

                try
                {
                    AddHtml(x, y + (line * scale), 140, 20, ((m_from.MortEngine.ContratListe[nb].Commanditaire != null) ? m_from.MortEngine.ContratListe[nb].Commanditaire.GetNameUsedBy(from) : ""), false, false);

                    AddHtml(x + 100, y + (line * scale), 140, 20, ((m_from.MortEngine.ContratListe[nb].Cible != null) ? m_from.MortEngine.ContratListe[nb].Cible.GetNameUsedBy(from) : ""), false, false);

                    AddButton(x + 200, y + (line * scale), 0xFAE, 0xFB0, GetButtonID(1, i), GumpButtonType.Reply, 0); // Transférer
                    AddButton(x + 250, y + (line * scale), 0xFB1, 0xFB3, GetButtonID(2, i), GumpButtonType.Reply, 0); // Effacer
                    line++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonID = info.ButtonID - 1;
            int type = buttonID % NbContratParPage;
            int index = buttonID / NbContratParPage;

            switch (type)
            {
                case 1: // Transférer
                    {
                        m_from.SendMessage("Transférer.");
                        break;
                    }
                case 2: // Effacer
                    {
                        m_from.SendMessage("Effacer.");
                        m_from.MortEngine.ContratListe.Remove(m_from.MortEngine.ContratListe[(m_page * NbContratParPage) + index]); // Prend pour acquis que la liste ne changera pas en attendant la réponse.
                        break;
                    }
                default: return;
            }

            m_from.SendGump(new GestionContratGump(m_from));
        }
    }
}
