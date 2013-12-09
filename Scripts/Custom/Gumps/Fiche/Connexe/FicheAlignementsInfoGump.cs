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
    public class FicheAlignementsInfoGump : GumpTemrael
    {
        private TMobile m_from;

        public FicheAlignementsInfoGump(TMobile from)
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

            AddTitre(x, y + line * scale, 180, "Loyal Bon");
            AddTitre(x + 180, y + line * scale, 180, "Neutre Bon");
            AddTitre(x + 360, y + line * scale, 180, "Chaotique Bon");
            ++line;
            if (from.Races != Races.ElfeNoir && from.Races != Races.Tieffelin && from.Races != Races.Orcish)
            {
                AddButton(x + 30, y + line * scale, 491, 491, 8, GumpButtonType.Reply, 0);
                AddTooltip(1063490);
            }
            if (from.Races != Races.ElfeNoir && from.Races != Races.Tieffelin && from.Races != Races.Orcish)
            {
                AddButton(x + 220, y + line * scale, 492, 492, 9, GumpButtonType.Reply, 0);
                AddTooltip(1063491);
            }
            if (from.Races != Races.ElfeNoir && from.Races != Races.Tieffelin)
            {
                AddButton(x + 370, y + line * scale, 493, 493, 10, GumpButtonType.Reply, 0);
                AddTooltip(1063492);
            }

            y += 150;

            AddTitre(x, y + line * scale, 180, "Loyal Neutre");
            AddTitre(x + 180, y + line * scale, 180, "Neutre");
            AddTitre(x + 360, y + line * scale, 180, "Chaotique Neutre");
            ++line;
            if (from.Races != Races.Aasimar && from.Races != Races.Tieffelin && from.Races != Races.Orcish)
            {
                AddButton(x, y + line * scale, 494, 494, 11, GumpButtonType.Reply, 0);
                AddTooltip(1063493);
            }
            if (from.Races != Races.Aasimar && from.Races != Races.Tieffelin && from.Races != Races.Orcish)
            {
                AddButton(x + 215, y + line * scale, 495, 495, 12, GumpButtonType.Reply, 0);
                AddTooltip(1063494);
            }
            if (from.Races != Races.Aasimar && from.Races != Races.Tieffelin)
            {
                AddButton(x + 390, y + line * scale, 496, 496, 13, GumpButtonType.Reply, 0);
                AddTooltip(1063495);
            }

            y += 150;

            AddTitre(x, y + line * scale, 180, "Loyal Mauvais");
            AddTitre(x + 180, y + line * scale, 180, "Neutre Mauvais");
            AddTitre(x + 360, y + line * scale, 180, "Chaotique Mauvais");
            ++line;
            if (from.Races != Races.Elfe && from.Races != Races.Aasimar && from.Races != Races.Orcish)
            {
                AddButton(x + 20, y + line * scale, 497, 497, 14, GumpButtonType.Reply, 0);
                AddTooltip(1063496);
            }
            if (from.Races != Races.Elfe && from.Races != Races.Aasimar && from.Races != Races.Orcish)
            {
                AddButton(x + 220, y + line * scale, 498, 498, 15, GumpButtonType.Reply, 0);
                AddTooltip(1063497);
            }
            if (from.Races != Races.Elfe && from.Races != Races.Aasimar)
            {
                AddButton(x + 410, y + line * scale, 499, 499, 16, GumpButtonType.Reply, 0);
                AddTooltip(1063498);
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
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Loyal;
                        from.AlignementB = AlignementB.Bon;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 9:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Neutre;
                        from.AlignementB = AlignementB.Bon;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 10:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Chaotique;
                        from.AlignementB = AlignementB.Bon;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 11:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Loyal;
                        from.AlignementB = AlignementB.Neutre;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 12:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Neutre;
                        from.AlignementB = AlignementB.Neutre;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 13:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Chaotique;
                        from.AlignementB = AlignementB.Neutre;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 14:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Loyal;
                        from.AlignementB = AlignementB.Mauvais;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 15:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Neutre;
                        from.AlignementB = AlignementB.Mauvais;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
                case 16:
                    if (from.NextAlignementChange < DateTime.Now)
                    {
                        from.AlignementA = AlignementA.Chaotique;
                        from.AlignementB = AlignementB.Mauvais;
                        from.NextAlignementChange = DateTime.Now.AddDays(7);
                        from.SendGump(new FicheRaceGump(from));
                    }
                    else
                    {
                        from.SendMessage(String.Concat("Vous ne pouvez pas changer d'alignement avant ", from.NextAlignementChange));
                    }
                    break;
            }
        }
    }
}
