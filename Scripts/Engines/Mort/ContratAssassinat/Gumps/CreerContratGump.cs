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
    public class CreerContratGump : GumpTemrael
    {
        public static void Initialize()
        {
            CommandSystem.Register("CreerContrat", AccessLevel.Player, new CommandEventHandler(CreerContrat_OnCommand));
        }

        [Usage("CreerContrat")]
        [Description("Permet de creer un contrat pour assassiner un personnage.")]
        public static void CreerContrat_OnCommand(CommandEventArgs e)
        {
            if (e.Mobile is PlayerMobile)
            {
                e.Mobile.SendGump(new CreerContratGump((PlayerMobile)e.Mobile));
            }
        }

        PlayerMobile m_from;
        ContratAssassinat m_contrat;

        int x = 50;
        int y = 50;

        int line = 0;
        int scale = 25;
        const int columnScale = 50;

        public CreerContratGump(PlayerMobile from)
            : this(from, new ContratAssassinat(from, null, null, null))
        {
        }


        public CreerContratGump(PlayerMobile from, ContratAssassinat contrat)
            : base("", 0, 0)
        {
            m_from = from;
            m_contrat = contrat;

            m_from.CloseGump(typeof(CreerContratGump));

            AddBackground(0, 0, 400, 410, 5054);

            AddHtml(x + 50, y + (line * scale), 150, 20, "<h3> Commanditaire </h3>", false, false);
            AddHtml(x + 200, y + (line * scale), 150, 20, ": " + ((contrat.Commanditaire != null) ? contrat.Commanditaire.GetNameUsedBy(from) : ""), false, false);

            line++;

            AddButton(x, y + (line * scale), 0xFAE, 0xFB0, 1, GumpButtonType.Reply, 0);
            AddHtml(x + 50, y + (line * scale), 150, 20, "<h3> Cible </h3>", false, false);
            AddHtml(x + 200, y + (line * scale), 150, 20, ": " + ((contrat.Cible != null) ? contrat.Cible.GetNameUsedBy(from) : ""), false, false);

            line += 2;

            AddHtml(x, y + (line * scale), 150, 20, "<h3> Explication </h3>", false, false);
            line++;
            AddBackground(25, y + (line * scale), 350, 175, 5054);
            AddTextEntry(50, y+25 + (line * scale), 300, 125, 0x7FA, 2, m_contrat.Explication);

            line += 8;

            AddButton(x, y + (line * scale), 0xFAE, 0xFB0, 3, GumpButtonType.Reply, 0);
            AddHtml(x + 50, y + (line * scale), 300, 20, "<h3> Valider et créer le contrat.</h3>", false, false);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if ((info.GetTextEntry(2)).Text != "")
            {
                m_contrat.Explication = (info.GetTextEntry(2)).Text;
            }

            switch (info.ButtonID)
            {
                case 0:
                    {
                        m_from.CloseGump(typeof(CreerContratGump));
                        return;
                    }
                case 1:
                    {
                        m_from.Target = new CibleTarget(m_from, m_contrat); // Cible
                        break;
                    }
                // case 2 == Explication.
                case 3:
                    {
                        if (m_contrat.Commanditaire != null)
                        {
                            if (m_contrat.Cible != null)
                            {
                                if (m_contrat.Explication != ContratAssassinat.DefaultExplication())
                                {
                                    m_from.MortEngine.ContratListe.Add(m_contrat); // Confirmer le contrat.
                                    return;
                                }
                                else
                                {
                                    m_from.SendMessage("Vous devez donner une explication.");
                                }
                            }
                            else
                            {
                                m_from.SendMessage("Vous devez choisir une cible!");
                            }
                        }
                        else
                        {
                            m_from.SendMessage("Arvendor scripte mal.");
                        }
                        m_from.SendGump(new CreerContratGump(m_from, m_contrat));
                        break;
                    }
            }
        }

        private class CibleTarget : Target
        {
            PlayerMobile m_from;
            ContratAssassinat m_contrat;

            public CibleTarget(PlayerMobile from, ContratAssassinat contrat)
                : base(10, false, TargetFlags.None)
            {
                m_from = from;
                m_contrat = contrat;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is PlayerMobile)
                {
                    PlayerMobile mob = (PlayerMobile)targeted;

                    m_contrat.Cible = mob;
                    m_from.SendGump(new CreerContratGump(m_from, m_contrat));
                }
            }
        }
    }
}
