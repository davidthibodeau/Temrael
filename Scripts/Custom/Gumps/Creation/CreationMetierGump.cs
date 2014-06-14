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
    public class CreationMetierGump : GumpTemrael
    {
        private TMobile m_from;
        private MetierType m_metierType;
        private int m_page;

        public CreationMetierGump(TMobile from)
            : this(from, from.Creation.metier, 0)
        {
        }

        public CreationMetierGump(TMobile from, MetierType metierType, int page)
            : base("Métier", 560, 622)
        {
            m_from = from;
            m_metierType = metierType;
            m_page = page;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
            int lineMax = 4;

            y = 650;
            x = 90;
            int space = 80;

            x += space;
            AddMenuItem(x, y, 1193, 2, true);
            x += space;
            AddMenuItem(x, y, 1190, 3, true);
            x += space;
            AddMenuItem(x, y, 1192, 4, false);
            x += space;
            AddMenuItem(x, y, 1188, 5, true);
            x += space;
            AddMenuItem(x, y, 1224, 6, true);
            x += space;
            AddMenuItem(x, y, 1182, 7, true);

            x = XBase;
            y = YBase;

            AddTitre(x + 360, y + line * scale, 190, "Métiers Accessibles");
            ++line;

            for (int i = page * lineMax; i < (page * lineMax) + lineMax && i < (int)MetierType.Maximum; i++)
            {
                MetierInfo info = Metiers.GetInfos((MetierType)i);

                AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, ((MetierType)i).ToString());
                ++line;
            }

            if (page > 0)
                AddButton(x + 360, y + line * scale, 4014, 4015, 9, GumpButtonType.Reply, 0);
            if (page < (int)MetierType.Maximum / lineMax)
                AddButton(x + 515, y + line * scale, 4005, 4006, 10, GumpButtonType.Reply, 0);

            if (metierType != MetierType.None)
            {
                MetierInfo info = Metiers.GetInfos(metierType);

                int linetmp = line;

                line = 0;
                AddButton(x, y + line * scale, 8, info.Image);
                //AddTooltip(TemraelClasse.GetTooltipMetier(metierType));

                List<Aptitude> listAptitude = new List<Aptitude>();
                bool hasAptitude = false;
                string temp = String.Empty;
                /*string nomTemp = String.Empty;
                string descrTemp = String.Empty;
                string reqTemp = String.Empty;*/

                //temp += "<strong>Compétences de Classe</strong>: ";

                /*for (int i = 0; i < info.MetierCompetences.Length; i++)
                {
                    if (i != info.MetierCompetences.Length - 1)
                        temp += info.MetierCompetences[i].ToString() + ", ";
                    else
                        temp += info.MetierCompetences[i].ToString();
                }*/

                for (int j = 0; j < info.Aptitudes.Length; j++)
                {
                    foreach (Aptitude aptitude in listAptitude)
                    {
                        if (aptitude == info.Aptitudes[j].Aptitude)
                        {
                            hasAptitude = true;
                        }
                    }

                    if (!hasAptitude)
                    {
                        AptitudeInfo infoApt = Aptitudes.GetInfos(info.Aptitudes[j].Aptitude);
                        temp += "<strong>" + infoApt.Name + "</strong>: " + infoApt.Description + Environment.NewLine;
                        listAptitude.Add(info.Aptitudes[j].Aptitude);
                    }
                }

                line = 12;
                AddSection(x, y + line * scale, 540, 180, "Aptitudes", temp);

                line = 0;
                AddButton(x + 195, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 245, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Confirmer<basefont></h3>", false, false);
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
                    from.Creation.metier = m_metierType;
                    from.SendGump(new CreationEquipementGump(from));
                    break;
                case 9:
                    from.SendGump(new CreationMetierGump(from, m_metierType, m_page - 1));
                    break;
                case 10:
                    from.SendGump(new CreationMetierGump(from, m_metierType, m_page + 1));
                    break;
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new CreationMetierGump(from, (MetierType)(info.ButtonID - 50), m_page));
            }
        }
    }
}
