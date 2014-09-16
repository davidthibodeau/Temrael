using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using Server.SkillHandlers;

namespace Server.Gumps
{
    class CompetenceGump : Gump
    {

        private TMobile m_From;
        private SkillCategory m_Comp;
        private bool m_ShowCaps;

        public CompetenceGump(TMobile from, SkillCategory Comp, bool ShowCaps) : base(0, 0)
        {
            m_From = from;
            m_Comp = Comp;
            m_ShowCaps = ShowCaps;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //Restore
            AddButton(242, 55, 2093, 2093, 1, GumpButtonType.Reply, 0);

            //Titre
            if (m_Comp == SkillCategory.Aucun)
                AddBackground(80, 72, 345, 215, 5170);
            else if (m_Comp == SkillCategory.Magie)
                AddBackground(80, 72, 345, 475, 5170);
            else if (m_Comp == SkillCategory.Combat)
                AddBackground(80, 72, 345, 515, 5170);
            else if (m_Comp == SkillCategory.Roublardise)
                AddBackground(80, 72, 345, 475, 5170);
            else if (m_Comp == SkillCategory.Artisanat)
                AddBackground(80, 72, 345, 395, 5170);

            AddHtml(215, 78, 200, 20, "<h3><basefont color=#025a>Compétences<basefont></h3>", false, false);

            //Ligne
            AddImage(150, 105, 2091);

            int ybase = 120;
            int ypos = 0;

            //Categories
            SkillCategory[] cds = (SkillCategory[])Enum.GetValues(typeof(SkillCategory));
            SkillName[] sns = SkillInfo.CatTable;
            foreach (SkillCategory cd in cds)
            {
                if (cd == SkillCategory.Aucun)
                    continue;
                if (m_Comp == cd)
                    AddButton(100, (ybase + ypos + 2), 2086, 2086, 3 + (int)cd, GumpButtonType.Reply, 0);
                else
                    AddButton(100, ybase + ypos, 2087, 2087, 3 + (int)cd, GumpButtonType.Reply, 0);
                AddHtml(115, ybase + ypos, 200, 20, String.Format("<h3><basefont color=#025a>{0}<basefont></h3>", cd.ToString()), false, false);
                int textoffset = 0;
                switch (cd)
                {
                    case SkillCategory.Artisanat: textoffset = 70; break;
                    case SkillCategory.Combat: textoffset = 50; break;
                    case SkillCategory.Magie: textoffset = 48; break;
                    case SkillCategory.Roublardise: textoffset = 82; break;
                        
                }
                AddImageTiled(115 + textoffset, ybase + ypos + 7, 250 - textoffset, 5, 2101);
                ypos += 20;

                if(m_Comp == cd)
                    foreach (SkillName sn in sns)
                    {
                        int i = (int)sn;
                        SkillInfo si = null;

                        si = SkillInfo.Table[i];
                        if (si.Category != cd)
                            continue;

                        if (si.Callback != null)
                            AddButton(110, (ybase + ypos + 3), 2103, 2104, 300 + (int)sn, GumpButtonType.Reply, 0);
                        AddHtml(125, (ybase + ypos), 200, 20, String.Format("<h3><basefont color=#5A4A31>{0}<basefont></h3>", si.Name), false, false);
                        AddTooltip(3006369 + i); //TODO: Fix those.

                        if (m_ShowCaps)
                            AddHtml(m_From.Skills[sn].Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills[sn].Cap + "<basefont></h3>", false, false);
                        else
                            AddHtml(m_From.Skills[sn].Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills[sn].Value + "<basefont></h3>", false, false);
                        if (Competences.CanRaise(from, m_From.Skills[sn]))
                            AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + i, GumpButtonType.Reply, 0);
                        if (Competences.CanLower(from, m_From.Skills[sn]))
                            AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + i, GumpButtonType.Reply, 0);
                        ypos += 20;


                    }

            }


            //Ligne
            AddImage(150, (ybase + ypos + 2), 2091);

            //PC
            if (m_From is TMobile)
            {
                AddImage(105, (ybase + ypos + 20), 5411);
                AddTooltip(3006366);
                AddHtml(128, (ybase + ypos + 20), 200, 20, "<h3><basefont color=#025a>" + Competences.GetDisponibleComp(((TMobile)m_From)) + " | " + (Competences.GetRemainingComp(((TMobile)m_From)) - Competences.GetDisponibleComp(((TMobile)m_From))) + "<basefont></h3>", false, false);
            }

            //Cap Total
            AddImage(370, (ybase + ypos + 20), 2092);
            AddTooltip(3006367);
            AddHtml(290, (ybase + ypos + 20), 200, 20, "<h3><basefont color=#025a>" + (m_From.SkillsTotal / 10) + " | " + (m_From.SkillsCap / 10) + "<basefont></h3>", false, false);

