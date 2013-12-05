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
    public class FicheCaracteristiqueGump : GumpTemrael
    {
        private TMobile m_from;

        public FicheCaracteristiqueGump(TMobile from)
            : base("Caractéristiques", 560, 622)
        {
            m_from = from;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1178, 1, true);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, false);
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

            int lineStart = line;

            int StatTotal = from.RawStr + from.RawCon + from.RawDex + from.RawCha + from.RawInt;
            int attente = from.StatCap - StatTotal;

            AddSection(x, y + line * scale, 200, 100, "Caractéristiques", "Les caractéristiques influencent les attributs (vitalité, stamina & mana) ainsi que certains systèmes comme le combat ou les différentes sortes de magie. Vous regagnez les points indisponibles à chaque niveau.", new string[] { "<h3><basefont color=#5A4A31>Dispo | Indispo: " + from.StatistiquesLibres.ToString() + "|" + attente.ToString() + "<basefont></h3>" });
            line += 6;
            ++line;

            AddSection(x, y + line * scale, 200, 100, "Constitution", "Augmente le maximum de points de vitalités ainsi que le maximum de points de stamina.", new string[] { "<h3><basefont color=#5A4A31>Constitution: " + from.RawCon + "%<basefont></h3>" });
            line += 6;
            if (Statistiques.CanRaise(from, StatType.Con))
                AddButton(x + 130, (y + line * scale) - 3, 9770, 9770, 15, GumpButtonType.Reply, 0);
            if (Statistiques.CanLower(from, StatType.Con))
                AddButton(x + 155, (y + line * scale) - 3, 9771, 9771, 16, GumpButtonType.Reply, 0);
            ++line;

            AddSection(x, y + line * scale, 200, 100, "Charisme", "Influence la religion et les miracles ainsi que les familiers (plus de chance aux jets de dressage) et augmente le maximum de mana.", new string[] { "<h3><basefont color=#5A4A31>Charisme: " + from.RawCha + "%<basefont></h3>" });
            line += 6;
            if (Statistiques.CanRaise(from, StatType.Cha))
                AddButton(x + 130, (y + line * scale) - 3, 9770, 9770, 19, GumpButtonType.Reply, 0);
            if (Statistiques.CanLower(from, StatType.Cha))
                AddButton(x + 155, (y + line * scale) - 3, 9771, 9771, 20, GumpButtonType.Reply, 0);

            //Images center
            line = lineStart;
            x += 215;
            AddBackground(x, y + line * scale, 110, 112, 2620);
            AddButton(x + 5, (y + line * scale) + 5, 1436, 1436, 0, GumpButtonType.Reply, 0);
            AddTooltip(3001037);
            line += 5;

            AddBackground(x, y + line * scale, 110, 112, 2620);
            AddButton(x + 5, (y + line * scale) + 5, 1437, 1437, 0, GumpButtonType.Reply, 0);
            AddTooltip(3001037);
            line += 5;

            AddBackground(x, y + line * scale, 110, 112, 2620);
            AddButton(x + 5, (y + line * scale) + 5, 1438, 1438, 0, GumpButtonType.Reply, 0);
            AddTooltip(3001037);

            //2e ranger
            line = lineStart;
            x += 125;
            AddSection(x, y + line * scale, 200, 100, "Force", "Augmente le poid maximum pouvant être porté, les dégâts ainsi que le maximum de points de vitalités.", new string[] { "<h3><basefont color=#5A4A31>Force: " + from.RawStr + "%<basefont></h3>" });
            line += 6;
            if (Statistiques.CanRaise(from, StatType.Str))
                AddButton(x + 130, (y + line * scale) - 3, 9770, 9770, 13, GumpButtonType.Reply, 0);
            if (Statistiques.CanLower(from, StatType.Str))
                AddButton(x + 155, (y + line * scale) - 3, 9771, 9771, 14, GumpButtonType.Reply, 0);
            ++line;

            AddSection(x, y + line * scale, 200, 100, "Dexterite", "Augmente la vitesse de frappe et la stamina. Elle est réduite pas le port d'armures lourdes.", new string[] { "<h3><basefont color=#5A4A31>Dexterite: " + from.RawDex + "%<basefont></h3>" });
            line += 6;
            if (Statistiques.CanRaise(from, StatType.Dex))
                AddButton(x + 130, (y + line * scale) - 3, 9770, 9770, 17, GumpButtonType.Reply, 0);
            if (Statistiques.CanLower(from, StatType.Dex))
                AddButton(x + 155, (y + line * scale) - 3, 9771, 9771, 18, GumpButtonType.Reply, 0);
            ++line;

            AddSection(x, y + line * scale, 200, 100, "Intelligence", "Augmente le maximum de mana et influence les sorts et le système de magie arcanique.", new string[] { "<h3><basefont color=#5A4A31>Intelligence: " + from.RawInt + "%<basefont></h3>" });
            line += 6;
            if (Statistiques.CanRaise(from, StatType.Int))
                AddButton(x + 130, (y + line * scale) - 3, 9770, 9770, 21, GumpButtonType.Reply, 0);
            if (Statistiques.CanLower(from, StatType.Int))
                AddButton(x + 155, (y + line * scale) - 3, 9771, 9771, 22, GumpButtonType.Reply, 0);
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
                case 13:
                    if (Statistiques.CanRaise(from, StatType.Str))
                    {
                        from.RawStr += 5;
                        from.StatistiquesLibres -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 14:
                    if (Statistiques.CanLower(from, StatType.Str))
                    {
                        from.RawStr -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 15:
                    if (Statistiques.CanRaise(from, StatType.Con))
                    {
                        from.RawCon += 5;
                        from.StatistiquesLibres -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 16:
                    if (Statistiques.CanLower(from, StatType.Con))
                    {
                        from.RawCon -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 17:
                    if (Statistiques.CanRaise(from, StatType.Dex))
                    {
                        from.RawDex += 5;
                        from.StatistiquesLibres -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 18:
                    if (Statistiques.CanLower(from, StatType.Dex))
                    {
                        from.RawDex -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 19:
                    if (Statistiques.CanRaise(from, StatType.Cha))
                    {
                        from.RawCha += 5;
                        from.StatistiquesLibres -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 20:
                    if (Statistiques.CanLower(from, StatType.Cha))
                    {
                        from.RawCha -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 21:
                    if (Statistiques.CanRaise(from, StatType.Int))
                    {
                        from.RawInt += 5;
                        from.StatistiquesLibres -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
                case 22:
                    if (Statistiques.CanLower(from, StatType.Int))
                    {
                        from.RawInt -= 5;
                    }
                    from.SendGump(new FicheCaracteristiqueGump(from));
                    break;
            }
        }
    }
}
