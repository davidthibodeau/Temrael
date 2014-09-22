using System;
using System.Xml;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Regions;
using Server.Network;

namespace Server
{
    public enum CardinalPoint
    {
        Invalid = -1,
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
}

namespace Server.Territories
{
    public abstract class TerritoryRegion : Region
    {
        public abstract Race RaceType { get; }
        public virtual bool IsCity { get { return false; } }
        public virtual bool UseWatchTower { get { return false; } }
        public virtual int StartX { get { return 0; } }
        public virtual int StartY { get { return 0; } }
        public virtual int EndX { get { return 0; } }
        public virtual int EndY { get { return 0; } }

        public TerritoryRegion(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
            Music = MusicName.Invalid;
        }

        public override void OnEnter(Mobile m)
        {
            //if (m.AccessLevel == AccessLevel.Administrator)
            //    m.SendMessage("Vous entrez le territoire {0}.", Name);

            //if (m is TMobile)
            //    VerifyAlarm((TMobile)m);
        }

        public override void OnExit(Mobile m)
        {
            //if (m.AccessLevel == AccessLevel.Administrator)
            //    m.SendMessage("Vous quittez le territoire {0}.", Name);
        }

        private static Hashtable m_AlarmsTimer = new Hashtable();

        public virtual void VerifyAlarm(TMobile m)
        {
            /*if (UseWatchTower && !m.Hidden && m.AccessLevel == AccessLevel.Player && RaceType != Races.Aucun && !IsInCity() && IsEnnemyOf(RaceType, m.Race))
            {
                //if (!m_AlarmsTimer.Contains(m))
                //{
                //    Timer.DelayCall(TimeSpan.FromSeconds(0.5), new TimerStateCallback(Waiting_OnCall), m);

                //    Timer t = new InternalTimer(m);

                //    m_AlarmsTimer[m] = t;

                //    t.Start();
                //}

                m.SendMessage("Vous entrez sur un territoire ennemi, vous risquez d'être repéré !");
            }*/
        }

        public class InternalTimer : Timer
        {
            private Mobile m;

            public InternalTimer(Mobile mobile)
                : base(TimeSpan.FromSeconds(10))
            {
                m = mobile;
            }

            protected override void OnTick()
            {
                if (m != null && m_AlarmsTimer.Contains(m))
                    m_AlarmsTimer.Remove(m);
            }
        }

        public bool IsInCity()
        {
            Region p = this;

            while (p != null)
            {
                if (p is TerritoryRegion && ((TerritoryRegion)p).IsCity)
                    return true;

                p = p.Parent;
            }

            return false;
        }

        private void Waiting_OnCall(object state)
        {
            /*TMobile m = (TMobile)state;

            if (m.Region is TerritoryRegion && ((TerritoryRegion)m.Region).IsInCity())
                return;

            ArrayList players = GetPlayers();

            if (players.Count > 0)
            {
                /*CardinalPoint point = GetCardinalPoint(m.Location);

                if (point != CardinalPoint.Invalid)
                {
                for (int j = 0; j < players.Count; ++j)
                {
                    if (players[j] is TMobile)
                    {
                        TMobile player = (TMobile)players[j];

                        player.SendMessage(0x22, String.Format("La vigie résonne, un {0} a été repéré sur le territoire.", m().ToLower()/*, GetCardinalPoint(point)));
                    }
                }
                }
            }*/
        }

        public static Region Find(int x, int y)
        {
            return Region.Find(new Point3D(x, y, 0), Map.Felucca);
        }

        public virtual string GetCardinalPoint(CardinalPoint point)
        {
            return m_CardinalPoint[(int)point];
        }

