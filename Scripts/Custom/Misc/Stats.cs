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

        private Dictionary<IAccount, bool> CompteurCourant;
        private DateTime DerniereHeure;
        private OrderedDictionary<DateTime, int> data = new OrderedDictionary<DateTime,int>();

        public static void Initialize()
        {
            stats = new Stats();
            // Load of stats
            // Save stats
            EventSink.Login += new LoginEventHandler(OnLogin);
            DateTime next = LastRoundHour().AddHours(1);
            new RecordingTimer(next - DateTime.Now).Start();
        }

        public static void OnLogin(LoginEventArgs e)
        {
            stats.AjouterCourant(e.Mobile.Account);
        }

        public Stats()
        {
            CompteurCourant = new Dictionary<IAccount, bool>();
            data = new OrderedDictionary<DateTime, int>();
            DerniereHeure = LastRoundHour();
        }

        public void AjouterCourant(IAccount a)
        {
            if(a.AccessLevel == AccessLevel.Player && !CompteurCourant.ContainsKey(a))
                CompteurCourant.Add(a, true);
        }

        public static DateTime LastRoundHour()
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
        }

        public void Enregistrer()
        {
            int courant = CompteurCourant.Count;
            data.Add(DerniereHeure, courant);
            DerniereHeure = LastRoundHour();

            CompteurCourant.Clear();
            foreach (NetState ns in NetState.Instances)
            {
                AjouterCourant(ns.Account);
            }
        }

        // Generate graph and statistics

        private class RecordingTimer : Timer
        {
            public RecordingTimer(TimeSpan delay)
                : base(delay, TimeSpan.FromHours(1))
            {
                Priority = TimerPriority.FiveSeconds;
            }

            protected override void OnTick()
            {
                stats.Enregistrer();
            }
        }

    }
}
