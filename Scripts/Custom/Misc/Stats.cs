using System;
using System.Collections.Generic;
using System.Text;
using Server.DataStructures;
using Server.Network;
using Server.Accounting;
using System.IO;
using System.Xml;

namespace Server.Misc
{
    public class Stats
    {
        private static Stats stats;

        private Dictionary<IAccount, bool> ThisHour;
        private DateTime LastHour;
        private OrderedDictionary<DateTime, int> DataHourly;

        private Dictionary<IAccount, bool> ThisDay;
        private DateTime LastDay;
        private OrderedDictionary<DateTime, int> DataDaily;

        private Dictionary<IAccount, bool> ThisWeek;
        private DateTime LastWeek;
        private OrderedDictionary<DateTime, int> DataWeekly;

        public static void Configure()
        {
            stats = new Stats();
            EventSink.Login += new LoginEventHandler(OnLogin);
            EventSink.WorldLoad += new WorldLoadEventHandler(Load);
            EventSink.WorldSave += new WorldSaveEventHandler(Save);
        }

        public static void OnLogin(LoginEventArgs e)
        {
            stats.RecordPlayer(e.Mobile.Account);
        }

        public static void Load()
        {
            string filePath = Path.Combine("Saves/Misc", "stats.xml");

            XmlDocument doc;
            XmlElement root;
            if(File.Exists(filePath))
            {
                doc = new XmlDocument();
                doc.Load(filePath);

                root = doc["stats"];
                if(root == null)
                {
                    Console.WriteLine("ERREUR: Impossible de lire la liste des stats");
                }
                XmlElement hourlies = root["hourlies"];
                foreach (XmlElement hourly in hourlies.ChildNodes)
                    stats.ThisHour.Add(Accounts.GetAccount(hourly.InnerText), true);
                XmlElement dailies = root["dailies"];
                foreach (XmlElement daily in dailies.ChildNodes)
                    stats.ThisDay.Add(Accounts.GetAccount(daily.InnerText), true);
                XmlElement weeklies = root["weeklies"];
                foreach (XmlElement weekly in weeklies.ChildNodes)
                    stats.ThisWeek.Add(Accounts.GetAccount(weekly.InnerText), true);

                DateTime read = Utility.GetXMLDateTime(Utility.GetText(root["lasthour"], ""), DateTime.Now);
                if (read < stats.LastHour)
                    stats.RecordHour();
                read = Utility.GetXMLDateTime(Utility.GetText(root["lastday"], ""), DateTime.Now);
                if (read < stats.LastDay)
                    stats.RecordDay();
                read = Utility.GetXMLDateTime(Utility.GetText(root["lastweek"], ""), DateTime.Now);
                if (read < stats.LastWeek)
                    stats.RecordWeek();
            }

        }

        public static void Save (WorldSaveEventArgs e)
        {
            string path = Directories.AppendPath(Directories.saves, "Misc");
            string filePath = Path.Combine(path, "stats.xml");
            using (StreamWriter op = new StreamWriter(filePath))
            {
                XmlTextWriter xml = new XmlTextWriter(op);

                xml.Formatting = Formatting.Indented;
                xml.IndentChar = '\t';
                xml.Indentation = 1;

                xml.WriteStartDocument(true);
                xml.WriteStartElement("stats");

                xml.WriteStartElement("hourlies");
                foreach (IAccount acc in stats.ThisHour.Keys)
                {
                    xml.WriteStartElement("hourly");
                    xml.WriteString(acc.Username);
                    xml.WriteEndElement();
                }
                xml.WriteEndElement();

                xml.WriteStartElement("dailies");
                foreach (IAccount acc in stats.ThisDay.Keys)
                {
                    xml.WriteStartElement("daily");
                    xml.WriteString(acc.Username);
                    xml.WriteEndElement();
                }
                xml.WriteEndElement();

                xml.WriteStartElement("weeklies");
                foreach (IAccount acc in stats.ThisWeek.Keys)
                {
                    xml.WriteStartElement("weekly");
                    xml.WriteString(acc.Username);
                    xml.WriteEndElement();
                }
                xml.WriteEndElement();

                xml.WriteStartElement("lasthour");
                xml.WriteString(stats.LastHour.ToString());
                xml.WriteEndElement();

                xml.WriteStartElement("lastday");
                xml.WriteString(stats.LastDay.ToString());
                xml.WriteEndElement();

                xml.WriteStartElement("lastweek");
                xml.WriteString(stats.LastWeek.ToString());
                xml.WriteEndElement();

                xml.WriteEndElement();
                xml.Close();
            }
        }

