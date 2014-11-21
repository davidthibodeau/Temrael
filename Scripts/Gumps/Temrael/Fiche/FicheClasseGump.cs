using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;

namespace Server.Gumps.Fiche
{
    public class FicheClasseGump : BaseFicheGump
    {
        private ClasseType m_classeType;
        private int m_pageClasse;
        private int m_pageMetier;

        public FicheClasseGump(PlayerMobile from)
            : this(from, ClasseType.None, 0, 0)
        {
        }

        public FicheClasseGump(PlayerMobile from, ClasseType classeType, int pageClasse, int pageMetier)
            : base(from, "Classe", 560, 622, 2)
        {
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

                for (int i = 0; i < info.ClasseCompetences.Length; i++)
                {
                    temp += info.ClasseCompetences[i].SkillName.ToString() + ": " + info.ClasseCompetences[i].Value.ToString() + "%";
                    if (i != info.ClasseCompetences.Length - 1)
                        temp += Environment.NewLine;
                }

                line = 12;
                AddSection(x, y + line * scale, 540, 120, "Compétences appliquées au niveau 30", temp);
                
                line -= 3;
                AddButton(x, y + (line * scale) + 10, 52, 52, 8, GumpButtonType.Reply, 0);
                AddHtml(x + 50, y + (line * scale) + 22, 200, 20, "<h3><basefont color=#025a>Classe<basefont></h3>", false, false);
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
            PlayerMobile from = (PlayerMobile)sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            if (info.ButtonID < 8)
            {
                base.OnResponse(sender, info);
                return;
            }

            switch (info.ButtonID)
            {
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
