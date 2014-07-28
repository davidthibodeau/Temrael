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
    public class CreationClasseGump : GumpTemrael
    {
        private TMobile m_from;
        private ClasseType m_classeType;
        private int m_page;

        public CreationClasseGump(TMobile from)
            : this(from, from.Creation.classe, 0)
        {
        }

        public CreationClasseGump(TMobile from, ClasseType classeType, int page)
            : base("Classe", 560, 622)
        {
            m_from = from;
            m_classeType = classeType;
            m_page = page;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
            int lineMax = 4;

            y = 650;
            x = 90;
            int space = 70;

            AddCreationMenuItem(x, y, 1193, 2, true);
            x += space;
            AddCreationMenuItem(x, y, 1190, 3, false);
            x += space;
            AddCreationMenuItem(x, y, 1188, 4, true);
            x += space;
            AddCreationMenuItem(x, y, 1224, 6, true);
            x += space;
            AddCreationMenuItem(x, y, 1182, 7, true);

            x = XBase;
            y = YBase;

            AddTitre(x + 360, y + line * scale, 190, "Classes");
            ++line;
            for (int i = page * lineMax; i < (page * lineMax) + lineMax && i < (int)ClasseType.Maximum; i++)
            {
                ClasseInfo tmp = Classes.GetInfos((ClasseType)i);

                AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, ((ClasseType)i).ToString());
                ++line;
            }

            if (page > 0)
                AddButton(x + 360, y + line * scale, 4014, 4015, 9, GumpButtonType.Reply, 0);
            if (page < (int)ClasseType.Maximum / lineMax)
                AddButton(x + 515, y + line * scale, 4005, 4006, 10, GumpButtonType.Reply, 0);
            ++line;

            if (classeType != ClasseType.None)
            {
                ClasseInfo info = Classes.GetInfos(classeType);

                int linetmp = line;

                line = 0;
                AddButton(x, y + line * scale, 8, info.Image);
                AddTooltip(info.Tooltip);

                AddButton(470, 645, 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(520, 645 + 12, 200, 20, "<h3><basefont color=#025a>Confirmer<basefont></h3>", false, false);

                line = linetmp;
                AddSection(x + 240, y + line * scale, 300, 90, info.Nom, info.Role);

                string temp = String.Empty;

                for (int i = 0; i < info.ClasseCompetences.Length; i++)
                {
                    temp += info.ClasseCompetences[i].SkillName.ToString() + ": " + info.ClasseCompetences[i].Value.ToString() + "%";
                    if (i != info.ClasseCompetences.Length - 1)
                         temp += Environment.NewLine;
                }

                line = 12;
                AddSection(x, y + line * scale, 540, 180, "Compétences appliquées au niveau 30", temp);
            }
        }
        public override void OnResponse(NetState sender, RelayInfo info)
        {
            TMobile from = (TMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 2:
                    from.SendGump(new CreationRaceGump(from));
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
                        from.SendGump(new CreationEquipementGump(from));
                    }
                    else
                    {
                        goto case 3;
                    }
                    break;
                case 6:
                    from.SendGump(new CreationCarteGump(from));
                    break;
                case 7:
                    from.SendGump(new CreationOverviewGump(from));
                    break;
                case 8:
                    from.Creation.classe = m_classeType;
                    from.SendGump(new CreationEquipementGump(from));
                    break;
                case 9:
                    from.SendGump(new CreationClasseGump(from, m_classeType, m_page - 1));
                    break;
                case 10:
                    from.SendGump(new CreationClasseGump(from, m_classeType, m_page + 1));
                    break;
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new CreationClasseGump(from, (ClasseType)(info.ButtonID - 50), m_page));
            }
        }
    }
}