            //Cap Individuel
            if (m_ShowCaps)
            {
                AddButton(390, (ybase + ypos + 45), 2223, 2223, 3, GumpButtonType.Reply, 0);
                AddTooltip(3006368);
                AddHtml(242, (ybase + ypos + 43), 200, 20, "<h3><basefont color=#025a>Montrer les Valeurs<basefont></h3>", false, false);
                AddTooltip(3006368);
            }
            else
            {
                AddButton(390, (ybase + ypos + 45), 2224, 2224, 3, GumpButtonType.Reply, 0);
                AddTooltip(3006368);
                AddHtml(265, (ybase + ypos + 43), 200, 20, "<h3><basefont color=#025a>Montrer les Caps<basefont></h3>", false, false);
                AddTooltip(3006368);
            }
            //Scroll
            AddImage(385, 100, 2089);
            AddImage(385, 115, 2088);
            AddImage(385, (ybase + ypos + 25), 2086);

            //AddButton(242, (ybase + ypos + 59), 2094, 2095, 2, GumpButtonType.Reply, 0);

            //Ligne
            //AddImage(150, (222 + ypos), 2091);

            //Libre
            //AddImage(365, (240 + ypos), 5411);
            //AddHtml(320, (240 + ypos), 200, 20, "<h3><basefont color=#025a>" + (m_From.SkillsTotal / 10).ToString("N1") + "<basefont></h3>", false, false);

            //Cap
            //AddImage(105, (240 + ypos), 2092);
            //AddHtml(120, (240 + ypos), 200, 20, "<h3><basefont color=#025a>" + (m_From.SkillsCap / 10).ToString("N1") + "<basefont></h3>", false, false);

            //Scroll
            //AddImage(385, (100 + ypos), 2089);
            //AddImage(385, (115 + ypos), 2088);
            //AddImage(385, (245 + ypos), 2086);

            //AddButton(242, (279 + ypos), 2094, 2095, 2, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 0: return;
                case 1: from.SendGump(new CompetenceSmallGump(m_From, m_Comp, m_ShowCaps)); break;
                case 2: from.SendGump(new CompetenceSmallGump(m_From, m_Comp, m_ShowCaps)); break;
                case 3:
                    if (m_ShowCaps)
                    {
                        from.SendGump(new CompetenceGump(m_From, m_Comp, false)); break;
                    }
                    else
                    {
                        from.SendGump(new CompetenceGump(m_From, m_Comp, true)); break;
                    }
                default:
                    try
                    {
                        int oldValue = 0;
                        SkillName comp;

                        if (info.ButtonID >= 300)
                        {
                            int i = info.ButtonID - 300;
                            comp = (SkillName)i;
                            if (i >= SkillInfo.Table.Length)
                            {
                                from.SendGump(new CompetenceGump(m_From, m_Comp, m_ShowCaps));
                                return;
                            }
                            if (from.NextSkillTime < Core.TickCount)
                            {
                                TimeSpan span = SkillInfo.Table[i].Callback(from);
                                from.NextSkillTime = Core.TickCount + Core.GetTicks(span);
                            }
                            else
                                from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                        }
                        if (info.ButtonID >= 200)
                        {
                            comp = (SkillName)(info.ButtonID - 200);
                            if ((int)comp >= SkillInfo.Table.Length)
                            {
                                from.SendGump(new CompetenceGump(m_From, m_Comp, m_ShowCaps));
                                return;
                            }
                            oldValue = Competences.GetValue(m_From, comp);

                            if (Competences.CanLower(m_From, comp))
                            {
                                Competences.Lower(m_From, comp, oldValue - 1);
                                if (comp == SkillName.Langues)
                                    m_From.Langues.FixLangues();
                                //m_From.Skills.(comp, oldValue - 1);
                            }
                            from.SendGump(new CompetenceGump(m_From, m_Comp, m_ShowCaps));
                        }
                        else if (info.ButtonID >= 100)
                        {
                            comp = (SkillName)(info.ButtonID - 100);
                            oldValue = Competences.GetValue(m_From, comp);

                            if (Competences.CanRaise(m_From, comp))
                            {
                                m_From.CompetencesLibres -= 1;
                                Competences.Raise(m_From, comp, oldValue + 1);
                            }
                            from.SendGump(new CompetenceGump(m_From, m_Comp, m_ShowCaps));
                        }
                        else
                        {
                            if (m_Comp != SkillCategory.Aucun)
                            {
                                from.SendGump(new CompetenceGump(m_From, SkillCategory.Aucun, m_ShowCaps));
                            }
                            else
                            {
                                from.SendGump(new CompetenceGump(m_From, (SkillCategory)(info.ButtonID - 3), m_ShowCaps));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Misc.ExceptionLogging.WriteLine(ex, "buttonID : {0}, from : {1}", info.ButtonID, from.NetState);
                    }
                    break;
            }

            
        }
    }
}
