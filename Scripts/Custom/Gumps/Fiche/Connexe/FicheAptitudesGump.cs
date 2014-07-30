using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Gumps
{
    class FicheAptitudesGump : GumpTemrael
    {
        private TMobile m_From;
        private ClasseBranche m_Tab;

        public FicheAptitudesGump(TMobile from, ClasseBranche tab)
            : base("Aptitudes", 560, 622)
        {
            m_From = from;
            m_Tab = tab;

            int x = XBase;
            int y = YBase;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1178, 1, true);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, true);
            x += space;
            AddMenuItem(x, y, 1194, 4, false);
            x += space;
            AddMenuItem(x, y, 1196, 5, true);
            x += space;
            AddMenuItem(x, y, 1222, 6, true);
            x += space;
            AddMenuItem(x, y, 1191, 7, true);

            x = XBase;
            y = YBase;

            if (!(tab == ClasseBranche.Aucun))
            {
                //AddLabel(302, 32, 2101, "Aptitudes");
                AddImage(240, 140, 95);
                AddImageTiled(240, 149, 247, 3, 96);
                AddImage(485, 140, 97);

                //AddLabel(186, 108, 2101, String.Format("Points d'aptitude disponibles / en attente: {0} / {1}", Aptitudes.GetDisponiblePA(m_From), Aptitudes.GetRemainingPA(m_From) - Aptitudes.GetDisponiblePA(m_From)));
                //AddImageTiled(175, 143, 327, 3, 9101);

                AddImage(95, 176, 95);
                AddImageTiled(95, 185, 545, 3, 96);
                AddImage(640, 176, 97);
                AddHtml(140, 172, 200, 20, "<h3><basefont color=#025a>Nom de l'Aptitude<basefont></h3>", false, false);
                AddHtml(275, 172, 200, 20, "<h3><basefont color=#025a>Niveau<basefont></h3>", false, false);
                AddHtml(330, 172, 200, 20, "<h3><basefont color=#025a>Coût<basefont></h3>", false, false);
                AddHtml(375, 172, 200, 20, "<h3><basefont color=#025a>Compétence Requise<basefont></h3>", false, false);
            }

        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            //Console.WriteLine("FicheAptitudesGump.ButtonID = " + info.ButtonID);
            switch (info.ButtonID)
            {
                //Navigation
                case 0:
                    if (m_Tab == ClasseBranche.Aucun)
                        from.SendGump(new FicheCompetencesGump(m_From));
                    else
                        from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Aucun));
                    break;
                case 1:
                    from.SendGump(new FicheRaceGump(m_From));
                    break;
                case 2:
                    from.SendGump(new FicheClasseGump(m_From));
                    break;
                case 3:
                    from.SendGump(new FicheCaracteristiqueGump(m_From));
                    break;
                case 4:
                    from.SendGump(new FicheCompetencesGump(m_From));
                    break;
                case 5:
                    from.SendGump(new FicheStatistiquesGump(m_From));
                    break;
                case 6:
                    from.SendGump(new FicheStatutsGump(m_From));
                    break;
                case 7:
                    from.SendGump(new FicheCommandesGump(m_From));
                    break;
                case 8:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Artisan));
                    break;
                case 9:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Guerrier));
                    break;
                case 10:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Magie));
                    break;
                case 11:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Cleric));
                    break;
                case 12:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Roublard));
                    break;
                default:
                    break;
            }

            
        }
    }
}