        public Stats()
        {
            ThisHour = new Dictionary<IAccount, bool>();
            ThisDay = new Dictionary<IAccount, bool>();
            ThisWeek = new Dictionary<IAccount, bool>();

            DataHourly = new OrderedDictionary<DateTime, int>();
            DataDaily = new OrderedDictionary<DateTime, int>();
            DataWeekly = new OrderedDictionary<DateTime, int>();

            LastHour = LastRoundHour();
            LastDay = LastRoundDay();
            LastWeek = LastRoundWeek();

            new HourlyTimer(LastHour.AddHours(1) - DateTime.Now).Start();
            new DailyTimer(LastDay.AddDays(1) - DateTime.Now).Start();
            new DailyTimer(LastWeek.AddDays(7) - DateTime.Now).Start();
        }

        public void RecordPlayer (IAccount a)
        {
            if(a.AccessLevel > AccessLevel.Player)
                return;
            if(!ThisHour.ContainsKey(a))
                ThisHour.Add(a, true);
            if(!ThisDay.ContainsKey(a))
                ThisDay.Add(a, true);
            if(!ThisWeek.ContainsKey(a))
                ThisWeek.Add(a, true);
        }

        public void RecordOnline()
        {
            foreach(NetState ns in NetState.Instances)
            {
                RecordPlayer(ns.Account);
            }
        }

        public static DateTime LastRoundHour()
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
        }

        public static DateTime LastRoundDay()
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day);
        }

        public static DateTime LastRoundWeek()
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day).Subtract(TimeSpan.FromDays((int)now.DayOfWeek));
        }

        public void RecordHour()
        {
            int count = ThisHour.Count;
            DataHourly.Add(LastHour, count);
            WriteRaw("rawHour.log", String.Format("[{0}] {1}", LastHour.ToString(), count.ToString()));
            if (LastHour == LastRoundHour())
                LastHour = LastHour.AddHours(1);
            else
                LastHour = LastRoundHour();

            ThisHour.Clear();
            RecordOnline();
        }

        public void RecordDay()
        {
            int count = ThisDay.Count;
            DataDaily.Add(LastDay, count);
            WriteRaw("rawDay.log", String.Format("[{0}] {1}", LastDay.ToString(), count.ToString()));
            if (LastDay == LastRoundDay())
                LastDay = LastRoundDay().AddDays(1);
            else
                LastDay = LastRoundDay();

            ThisDay.Clear();
            RecordOnline();
        }

        public void RecordWeek()
        {
            int count = ThisWeek.Count;
            DataWeekly.Add(LastWeek, count);
            WriteRaw("rawWeek.log", String.Format("[{0}] {1}", LastWeek.ToString(), count.ToString()));
            if (LastWeek == LastRoundWeek())
                LastWeek = LastRoundWeek().AddDays(7);
            else
                LastWeek = LastRoundWeek();

            ThisWeek.Clear();
            RecordOnline();
        }

        public void WriteRaw(string file, string entry)
        {
            string path = Path.Combine(Directories.stats, file);
            try
            {
                using(StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(entry);
                }
            }
            catch { }
        }

        // Generate graph and statistics

        private class HourlyTimer : Timer
        {
            public HourlyTimer(TimeSpan delay)
                : base(delay, TimeSpan.FromHours(1))
            {
                Priority = TimerPriority.FiveSeconds;
            }

            protected override void OnTick()
            {
                stats.RecordHour();
            }
        }

        private class DailyTimer : Timer
        {
            public DailyTimer(TimeSpan delay)
                : base(delay, TimeSpan.FromDays(1))
            {
                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                stats.RecordDay();
            }
        }

        private class WeeklyTimer : Timer
        {
            public WeeklyTimer(TimeSpan delay)
                : base(delay, TimeSpan.FromDays(7))
            {
                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                stats.RecordWeek();
            }
        }
    }
}
