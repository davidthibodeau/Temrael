using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using System.Collections.Generic;

namespace Server.Misc
{
    public class Weather
    {
        public static TimeSpan Interval = TimeSpan.FromHours(2.0); //4.0 hours

        private static ArrayList m_Weathers = new ArrayList();
        public static ArrayList Weathers { get { return m_Weathers; } }

        public static void Initialize()
        {
            //iles de glace
            //AddWeather(Temperature.Glacial, DensityOfCloud.PassageNuageux, QuantityOfWind.Faible, true, new Rectangle2D(new Point2D(12, 14), new Point2D(402, 556)), new Rectangle2D(new Point2D(402, 14), new Point2D(794, 354)), new Rectangle2D(new Point2D(928, 14), new Point2D(1044, 170)), new Rectangle2D(new Point2D(1076, 14), new Point2D(1212, 138)), new Rectangle2D(new Point2D(1706, 369), new Point2D(1862, 512)), new Rectangle2D(new Point2D(1786, 512), new Point2D(1902, 652)), new Rectangle2D(new Point2D(1862, 286), new Point2D(2156, 594)), new Rectangle2D(new Point2D(2156, 292), new Point2D(2444, 408)), new Rectangle2D(new Point2D(2444, 118), new Point2D(2718, 712)), new Rectangle2D(new Point2D(2718, 20), new Point2D(3072, 712)), new Rectangle2D(new Point2D(3072, 20), new Point2D(3752, 584)), new Rectangle2D(new Point2D(4708, 66), new Point2D(5006, 314)));

            //hildrim quartier de l'hiver
            //AddWeather(Temperature.Glacial, DensityOfCloud.PassageNuageux, QuantityOfWind.Faible, true, new Rectangle2D(new Point2D(1757, 1892), new Point2D(1781, 1906)), new Rectangle2D(new Point2D(1748, 1906), new Point2D(1788, 1922)), new Rectangle2D(new Point2D(1737, 1922), new Point2D(1791, 1942)), new Rectangle2D(new Point2D(1729, 1942), new Point2D(1773, 1958)), new Rectangle2D(new Point2D(1650, 1958), new Point2D(1770, 1985)), new Rectangle2D(new Point2D(1665, 1985), new Point2D(1769, 1998)), new Rectangle2D(new Point2D(1677, 1998), new Point2D(1757, 2009)), new Rectangle2D(new Point2D(1688, 2009), new Point2D(1745, 2022)), new Rectangle2D(new Point2D(1697, 2022), new Point2D(1731, 2031)));

            //déserts
            //AddWeather(Temperature.Torride, DensityOfCloud.PassageNuageux, QuantityOfWind.Faible, true, new Rectangle2D(new Point2D(384, 1488), new Point2D(611, 1664)), new Rectangle2D(new Point2D(1840, 2288), new Point2D(2038, 2826)), new Rectangle2D(new Point2D(2038, 2250), new Point2D(2272, 2906)), new Rectangle2D(new Point2D(2272, 2270), new Point2D(2526, 2906)), new Rectangle2D(new Point2D(3385, 1759), new Point2D(4053, 2140)), new Rectangle2D(new Point2D(4614, 3580), new Point2D(4690, 3622)), new Rectangle2D(new Point2D(4614, 3622), new Point2D(4708, 3708)), new Rectangle2D(new Point2D(4589, 3680), new Point2D(4690, 3760)));

            //donjons
            AddWeather(Temperature.Frais, DensityOfCloud.Caverne, QuantityOfWind.Aucun, true, new Rectangle2D(new Point2D(5120, 0), new Point2D(6144, 1288)), new Rectangle2D(new Point2D(5120, 1288), new Point2D(5484, 1524)), new Rectangle2D(new Point2D(5120, 2308), new Point2D(5309, 2501)), new Rectangle2D(new Point2D(5120, 2308), new Point2D(5564, 3716)), new Rectangle2D(new Point2D(5564, 2556), new Point2D(6144, 4096)));

            // carte normale
            AddWeather(Temperature.Confortable, DensityOfCloud.PassageNuageux, QuantityOfWind.Faible, false, new Rectangle2D(new Point2D(0, 0), new Point2D(6145, 4097)));
        }

        public static void AddWeather(Temperature temperature, DensityOfCloud cloud, QuantityOfWind wind, bool isStatic, params Rectangle2D[] area)
        {
            new Weather(area, temperature, cloud, wind, isStatic);
        }

