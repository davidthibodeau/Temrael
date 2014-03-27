using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Gumps
{
    class FicheAptitudesGump : GumpTemrael
    {
        private TMobile m_From;
        private ClasseBranche m_Tab;

        public FicheAptitudesGump(TMobile from, ClasseBranche tab)
            : base("Aptitudes", 560, 622)
        {
            m_From = from;
            m_Tab = tab;

            int x = XBase;
            int y = YBase;

            y = 650;
            x = 90;
            int space = 80;

            AddMenuItem(x, y, 1178, 1, true);
            x += space;
            AddMenuItem(x, y, 1179, 2, true);
            x += space;
            AddMenuItem(x, y, 1180, 3, true);
            x += space;
            AddMenuItem(x, y, 1194, 4, false);
            x += space;
            AddMenuItem(x, y, 1196, 5, true);
            x += space;
            AddMenuItem(x, y, 1222, 6, true);
            x += space;
            AddMenuItem(x, y, 1191, 7, true);

            x = XBase;
            y = YBase;

            if (!(tab == ClasseBranche.Aucun))
            {
                //AddLabel(302, 32, 2101, "Aptitudes");
                AddHtml(251, 135, 400, 20, String.Format("<h3><basefont color=#025a>Disponible : {0} | Indisponible : {1}<basefont></h3>", Aptitudes.GetDisponiblePA(m_From), Aptitudes.GetRemainingPA(m_From) - Aptitudes.GetDisponiblePA(m_From)), false, false);
                AddImage(240, 140, 95);
                AddImageTiled(240, 149, 247, 3, 96);
                AddImage(485, 140, 97);

                //AddLabel(186, 108, 2101, String.Format("Points d'aptitude disponibles / en attente: {0} / {1}", Aptitudes.GetDisponiblePA(m_From), Aptitudes.GetRemainingPA(m_From) - Aptitudes.GetDisponiblePA(m_From)));
                //AddImageTiled(175, 143, 327, 3, 9101);

                AddImage(95, 176, 95);
                AddImageTiled(95, 185, 545, 3, 96);
                AddImage(640, 176, 97);
                AddHtml(140, 172, 200, 20, "<h3><basefont color=#025a>Nom de l'Aptitude<basefont></h3>", false, false);
                AddHtml(275, 172, 200, 20, "<h3><basefont color=#025a>Niveau<basefont></h3>", false, false);
                AddHtml(330, 172, 200, 20, "<h3><basefont color=#025a>Coût<basefont></h3>", false, false);
                AddHtml(375, 172, 200, 20, "<h3><basefont color=#025a>Compétence Requise<basefont></h3>", false, false);
            }

            switch(tab)
            {
                case ClasseBranche.Aucun:
                    AddButton(125, 148, 166, 166, 8, GumpButtonType.Reply, 0);
                    AddButton(320, 148, 167, 167, 9, GumpButtonType.Reply, 0);
                    AddButton(480, 148, 168, 168, 10, GumpButtonType.Reply, 0);
                    //AddButton(165, 390, 169, 169, 11, GumpButtonType.Reply, 0);
                    AddButton(395, 390, 170, 170, 12, GumpButtonType.Reply, 0);
                    break;
                case ClasseBranche.Guerrier:
                    AddImage(425, 248, 263);
                    CreateAptitudes(m_From, ClasseBranche.Guerrier);
                    break;
                case ClasseBranche.Artisan:
                    AddImage(125, 328, 179);
                    AddImage(325, 348, 318);
                    CreateAptitudes(m_From, ClasseBranche.Artisan);
                    break;
                case ClasseBranche.Cleric:
                    AddImage(125, 328, 350);
                    CreateAptitudes(m_From, ClasseBranche.Cleric);
                    break;
                case ClasseBranche.Magie:
                    AddImage(125, 328, 438);
                    AddImage(522, 328, 299);
                    CreateAptitudes(m_From, ClasseBranche.Magie);
                    break;
                case ClasseBranche.Roublard:
                    AddImage(535, 348, 308);
                    AddImage(275, 398, 316);
                    CreateAptitudes(m_From, ClasseBranche.Roublard);
                    break;
                default: break;
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            //Console.WriteLine("FicheAptitudesGump.ButtonID = " + info.ButtonID);
            switch (info.ButtonID)
            {
                //Navigation
                case 0:
                    if (m_Tab == ClasseBranche.Aucun)
                        from.SendGump(new FicheAptitudeGump(m_From));
                    else
                        from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Aucun));
                    break;
                case 1:
                    from.SendGump(new FicheRaceGump(m_From));
                    break;
                case 2:
                    from.SendGump(new FicheClasseGump(m_From));
                    break;
                case 3:
                    from.SendGump(new FicheCaracteristiqueGump(m_From));
                    break;
                case 4:
                    from.SendGump(new FicheAptitudeGump(m_From));
                    break;
                case 5:
                    from.SendGump(new FicheMagieGump(m_From));
                    break;
                case 6:
                    from.SendGump(new FicheStatutsGump(m_From));
                    break;
                case 7:
                    from.SendGump(new FicheCommandesGump(m_From));
                    break;
                case 8:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Artisan));
                    break;
                case 9:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Guerrier));
                    break;
                case 10:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Magie));
                    break;
                case 11:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Cleric));
                    break;
                case 12:
                    from.SendGump(new FicheAptitudesGump(m_From, ClasseBranche.Roublard));
                    break;
            }

            try
            {
                int oldValue = 0;
                Aptitude aptitude;

                if (info.ButtonID >= 1000)
                {
                    aptitude = (Aptitude)(info.ButtonID - 1000);
                    oldValue = Aptitudes.GetValue(m_From, aptitude);

                    from.SendGump(new FicheAptitudeInfoGump(m_From, aptitude));
                }
                else if (info.ButtonID >= 500)
                {
                    aptitude = (Aptitude)(info.ButtonID - 500);
                    oldValue = Aptitudes.GetValue(m_From, aptitude);

                    if (Aptitudes.CanLower(m_From, aptitude))
                    {
                        m_From.Aptitudes.SetValue(aptitude, oldValue - 1);
                    }
                    from.SendGump(new FicheAptitudesGump(m_From, m_Tab));
                }
                else if (info.ButtonID >= 100)
                {
                    aptitude = (Aptitude)(info.ButtonID - 100);
                    oldValue = Aptitudes.GetValue(m_From, aptitude);

                    if (Aptitudes.CanRaise(m_From, aptitude))
                    {
                        m_From.AptitudesLibres -= Aptitudes.GetRequiredPA(m_From, aptitude);
                        m_From.Aptitudes.SetValue(aptitude, oldValue + 1);
                    }
                    from.SendGump(new FicheAptitudesGump(m_From, m_Tab));
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex);
            }
        }

        public static Hashtable GetAptitudesList(TMobile from, ClasseBranche archetype)
        {
            Hashtable list = new Hashtable();

            for (int i = 0; i < Aptitudes.m_AptitudeEntries.Length; ++i)
            {
                if ((Aptitudes.m_AptitudeEntries[i].Type == archetype) || (archetype == ClasseBranche.Aucun))
                {
                    AptitudeInfo infoApt = Aptitudes.GetInfos(Aptitudes.m_AptitudeEntries[i].Aptitude);
                    list.Add(Aptitudes.m_AptitudeEntries[i].Aptitude, infoApt.Name);
                }
            }

            return list;
        }

        private void CreateAptitudes(TMobile from, ClasseBranche archetype)
        {
            Hashtable aptitudes = GetAptitudesList(from, archetype);
            int count = 0;

            ArrayList listKeys = new ArrayList();

            IDictionaryEnumerator en = aptitudes.GetEnumerator();

            while (en.MoveNext())
            {
                if (en.Value is string)
                {
                    listKeys.Add((string)en.Value);
                }
            }

            listKeys.Sort();

            try
            {
                en = aptitudes.GetEnumerator();

                while (en.MoveNext())
                {
                    if (en.Key is Aptitude)
                    {
                        Aptitude aptitude = (Aptitude)en.Key;
                        int index = listKeys.IndexOf(en.Value.ToString());
                        int varX = ((index / 26) * 250);
                        int varY = (index * 16) - ((index / 26) * 416);

                        AddHtml(145 + varX, 195 + varY, 200, 20, "<h3><basefont color=#5A4A31>" + en.Value.ToString() + "<basefont></h3>", false, false);
                        AddTooltip(Aptitudes.GetTooltip(aptitude));
                        AddHtml(272 + varX, 195 + varY, 200, 20, "<h3><basefont color=#5A4A31>" + String.Format(": {0}", from.GetAptitudeValue(aptitude)) + "<basefont></h3>", false, false);
                        AddHtml(330 + varX, 195 + varY, 200, 20, "<h3><basefont color=#5A4A31>" + Aptitudes.GetRequiredPA(from, aptitude).ToString() + "<basefont></h3>", false, false);
                        AddHtml(375 + varX, 195 + varY, 200, 20, "<h3><basefont color=#5A4A31>" + (Aptitudes.GetCompReq(from, aptitude) > -1 ? m_From.Skills[Aptitudes.GetCompReq(from, aptitude)].Name:"Aucun") + "<basefont></h3>", false, false);
                        AddHtml(515 + varX, 195 + varY, 200, 20, "<h3><basefont color=#5A4A31>[" + Aptitudes.GetCompNumReq(from, aptitude) + "%]<basefont></h3>", false, false);

                        //AddLabel(120 + varX, 195 + varY, 2101, en.Value.ToString());
                        //AddLabel(247 + varX, 195 + varY, 2101, String.Format(": {0}", from.GetAptitudeValue(aptitude)));
                        //AddLabel(300 + varX, 195 + varY, 2101, Aptitudes.GetRequiredPA(from, aptitude).ToString());

                        if (Aptitudes.CanRaise(from, aptitude))
                            AddButton(105 + varX, 200 + varY, 2089, 2089, 100 + (int)aptitude, GumpButtonType.Reply, 0);

                        if (Aptitudes.CanLower(from, aptitude))
                            AddButton(123 + varX, 199 + varY, 2086, 2086, 500 + (int)aptitude, GumpButtonType.Reply, 0);

                        AddButton(580 + varX, 195 + varY, 4011, 4013, 1000 + (int)aptitude, GumpButtonType.Reply, 0);

                        ++count;
                    }
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex);
            }
        }
    }
}
