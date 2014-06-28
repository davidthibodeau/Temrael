using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.Necromancy;
//using Server.Spells.Ninjitsu;
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

			if ( Core.AOS )
			{
				Mobile.StamRegenRateHandler = new RegenRateHandler( Mobile_StamRegenRate );
				Mobile.HitsRegenRateHandler = new RegenRateHandler( Mobile_HitsRegenRate );
			}
		}

		private static void CheckBonusSkill( Mobile m, int cur, int max, SkillName skill )
		{
			if ( !m.Alive )
				return;

			double n = (double)cur / max;
			double v = Math.Sqrt( m.Skills[skill].Value * 0.005 );

			n *= (1.0 - v);
			n += v;

			//m.CheckSkill( skill, n );
		}

		/*private static bool CheckTransform( Mobile m, Type type )
		{
			return TransformationSpellHelper.UnderTransformation( m, type );
		}

		private static bool CheckAnimal( Mobile m, Type type )
		{
			return AnimalForm.UnderTransformation( m, type );
		}*/

		private static TimeSpan Mobile_HitsRegenRate( Mobile from )
		{
			int points = AosAttributes.GetValue( from, AosAttribute.RegenHits );

            if (points > 5)
                points = 5;

			if ( from is BaseCreature && !((BaseCreature)from).IsAnimatedDead )
				points += 4;

			if ( (from is BaseCreature && ((BaseCreature)from).IsParagon) || from is Leviathan )
				points += 40;

            if (RetablissementMiracle.m_RetablissementTable.Contains(from))
                points -= ((int)RetablissementMiracle.m_RetablissementTable[from] - 1); //+0.35

			if( Core.ML && from.Race == Race.Human )	//Is this affected by the cap?
				points += 2;

			if ( points < 0 )
				points = 0;

			if( Core.ML && from is PlayerMobile )	//does racial bonus go before/after?
				points = Math.Min( points, 18 );

			//if ( CheckTransform( from, typeof( HorrificBeastSpell ) ) )
			//	points += 20;

			//if ( CheckAnimal( from, typeof( Dog ) ) || CheckAnimal( from, typeof( Cat ) ) )
			//	points += from.Skills[SkillName.Ninjitsu].Fixed / 30;

			return TimeSpan.FromSeconds( 1.0 / (0.1 * (1 + points)) );
		}

		private static TimeSpan Mobile_StamRegenRate( Mobile from )
		{
			if ( from.Skills == null )
				return Mobile.DefaultStamRate;

            CheckBonusSkill(from, from.Stam, from.StamMax, SkillName.Concentration);

			int points =(int)(from.Skills[SkillName.Concentration].Value * 0.03); //Stam regen for Mage
            points += (int)(from.StamMax * 0.04); //Stam regen for others

            if (points > 5)
                points = 5;

			if( (from is BaseCreature && ((BaseCreature)from).IsParagon) || from is Leviathan )
				points += 40;

			int cappedPoints = AosAttributes.GetValue( from, AosAttribute.RegenStam );

			/*if ( CheckTransform( from, typeof( VampiricEmbraceSpell ) ) )
				cappedPoints += 15;

			if ( CheckAnimal( from, typeof( Kirin ) ) )
				cappedPoints += 20;*/

			if( Core.ML && from is PlayerMobile )
				cappedPoints = Math.Min( cappedPoints, 24 );

			points += cappedPoints;

			if ( points < -1 )
				points = -1;

			return TimeSpan.FromSeconds( 1.0 / (0.1 * (2 + points)) );
		}

		private static TimeSpan Mobile_ManaRegenRate( Mobile from )
		{
			if ( from.Skills == null )
				return Mobile.DefaultManaRate;

			if ( !from.Meditating )
				CheckBonusSkill( from, from.Mana, from.ManaMax, SkillName.Concentration );

			double rate;
			double armorPenalty = GetArmorOffset( from );
            //double armorPenalty = 0.0;

            if (from is TMobile)
            {
                TMobile tmob = (TMobile)from;
                if (tmob.Aptitudes != null)
                    if (tmob.GetAptitudeValue(Aptitude.PortArmeMagique) >= 3)
                        armorPenalty = 0;
            }

			if ( Core.AOS )
			{
				double medPoints = from.Int + (from.Skills[SkillName.Concentration].Value * 3);

				medPoints *= ( from.Skills[SkillName.Concentration].Value < 100.0 ) ? 0.025 : 0.0275;

                CheckBonusSkill(from, from.Mana, from.ManaMax, SkillName.Concentration);

                double focusPoints = (from.Skills[SkillName.Concentration].Value * 0.05);

				if ( armorPenalty > 0 )
					medPoints = 0; // In AOS, wearing any meditation-blocking armor completely removes meditation bonus

				double totalPoints = focusPoints + medPoints + (from.Meditating ? (medPoints > 13.0 ? 13.0 : medPoints) : 0.0);

				if( (from is BaseCreature && ((BaseCreature)from).IsParagon) || from is Leviathan )
					totalPoints += 40;

				int cappedPoints = AosAttributes.GetValue( from, AosAttribute.RegenMana );

                if (cappedPoints > 5)
                    cappedPoints = 5;

				/*if ( CheckTransform( from, typeof( VampiricEmbraceSpell ) ) )
					cappedPoints += 3;
				else if ( CheckTransform( from, typeof( LichFormSpell ) ) )
					cappedPoints += 13;*/

				if( Core.ML && from is PlayerMobile )
					cappedPoints = Math.Min( cappedPoints, 18 );

				totalPoints += cappedPoints;

				if ( totalPoints < -1 )
					totalPoints = -1;

				if ( Core.ML )
					totalPoints = Math.Floor( totalPoints );

				rate = 1.0 / (0.1 * (2 + totalPoints));
			}
			else
			{
				double medPoints = (from.Int + from.Skills[SkillName.Concentration].Value) * 0.5;

				if ( medPoints <= 0 )
					rate = 7.0;
				else if ( medPoints <= 100 )
					rate = 7.0 - (239*medPoints/2400) + (19*medPoints*medPoints/48000);
				else if ( medPoints < 120 )
					rate = 1.0;
				else
					rate = 0.75;

				rate += armorPenalty;

				if ( from.Meditating )
					rate *= 0.5;

				if ( rate < 0.5 )
					rate = 0.5;
				else if ( rate > 7.0 )
					rate = 7.0;
			}

			return TimeSpan.FromSeconds( rate );
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

			return rating / 4;
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
                    case ArmorMeditationAllowance.None: return ar.BaseArmorRatingScaled;
                    case ArmorMeditationAllowance.Half: return ar.BaseArmorRatingScaled / 2.0;
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