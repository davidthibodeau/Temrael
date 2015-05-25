using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Mobiles;

namespace Server.Misc
{
	public class RegenRates
	{
		[CallPriority( 10 )]
		public static void Configure()
		{
			Mobile.DefaultHitsRate = TimeSpan.FromSeconds( 11.0 );
			Mobile.DefaultStamRate = TimeSpan.FromSeconds(  7.0 );
			Mobile.DefaultManaRate = TimeSpan.FromSeconds(  7.0 );

			Mobile.ManaRegenRateHandler = new RegenRateHandler( Mobile_ManaRegenRate );
	        Mobile.StamRegenRateHandler = new RegenRateHandler( Mobile_StamRegenRate );
			Mobile.HitsRegenRateHandler = new RegenRateHandler( Mobile_HitsRegenRate );
		}

        //Test de skill ayant pour but de verifier s'il y a un gain
        private static void CheckBonusSkill(Mobile m, int cur, int max, SkillName skill)
        {
            if (!m.Alive)
                return;

            double n = (double)cur / max;
            double v = Math.Sqrt(m.Skills[skill].Value * 0.005);

            n *= (1.0 - v);
            n += v;

            m.CheckSkill(skill, n);
        }


		private static TimeSpan Mobile_HitsRegenRate( Mobile from )
		{
            double points = from.Str / 20;

            return TimeSpan.FromSeconds(1.0 / (0.1 * (1 + points)));
		}

		private static TimeSpan Mobile_StamRegenRate( Mobile from )
		{
            CheckBonusSkill(from, from.Stam, from.StamMax, SkillName.Concentration);

            double pourc = (from.Dex / 120.0) + (from.Skills[SkillName.Concentration].Value / 120);
            double points = from.StamMax * pourc / 100;
            double delay = 1.0 / points;
            if (delay > 60.0)
                delay = 60.0;
            return TimeSpan.FromSeconds(delay);
		}

		private static TimeSpan Mobile_ManaRegenRate( Mobile from )
		{
            if (!from.Meditating)
                CheckBonusSkill(from, from.Mana, from.ManaMax, SkillName.Meditation);
            CheckBonusSkill(from, from.Mana, from.ManaMax, SkillName.Concentration);

            double med = from.Skills[SkillName.Meditation].Value;

            double points = (from.Int / 20) + med / 8;

            points += (from.Skills[SkillName.Concentration].Value / 20);

            points *= GetArmorOffset(from);

            if (from.Meditating)
            {
                points *= 1.7;
            }

            return TimeSpan.FromSeconds(1.0 / (0.1 * (1 + points)));
		}

		public static double GetArmorOffset( Mobile from )
		{
            return 1 - (from.PhysicalResistance / 75) * 0.5;
		}
	}
}