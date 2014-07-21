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
    public class FicheClasseGump : GumpTemrael
    {
        private TMobile m_from;
        private ClasseType m_classeType;
        private int m_pageClasse;
        private int m_pageMetier;

        public FicheClasseGump(TMobile from)
            : this(from, from.ClasseType, 0, 0)
        {
        }

        public FicheClasseGump(TMobile from, ClasseType classeType, int pageClasse, int pageMetier)
            : base("Classe & Métier", 560, 622)
        {
            m_from = from;
            m_classeType = classeType;
            m_pageClasse = pageClasse;
            m_pageMetier = pageMetier;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;

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

            List<string> listDon = new List<string>();
            string temp = String.Empty;
            string nomTemp = String.Empty;
            string descrTemp = String.Empty;
            string reqTemp = String.Empty;

            /*Classe*/
            if (classeType != ClasseType.None && classeType != ClasseType.Maximum)
            {
                ClasseInfo info = Classes.GetInfos(classeType);

                AddButton(x, y + line * scale, 8, info.Image);
                AddTooltip(info.Tooltip);

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

                ClasseAptitudes[] classeApt = null;

                if (from.Niveau >= 30)
                    classeApt = info.FourthApt;
                else if (from.Niveau >= 20)
                    classeApt = info.ThirdApt;
                else if (from.Niveau >= 10)
                    classeApt = info.SecondApt;
                else
                    classeApt = info.FirstApt;

                line = 13;
                /*classes = new TemraelClasse[from.GetClasses().Count];
                from.GetClasses().CopyTo(classes, 0);
                if (pageClasse > 0)
                    AddButton(x + 175, y + line * scale, 4014, 4015, 10, GumpButtonType.Reply, 0);
                if (pageClasse < classes.Length - 1)
                    AddButton(x + 225, y + line * scale, 4005, 4006, 11, GumpButtonType.Reply, 0);*/

                ++line;
                AddSection(x, y + line * scale, 265, 120, info.Nom, temp);
                
                line -= 3;
                AddButton(x, y + (line * scale) + 10, 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 50, y + (line * scale) + 22, 200, 20, "<h3><basefont color=#025a>Classe<basefont></h3>", false, false);

                /*if (from.NivClassDispo > 0 && canUpClasse(from, info))
                {
                    line += 9;
                    AddButton(x + 105, y + line * scale, 4005, 4006, 14, GumpButtonType.Reply, 0);
                }*/
            }
            else
            {
                line = 11;
                AddButton(x, y + (line * scale) + 10, 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 50, y + (line * scale) + 22, 200, 20, "<h3><basefont color=#025a>Classe<basefont></h3>", false, false);
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
                    from.SendGump(new FicheClassesInfoGump(from, m_classeType, 0));
                    break;
                
                case 12:
                    --m_pageMetier;
                    from.SendGump(new FicheClasseGump(from, m_classeType, m_pageClasse, m_pageMetier));
                    break;
                case 13:
                    ++m_pageMetier;
                    from.SendGump(new FicheClasseGump(from, m_classeType, m_pageClasse, m_pageMetier));
                    break;
                case 14:
                    /*if (from.Dons.canUpClasse())
                    {
                        TemraelClasse c = null;
                        try
                        {
                            c = from.getClasse(m_classeType);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Mauvaise classe : FicheClassesInfoGump, case 9, OnResponse");
                        }
                        if (c != null)
                            from.MakeClasse(c.GetType(), c.Niveau + 1);
                    }*/
                    from.SendGump(new FicheClasseGump(from, m_classeType, m_pageClasse, m_pageMetier));
                    break;
            }
        }
    }
}
