using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;
using System.Reflection;
using Server.HuePickers;
using System.Collections.Generic;
using System.Collections;

namespace Server.Gumps
{
    public class FicheAptitudeGump : GumpTemrael
    {
        private TMobile m_from;
        private int m_page;

        public FicheAptitudeGump(TMobile from)
            : this(from, 0)
        {
        }

        public FicheAptitudeGump(TMobile from, int page)
            : base("Aptitudes & Compétences", 560, 622)
        {
            m_from = from;

            int x = XBase;
            int y = YBase;
            int line = 0;
            int scale = 25;
            int linePerPage = 20;

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

            /*Dons*/
            AddSection(x, y + line * scale, 255, 465, "Aptitudes");
            line += 2;

            AddHtml(x + 30, y + line * scale, 400, 20, "<h3><basefont color=#5A4A31>Dispo | Indispo: " + Aptitudes.GetDisponiblePA(from) + " | " + (Aptitudes.GetRemainingPA(from) - Aptitudes.GetDisponiblePA(from)) + "<basefont></h3>", false, false);
            ++line;

            CreateAptitudes(from);

            /*Compétences*/
            line = 0;
            x = 380;
            AddSection(x, y + line * scale, 255, 465, "Compétences");
            line += 2;

            for (int s = 0; s < from.Skills.Length; s++)
            {
                if (from.Skills[s].Value > 0)
                {
                    AddHtmlTexte(x + 30, y + line * scale, DefaultHtmlLength, from.Skills[s].Name + " [ " + from.Skills[s].Value + "% ]");
                    ++line;
                }
            }

            AddButton(x + 30, 580, 52, 52, 9, GumpButtonType.Reply, 0);
            AddHtml(x + 80, 592, 200, 20, "<h3><basefont color=#025a>Compétences<basefont></h3>", false, false);

            AddButton(130, 580, 52, 52, 8, GumpButtonType.Reply, 0);
            AddHtml(180, 592, 200, 20, "<h3><basefont color=#025a>Aptitudes<basefont></h3>", false, false);
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
                    from.SendGump(new FicheAptitudesGump(from, ClasseBranche.Aucun));
                    break;
                case 9:
                    from.SendGump(new CompetenceGump(from, Server.Gumps.CompetenceGump.CompDomaines.Aucun, false));
                    break;
            }

            if (info.ButtonID >= 50)
                from.SendGump(new FicheAptitudeInfoGump(from, (NAptitude)info.ButtonID - 50));
        }

        public static Hashtable GetAptitudesList(TMobile from)
        {
            Hashtable list = new Hashtable();

            for (int i = 0; i < Aptitudes.m_AptitudeEntries.Length; ++i)
            {
                if (from.GetAptitudeValue((NAptitude)i) > 0)
                {
                    AptitudeInfo infoApt = Aptitudes.GetInfos(Aptitudes.m_AptitudeEntries[i].Aptitude);
                    list.Add(Aptitudes.m_AptitudeEntries[i].Aptitude, infoApt.Name);
                }
            }

            return list;
        }

        private void CreateAptitudes(TMobile from)
        {
            Hashtable aptitudes = GetAptitudesList(from);
            int count = 0;
            int varY = 0;

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
                    if (en.Key is NAptitude)
                    {

                        NAptitude aptitude = (NAptitude)en.Key;
                        int index = listKeys.IndexOf(en.Value.ToString());
                        varY = (index * 16) - ((index / 26) * 416);

                        AddHtml(135, 190 + varY, 200, 20, "<h3><basefont color=#5A4A31>" + en.Value.ToString() + "<basefont></h3>", false, false);
                        AddHtml(257, 190 + varY, 200, 20, "<h3><basefont color=#5A4A31>" + String.Format(": {0}", from.GetAptitudeValue(aptitude)) + "<basefont></h3>", false, false);
                        AddButton(300, 190 + varY, 4011, 4013, 50 + (int)aptitude, GumpButtonType.Reply, 0);

                        //AddLabel(120 + varX, 195 + varY, 2101, en.Value.ToString());
                        //AddLabel(247 + varX, 195 + varY, 2101, String.Format(": {0}", from.GetAptitudeValue(aptitude)));
                        //AddLabel(300 + varX, 195 + varY, 2101, Aptitudes.GetRequiredPA(from, aptitude).ToString());

                        ++count;
                    }
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex, new System.Diagnostics.StackFrame(0, true));
            }
        }
    }
}
