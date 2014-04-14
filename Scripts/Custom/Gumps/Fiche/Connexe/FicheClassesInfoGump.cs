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
    public class FicheClassesInfoGump : GumpTemrael
    {
        TMobile m_from;
        ClasseType m_classeType;
        private int m_page;

        public FicheClassesInfoGump(TMobile from) : this(from, from.ClasseType, 0)
        {
        }

        public FicheClassesInfoGump(TMobile from, ClasseType classeType, int page)
            : base("Classe & Métier", 560, 622)
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
                AddButton(x + 360, y + line * scale, 4014, 4015, 10, GumpButtonType.Reply, 0);
            if (page < (int)ClasseType.Maximum / lineMax)
                AddButton(x + 515, y + line * scale, 4005, 4006, 11, GumpButtonType.Reply, 0);
            ++line;

            if (classeType != ClasseType.None && classeType != ClasseType.Maximum)
            {
                ClasseInfo info = Classes.GetInfos(classeType);

                int linetmp = line;

                line = 0;

                if (from.ClasseType == ClasseType.None)
                {
                    AddButton(x + 195, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                    AddHtml(x + 245, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Choisir<basefont></h3>", false, false);
                }
                AddButton(x, y + line * scale, 9, info.Image);
                AddTooltip(info.Tooltip);

                // Apparait en double pour assurer l'affichage correct ainsi que la priorite du bouton. 
                if (from.ClasseType == ClasseType.None)
                {
                    AddButton(x + 195, y + (line * scale), 52, 52, 8, GumpButtonType.Reply, 0);
                    AddHtml(x + 245, y + (line * scale) + 12, 200, 20, "<h3><basefont color=#025a>Choisir<basefont></h3>", false, false);
                }

                

                line = linetmp;
                AddSection(x + 240, y + line * scale, 300, 90, info.Nom, info.Role);

                List<string> listDon = new List<string>();
                string temp = String.Empty;
                string nomTemp = String.Empty;
                string descrTemp = String.Empty;
                string reqTemp = String.Empty;

                /*temp += "<strong>Arme de Prédilection</strong>: " + info.ArmeAllow.ToString() + Environment.NewLine;
                temp += "<strong>Armure de Prédilection</strong>: " + info.ArmorAllow.ToString() + Environment.NewLine;
                temp += "<strong>Compétences de Classe</strong>: ";

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
                AddSection(x, y + line * scale, 540, 155, "Aptitudes & Spécialités", temp);
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
                    from.ClasseType = m_classeType;
                    from.SendGump(new FicheClasseGump(from));
                    break;
                case 9:
                    from.SendGump(new FicheClassesInfoGump(from, m_classeType, m_page));
                    break;
                case 10:
                    from.SendGump(new FicheClassesInfoGump(from, m_classeType, m_page - 1));
                    break;
                case 11:
                    from.SendGump(new FicheClassesInfoGump(from, m_classeType, m_page + 1));
                    break;
            }

            if (info.ButtonID >= 50)
            {
                from.SendGump(new FicheClassesInfoGump(from, (ClasseType)(info.ButtonID - 50), m_page));
            }
        }
    }
}
