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
            int space = 80;

            AddMenuItem(x, y, 1189, 1, true);
            x += space;
            AddMenuItem(x, y, 1193, 2, true);
            x += space;
            AddMenuItem(x, y, 1190, 3, false);
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

            AddTitre(x + 360, y + line * scale, 190, "Classes");
            ++line;
            for (int i = page * lineMax; i < (page * lineMax) + lineMax && i < (int)ClasseType.Maximum; i++)
            {
                ClasseInfo tmp = Classes.GetInfos((ClasseType)i);

                if ((tmp.Alignement == from.Creation.alignementB || tmp.Alignement == AlignementB.Aucun))
                {
                    AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                    AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, ((ClasseType)i).ToString());
                    ++line;
                }
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

                AddButton(x + 195, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 245, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Confirmer<basefont></h3>", false, false);

                line = linetmp;
                AddSection(x + 240, y + line * scale, 300, 90, info.Nom, info.Role);

                List<NAptitude> listAptitude = new List<NAptitude>();
                bool hasAptitude = false;
                string temp = String.Empty;
                /*string nomTemp = String.Empty;
                string descrTemp = String.Empty;
                string reqTemp = String.Empty;*/

                /*temp += "<strong>Arme de Prédilection</strong>: " + info.ArmeAllow.ToString() + Environment.NewLine;
                temp += "<strong>Armure de Prédilection</strong>: " + info.ArmorAllow.ToString() + Environment.NewLine;*/
                /*temp += "<strong>Compétences de Classe</strong>: ";

                for (int i = 0; i < info.ClasseCompetences.Length; i++)
                {
                    if (i != info.ClasseCompetences.Length - 1)
                        temp += info.ClasseCompetences[i].ToString() + ", ";
                    else
                        temp += info.ClasseCompetences[i].ToString();
                }*/

                for (int j = 0; j < info.FourthApt.Length; j++)
                {
                    AptitudeInfo infoApt = Aptitudes.GetInfos(info.FourthApt[j].Aptitude);
                    temp += "<strong>" + infoApt.Name + "</strong>: " + infoApt.Description + Environment.NewLine;
                }

                line = 12;
                AddSection(x, y + line * scale, 540, 180, "Aptitudes", temp);
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
                    from.Creation.classe = m_classeType;
                    from.SendGump(new CreationMetierGump(from));
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
