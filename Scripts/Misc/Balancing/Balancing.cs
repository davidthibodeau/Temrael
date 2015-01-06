using System;

namespace Server.Misc.Balancing
{
    public delegate void DeathEventHandler( DeathEventArgs e );

    public static class Balancing
    {
        private static DateTime start;
        private static DateTime end;
        private static bool done;
        private static Mobile loser;
        private static Mobile mob1, mob2;
        private static int combats, gains1, gains2;
        public static event DeathEventHandler Death;

        public static void Initialize()
        {
            if (!Core.Balancing)
                return;

            mob1 = new MobilePlaqueEpeeLente();
            mob1.Name = "Two handed lente";
            mob2 = new MobilePlaqueEpeeRapideBouclier();
            mob2.Name = "One handed rapide 75 int";

            Death += new DeathEventHandler(EventSink_Death);

            StartCombat();
            new FinishTimer().Start();
            Console.WriteLine("Début des tests");
        }

        public static void InvokeDeath(DeathEventArgs e)
        {
            if (Death != null)
                Death(e);
        }

        public static void StartCombat()
        {
            done = false;
            Heal(mob1);
            Heal(mob2);
            mob1.Map = mob2.Map = Map.Felucca;
            mob1.Location = new Point3D(4059, 66, 0);
            mob2.Location = new Point3D(4060, 66, 0);
            mob1.Combatant = mob2;
            mob2.Combatant = mob1;
            start = DateTime.Now;
        }

        public static void Heal(Mobile m)
        {
            m.Hits = m.HitsMax;
            m.Stam = m.StamMax;
            m.Mana = m.ManaMax;
        }

        public static void EventSink_Death(DeathEventArgs e)
        {
            Mobile from = e.Mobile;
            loser = from;
            end = DateTime.Now;

            done = true;
        }

        public static void Loop()
        {
            ReportFight();
            StartCombat();
        }

        public static void ReportFight()
        {
            int hitsleft = 0;
            string gagnant = "";
            combats++;
            if(loser == mob1)
            {
                gains2++;
                hitsleft = mob2.Hits;
                gagnant = mob2.Name;
            }
            else if(loser == mob2)
            {
                gains1++;
                hitsleft = mob1.Hits;
                gagnant = mob1.Name;
            }
            TimeSpan duration = end - start;
            string durText = String.Format("{0}:{1}:{2}", duration.Hours, duration.Minutes, duration.Seconds);
            Console.WriteLine("Combat {1}\n\tDurée: {0}.\n\tGagnant: combattant {2}.\n\tVie restante: {3}.", 
               durText, combats, gagnant, hitsleft);
            Console.WriteLine("\tRésultats préliminaires:\n\t\tCombattant {2} : {0} ({4}%).\n\t\tCombattant {3} : {1} ({5}%).", 
                gains1, gains2, mob1.Name, mob2.Name, gains1 * 100 /combats, gains2 * 100 /combats);
        }

        public class FinishTimer : Timer
        {
            public FinishTimer() : base(new TimeSpan(0,0,1), new TimeSpan(0,0,1))
            {
            }

            protected override void OnTick()
            {
                if (done)
                {
                    done = false;
                    mob1.Combatant = null;
                    mob2.Combatant = null;
                    Loop();
                }
            }
        }
    }

	public class DeathEventArgs : EventArgs
	{
		private Mobile m_Mobile;

		public Mobile Mobile{ get{ return m_Mobile; } }

		public DeathEventArgs( Mobile mobile )
		{
			m_Mobile = mobile;
		}
	}
}
