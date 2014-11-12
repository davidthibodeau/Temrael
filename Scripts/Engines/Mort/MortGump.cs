using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.Engines.Mort;
using System.Collections.Generic;
using Server.Misc;

namespace Server.Engines.Mort
{
    class MortGump : Gump
    {
        private Mobile m_From;
        private ContratAssassinat m_cs;
        private List<Mobile> m_listePersoPresent = new List<Mobile>();

        public MortGump(Mobile from, ContratAssassinat cs)
            : base(0, 0)
        {
            m_From = from;
            m_cs = cs;

            // Prise en mémoire des personnes autour du corps, lorsque le personnage a été achevé.
            List<Mobile> listePersoPresent = new List<Mobile>();
            foreach (Mobile m in m_cs.Cible.Corpse.GePlayerMobilesInRange(20))
            {
                m_listePersoPresent.Add(m);
            }

            Closable = false;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //BG
            AddBackground(80, 72, 390, 185, 3600);
            AddBackground(90, 82, 370, 165, 9200);
            AddBackground(100, 92, 350, 140, 3500);

            AddHtml(140, 115, 200, 20, "<h1><basefont color=#025a>Vous avez été achevé !<basefont></h1>", false, false);

            AddHtml(140, 155, 300, 20, "Souhaitez-vous contester votre mort ? ", false, false);

            AddHtml(190, 180, 100, 20, "Oui", false, false);
            AddButton(220, 180, 0x481, 0x483, 1, GumpButtonType.Reply, 0);

            AddHtml(320, 180, 100, 20, "Non", false, false);
            AddButton(350, 180, 0x47E, 0x480, 2, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            if (m_From.Deleted)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    m_cs.Cible.Corpse.PublicOverheadMessage(MessageType.Regular, 0x0, false, "La mort a été contestée.");

                    m_cs.Cible.Resurrect(); // Pour éviter que le cadavre decay..

                    // Teleport to jail.

                    ((PlayerMobile)m_cs.Cible).MortEngine.Mort = false;
                    ((PlayerMobile)m_cs.Cible).MortEngine.MortCurrentState = MortState.Aucun;

                    m_cs.Cible.SendGump(new MortContestGump(m_From, m_cs, m_listePersoPresent));

                    break;
                case 2:
                    m_cs.Cible.Corpse.PublicOverheadMessage(MessageType.Regular, 0x0, false, "La mort a été acceptée.");

                    // Teleport to cemetary.

                    m_cs.Cible.SendMessage("C'est ainsi que se termine l'histoire de " + m_cs.Cible.Name + ". RIP.");

                    break;

                default: break;
            }

            m_cs.Cible.CloseGump(typeof(MortGump));
        }


        class MortContestGump : Gump
        {
            private Mobile m_From;
            private ContratAssassinat m_cs;
            private List<Mobile> m_listePersoPresent = new List<Mobile>();

            public MortContestGump(Mobile from, ContratAssassinat cs, List<Mobile> listePersoPresent)
                : base(0, 0)
            {
                m_From = from;
                m_cs = cs;
                m_listePersoPresent = listePersoPresent;

                Closable = false;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                //BG
                AddBackground(80, 72, 390, 400, 3600);
                AddBackground(90, 82, 370, 380, 9200);
                AddBackground(100, 92, 350, 355, 3500);
                AddBackground(140, 230, 270, 120, 0xBB8);

                AddHtml(140, 125, 270, 100, "Désirez-vous laisser un message ? \n\nIci vous pouvez décrire quelles ont été les circonstances de votre mort, et pourquoi vous souhaitez contester.", false, false);

                AddTextEntry(140, 240, 265, 120, 0x7FA, 2, "");

                AddHtml(220, 380, 100, 20, "Envoyer", false, false);
                AddButton(280, 380, 0x481, 0x483, 1, GumpButtonType.Reply, 0);
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                Mobile from = sender.Mobile;

                if (from.Deleted)
                    return;

                switch (info.ButtonID)
                {
                    case 1:

                        String message = (info.GetTextEntry(2)).Text;

                        // Transformation de la liste de nom en un string.
                        String noms = "";

                        foreach (Mobile m in m_listePersoPresent)
                        {
                            noms += m.Name += "\n";
                        }


                        // Make forum ticket.
                        PhpBB forumPost = new PhpBB("USERNAME", "PASSWORD");

                        forumPost.Login();

                        m_cs.Cible.SendMessage("Envoi de la demande...");

                        forumPost.Post("117", "PERSONNAGE ACHEVÉ : " + m_From.Name,
                        "\n" +
                        " DATE DE L'ACHÈVEMENT : " + DateTime.Now.ToString() + "\n" +
                        "\n" +
                        " INFORMATIONS RELATIVES AU CONTRAT \n" +
                        " ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n" +
                        " Nom du commanditaire : " + m_cs.Commanditaire.Name + "\n" +
                        " Nom de l'assassin    : " + m_cs.Assassin.Name + "\n" +
                        " Nom de la cible      : " + m_cs.Cible.Name + "\n" +
                        " Explication          : " + m_cs.Explication + "\n" +
                        "\n" +
                        "\n" +
                        " COMMENTAIRE DE L'ACHEVÉ \n" +
                        " ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n" +
                        message + "\n" +
                        "\n" +
                        "\n" +
                        " PERSONNAGES PRÉSENTS \n" +
                        " ¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯¯ \n" +
                        noms);
                        
                        //

                        m_cs.Cible.SendMessage("Une demande de contestation a été envoyée à l'équipe, et sera traitée dans les plus brefs délais !");

                        break;
                    default: break;
                }
            }
        }




    }
}
