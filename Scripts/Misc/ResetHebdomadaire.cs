using Server.Commands;
using Server.Engines.Evolution;
using Server.Items;
using Server.Mobiles;
using Server.Mobiles.Vendeurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Misc
{
    public class ResetHebdomadaire
    {
        public static DateTime LastReset = DateTime.Now;

        public static void Initialize()
        {
            DateTime now = DateTime.Now;
            DateTime today = new DateTime(now.Year, now.Month, now.Day, 3, 0, 0);
            DateTime next = today.AddDays(7 - (int)today.DayOfWeek);

            new ResetTimer(next - now).Start();
            if (LastReset.AddDays(7) < now)
            {
                Console.WriteLine("Le dernier reset hebdomadaire était le {0}. Un reset est maintenant fait.", LastReset.ToString());
                ResetWeek();
            }
        }

             public class ResetTimer : Timer
        {
            public ResetTimer(TimeSpan delay)
                : base(delay, TimeSpan.FromDays(7))
            {
                Priority = TimerPriority.OneMinute;
            }

            protected override void OnTick()
            {
                ResetWeek();
            }
        }

        public static void ResetWeek()
        {
            CommandLogging.WriteLine("Lancement d'un reset de gain d'xp hebdomadaire manuel.");

            Experience.ResetAllTicks();

            CompensationGump.CompenserGMs();

            Acheteur.Reset();

            InstitutionHandler.Pay(); // Salaire venant des institutions.

            BoiteAuLettreComponent.WeeklyPay(); // Paiement des maisons.

            LastReset = DateTime.Now;
        }
    }
}
