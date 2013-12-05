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
    public class FicheMetiersInfoGump : GumpTemrael
    {
        TMobile m_from;
        MetierType m_metierType;
        private int m_page;

        private bool canMultiClasse(TMobile mob)
        {
            if (mob.ClasseType == ClasseType.Artisan)
            {
                Console.WriteLine("Métier Count : " + mob.MetierType.Count);
                Console.WriteLine("Niveau / 10 - 1 : " + mob.Niveau / 10);

                if (mob.MetierType.Count < 1)
                {
                    return true;
                }

                if (mob.MetierType.Count - 1 < (mob.Niveau / 10))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (mob.MetierType.Count < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public FicheMetiersInfoGump(TMobile from)
            : this(from, from.MetierType[0], 0)
        {
        }

        public FicheMetiersInfoGump(TMobile from, MetierType metierType, int page)
            : base("Classe & Métier", 560, 622)
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

            AddMenuItem(x, y, 1178, 1, true);
            x += space;
            AddMenuItem(x, y, 1179, 2, false);
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

            AddTitre(x + 360, y + line * scale, 190, "Métiers Accessibles");
            ++line;

            for (int i = page * lineMax; i < (page * lineMax) + lineMax && i < (int)MetierType.Maximum; i++)
            {
                MetierInfo tmp = Metiers.GetInfos(((MetierType)i));

                AddButton(x + 360, y + line * scale, 0x4b9, 0x4bA, i + 50, GumpButtonType.Reply, 0);
                AddHtmlTexte(x + 375, y + line * scale, DefaultHtmlLength, ((MetierType)i).ToString());
                ++line;
            }

            if (page > 0)
                AddButton(x + 360, y + line * scale, 4014, 4015, 10, GumpButtonType.Reply, 0);
            if (page < (int)MetierType.Maximum / lineMax)
                AddButton(x + 515, y + line * scale, 4005, 4006, 11, GumpButtonType.Reply, 0);

            if (metierType != MetierType.None)
            {
                MetierInfo info = Metiers.GetInfos(metierType);

                int linetmp = line;

                line = 0;
                AddButton(x, y + line * scale, 8, info.Image);
                //AddTooltip(TemraelClasse.GetTooltipMetier(metierType));

                List<string> listDon = new List<string>();
                bool HasDon = false;
                string temp = String.Empty;
                string nomTemp = String.Empty;
                string descrTemp = String.Empty;
                string reqTemp = String.Empty;

                /*temp += "<strong>Compétences de Classe</strong>: ";

                for (int i = 0; i < info.MetierCompetences.Length; i++)
                {
                    if (i != info.MetierCompetences.Length - 1)
                        temp += info.MetierCompetences[i].ToString() + ", ";
                    else
                        temp += info.MetierCompetences[i].ToString();
                }*/

                List<NAptitude> listAptitude = new List<NAptitude>();
                bool hasAptitude = false;
                for (int j = 0; j < info.Aptitudes.Length; j++)
                {
                    foreach (NAptitude aptitude in listAptitude)
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
                AddSection(x, y + line * scale, 540, 155, "Aptitudes & Spécialités", temp);

                line = 0;
                if (!from.hasMetier(metierType))
                {
                    if (canMultiClasse(from))
                    {
                        AddButton(x + 195, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                        AddHtml(x + 245, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Multiclasser<basefont></h3>", false, false);
                    }
                }

                /*if (from.hasMetier(metierType))
                {
                    if (canUp && canUpClasse(from, info))
                    {
                        AddButton(x + 195, y + (line * scale), 52, 52, 9, GumpButtonType.Reply, 0);
                        AddHtml(x + 245, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Augmenter<basefont></h3>", false, false);
                    }
                }*/
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
                    from.MetierType.Add(m_metierType);
                    from.SendGump(new FicheClasseGump(from));
                    break;
                case 9:

                    break;
                case 10:
                    from.SendGump(new FicheMetiersInfoGump(from, m_metierType, m_page - 1));
                    break;
                case 11:
                    from.SendGump(new FicheMetiersInfoGump(from, m_metierType, m_page + 1));
                    break;
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new FicheMetiersInfoGump(from, (MetierType)(info.ButtonID - 50), m_page));
            }
        }
    }
}
