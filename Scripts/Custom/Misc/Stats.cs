using System;
using System.Collections.Generic;
using System.Text;
using Server.DataStructures;
using Server.Network;
using Server.Accounting;

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

        public static void Initialize()
        {
            stats = new Stats();
            // Load of stats
            // Save stats EventSink
            EventSink.Login += new LoginEventHandler(OnLogin);

            DateTime next = LastRoundHour().AddHours(1);
            new HourlyTimer(next - DateTime.Now).Start();
            next = LastRoundDay().AddDays(1);
            new DailyTimer(next - DateTime.Now).Start();
            next = today.AddDays(7 - (int)DateTime.Now.DayOfWeek); //maybe with LastRoundWeek()?
            new DailyTimer(next - DateTime.Now).Start();
            
        }

        public static void OnLogin(LoginEventArgs e)
        {
            stats.RecordPlayer(e.Mobile.Account);
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
        }

        public void RecordPlayer (IAccount a)
        {
            if(a.AccessLevel > AccessLevel.Player)
                return;
            if(!ThisHour.ContainsKey(a)))
                ThisHour.Add(a, true);
            if(!ThisDay.ContainsKey(a)))
                ThisDay.Add(a, true);
            if(!ThisWeek.ContainsKey(a)))
                ThisWeek.Add(a, true);
        
        }

        public void RecordOnline()
        {
            foreach(Netstate ns in Nestate.Instances)
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
            return new DateTime(now.Year, now.Month, now.Day); //.AddDays(7 - now.DayOfWeek);
            //Find right day of the week for previous.
        }

        public void RecordHour()
        {
            int count = ThisHour.Count;
            DataHourly.Add(LastHour, count);
            WriteRaw("rawHour.log", String.Format("[{0}] {1}", LastHour.ToString(), count.ToString())); 
            LastHour = LastRoundHour();

            ThisHour.Clear();
            RecordOnline();
        }

        public void RecordDay()
        {
            int count = ThisDay.Count;
            DataDaily.Add(LastDay, count);
            WriteRaw("rawDay.log", String.Format("[{0}] {1}", LastDay.ToString(), count.ToString())); 

            LastDay = LastRoundDay();

            ThisDay.Clear();
            RecordOnline();
        }

        public void RecordWeek()
        {
            int count = ThisWeek.Count;
            DataWeekly.Add(LastWeek, count);
            WriteRaw("rawWeek.log", String.Format("[{0}] {1}", LastWeek.ToString(), count.ToString())); 

            LastWeek = LastRoundWeek();

            ThisWeek.Clear();
            RecordOnline();
        }

        public void WriteRaw(string file, string entry)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(file, true))
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
