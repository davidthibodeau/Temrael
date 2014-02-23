using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
    class ConditionGump : Gump
    {
        private Mobile m_From;

        public static string[] m_Temperature = new string[]
            {
                "Glacial",
                "Hivernal",
                "Froid",
                "Frais",
                "Confortable",
                "Chaud",
                "Torride",
                "Brûlant"
            };

        public static string[] m_DensityOfCloudSummerDay = new string[]
            {
                "Aucun",
                "Ensoleillé",//"Generalement ensolleilé"
                "Passage nuageux",
                "Ciel variable",
                "Quelques Nuages",//"Nuageux avec éclaircies"
                "Nuageux",
                "Faible pluie",
                "Pluie",
                "Orage",
                "Donjon"
            };

        public static string[] m_DensityOfCloudWinterDay = new string[]
            {
                "Aucun",
                "Ensoleillé",
                "Passage nuageux",
                "Ciel variable",
                "Quelques Nuages",
                "Nuageux",
                "Neige",
                "Tempête de Neige",
                "Grêle",
                "Donjon"
            };

        public static string[] m_DensityOfCloudSummerNight = new string[]
            {
                "Aucun",
                "Dégagé",
                "Passage nuageux",
                "Ciel variable",
                "Quelques Nuages",
                "Nuageux",
                "Faible pluie",
                "Pluie",
                "Orage",
                "Donjon"
            };

        public static string[] m_DensityOfCloudWinterNight = new string[]
            {
                "Aucun",
                "Dégagé",
                "Passage nuageux",
                "Ciel variable",
                "Quelques Nuages",
                "Nuageux",
                "Neige",
                "Tempête de Neige",
                "Grêle",
                "Donjon"
            };

        public static string[] m_QuantityOfWind = new string[]
            {
                "Aucun",
                "Calme",
                "Brise",
                "Faible",
                "Normal",
                "Fort",
                "Bourrasque",
                "Tempête",
                "Ouragan"
            };

        public static string[] m_Season = new string[]
            {
                "Printemps",
                "Été",
                "Automne",
                "Hiver"
            };

        public ConditionGump(Mobile from) : base(0, 0)
        {
            m_From = from;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            //Background
            AddBackground(80, 72, 420, 500, 3600);
            AddBackground(90, 82, 400, 480, 9200);
            AddBackground(100, 92, 380, 460, 3500);
            AddBackground(115, 335, 350, 200, 9300);

            //Dragons
            AddImage(39, 53, 10440);
            AddImage(459, 53, 10441);

            //Titres
            AddImage(125, 110, 95);
            AddImage(132, 119, 96);
            AddImage(268, 119, 96);
            AddImage(445, 110, 97);

            AddImage(125, 350, 95);
            AddImage(132, 359, 96);
            AddImage(268, 359, 96);
            AddImage(445, 350, 97);

            AddHtml(248, 105, 200, 20, "<h3><basefont color=#025a>Condition<basefont></h3>", false, false);
            AddHtml(240, 344, 200, 20, "<h3><basefont color=#025a>Informations<basefont></h3>", false, false);

            try
            {
                Server.Misc.Weather weather = Server.Misc.Weather.GetWeather(from.Location);

                if (weather != null)
                {
                    TimeOfDay t = LightCycle.GetTimeofDay();
                    Season s = (Season)Map.Felucca.Season;
                    DensityOfCloud c = weather.Cloud;
                    string[] cloud;

                    if (s == Season.Winter)
                    {
                        if (t == TimeOfDay.Night)
                            cloud = m_DensityOfCloudWinterNight;
                        else
                            cloud = m_DensityOfCloudWinterDay;
                    }
                    else
                    {
                        if (t == TimeOfDay.Night)
                            cloud = m_DensityOfCloudSummerNight;
                        else
                            cloud = m_DensityOfCloudSummerDay;
                    }

                    AddHtml(130, 380, 200, 20, String.Format("<h3><basefont color=#5A4A31>Temperature : {0}<basefont></h3>", m_Temperature[(int)weather.Temperature]), false, false);
                    AddHtml(130, 410, 200, 20, String.Format("<h3><basefont color=#5A4A31>Temps : {0}<basefont></h3>", cloud[(int)c]), false, false);
                    AddHtml(130, 440, 200, 20, String.Format("<h3><basefont color=#5A4A31>Vent : {0}<basefont></h3>", m_QuantityOfWind[(int)weather.Wind]), false, false);
                    AddHtml(130, 470, 200, 20, String.Format("<h3><basefont color=#5A4A31>Saison : {0}<basefont></h3>", m_Season[(int)s]), false, false);
                    
                    int gumpID;

                    switch (c)
                    {
                        default: //DensityOfCloud.Cloud0
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay: gumpID = 1574; break;
                                    case TimeOfDay.ScaleToNight: gumpID = 1538; break;
                                    case TimeOfDay.Night: gumpID = 1537; break;
                                    default: gumpID = 1536; break; //TimeOfDay.Day
                                }

                                break;
                            }
                        case DensityOfCloud.Ensolleile:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay:
                                    case TimeOfDay.ScaleToNight: gumpID = 1541; break;
                                    case TimeOfDay.Night: gumpID = 1540; break;
                                    default: gumpID = 1539; break;
                                }

                                break;
                            }
                        case DensityOfCloud.PassageNuageux:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay:
                                    case TimeOfDay.ScaleToNight: gumpID = 1544; break;
                                    case TimeOfDay.Night: gumpID = 1543; break;
                                    default: gumpID = 1542; break;
                                }

                                break;
                            }
                        case DensityOfCloud.CielVariable:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay:
                                    case TimeOfDay.ScaleToNight: gumpID = 1547; break;
                                    case TimeOfDay.Night: gumpID = 1546; break;
                                    default: gumpID = 1545; break;
                                }

                                break;
                            }
                        case DensityOfCloud.NuageuxAvecEclaircies:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay:
                                    case TimeOfDay.ScaleToNight: gumpID = 1550; break;
                                    case TimeOfDay.Night: gumpID = 1549; break;
                                    default: gumpID = 1548; break;
                                }

                                break;
                            }
                        case DensityOfCloud.Nuageux:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay:
                                    case TimeOfDay.ScaleToNight: gumpID = 1562; break;
                                    case TimeOfDay.Night: gumpID = 1561; break;
                                    default: gumpID = 1560; break;
                                }

                                break;
                            }
                        case DensityOfCloud.FaiblePluie:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay: gumpID = 1572; break;
                                    case TimeOfDay.ScaleToNight: gumpID = 1565; break;
                                    case TimeOfDay.Night: gumpID = 1564; break;
                                    default: gumpID = 1563; break;
                                }

                                break;
                            }
                        case DensityOfCloud.Pluie:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay: gumpID = 1573; break;
                                    case TimeOfDay.ScaleToNight: gumpID = 1568; break;
                                    case TimeOfDay.Night: gumpID = 1567; break;
                                    default: gumpID = 1566; break;
                                }

                                break;
                            }
                        case DensityOfCloud.FortePluie:
                            {
                                switch (t)
                                {
                                    case TimeOfDay.ScaleToDay:
                                    case TimeOfDay.ScaleToNight: gumpID = 1571; break;
                                    case TimeOfDay.Night: gumpID = 1570; break;
                                    default: gumpID = 1569; break;
                                }

                                break;
                            }
                        case DensityOfCloud.Caverne:
                            {
                                gumpID = 1551;

                                break;
                            }
                    }

                    //AddImage(257, 88, gumpID);
                    AddBackground(200, 145, 170, 133, 2620);
                    AddButton(205, 150, gumpID, gumpID, 1, GumpButtonType.Reply, 0);
                }
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex, new System.Diagnostics.StackTrace(true));
            }

            //Image
            //AddBackground(200, 145, 170, 133, 2620);
            //AddButton(205, 150, 1536, 1536, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (from.Deleted || !from.Alive)
                return;

            switch (info.ButtonID)
            {
                case 1: from.SendGump(new ConditionGump(from)); break;
                default: break;
            }
        }
    }
}