        public static bool RemoveWeather(IPoint2D p)
        {
            for (int i = 0; i < m_Weathers.Count; ++i)
            {
                Weather weather = (Weather)m_Weathers[i];

                if (weather.Area != null)
                {
                    for (int j = 0; j < weather.Area.Length; ++j)
                    {
                        if (weather.Area[j].Contains(p))
                        {
                            m_Weathers.RemoveAt(i);
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private Rectangle2D[] m_Area;
        private Temperature m_Temperature;
        private DensityOfCloud m_Cloud;
        private QuantityOfWind m_Wind;
        private bool m_IsStatic;
        private DateTime m_NextWeatherChange;

        public Rectangle2D[] Area { get { return m_Area; } set { m_Area = value; } }
        public Temperature Temperature { get { return AdjustTemperatureBySeason(m_Temperature); } set { m_Temperature = value; } }
        public DensityOfCloud Cloud { get { return m_Cloud; } set { m_Cloud = value; } }
        public QuantityOfWind Wind { get { return m_Wind; } set { m_Wind = value; } }
        public DateTime NextWeatherChange { get { return m_NextWeatherChange; } set { m_NextWeatherChange = value; } }
        public bool IsStatic { get { return m_IsStatic; } }
        public bool IsRaining { get { return m_Cloud == DensityOfCloud.FaiblePluie || m_Cloud == DensityOfCloud.Pluie || m_Cloud == DensityOfCloud.FortePluie; } }
        public bool IsUnderEarth { get { return m_Wind == QuantityOfWind.Aucun; } }
        public bool IsUnderZero { get { return Map.Felucca.Season == (int)Season.Winter; } }

        public static Weather GetWeather(IPoint2D p)
        {
            for (int i = 0; i < m_Weathers.Count; ++i)
            {
                Weather weather = (Weather)m_Weathers[i];

                if (weather.Area != null)
                {
                    for (int j = 0; j < weather.Area.Length; ++j)
                    {
                        if (weather.Area[j].Contains(p))
                        {
                            return weather;
                        }
                    }
                }
            }

            return null;
        }

        public Weather(Rectangle2D[] area, Temperature temperature, DensityOfCloud cloud, QuantityOfWind wind, bool isStatic)
        {
            m_Area = area;
            m_Temperature = temperature;
            m_Cloud = cloud;
            m_Wind = wind;
            m_IsStatic = isStatic;

            m_Weathers.Add(this);

            m_NextWeatherChange = DateTime.Now + Interval;

            Timer.DelayCall(TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(60.0), new TimerCallback(Weather_OnTick));
        }

        public virtual Temperature AdjustTemperatureBySeason(Temperature t)
        {
            TimeOfDay timeOfDay = LightCycle.GetTimeofDay();
            Season season = (Season)Map.Felucca.Season;
            Temperature[] entry = TemperatureEntry.GetEntry(season, timeOfDay);

            try
            {
                return entry[(int)t];
            }
            catch (Exception e)
            {
                if (entry == null)
                {
                    Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(), "entry was null");
                    return t;
                }
                else
                {
                    Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(),
                        "Le length de entry est de " + entry.Length + " alors que l'index de température était "
                                  + t + " ce qui donne un chiffre de " + ((int)t) + ". La saison était " + season + ".");
                    return entry[entry.Length - 1];
                }
            }
        }

        public virtual Temperature GenerateTemperature()
        {
            if (!IsStatic && !IsUnderEarth)
            {
                int t = (int)m_Temperature;

                if (t == 0 || t == 1)
                {
                    t += Utility.RandomMinMax(1, 3);
                }
                else if (t == 6 || t == 7)
                {
                    t -= Utility.RandomMinMax(1, 3);
                }
                else
                {
                    t += Utility.RandomMinMax(-3, 4);

                    if (t > 7)
                        t = 7;

                    if (t < 0)
                        t = 0;
                }

                return (Temperature)t;
            }

            return m_Temperature;
        }

        public virtual DensityOfCloud GenerateCloud()
        {
            if (!IsUnderEarth)
            {
                int c = (int)m_Cloud;

                if (c == 0 || c == 1)
                {
                    c += Utility.RandomMinMax(1, 3);
                }
                else if (c == 7 || c == 8)
                {
                    c -= Utility.RandomMinMax(1, 3);
                }
                else
                {
                    c += Utility.RandomMinMax(-3, 3);

                    if (c > 8)
                        c = 8;

                    if (c < 0)
                        c = 0;
                }

                return (DensityOfCloud)c;
            }

            return m_Cloud;
        }

        public virtual QuantityOfWind GenerateWind()
        {
            if (!IsUnderEarth)
            {
                int w = (int)m_Wind;

                if (w == 0 || w == 1)
                {
                    w += Utility.RandomMinMax(1, 3);
                }
                else if (w == 6 || w == 7)
                {
                    w -= Utility.RandomMinMax(1, 3);
                }
                else
                {
                    w += Utility.RandomMinMax(-3, 3);

                    if (w > 7)
                        w = 7;

                    if (w < 0)
                        w = 0;
                }

                return (QuantityOfWind)w;
            }

            return m_Wind;
        }

        public virtual void Weather_OnTick()
        {
            int type = 0xFE;
            int density = 0;
            int temperature = IsUnderZero ? -30 : 30;
            bool wasRaining = IsRaining;
            bool seasonHasChanged = false;

            if (m_NextWeatherChange < DateTime.Now)
            {
                m_Temperature = GenerateTemperature();
                m_Cloud = GenerateCloud();
                m_Wind = GenerateWind();

                m_NextWeatherChange = DateTime.Now + Interval;
            }

            if (IsRaining)
            {
                if (!IsUnderZero)
                    type = 0;
                else
                    type = 2;

                if (m_Cloud == DensityOfCloud.FaiblePluie)
                    density = 30;
                else if (m_Cloud == DensityOfCloud.Pluie)
                    density = 50;
                else if (m_Cloud == DensityOfCloud.FortePluie)
                    density = 70;
            }

            int year, month, day;

            Calendrier.GetDate(out year, out month, out day);

            Season season = Calendrier.m_Entries[month - 1].Season;

            if (Map.Felucca.Season != (int)season)
            {
                Map.Felucca.Season = (int)season;
                Calendrier.OnSeasonChange(season);
                seasonHasChanged = true;
            }

            List<NetState> states = NetState.Instances;

            Packet weatherPacket = null;
            Packet seasonPacket = null;

            for (int i = 0; i < states.Count; ++i)
            {
                NetState ns = (NetState)states[i];
                Mobile mob = ns.Mobile;

                if (mob == null || mob.Map != Map.Felucca)
                    continue;

                if (seasonHasChanged)
                {
                    if (seasonPacket == null)
                        seasonPacket = Packet.Acquire(new SeasonChange(Map.Felucca.Season, false));

                    ns.Send(seasonPacket);

                    mob.CheckLightLevels(false);
                }

                bool contains = (m_Area.Length == 0);

                for (int j = 0; !contains && j < m_Area.Length; ++j)
                    contains = m_Area[j].Contains(mob.Location);

                if (!contains)
                    continue;

                if (weatherPacket == null)
                    weatherPacket = Packet.Acquire(new Server.Network.Weather(type, density, temperature));

                ns.Send(weatherPacket);

                if (wasRaining && !IsRaining)
                {
                    ns.Send(new MobileUpdate(mob));
                    ns.Send(new MobileIncoming(mob, mob));
                }

                //ns.Mobile.ProcessDelta();
            }
        }
    }

    public class WeatherMap : MapItem
    {
        [Constructable]
        public WeatherMap()
        {
            Name = "weather map";
            SetDisplay(0, 0, 5119, 4095, 400, 400);
        }

        public override void OnDoubleClick(Mobile from)
        {
            Map facet = from.Map;

            if (facet == null)
                return;

            ArrayList list = Weather.Weathers;

            ClearPins();

            for (int i = 0; i < list.Count; ++i)
            {
                Weather w = (Weather)list[i];

                for (int j = 0; j < w.Area.Length; ++j)
                    AddWorldPin(w.Area[j].X + (w.Area[j].Width / 2), w.Area[j].Y + (w.Area[j].Height / 2));
            }

            base.OnDoubleClick(from);
        }

        public WeatherMap(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}

/*private int m_Count;
private int m_MaxCount;

private void WeatherChange_OnTick(object state)
{
    double[] values = (double[])state;

    double oldtemperature = values[0];
    double oldchanceOfPrecitation = values[1];
    double oldcloud = values[2];
    double oldwind = values[3];

    double newtemperature = values[4];
    double newchanceOfPrecitation = values[5];
    double newcloud = values[6];
    double newwind = values[7];

    if (m_Count >= m_MaxCount)
    {
        m_Temperature = newtemperature;
        m_ChanceOfPercipitation = newchanceOfPrecitation;
        m_Cloud = newcloud;
        m_Wind = newwind;

        m_IsRaining = (m_ChanceOfPercipitation > Utility.Random(100));
    }
    else
    {
        m_Temperature -= (oldtemperature - newtemperature) / m_MaxCount;
        m_ChanceOfPercipitation -= (oldchanceOfPrecitation - newchanceOfPrecitation) / m_MaxCount;
        m_Cloud -= (oldcloud - newcloud) / m_MaxCount;
        m_Wind -= (oldwind - newwind) / m_MaxCount;

        m_Count++;
    }
}

private void WeatherChange(double oldtemperature, double oldchanceOfPrecitation, double oldcloud, double oldwind, double newtemperature, double newchanceOfPrecitation, double newcloud, double newwind)
{
    m_Count = 0;
    m_MaxCount = 15;
    //15.0
    Timer.DelayCall(TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0), m_MaxCount, new TimerStateCallback(WeatherChange_OnTick), new double[] { oldtemperature, oldchanceOfPrecitation, oldcloud, oldwind, newtemperature, newchanceOfPrecitation, newcloud, newwind });
}*/