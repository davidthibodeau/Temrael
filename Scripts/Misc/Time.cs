using Server.Mobiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Server.Misc
{

    public enum TimeOfDay
    {
        Night,
        ScaleToDay,
        Day,
        ScaleToNight
    }

    public enum Day
    {
        Dimanche,
        Lundi,
        Mardi,
        Mercredi,
        Jeudi,
        Vendredi,
        Samedi,
    }

    public enum MoonPhase
    {
        NewMoon,
        WaxingCrescentMoon,
        FirstQuarter,
        WaxingGibbous,
        FullMoon,
        WaningGibbous,
        LastQuarter,
        WaningCrescent
    }

    public enum Month
    {
        Janvier,
        Fevrier,
        Mars,
        Avril,
        Mai,
        Juin,
        Juillet,
        Aout,
        Septembre,
        Octobre,
        Novembre,
        Decembre
    }

    public enum Season
    {
        Spring,
        Summer,
        Automn,
        Winter
    }

    public class Time
    {
        public static readonly DateTime WorldStart = new DateTime(2014, 1, 1);

        public const double SecondsPerUOMinute = 15;

        private static DateTime m_ServerStart;

		public static DateTime ServerStart
		{
			get{ return m_ServerStart; }
		}

		public static void Initialize()
		{
			m_ServerStart = DateTime.Now;
		}

        public class CalendrierEntry
        {
            private Month m_Month;
            private Season m_Season;
            private int m_Days;

            public Month Month { get { return m_Month; } }
            public Season Season { get { return m_Season; } }
            public int Days { get { return m_Days; } }

            public CalendrierEntry(Month month, Season season, int days)
            {
                m_Month = month;
                m_Season = season;
                m_Days = days;
            }
        }
        public static CalendrierEntry[] Months = new CalendrierEntry[]
			{
				new CalendrierEntry( Month.Janvier, Season.Winter, 31 ),
				new CalendrierEntry( Month.Fevrier, Season.Winter, 28 ),
				new CalendrierEntry( Month.Mars, Season.Winter, 31 ),
				new CalendrierEntry( Month.Avril, Season.Spring, 30 ),
				new CalendrierEntry( Month.Mai, Season.Spring, 31 ),
				new CalendrierEntry( Month.Juin, Season.Spring, 30 ),
				new CalendrierEntry( Month.Juillet, Season.Summer, 31 ),
				new CalendrierEntry( Month.Aout, Season.Summer, 31 ),
				new CalendrierEntry( Month.Septembre, Season.Summer, 30 ),
				new CalendrierEntry( Month.Octobre, Season.Automn, 31 ),
                new CalendrierEntry( Month.Novembre, Season.Automn, 30 ),
                new CalendrierEntry( Month.Decembre, Season.Automn, 31 )
			};

        public static void GetTime(out int hours, out int minutes)
        {
            TimeSpan timeSpan = DateTime.Now - WorldStart;

            int totalMinutes = (int)(timeSpan.TotalSeconds / Time.SecondsPerUOMinute);

            hours = (totalMinutes / 60) % 24;
            minutes = totalMinutes % 60;
        }

        public static string GetExactTime()
        {
            int hours, minutes;

            GetTime(out hours, out minutes);

            hours %= 12;

            return String.Format("{0}:{1:D2}", hours, minutes);
        }

        public static int GetDay(int totalDays)
        {
            totalDays %= 365;
            int month = GetMonth(totalDays) - 1;

            //Console.WriteLine(totalDays);
            //Console.WriteLine(month);

            for (int i = 0; i < Months.Length; ++i)
            {
                if (month > 0 && totalDays > Months[i].Days)
                {
                    totalDays -= Months[i].Days;
                    month--;
                }
                else
                {
                    break;
                }
            }

            return totalDays;
        }

        public static void GetDate(out int year, out int month, out int day)
        {
            TimeSpan timeSpan = DateTime.Now - WorldStart;

            int totalMinutes = (int)(timeSpan.TotalSeconds / Time.SecondsPerUOMinute);
            int totalDays = totalMinutes / (24 * 60);

            year = totalDays / 365 + 190;
            month = GetMonth(totalDays);
            day = GetDay(totalDays);
        }

        public static MoonPhase GetMoonPhase(Map map, int x, int y)
		{
			int hours, minutes;

			Time.GetTime( out hours, out minutes );

			if ( map != null )
				minutes /= 10 + (map.MapIndex * 20);

			return (MoonPhase)(minutes % 8);
		}

        public static int GetMonth(int totalDays)
        {
            totalDays %= 365;
            int month = 0;

            for (int i = 0; i < Months.Length; ++i)
            {
                if (totalDays >= Months[i].Days)
                {
                    totalDays -= Months[i].Days;
                    month++;
                }
                else
                {
                    break;
                }
            }

            return month + 1;
        }

        public static void CheckSeason()
        {
            int year, month, day;

            GetDate(out year, out month, out day);

            Map.Felucca.Season = Convert.ToInt32(Months[month - 1].Season);

            OnSeasonChange(Months[month - 1].Season);
        }

        public static void OnSeasonChange(Season season)
        {
            ArrayList items = new ArrayList(World.Items.Values);

            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i] is Item)
                {
                    Item item = (Item)items[i];

                    if (item is PlantSpawner)
                    {
                        PlantSpawner ps = (PlantSpawner)item;

                        ps.Respawn();
                    }
                }
            }
        }



        /* OSI times:
        * 
        * Midnight ->  3:59 AM : Night
        *  4:00 AM -> 11:59 PM : Day
        * 
        * RunUO times:
        * 
        * 10:00 PM -> 11:59 PM : Scale to night
        * Midnight ->  3:59 AM : Night
        *  4:00 AM ->  5:59 AM : Scale to day
        *  6:00 AM ->  9:59 PM : Day
        *
        * Server times:
        * 
        * Été
        *
        *  5:00 AM -> 7:59 AM : Scale to day
        *  8:00 AM -> 7:59 PM : Day
        *  8:00 PM -> 11:59 PM : Scale to night
        *  00:00 AM -> 4:59 AM : Night
        *
        * Automne
        *
        *  5:00 AM -> 7:59 AM : Scale to day
        *  8:00 AM -> 6:59 PM : Day
        *  7:00 PM -> 10:59 PM : Scale to night
        *  11:00 PM -> 4:59 AM : Night
        *
        * Hiver
        *
        *  6:00 AM -> 8:59 AM : Scale to day
        *  9:00 AM -> 5:59 PM : Day
        *  6:00 PM -> 9:59 PM : Scale to night
        *  10:00 PM -> 5:59 AM : Night 
        * 
        * Abyss
        *
        *  7:00 AM -> 9:59 AM : Scale to day
        *  10:00 AM -> 4:59 PM : Day
        *  5:00 PM -> 7:59 PM : Scale to night
        *  8:00 PM -> 6:59 AM : Night 
        * 
        * Printemps
        * 
        *  5:00 AM -> 7:59 AM : Scale to day
        *  8:00 AM -> 6:59 PM : Day
        *  7:00 PM -> 10:59 PM : Scale to night
        *  11:00 PM -> 4:59 AM : Night 
        * 
        */
        public static TimeOfDay GetTimeofDay()
        {
            int hours, minutes;

            GetTime(out hours, out minutes);

            switch (Map.Felucca.Season)
            {
                case 0: // Printemps
                    {
                        if (hours < 5)
                            return TimeOfDay.Night;

                        if (hours < 8)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 19)
                            return TimeOfDay.Day;

                        if (hours < 23)
                            return TimeOfDay.ScaleToNight;

                        if (hours < 24)
                            return TimeOfDay.Night;

                        break;
                    }
                case 1: // Été
                    {
                        if (hours < 5)
                            return TimeOfDay.Night;

                        if (hours < 8)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 20)
                            return TimeOfDay.Day;

                        if (hours < 24)
                            return TimeOfDay.ScaleToNight;

                        break;
                    }
                case 2: // Automne
                    {
                        if (hours < 5)
                            return TimeOfDay.Night;

                        if (hours < 8)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 19)
                            return TimeOfDay.Day;

                        if (hours < 23)
                            return TimeOfDay.ScaleToNight;

                        if (hours < 24)
                            return TimeOfDay.Night;

                        break;
                    }
                case 3: // Hiver
                    {
                        if (hours < 6)
                            return TimeOfDay.Night;

                        if (hours < 9)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 18)
                            return TimeOfDay.Day;

                        if (hours < 22)
                            return TimeOfDay.ScaleToNight;

                        if (hours < 24)
                            return TimeOfDay.Night;

                        break;
                    }
            }

            return TimeOfDay.Night; // should never be
        }


    }
}
