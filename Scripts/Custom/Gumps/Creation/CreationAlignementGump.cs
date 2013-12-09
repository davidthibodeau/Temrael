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
    public class CreationAlignementGump : GumpTemrael
    {
        private TMobile m_From;
        private Aura m_aura;

        public CreationAlignementGump(TMobile from)
            : base("Alignement", 560, 622)
        {
            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1189, 1, false);
            x += space;
            AddMenuItem(x, y, 1193, 2, true);
            x += space;
            AddMenuItem(x, y, 1190, 3, true);
            x += space;
            AddMenuItem(x, y, 1192, 4, true);
            x += space;
            AddMenuItem(x, y, 1188, 5, true);
            x += space;
            AddMenuItem(x, y, 1224, 6, true);
            x += space;
            AddMenuItem(x, y, 1182, 7, true);

            x = XBase;
            y = YBase;

            AddTitre(x, y + line * scale, 180, "Loyal Bon");
            AddTitre(x + 180, y + line * scale, 180, "Neutre Bon");
            AddTitre(x + 360, y + line * scale, 180, "Chaotique Bon");
            ++line;
            AddButton(x + 30, y + line * scale, 491, 491, 8, GumpButtonType.Reply, 0);
            AddTooltip(1063490);
            AddButton(x + 220, y + line * scale, 492, 492, 9, GumpButtonType.Reply, 0);
            AddTooltip(1063491);
            AddButton(x + 370, y + line * scale, 493, 493, 10, GumpButtonType.Reply, 0);
            AddTooltip(1063492);

            y += 150;

            AddTitre(x, y + line * scale, 180, "Loyal Neutre");
            AddTitre(x + 180, y + line * scale, 180, "Neutre");
            AddTitre(x + 360, y + line * scale, 180, "Chaotique Neutre");
            ++line;
            AddButton(x, y + line * scale, 494, 494, 11, GumpButtonType.Reply, 0);
            AddTooltip(1063493);
            AddButton(x + 215, y + line * scale, 495, 495, 12, GumpButtonType.Reply, 0);
            AddTooltip(1063494);
            AddButton(x + 390, y + line * scale, 496, 496, 13, GumpButtonType.Reply, 0);
            AddTooltip(1063495);

            y += 150;

            AddTitre(x, y + line * scale, 180, "Loyal Mauvais");
            AddTitre(x + 180, y + line * scale, 180, "Neutre Mauvais");
            AddTitre(x + 360, y + line * scale, 180, "Chaotique Mauvais");
            ++line;
            AddButton(x + 20, y + line * scale, 497, 497, 14, GumpButtonType.Reply, 0);
            AddTooltip(1063496);
            AddButton(x + 220, y + line * scale, 498, 498, 15, GumpButtonType.Reply, 0);
            AddTooltip(1063497);
            AddButton(x + 410, y + line * scale, 499, 499, 16, GumpButtonType.Reply, 0);
            AddTooltip(1063498);
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1:
                    from.SendGump(new CreationAlignementGump(from));
                    break;
                case 2:
                    if (from.Creation.alignementA != AlignementA.Aucun && from.Creation.alignementB != AlignementB.Aucun)
                    {
                        from.SendGump(new CreationRaceGump(from));
                    }
                    else
                    {
                        goto case 1;
                    }
                    break;
                case 3:
                    if (from.Creation.race != Races.Aucun)
                    {
                        from.SendGump(new CreationClasseGump(from));
                    }
                    else
                    {
                        goto case 2;
                    }
                    break;
                case 4:
                    if (from.Creation.classe != ClasseType.None)
                    {
                        from.SendGump(new CreationMetierGump(from));
                    }
                    else
                    {
                        goto case 3;
                    }
                    break;
                case 5:
                    if (from.Creation.metier != MetierType.None)
                    {
                        from.SendGump(new CreationEquipementGump(from));
                    }
                    else
                    {
                        goto case 4;
                    }
                    break;
                case 6:
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 7:
                    from.SendGump(new CreationOverviewGump(from));
                    break;
                case 8:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Loyal;
                    from.Creation.alignementB = AlignementB.Bon;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 9:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Neutre;
                    from.Creation.alignementB = AlignementB.Bon;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 10:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Chaotique;
                    from.Creation.alignementB = AlignementB.Bon;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 11:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Loyal;
                    from.Creation.alignementB = AlignementB.Neutre;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 12:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Neutre;
                    from.Creation.alignementB = AlignementB.Neutre;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 13:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Chaotique;
                    from.Creation.alignementB = AlignementB.Neutre;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 14:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Loyal;
                    from.Creation.alignementB = AlignementB.Mauvais;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 15:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Neutre;
                    from.Creation.alignementB = AlignementB.Mauvais;
                    from.SendGump(new CreationRaceGump(from));
                    break;
                case 16:
                    from.Creation.Reboot();
                    from.Creation.alignementA = AlignementA.Chaotique;
                    from.Creation.alignementB = AlignementB.Mauvais;
                    from.SendGump(new CreationRaceGump(from));
                    break;
            }
        }
    }
}
