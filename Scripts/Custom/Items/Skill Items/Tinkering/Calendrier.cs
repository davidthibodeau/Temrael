using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;

namespace Server
{
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

    public enum Season
    {
        Spring,
        Summer,
        Automn,
        Winter
    }
}

namespace Server.Items
{
	public class Calendrier : Item
	{
		[Constructable]
		public Calendrier() : base( 5359 )
		{
			Name = "calendrier";
			Weight = 1.0;
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

        public static CalendrierEntry[] m_Entries = new CalendrierEntry[]
			{
				new CalendrierEntry( Month.Janvier, Season.Winter, 31 ),
				new CalendrierEntry( Month.Fevrier, Season.Winter, 28 ),
				new CalendrierEntry( Month.Mars, Season.Spring, 31 ),
				new CalendrierEntry( Month.Avril, Season.Spring, 30 ),
				new CalendrierEntry( Month.Mai, Season.Spring, 31 ),
				new CalendrierEntry( Month.Juin, Season.Summer, 30 ),
				new CalendrierEntry( Month.Juillet, Season.Summer, 31 ),
				new CalendrierEntry( Month.Aout, Season.Summer, 31 ),
				new CalendrierEntry( Month.Septembre, Season.Automn, 30 ),
				new CalendrierEntry( Month.Octobre, Season.Automn, 31 ),
                new CalendrierEntry( Month.Novembre, Season.Automn, 30 ),
                new CalendrierEntry( Month.Decembre, Season.Winter, 31 )
			};

        public static void CheckSeason()
        {
            int year, month, day;

            GetDate(out year, out month, out day);

            Map.Felucca.Season = Convert.ToInt32(m_Entries[month - 1].Season);

            OnSeasonChange(m_Entries[month - 1].Season);
        }

        public static int GetMonth(int totalDays)
        {
            totalDays %= 360;
            int month = 0;

            for (int i = 0; i < m_Entries.Length; ++i)
            {
                if (totalDays >= m_Entries[i].Days)
                {
                    totalDays -= m_Entries[i].Days;
                    month++;
                }
                else
                {
                    break;
                }
            }

            return month + 1;
        }

        public static int GetDay(int totalDays)
        {
            totalDays %= 360;
            int month = GetMonth(totalDays) - 1;

            //Console.WriteLine(totalDays);
            //Console.WriteLine(month);

            for (int i = 0; i < m_Entries.Length; ++i)
            {
                if (month > 0 && totalDays > m_Entries[i].Days)
                {
                    totalDays -= m_Entries[i].Days;
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
            TimeSpan timeSpan = DateTime.Now - Clock.WorldStart;

            int totalMinutes = (int)(timeSpan.TotalSeconds * Clock.SecondsPerUOMinute);
            int totalDays = totalMinutes / 80;

            year = totalMinutes / 518400;
            month = GetMonth(totalDays);
            day = GetDay(totalDays);
        }

        public static void OnSeasonChange(Season seacon)
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

        public override void OnDoubleClick(Mobile from)
        {
            try
            {
                int year;
                int month;
                int day;

                GetDate(out year, out month, out day);

                LabelTo(from, String.Format("{0} {1} de l'annee du seigneur {2}", day, m_Entries[month - 1].Month, year));
            }
            catch (Exception ex)
            {
                Misc.ExceptionLogging.WriteLine(ex, new System.Diagnostics.StackTrace(true));
            }
        }

        public Calendrier(Serial serial) : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}