        public virtual CardinalPoint GetCardinalPoint(Point3D p)
        {
            if (p == Point3D.Zero)
                return CardinalPoint.Invalid;

            double width = EndX - StartX;
            double height = EndY - StartY;
            double wbh = width / height;
            double x = p.X - StartX;
            double y = p.Y - StartY;
            double tierYfirst = (height / 3);
            double tierYsecond = tierYfirst * 2;

            if (((3.0 / wbh) * x) - height > y) // N ou NE ou E ou SE
            {
                if (((-3.0 / wbh) * x) + (height * 2) < y) // NE ou E ou SE
                {
                    if (((-0.33 / wbh) * x) + tierYsecond < y) // E ou SE
                    {
                        if (((0.33 / wbh) * x) + tierYfirst < y) // SE
                        {
                            return CardinalPoint.SouthEast;
                        }
                        else // E
                        {
                            return CardinalPoint.East;
                        }
                    }
                    else // NE
                    {
                        return CardinalPoint.NorthEast;
                    }
                }
                else // N
                {
                    return CardinalPoint.North;
                }
            }
            else // S ou SW ou W ou NW
            {
                if (((-3.0 / wbh) * x) + (height * 2) > y) // SW ou W ou NW
                {
                    if (((-0.33 / wbh) * x) + tierYsecond > y) // W ou NW
                    {
                        if (((0.33 / wbh) * x) + tierYfirst > y) // NW
                        {
                            return CardinalPoint.NorthWest;
                        }
                        else // W
                        {
                            return CardinalPoint.West;
                        }
                    }
                    else // SW
                    {
                        return CardinalPoint.SouthWest;
                    }
                }
                else // S
                {
                    return CardinalPoint.South;
                }
            }
        }

        public static Hashtable Vigies = new Hashtable();

        public static string[] LoadRaces = new string[] {
        "Aucun",
        "Daelwena",
        "Drakan",
        "Gorlak",
        "Hastane",
        "Kardar",
        "Kheijan",
        "Mortanyss",
        "Nalkiri",
        "Nargolith",
        "Nebulix",
        "GM"
        };

        public static void Initialize()
        {
            XmlDocument doc = new XmlDocument();

            if (System.IO.File.Exists("Data/Vigies.xml"))
            {
                doc.Load("Data/Vigies.xml");
            }
            else
            {
                Console.WriteLine("Erreur lors de l'initialisation des ennemis.");
                return;
            }

            XmlElement root = doc["vigies"];
            foreach (XmlElement facet in root.GetElementsByTagName("race"))
            {
                string arace = facet.GetAttribute("Race");
                if (arace == null || arace.Length <= 0)
                    continue;

                Race firstrace = GetRace(arace);

                ArrayList ennemies = new ArrayList();

                foreach (XmlElement reg in facet.GetElementsByTagName("ennemy"))
                {
                    string brace = reg.GetAttribute("Race");
                    if (brace == null || brace.Length <= 0)
                        continue;

                    Race secondrace = GetRace(brace);

                    ennemies.Add(secondrace);
                }
            }
        }

        public static Race GetRace(string racestring)
        {
            for (int i = 0; i < LoadRaces.Length; i++)
            {
                if (racestring == (string)LoadRaces[i])
                {
                    return (Race)i;
                }
            }

            return Race.Aucun;
        }

        public virtual bool IsEnnemyOf(Race firstRace, Race secondRace)
        {
            if (firstRace <= Race.Aucun || firstRace >= Race.MJ)
                return false;

            if (secondRace <= Race.Aucun || secondRace >= Race.MJ)
                return false;

            if (Vigies == null)
                Vigies = new Hashtable();

            if (Vigies.Contains(firstRace))
            {
                Race[] racelist = (Race[])Vigies[firstRace];

                for (int i = 0; i < racelist.Length; i++)
                {
                    if ((Race)racelist[i] == secondRace)
                        return true;
                }
            }

            return false;
        }

        public static TerritoryRegion GetRaceTerritory(Race race)
        {
            if (race <= Race.Aucun || race >= Race.MJ)
                return null;

            for (int i = 0; i < Regions.Count; ++i)
            {
                if (Regions[i] is TerritoryRegion)
                {
                    TerritoryRegion region = (TerritoryRegion)Regions[i];

                    if (region.RaceType == race)
                        return region;
                }
            }

            return null;
        }

        #region Tables
        private static string[] m_CardinalPoint = new string[] { "invalid", "au nord", "au nord-est", "à l'est", "au sud-est", "au sud", "au sud-ouest", "à l'ouest", "au nord-ouest" };
        #endregion
    }
}