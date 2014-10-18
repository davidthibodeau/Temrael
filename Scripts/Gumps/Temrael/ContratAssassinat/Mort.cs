using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Engines.Mort;

namespace Server.Gumps
{
    class MortGump : Gump
    {
        private Mobile m_From;
        private ContratAssassinat m_cs;

        public MortGump(Mobile from, ContratAssassinat cs)
            : base(0, 0)
        {
            m_From = from;
            m_cs = cs;

            Closable = false;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //BG
            AddBackground(80, 72, 420, 397, 3600);
            AddBackground(90, 82, 400, 377, 9200);
            AddBackground(100, 92, 380, 350, 3500);

            //Dragons
            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            AddHtml(140, 115, 200, 20, "<h1><basefont color=#025a>Vous avez été achevé !<basefont></h1>", false, false);

            AddHtml(140, 155, 200, 20, "Commanditaire : " + from.GetNameUseBy(cs.Commanditaire), false, false);

            AddHtml(140, 195, 200, 20, "Explication : ", false, false);
            AddBackground(140, 225, 300, 120, 0x23F0);

            AddHtml(145, 235, 290, 100, cs.Explication, false, true);

            AddHtml(140, 350, 300, 20, "Souhaitez-vous contester votre mort ? ", false, false);

            AddHtml(190, 375, 100, 20, "Oui", false, false);
            AddButton(220, 375, 0x481, 0x483, 1, GumpButtonType.Reply, 0);

            AddHtml(320, 375, 100, 20, "Non", false, false);
            AddButton(350, 375, 0x47E, 0x480, 2, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    m_cs.Cible.Corpse.PublicOverheadMessage(MessageType.Regular, 0x0, false, "La mort a été contestée.");
                    
                    // Resurect corpse ( Pour éviter que le cadavre decay, peut-être ? )

                    // Teleport to jail.

                    //((TMobile)m_cs.Cible).Mort = false;
                    //((TMobile)m_cs.Cible).MortCurrentState = MortState.Aucun;

                    // Make forum ticket.

                    // Message explicatif pour le joueur achevé, lui disant que la demande a été envoyée et sera traitée.

                    break;
                case 2:
                    
                    m_cs.Cible.Corpse.PublicOverheadMessage(MessageType.Regular, 0x0, false, "La mort a été acceptée.");

                    // Teleport to cemetary.

                    // Write sad message. RIP.

                    break;

                default: break;
            }
        }
    }
}
