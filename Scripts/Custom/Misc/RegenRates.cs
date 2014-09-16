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

		private static TimeSpan Mobile_HitsRegenRate( Mobile from )
		{
            double points = from.HitsMax / 30;

            return TimeSpan.FromSeconds(1.0 / (0.1 * (1 + points)));
		}

		private static TimeSpan Mobile_StamRegenRate( Mobile from )
		{
            double points = (from.StamMax / 20);

            return TimeSpan.FromSeconds(1.0 / (0.1 * (1 + points)));
		}

		private static TimeSpan Mobile_ManaRegenRate( Mobile from )
		{
			double armorPenalty = GetArmorOffset( from );

            double points = (from.ManaMax / 20) + (from.Skills[SkillName.Concentration].Value / 10);

            if (armorPenalty > 0)
                points /= armorPenalty;

            double totalPoints = points + (from.Meditating ? points : 0.0);

            return TimeSpan.FromSeconds(1.0 / (0.1 * (1 + totalPoints)));
		}

		public static double GetArmorOffset( Mobile from )
		{
			double rating = 0.0;

            if (from != null)
            {
                if (from.NeckArmor != null)
                    rating += GetArmorMeditationValue(from.NeckArmor as BaseArmor);
                if (from.HandArmor != null)
                    rating += GetArmorMeditationValue(from.HandArmor as BaseArmor);
                if (from.HeadArmor != null)
                    rating += GetArmorMeditationValue(from.HeadArmor as BaseArmor);
                if (from.ArmsArmor != null)
                    rating += GetArmorMeditationValue(from.ArmsArmor as BaseArmor);
                if (from.LegsArmor != null)
                    rating += GetArmorMeditationValue(from.LegsArmor as BaseArmor);
                if (from.ChestArmor != null)
                    rating += GetArmorMeditationValue(from.ChestArmor as BaseArmor);
            }

            return rating;
		}

		private static double GetArmorMeditationValue( BaseArmor ar )
		{
            try
            {
                if (ar == null || ar.ArmorAttributes.MageArmor != 0 || ar.Attributes.SpellChanneling != 0)
                    return 0.0;

                switch (ar.MeditationAllowance)
                {
                    default:
                    case ArmorMeditationAllowance.None: return 2.0; //return ar.BaseArmorRatingScaled;
                    case ArmorMeditationAllowance.Half: return 1.0; //return ar.BaseArmorRatingScaled / 2.0;
                    case ArmorMeditationAllowance.All: return 0.0;
                }
            }
            catch
            {
                return 0.0;
            }
		}
	}
}