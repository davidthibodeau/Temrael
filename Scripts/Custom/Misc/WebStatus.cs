using System;
using System.IO;
using System.Text;
using System.Collections;
using Server;
using Server.Network;
using Server.Guilds;
using Server.Mobiles;
using Server.Territories;
using Server.Regions;

namespace Server.Misc
{
    public class StatusPage : Timer
    {
        public static void Initialize()
        {
            new StatusPage().Start();
        }

        public StatusPage()
            : base(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(60.0))
        {
            Priority = TimerPriority.FiveSeconds;
        }

        private static string Encode(string input)
        {
            StringBuilder sb = new StringBuilder(input);

            sb.Replace("&", "&amp;");
            sb.Replace("<", "&lt;");
            sb.Replace(">", "&gt;");
            sb.Replace("\"", "&quot;");
            sb.Replace("'", "&#39;");
            sb.Replace("é", "&eacute;");
            sb.Replace("É", "&Eacute;");
            sb.Replace("è", "&egrave;");
            sb.Replace("È", "&Egrave;");
            sb.Replace("à", "&agrave;");
            sb.Replace("À", "&Agrave;");
            sb.Replace("©", "&copy;");

            return sb.ToString();
        }

        protected override void OnTick()
        {
            try
            {
                if (!Directory.Exists("web"))
                    Directory.CreateDirectory("web");

                using (StreamWriter op = new StreamWriter(@"C:\Status\status.html"))
                {
                    int totaljoueurs = 0;
                    int nbHumain = 0;
                    int nbNordique = 0;
                    int nbNomade = 0;
                    int nbNain = 0;
                    int nbOrcish = 0;
                    int nbElfe = 0;
                    int nbElfeNoir = 0;
                    int nbMortVivant = 0;
                    int nbMJ = 0;

                    int Landes = 0;
                    int cHumain = 0;
                    int cNordique = 0;
                    int cNomade = 0;
                    int cNain = 0;
                    int cOrcish = 0;
                    int cElfe = 0;
                    int cElfeNoir = 0;
                    int cTieffelin = 0;
                    int cMortVivant = 0;

                    foreach (NetState state in NetState.Instances)
                    {
                        Mobile m = state.Mobile;

                        if (m != null)
                        {
                            if (m is TMobile)
                            {
                                TMobile tm = (TMobile)m;

                                if (!(tm.AccessLevel != AccessLevel.Player && tm.Hidden == true))
                                {
                                    totaljoueurs++;

                                    if (tm.Races == Races.MortVivant)
                                    {
                                        if (tm.MortVivant)
                                        {
                                            nbMortVivant++;
                                        }
                                        else
                                        {
                                            switch (tm.MortRace)
                                            {
                                                case Races.Elfe: nbElfe++;
                                                    break;
                                                case Races.ElfeNoir: nbElfeNoir++;
                                                    break;
                                                case Races.Capiceen: nbHumain++;
                                                    break;
                                                case Races.Nain: nbNain++;
                                                    break;
                                                case Races.Nomade: nbNomade++;
                                                    break;
                                                case Races.Nordique: nbNordique++;
                                                    break;
                                                case Races.Orcish: nbOrcish++;
                                                    break;
                                                case Races.Tieffelin:
                                                    if (tm.RaceSecrete == Races.Nomade)
                                                        nbNomade++;
                                                    else if (tm.RaceSecrete == Races.Nordique)
                                                        nbNordique++;
                                                    else
                                                        nbHumain++;
                                                    break;
                                                case Races.Aasimar:
                                                    if (tm.RaceSecrete == Races.Nomade)
                                                        nbNomade++;
                                                    else if (tm.RaceSecrete == Races.Nordique)
                                                        nbNordique++;
                                                    else
                                                        nbHumain++;
                                                    break;
                                                case Races.MJ: if (!(tm.Hidden)) nbMJ++;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        switch (tm.Races)
                                        {
                                            case Races.Elfe: nbElfe++;
                                                break;
                                            case Races.ElfeNoir: nbElfeNoir++;
                                                break;
                                            case Races.Capiceen: nbHumain++;
                                                break;
                                            case Races.Nain: nbNain++;
                                                break;
                                            case Races.Nomade: nbNomade++;
                                                break;
                                            case Races.Nordique: nbNordique++;
                                                break;
                                            case Races.Orcish: nbOrcish++;
                                                break;
                                            case Races.Tieffelin:
                                                if (tm.RaceSecrete == Races.Nomade)
                                                    nbNomade++;
                                                else if (tm.RaceSecrete == Races.Nordique)
                                                    nbNordique++;
                                                else
                                                    nbHumain++;
                                                break;
                                            case Races.Aasimar:
                                                if (tm.RaceSecrete == Races.Nomade)
                                                    nbNomade++;
                                                else if (tm.RaceSecrete == Races.Nordique)
                                                    nbNordique++;
                                                else
                                                    nbHumain++;
                                                break;
                                            case Races.MJ: if(!(tm.Hidden)) nbMJ++;
                                                break;
                                        }
                                    }

                                    Races race = Races.Aucun;

                                    if (tm.Region is TerritoryRegion)
                                        race = ((TerritoryRegion)tm.Region).RaceType;
                                    else if (tm.Region is TavernRegion)
                                        race = ((TavernRegion)tm.Region).RaceType;

                                    switch (race)
                                    {
                                        case Races.Elfe: cElfe++;
                                            break;
                                        case Races.ElfeNoir: cElfeNoir++;
                                            break;
                                        case Races.Capiceen: cHumain++;
                                            break;
                                        case Races.MortVivant: cMortVivant++;
                                            break;
                                        case Races.Nain: cNain++;
                                            break;
                                        case Races.Nomade: cNomade++;
                                            break;
                                        case Races.Nordique: cNordique++;
                                            break;
                                        case Races.Orcish: cOrcish++;
                                            break;
                                        case Races.Tieffelin: cTieffelin++;
                                            break;
                                        default: 
                                            Landes++;
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    //////on trouve le max de joueur online
                    int maxjoueurs = 0;
                    int version = 1;
                    int jour = 0;
                    int mois = 0;
                    int year = 0;
                    int hour = 0;
                    int minute = 0;
                    if (!File.Exists(@"C:\Status\record.rec"))
                    {
                        Stream s = new FileStream(@"C:\Status\record.rec", FileMode.CreateNew);
                        BinaryWriter bw = new BinaryWriter(s);
                        bw.Write(version);
                        bw.Write(totaljoueurs);
                        bw.Write(DateTime.Now.Day);
                        bw.Write(DateTime.Now.Month);
                        bw.Write(DateTime.Now.Year);
                        bw.Write(DateTime.Now.Hour);
                        bw.Write(DateTime.Now.Minute);
                        bw.Close();
                        maxjoueurs = totaljoueurs;
                        jour = DateTime.Now.Day;
                        mois = DateTime.Now.Month;
                        year = DateTime.Now.Year;
                        hour = DateTime.Now.Hour;
                        minute = DateTime.Now.Minute;
                        s.Close();
                    }
                    else
                    {
                        Stream s = new FileStream(@"C:\Status\record.rec", FileMode.Open);
                        BinaryReader br = new BinaryReader(s);
                        int versionlu = br.ReadInt32();
                        maxjoueurs = br.ReadInt32();
                        jour = br.ReadInt32();
                        mois = br.ReadInt32();
                        year = br.ReadInt32();
                        hour = br.ReadInt32();
                        minute = br.ReadInt32();
                        br.Close();
                        s.Close();

                        if (maxjoueurs < totaljoueurs)
                        {
                            s = new FileStream(@"C:\Status\record.rec", FileMode.Create);
                            BinaryWriter bw = new BinaryWriter(s);
                            bw.Write(version);
                            bw.Write(totaljoueurs);
                            bw.Write(DateTime.Now.Day);
                            bw.Write(DateTime.Now.Month);
                            bw.Write(DateTime.Now.Year);
                            bw.Write(DateTime.Now.Hour);
                            bw.Write(DateTime.Now.Minute);
                            bw.Close();
                            maxjoueurs = totaljoueurs;
                            jour = DateTime.Now.Day;
                            mois = DateTime.Now.Month;
                            year = DateTime.Now.Year;
                            hour = DateTime.Now.Hour;
                            minute = DateTime.Now.Minute;
                            s.Close();
                        }
                    }


                    ///fin

                    op.WriteLine("<html>");
                    op.WriteLine("<head>");
                    op.WriteLine("<title>Temrael - Serveur Ultima Online</title>");
                    op.WriteLine("<link rel=\"stylesheet\" href=\"/Status/Styles/Site.css\" type=\"text/css\" media=\"all\" />");
                    op.WriteLine("<link rel=\"stylesheet\" href=\"/Status/Styles/Menu.css\" type=\"text/css\" media=\"all\" />");
                    op.WriteLine("</head>");
                    op.WriteLine("<body>");
                    op.WriteLine("<div id=\"main\">");
                    op.WriteLine("<div id=\"wrapper\">");
                    op.WriteLine("<div id=\"wrapper_inner\">");
   	                op.WriteLine("<div id=\"content\">");
                    op.WriteLine("<div id=\"menuheader\">");
                    op.WriteLine("<ul class=\"generalmenu\">");
                    op.WriteLine("<li class=\"general\">");
                    op.WriteLine("<ul>");
                    op.WriteLine("<a href=\"http://uotemrael.com/index.aspx\">Index</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/blog/\">Blog</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/General/Screenshots.aspx\">Capture &Eacute;cran</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/General/Credits.aspx\">Cr&eacute;dits</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/General/Staff.aspx\">&Eacute;quipe</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/General/FAQ.aspx\">FAQ</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/General/Installation.aspx\">Installation</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/General/Regles.aspx\">R&egrave;gles</a>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</li>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</div>");
                    op.WriteLine("<div id=\"menuheader\">");
                    op.WriteLine("<ul class=\"guidemenu\">");
                    op.WriteLine("<li class=\"biblio\">");
                    op.WriteLine("<ul>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Guide/Carte.aspx\">Carte</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Guide/Races.aspx\">Races</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Guide/Religions.aspx\">Religions</a>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</li>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</div>");
                    op.WriteLine("<div id=\"menuheader\">");
                    op.WriteLine("<ul class=\"sysmenu\">");
                    op.WriteLine("<li class=\"sys\">");
                    op.WriteLine("<ul>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Systemes/Aptitudes.aspx\">Aptitudes</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Systemes/Classes.aspx\">Classes</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Systemes/Creation.aspx\">Cr&eacute;ation</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Systemes/Evolution.aspx\">Evolution</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Systemes/Metiers.aspx\">M&eacute;tiers</a><br/>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/Systemes/Tutoriels.aspx\">Tutoriels</a>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</li>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</div>");
                    op.WriteLine("<a href=\"http://uotemrael.com/forum/index.php\">");
                    op.WriteLine("<div id=\"menuheader\">");
                    op.WriteLine("<ul class=\"forummenu\">");
                    op.WriteLine("<li class=\"forum\">");
                    op.WriteLine("</li>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</div>");
                    op.WriteLine("</a>");
                    op.WriteLine("<a href=\"\">");
                    op.WriteLine("<div id=\"menuheader\">");
                    op.WriteLine("<ul class=\"statutmenu\">");
                    op.WriteLine("<li class=\"statut\">");
                    op.WriteLine("</li>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</div>");
                    op.WriteLine("</a>");
                    op.WriteLine("<a href=\"http://uotemrael.com/Pages/General/Inscription.aspx\">");
                    op.WriteLine("<div id=\"menuheader\">");
                    op.WriteLine("<ul class=\"inscriptionmenu\">");
                    op.WriteLine("<li class=\"inscription\">");
                    op.WriteLine("</li>");
                    op.WriteLine("</ul>");
                    op.WriteLine("</div>");
                    op.WriteLine("</a>");
                    op.WriteLine("<center><h1><b><u>Statut Serveur</b></u></h1></center>");
                    op.WriteLine("<br/>");
                    op.WriteLine("<table width=\"100%\" border=\"1\"align=\"center\">");
                    op.WriteLine("<tr><td align=\"center\" valign=\"middle\"><h1><b><u>Informations</b></u></h1></td></tr>");

                    string szminute = "";
                    
                    if (DateTime.Now.Minute.ToString().Length == 1)
                        szminute = "0" + DateTime.Now.Minute.ToString();
                    else
                        szminute = DateTime.Now.Minute.ToString();

                    op.WriteLine("<tr><td>");
                    op.WriteLine(String.Format("<b>Derni&egrave;re Mis &agrave; jour :</b> {0}/{1}/{2} &agrave; {3}:{4} QC", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, DateTime.Now.Hour, szminute));
                    op.WriteLine("</td></tr>");
                    op.WriteLine("<tr><td>");

                    if (minute.ToString().Length == 1)
                        szminute = "0" + minute.ToString();
                    else
                        szminute = minute.ToString();

                    op.WriteLine(String.Format("<b>Record de Joueurs :</b> {0} le {1}/{2}/{3} &agrave; {4}:{5} QC", maxjoueurs, jour, mois, year, hour, szminute));
                    op.WriteLine("</td>");
                    op.WriteLine("</tr>");
                    op.WriteLine("<tr><td><b>Joueurs en Ligne : </b>" + totaljoueurs.ToString() + "</td></tr><br>");
                    op.WriteLine("</table>");

                    op.WriteLine("<br/><br/>");

                    op.WriteLine("<table width=\"100%\" border=\"1\" align=\"center\">");
                    op.WriteLine("<tr><td colspan=\"5\"><b>Joueurs class&eacute;s par race :</b></td></tr>");
                    op.WriteLine("<tr><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Elfe :</h1> ");
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Elfe Noir :</h1> ");
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Humain :</h1> ");
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Orcish :</h1> ");
                    op.WriteLine("</td></tr>");

                    op.WriteLine("<tr><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbElfe.ToString());
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbElfeNoir.ToString());
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbHumain.ToString());
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbOrcish.ToString());
                    op.WriteLine("</td></tr>");

                    op.WriteLine("<tr><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Nomade :</h1> ");
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Nordique :</h1> ");
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Nain :</h1> ");
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>MJ :</h1> ");
                    op.WriteLine("</td></tr>");

                    op.WriteLine("<tr><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbNomade.ToString());
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbNordique.ToString());
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbNain.ToString());
                    op.WriteLine("</td><td width=\"25%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(nbMJ.ToString());
                    op.WriteLine("</td></tr>");
                    op.WriteLine("</table>");

                    op.WriteLine("<br/><br/>");

                    op.WriteLine("<table width=\"100%\" border=\"1\" align=\"center\">");
                    op.WriteLine("<tr><td colspan=\"5\"><b>Joueurs class&eacute;s par localisation :</b></td></tr>");
                    op.WriteLine("<tr><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Brandheim :</h1> ");
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Elamsham :</h1> ");
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Citarel :</h1> ");
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>Serenit&eacute; :</h1> ");
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine("<h1>M&eacute;landre :</h1> ");
                    op.WriteLine("</td></tr>");
                    op.WriteLine("<tr><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(cNordique.ToString());
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(cElfeNoir.ToString());
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(cHumain.ToString());
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(cElfe.ToString());
                    op.WriteLine("</td><td width=\"20%\" align=\"center\" valign=\"middle\">");
                    op.WriteLine(cNomade.ToString());
                    op.WriteLine("</td></tr>");
                    op.WriteLine("<tr><td width=\"100%\" align=\"center\" valign=\"middle\" colspan=\"5\">");
                    op.WriteLine("<h1>Landes de Temrael :</h1> ");
                    op.WriteLine("</td></tr>");
                    op.WriteLine("<tr><td width=\"100%\" align=\"center\" valign=\"middle\" colspan=\"5\">");
                    op.WriteLine(Landes.ToString());
                    op.WriteLine("</td></tr>");
                    op.WriteLine("</table>");

                    /*op.WriteLine("<table width=\"100%\" border=\"1\" background=\"images/fond2.jpg\" align=\"center\" cellpadding=\"5\" bordercolor=\"#444444\">");
                    op.WriteLine("<tr><td bordercolor=\"#B5A579\" bgcolor=\"#A5A5A5\" background=\"images/entete.jpg\" align=\"center\" valign=\"middle\" colspan=\"7\"><font face=\"Arial\" size=\"4\" color=\"#D4D4D4\"><b><u>Joueurs actuellement en ligne</b></u></font></td></tr>");
                    op.WriteLine("<tr>");
                    op.WriteLine("<td width=\"33%\" style=\"text-align:center\" bgcolor=\"#444444\" background=\"images/fond2.jpg\"><font size=\"3\" color=\"#444444\"><b>Joueurs</b></font></td>");
                    op.WriteLine("<td width=\"33%\" style=\"text-align:center\" bgcolor=\"#444444\" background=\"images/fond2.jpg\"><font size=\"3\" color=\"#444444\"><b>Races</b></font></td>");
                    op.WriteLine("<td width=\"34%\" style=\"text-align:center\" bgcolor=\"#444444\" background=\"images/fond2.jpg\"><font size=\"3\" color=\"#444444\"><b>Localisations</b></font></td>");
                    op.WriteLine("</tr>");*/
   	                op.WriteLine("<div id=\"Footer\">");
                    op.WriteLine("<center>");
                    op.WriteLine("&copy; 2012 Temrael");
                    op.WriteLine("</center>");
   	                op.WriteLine("</div>");
                    op.WriteLine("</div>");
                    op.WriteLine("</div>");
                    op.WriteLine("</div>");
                    op.WriteLine("</div>");

                    /*int cmp = 0;

                    ArrayList list = new ArrayList();

                    foreach (NetState state in NetState.Instances)
                    {
                        Mobile m = state.Mobile;

                        if (m != null)
                        {
                            if (m is TMobile)
                            {
                                TMobile tm = (TMobile)m;

                                list.Add(tm);
                            }
                        }
                    }

                    list.Sort(new MobileComparer());

                    for (int i = 0; i < list.Count; i++)
                    {
                        TMobile tm = (TMobile)list[i];

                        if (tm != null)
                        {
                            string nom = tm.Name;
                            nom = Encode(nom);
                            string race = tm.Race.ToString();
                            race = Encode(race);
                            string location = Encode("Sur les landes");

                            Races Races = Races.Aucun;

                            if (tm.Region is TerritoryRegion)
                                Races = ((TerritoryRegion)tm.Region).Races;

                            switch (Races)
                            {
                                case Races.Elfe: location = Encode("Citadelle");
                                    break;
                                case Races.ElfeNoir: location = Encode("Lloth");
                                    break;
                                case Races.Humain: location = Encode("Citarelle");
                                    break;
                                //case Races.MortVivant: location = Encode("");
                                //    break;
                                case Races.Nain: location = Encode("Mineroc");
                                    break;
                                case Races.Nomade: location = Encode("Mirage & Mélandre");
                                    break;
                                case Races.Nordique: location = Encode("Golfrund");
                                    break;
                                case Races.Orcish: location = Encode("Camps");
                                    break;
                                case Races.Tieffelin: location = Encode("Ancien Monde");
                                    break;
                                default: location = Encode("Monde de Temrael");
                                    break;
                            }

                            if (!(tm.AccessLevel != AccessLevel.Player && tm.Hidden == true))
                            {
                                if (cmp % 2 == 0)
                                    op.WriteLine("<tr><td style=\"text-align:center\" background=\"images/fond2.jpg\">");
                                else
                                    op.WriteLine("<tr><td bgcolor=\"#cccccc\" style=\"text-align:center\" background=\"images/fond2.jpg\">");
                                op.WriteLine(nom);
                                if (cmp % 2 == 0)
                                    op.WriteLine("</td><td style=\"text-align:center\" background=\"images/fond2.jpg\">");
                                else
                                    op.WriteLine("</td><td bgcolor=\"#cccccc\" style=\"text-align:center\" background=\"images/fond2.jpg\">");
                                op.WriteLine(race);
                                if (cmp % 2 == 0)
                                    op.WriteLine("</td><td style=\"text-align:center\" background=\"images/fond2.jpg\">");
                                else
                                    op.WriteLine("</td><td bgcolor=\"#cccccc\" style=\"text-align:center\" background=\"images/fond2.jpg\">");
                                op.WriteLine(location);
                                op.WriteLine("</td></tr>");

                                cmp++;
                            }
                        }
                    }

                    op.WriteLine("      </table>");*/
                    op.WriteLine("</body>");
                    op.WriteLine("</html>");
                }
            }
            catch
            {
            }
        }

        private class MobileComparer : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                TMobile c1 = (TMobile)a;
                TMobile c2 = (TMobile)b;

                if ((int)c1.Races > (int)c2.Races)
                    return 1;

                if ((int)c1.Races < (int)c2.Races)
                    return -1;

                else
                    return string.Compare(c1.Name, c2.Name);
            }
        }
    }
}