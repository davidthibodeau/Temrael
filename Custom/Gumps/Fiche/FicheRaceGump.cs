using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;

namespace Server.Gumps
{
    public class FicheRaceGump : GumpTemrael
    {
        private TMobile m_from;

        public FicheRaceGump(TMobile from)
            : base("Race & Alignement", 560, 622)
        {
            m_from = from;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1178, 1, false);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, true);
            x += space;
            AddMenuItem(x, y, 1194, 4, true);
            x += space;
            AddMenuItem(x, y, 1196, 5, true);
            x += space;
            AddMenuItem(x, y, 1222, 6, true);
            x += space;
            AddMenuItem(x, y, 1191, 7, true);

            x = XBase;
            y = YBase;

            /*Race*/
            if (from.Races != Races.Aucun && from.Races != Races.Maximum)
            {
                BaseRace race = RaceManager.getRace(from.Races);
                AddButton(x, y + line * scale, 8, race.Image);
                AddTooltip(race.Tooltip);

                /*Alignement*/
                switch (from.AlignementB)
                {
                    case AlignementB.Bon:
                        {
                            if (from.AlignementA == AlignementA.Loyal)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Loyal Bon");
                                ++line;
                                AddButton(x + 340, y + line * scale, 491, 491, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            else if (from.AlignementA == AlignementA.Neutre)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Neutre Bon");
                                ++line;
                                AddButton(x + 340, y + line * scale, 492, 492, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            else if (from.AlignementA == AlignementA.Chaotique)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Chaotique Bon");
                                ++line;
                                AddButton(x + 340, y + line * scale, 493, 493, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            break;
                        }
                    case AlignementB.Neutre:
                        {
                            if (from.AlignementA == AlignementA.Loyal)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Loyal Neutre");
                                ++line;
                                AddButton(x + 340, y + line * scale, 494, 494, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            else if (from.AlignementA == AlignementA.Neutre)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Neutre");
                                ++line;
                                AddButton(x + 340, y + line * scale, 495, 495, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            else if (from.AlignementA == AlignementA.Chaotique)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Chaotique Neutre");
                                ++line;
                                AddButton(x + 340, y + line * scale, 496, 496, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            break;
                        }
                    case AlignementB.Mauvais:
                        {
                            if (from.AlignementA == AlignementA.Loyal)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Loyal Mauvais");
                                ++line;
                                AddButton(x + 340, y + line * scale, 497, 497, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            else if (from.AlignementA == AlignementA.Neutre)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Chaotique Mauvais");
                                ++line;
                                AddButton(x + 340, y + line * scale, 498, 498, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            else if (from.AlignementA == AlignementA.Chaotique)
                            {
                                AddTitre(x + 330, y + line * scale, 180, "Chaotique Mauvais");
                                ++line;
                                AddButton(x + 340, y + line * scale, 499, 499, 9, GumpButtonType.Reply, 0);
                                AddTooltip(1063492);
                            }
                            break;
                        }
                }

                line += 5;
                AddButton(440, y + (line * scale), 52, 52, 9, GumpButtonType.Reply, 0);
                AddHtml(490, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Modifier<basefont></h3>", false, false);

                /*Bonus Raciaux*/
                string bonus = race.BonusDescr;

                line += 8;
                AddSection(x + 220, y + line * scale, 300, 120, "Bonus Raciaux", bonus);

                line -= 5;
                AddSection(x + 220, y + line * scale, 300, 80, "Évolution");
                ++line;
                ++line;
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Exp : ", from.XP));
                ++line;
                AddButton(x + 235, y + line * scale, 2117, 2118, 10, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Niveau : ", from.Niveau));
                ++line;
                AddButton(x + 235, y + line * scale, 2117, 2118, 11, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 255, y + line * scale, DefaultHtmlLength, String.Concat("Reset", (from.FreeReset == true ? " (1 Gratuit)" : " (0 Gratuit)")));

                line -= 1;
                AddButton(x, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 50, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Informations<basefont></h3>", false, false);
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.SendGump(new FicheRaceGump(from));
                    break;
                case 2:
                    from.SendGump(new FicheClasseGump(from));
                    break;
                case 3:
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 4:
                    from.SendGump(new FicheAptitudeGump(from));
                    break;
                case 5:
                    from.SendGump(new FicheMagieGump(from));
                    break;
                case 6:
                    from.SendGump(new FicheStatutsGump(from));
                    break;
                case 7:
                    from.SendGump(new FicheCommandesGump(from));
                    break;
                case 8:
                    from.SendGump(new FicheRacesInfoGump(from));
                    break;
                case 9:
                    from.SendGump(new FicheAlignementsInfoGump(from));
                    break;
                case 10:
                    if (XP.CanEvolve((TMobile)from))
                        XP.Evolve((TMobile)from);
                    from.SendGump(new FicheRaceGump(from));
                    break;
                case 11:
                    from.SendGump(new FicheResetMessageGump(from));
                    break;
            }
        }
    }
}
