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
        public enum CompDomaines
        {
            Aucun,
            Magie,
            Combat,
            Roublard,
            Artisanat,
            Connaissances
        }

        private TMobile m_From;
        private CompDomaines m_Comp;
        private bool m_ShowCaps;

        public CompetenceGump(TMobile from, CompDomaines Comp, bool ShowCaps) : base(0, 0)
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
            if (m_Comp == CompDomaines.Aucun)
                AddBackground(80, 72, 345, 215, 5170);
            else if (m_Comp == CompDomaines.Magie)
                AddBackground(80, 72, 345, 435, 5170);
            else if (m_Comp == CompDomaines.Combat)
                AddBackground(80, 72, 345, 415, 5170);
            else if (m_Comp == CompDomaines.Roublard)
                AddBackground(80, 72, 345, 495, 5170);
            else if (m_Comp == CompDomaines.Artisanat)
                AddBackground(80, 72, 345, 395, 5170);
            else if (m_Comp == CompDomaines.Connaissances)
                AddBackground(80, 72, 345, 235, 5170);
            else
                AddBackground(80, 72, 345, 215, 5170);

            AddHtml(215, 78, 200, 20, "<h3><basefont color=#025a>Compétences<basefont></h3>", false, false);

            //Ligne
            AddImage(150, 105, 2091);

            int ybase = 120;
            int ypos = 0;

            //Categories
            if (m_Comp == CompDomaines.Magie)
                AddButton(100, (ybase + 2), 2086, 2086, 3, GumpButtonType.Reply, 0);
            else
                AddButton(100, ybase, 2087, 2087, 3, GumpButtonType.Reply, 0);
            AddHtml(115, ybase, 200, 20, "<h3><basefont color=#025a>Magie<basefont></h3>", false, false);
            AddImageTiled(160, (ybase + 7), 195, 5, 2101);
            ypos += 20;

            if (m_Comp == CompDomaines.Magie)
            {
                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Alchimie<basefont></h3>", false, false);
                AddTooltip(3006369);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Alchimie.Cap > 99 ? 327:332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Alchimie.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Alchimie.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Alchimie.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Alchimie))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Alchimie.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Alchimie))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Alchimie.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Art de la Magie<basefont></h3>", false, false);
                AddTooltip(3006370);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ArtMagique.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArtMagique.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ArtMagique.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArtMagique.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ArtMagique))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ArtMagique.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ArtMagique))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ArtMagique.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 300, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Concentration<basefont></h3>", false, false);
                AddTooltip(3006371);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Concentration.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Concentration.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Concentration.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Concentration.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Concentration))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Concentration.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Concentration))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Concentration.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Conjuration<basefont></h3>", false, false);
                AddTooltip(3006372);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Conjuration.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Conjuration.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Conjuration.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Conjuration.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Conjuration))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Conjuration.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Conjuration))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Conjuration.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Destruction<basefont></h3>", false, false);
                AddTooltip(3006373);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Destruction.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Destruction.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Destruction.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Destruction.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Destruction))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Destruction.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Destruction))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Destruction.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Goetie<basefont></h3>", false, false);
                AddTooltip(3006374);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Goetie.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Goetie.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Goetie.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Goetie.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Goetie))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Goetie.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Goetie))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Goetie.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 301, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Inscription<basefont></h3>", false, false);
                AddTooltip(3006375);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Inscription.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Inscription.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Inscription.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Inscription.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Inscription))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Inscription.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Inscription))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Inscription.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                /*AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Miracles<basefont></h3>", false, false);
                AddTooltip(3006376);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Miracles.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Miracles.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Miracles.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Miracles.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Miracles))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Miracles.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Miracles))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Miracles.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;*/

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Mysticisme<basefont></h3>", false, false);
                AddTooltip(3006377);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Mysticisme.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Mysticisme.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Mysticisme.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Mysticisme.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Mysticisme))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Mysticisme.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Mysticisme))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Mysticisme.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                /*AddButton(110, (ybase + ypos + 3), 2103, 2104, 302, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Prières<basefont></h3>", false, false);
                AddTooltip(3006378);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Priere.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Priere.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Priere.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Priere.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Priere))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Priere.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Priere))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Priere.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;*/

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Restoration<basefont></h3>", false, false);
                AddTooltip(3006379);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Restoration.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Restoration.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Restoration.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Restoration.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Restoration))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Restoration.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Restoration))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Restoration.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Rêve<basefont></h3>", false, false);
                AddTooltip(3006380);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Reve.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Reve.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Reve.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Reve.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Reve))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Reve.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Reve))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Reve.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Tenebrea<basefont></h3>", false, false);
                AddTooltip(3006381);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Tenebrea.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Tenebrea.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Tenebrea.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Tenebrea.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Tenebrea))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Tenebrea.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Tenebrea))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Tenebrea.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;
            }

            if (m_Comp == CompDomaines.Combat)
                AddButton(100, (ybase + ypos + 2), 2086, 2086, 4, GumpButtonType.Reply, 0);
            else
                AddButton(100, (ybase + ypos), 2087, 2087, 4, GumpButtonType.Reply, 0);
            AddHtml(115, (ybase + ypos), 200, 20, "<h3><basefont color=#025a>Combat<basefont></h3>", false, false);
            AddImageTiled(162, (ybase + ypos + 7), 193, 5, 2101);
            ypos += 20;

            if (m_Comp == CompDomaines.Combat)
            {
                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Armes d'Hastes<basefont></h3>", false, false);
                AddTooltip(3006382);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ArmeHaste.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeHaste.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ArmeHaste.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeHaste.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ArmeHaste))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ArmeHaste.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ArmeHaste))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ArmeHaste.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Armes de Distance<basefont></h3>", false, false);
                AddTooltip(3006383);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ArmeDistance.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeDistance.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ArmeDistance.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeDistance.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ArmeDistance))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ArmeDistance.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ArmeDistance))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ArmeDistance.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Armes Contondantes<basefont></h3>", false, false);
                AddTooltip(3006384);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ArmeContondante.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeContondante.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ArmeContondante.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeContondante.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ArmeContondante))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ArmeContondante.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ArmeContondante))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ArmeContondante.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Armes Tranchantes<basefont></h3>", false, false);
                AddTooltip(3006385);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ArmeTranchante.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeTranchante.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ArmeTranchante.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmeTranchante.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ArmeTranchante))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ArmeTranchante.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ArmeTranchante))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ArmeTranchante.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Armes Perforantes<basefont></h3>", false, false);
                AddTooltip(3006386);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ArmePerforante.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmePerforante.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ArmePerforante.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmePerforante.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ArmePerforante))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ArmePerforante.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ArmePerforante))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ArmePerforante.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Armes de Poings<basefont></h3>", false, false);
                AddTooltip(3006387);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ArmePoing.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmePoing.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ArmePoing.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ArmePoing.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ArmePoing))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ArmePoing.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ArmePoing))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ArmePoing.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Équitation<basefont></h3>", false, false);
                AddTooltip(3006388);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Equitation.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Equitation.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Equitation.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Equitation.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Equitation))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Equitation.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Equitation))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Equitation.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Parer<basefont></h3>", false, false);
                AddTooltip(3006389);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Parer.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Parer.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Parer.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Parer.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Parer))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Parer.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Parer))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Parer.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 303, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Soins<basefont></h3>", false, false);
                AddTooltip(3006390);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Soins.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Soins.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Soins.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Soins.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Soins))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Soins.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Soins))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Soins.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Tactiques<basefont></h3>", false, false);
                AddTooltip(3006391);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Tactiques.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Tactiques.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Tactiques.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Tactiques.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Tactiques))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Tactiques.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Tactiques))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Tactiques.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;
            }

            if (m_Comp == CompDomaines.Roublard)
                AddButton(100, (ybase + ypos + 2), 2086, 2086, 5, GumpButtonType.Reply, 0);
            else
                AddButton(100, (ybase + ypos), 2087, 2087, 5, GumpButtonType.Reply, 0);
            AddHtml(115, (ybase + ypos), 200, 20, "<h3><basefont color=#025a>Roublard<basefont></h3>", false, false);
            AddImageTiled(175, (ybase + ypos + 7), 180, 5, 2101);
            ypos += 20;

            if (m_Comp == CompDomaines.Roublard)
            {
                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Crochetage<basefont></h3>", false, false);
                AddTooltip(3006392);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Crochetage.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Crochetage.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Crochetage.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Crochetage.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Crochetage))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Crochetage.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Crochetage))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Crochetage.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 304, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Dégustation<basefont></h3>", false, false);
                AddTooltip(3006393);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Degustation.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Degustation.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Degustation.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Degustation.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Degustation))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Degustation.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Degustation))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Degustation.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 305, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Détection<basefont></h3>", false, false);
                AddTooltip(3006393);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Detection.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Detection.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Detection.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Detection.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Detection))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Detection.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Detection))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Detection.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 306, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Discrétion<basefont></h3>", false, false);
                AddTooltip(3006394);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Discretion.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Discretion.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Discretion.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Discretion.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Discretion))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Discretion.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Discretion))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Discretion.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 307, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Dressage<basefont></h3>", false, false);
                AddTooltip(3006395);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Dressage.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Dressage.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Dressage.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Dressage.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Dressage))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Dressage.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Dressage))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Dressage.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Élevage<basefont></h3>", false, false);
                AddTooltip(3006396);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Elevage.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Elevage.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Elevage.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Elevage.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Elevage))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Elevage.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Elevage))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Elevage.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 308, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Empoisonner<basefont></h3>", false, false);
                AddTooltip(3006397);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Empoisonner.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Empoisonner.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Empoisonner.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Empoisonner.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Empoisonner))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Empoisonner.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Empoisonner))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Empoisonner.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 309, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Fouille<basefont></h3>", false, false);
                AddTooltip(3006398);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Fouille.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Fouille.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Fouille.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Fouille.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Fouille))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Fouille.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Fouille))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Fouille.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 310, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Infiltration<basefont></h3>", false, false);
                AddTooltip(3006399);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Infiltration.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Infiltration.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Infiltration.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Infiltration.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Infiltration))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Infiltration.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Infiltration))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Infiltration.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 311, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Maîtrise des Pièges<basefont></h3>", false, false);
                AddTooltip(3006400);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Pieges.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Pieges.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Pieges.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Pieges.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Pieges))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Pieges.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Pieges))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Pieges.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Musique<basefont></h3>", false, false);
                AddTooltip(3006401);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Musique.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Musique.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Musique.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Musique.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Musique))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Musique.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Musique))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Musique.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 312, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Poursuite<basefont></h3>", false, false);
                AddTooltip(30064020);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Poursuite.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Poursuite.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Poursuite.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Poursuite.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Poursuite))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Poursuite.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Poursuite))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Poursuite.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 313, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Survie<basefont></h3>", false, false);
                AddTooltip(3006403);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Survie.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Survie.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Survie.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Survie.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Survie))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Survie.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Survie))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Survie.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 314, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Vol<basefont></h3>", false, false);
                AddTooltip(3006404);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Vol.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Vol.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Vol.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Vol.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Vol))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Vol.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Vol))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Vol.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;
            }

            if (m_Comp == CompDomaines.Artisanat)
                AddButton(100, (ybase + ypos + 2), 2086, 2086, 6, GumpButtonType.Reply, 0);
            else
                AddButton(100, (ybase + ypos), 2087, 2087, 6, GumpButtonType.Reply, 0);
            AddHtml(115, (ybase + ypos), 200, 20, "<h3><basefont color=#025a>Artisanat<basefont></h3>", false, false);
            AddImageTiled(181, (ybase + ypos + 7), 174, 5, 2101);
            ypos += 20;

            if (m_Comp == CompDomaines.Artisanat)
            {
                /*//AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Agriculture<basefont></h3>", false, false);
                AddTooltip(3006405);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Agriculture.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Agriculture.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Agriculture.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Agriculture.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Agriculture))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Agriculture.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Agriculture))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Agriculture.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;*/

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Bricolage<basefont></h3>", false, false);
                AddTooltip(3006406);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Bricolage.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Bricolage.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Bricolage.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Bricolage.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Bricolage))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Bricolage.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Bricolage))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Bricolage.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Cuisine<basefont></h3>", false, false);
                AddTooltip(3006407);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Cuisine.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Cuisine.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Cuisine.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Cuisine.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Cuisine))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Cuisine.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Cuisine))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Cuisine.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Couture<basefont></h3>", false, false);
                AddTooltip(3006408);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Couture.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Couture.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Couture.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Couture.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Couture))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Couture.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Couture))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Couture.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Excavation<basefont></h3>", false, false);
                AddTooltip(3006409);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Excavation.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Excavation.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Excavation.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Excavation.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Excavation))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Excavation.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Excavation))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Excavation.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                /*AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Fabrication d'Art<basefont></h3>", false, false);
                AddTooltip(3006410);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.FabricationArt.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.FabricationArt.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.FabricationArt.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.FabricationArt.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.FabricationArt))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.FabricationArt.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.FabricationArt))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.FabricationArt.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;*/

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Foresterie<basefont></h3>", false, false);
                AddTooltip(3006411);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Foresterie.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Foresterie.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Foresterie.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Foresterie.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Foresterie))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Foresterie.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Foresterie))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Foresterie.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Forge<basefont></h3>", false, false);
                AddTooltip(3006412);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Forge.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Forge.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Forge.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Forge.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Forge))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Forge.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Forge))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Forge.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                AddButton(110, (ybase + ypos + 3), 2103, 2104, 319, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Identification<basefont></h3>", false, false);
                AddTooltip(3006413);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Identification.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Identification.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Identification.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Identification.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Identification))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Identification.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Identification))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Identification.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Menuiserie<basefont></h3>", false, false);
                AddTooltip(3006414);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Menuiserie.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Menuiserie.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Menuiserie.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Menuiserie.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Menuiserie))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Menuiserie.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Menuiserie))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Menuiserie.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 7, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Pêche<basefont></h3>", false, false);
                AddTooltip(3006415);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.Peche.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Peche.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.Peche.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.Peche.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.Peche))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.Peche.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.Peche))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.Peche.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;
            }

            if(m_Comp == CompDomaines.Connaissances)
                AddButton(100, (ybase + ypos + 2), 2086, 2086, 7, GumpButtonType.Reply, 0);
            else
                AddButton(100, (ybase + ypos), 2087, 2087, 7, GumpButtonType.Reply, 0);

            AddHtml(115, (ybase + ypos), 200, 20, "<h3><basefont color=#025a>Connaissances<basefont></h3>", false, false);
            AddImageTiled(208, (ybase + ypos + 7), 147, 5, 2101);
            ypos += 20;

            if (m_Comp == CompDomaines.Connaissances)
            {
                /*//AddButton(110, (ybase + ypos + 3), 2103, 2104, 315, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Connaissance(Bestiaire)<basefont></h3>", false, false);
                AddTooltip(3006416);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ConnaissanceBestiaire.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceBestiaire.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ConnaissanceBestiaire.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceBestiaire.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ConnaissanceBestiaire))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ConnaissanceBestiaire.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ConnaissanceBestiaire))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ConnaissanceBestiaire.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;*/

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 316, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Connaissance(Langue)<basefont></h3>", false, false);
                AddTooltip(3006417);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ConnaissanceLangue.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceLangue.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ConnaissanceLangue.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceLangue.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ConnaissanceLangue))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ConnaissanceLangue.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ConnaissanceLangue))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ConnaissanceLangue.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                /*//AddButton(110, (ybase + ypos + 3), 2103, 2104, 317, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Connaissance(Nature)<basefont></h3>", false, false);
                AddTooltip(3006418);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ConnaissanceNature.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceNature.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ConnaissanceNature.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceNature.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ConnaissanceNature))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ConnaissanceNature.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ConnaissanceNature))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ConnaissanceNature.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;

                //AddButton(110, (ybase + ypos + 3), 2103, 2104, 318, GumpButtonType.Reply, 0);
                AddHtml(125, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>Connaissance(Noblesse)<basefont></h3>", false, false);
                AddTooltip(3006419);
                if (m_ShowCaps)
                    AddHtml(m_From.Skills.ConnaissanceNoblesse.Cap > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceNoblesse.Cap + "<basefont></h3>", false, false);
                else
                    AddHtml(m_From.Skills.ConnaissanceNoblesse.Value > 99 ? 327 : 332, (ybase + ypos), 200, 20, "<h3><basefont color=#5A4A31>" + m_From.Skills.ConnaissanceNoblesse.Value + "<basefont></h3>", false, false);
                if (Competences.CanRaise(from, m_From.Skills.ConnaissanceNoblesse))
                    AddButton(353, (ybase + ypos + 3), 2089, 2089, 100 + (int)m_From.Skills.ConnaissanceNoblesse.SkillID, GumpButtonType.Reply, 0);
                if (Competences.CanLower(from, m_From.Skills.ConnaissanceNoblesse))
                    AddButton(368, (ybase + ypos + 3), 2086, 2086, 200 + (int)m_From.Skills.ConnaissanceNoblesse.SkillID, GumpButtonType.Reply, 0);
                ypos += 20;*/
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
                AddButton(390, (ybase + ypos + 45), 2223, 2223, 8, GumpButtonType.Reply, 0);
                AddTooltip(3006368);
                AddHtml(242, (ybase + ypos + 43), 200, 20, "<h3><basefont color=#025a>Montrer les Valeurs<basefont></h3>", false, false);
                AddTooltip(3006368);
            }
            else
            {
                AddButton(390, (ybase + ypos + 45), 2224, 2224, 8, GumpButtonType.Reply, 0);
                AddTooltip(3006368);
                AddHtml(265, (ybase + ypos + 43), 200, 20, "<h3><basefont color=#025a>Montrer les Caps<basefont></h3>", false, false);
                AddTooltip(3006368);
            }
            //Scroll
            AddImage(385, 100, 2089);
            AddImage(385, 115, 2088);
            AddImage(385, (ybase + ypos + 25), 2086);

            AddButton(242, (ybase + ypos + 59), 2094, 2095, 2, GumpButtonType.Reply, 0);

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
                case 1: from.SendGump(new CompetenceSmallGump(m_From, m_Comp, m_ShowCaps)); break;
                case 2: from.SendGump(new CompetenceSmallGump(m_From, m_Comp, m_ShowCaps)); break;
                case 3:
                    if (m_Comp == CompDomaines.Magie)
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Aucun, m_ShowCaps)); break;
                    }
                    else
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Magie, m_ShowCaps)); break;
                    }
                case 4:
                    if (m_Comp == CompDomaines.Combat)
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Aucun, m_ShowCaps)); break;
                    }
                    else
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Combat, m_ShowCaps)); break;
                    }
                case 5:
                    if (m_Comp == CompDomaines.Roublard)
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Aucun, m_ShowCaps)); break;
                    }
                    else
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps)); break;
                    }
                case 6:
                    if (m_Comp == CompDomaines.Artisanat)
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Aucun, m_ShowCaps)); break;
                    }
                    else
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Artisanat, m_ShowCaps)); break;
                    }
                case 7:
                    if (m_Comp == CompDomaines.Connaissances)
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Aucun, m_ShowCaps)); break;
                    }
                    else
                    {
                        from.SendGump(new CompetenceGump(m_From, CompDomaines.Connaissances, m_ShowCaps)); break;
                    }
                case 8:
                    if (m_ShowCaps)
                    {
                        from.SendGump(new CompetenceGump(m_From, m_Comp, false)); break;
                    }
                    else
                    {
                        from.SendGump(new CompetenceGump(m_From, m_Comp, true)); break;
                    }
                    //Concentration
                case 300:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = Meditation.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Magie, m_ShowCaps));
                    break;
                    //Inscription
                case 301:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = Inscribe.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Magie, m_ShowCaps));
                    break;
                    //Prieres
                case 302:
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Magie, m_ShowCaps));
                    break;
                    //Soins
                case 303:
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Combat, m_ShowCaps));
                    break;
                    //Degustation
                case 304:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = TasteID.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Detection
                case 305:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = DetectHidden.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Discretion
                case 306:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = Hiding.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Dressage
                case 307:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = AnimalTaming.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Empoisonner
                case 308:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = Poisoning.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Fouille
                case 309:
                    from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Infiltration
                case 310:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = Stealth.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                case 311:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = RemoveTrap.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Poursuite
                case 312:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = Tracking.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Survie
                case 313:
                    from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Vol
                case 314:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = Stealing.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Roublard, m_ShowCaps));
                    break;
                    //Connaissances Bestiaire
                case 315:
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Connaissances, m_ShowCaps));
                    break;
                    //Connaissances Langue
                case 316:
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Connaissances, m_ShowCaps));
                    break;
                    //Connaissances Nature
                case 317:
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Connaissances, m_ShowCaps));
                    break;
                    //Connaissances Noblesse
                case 318:
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Connaissances, m_ShowCaps));
                    break;
                    //Identification
                case 319:
                    if (from.NextSkillTime < DateTime.Now)
                    {
                        TimeSpan span = ItemIdentification.OnUse(from);
                        from.NextSkillTime = DateTime.Now.Add(span);
                    }
                    else
                    {
                        from.SendMessage("Il est trop tot pour utiliser une competence a nouveau.");
                    }
                    //from.SendGump(new CompetenceGump(m_From, CompDomaines.Artisanat, m_ShowCaps));
                    break;
                default: break;
            }

            try
            {
                int oldValue = 0;
                SkillName comp;

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
                        if (comp == SkillName.ConnaissanceLangue)
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
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex, "buttonID : {0}, from : {1}", info.ButtonID, from.NetState);
            }
        }
    }
}
