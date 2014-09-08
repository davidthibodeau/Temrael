using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells.Eighth
{
	public class WaterElementalSpell : Spell
	{
        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;

		private static SpellInfo m_Info = new SpellInfo(
				"Elemental d'Eau", "Kal Vas Xen An Flam",
                SpellCircle.Sixth,
				269,
				9070,
                s_ManaCost,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

		public WaterElementalSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 3) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
            {
                double duration = (2 * Caster.Skills.Conjuration.Fixed) / 5;

                SpellHelper.Summon(new WaterElemental(), Caster, 0x217, TimeSpan.FromSeconds(duration), true, true);
			}

			FinishSequence();
        }

        public override TimeSpan GetCastDelay()
        {
            return base.GetCastDelay() + TimeSpan.FromSeconds(4.0);
        }
	}
}