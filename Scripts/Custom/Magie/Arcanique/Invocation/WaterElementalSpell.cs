using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class ElementaireEauSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elementaire d'eau", "Kal Vas Xen An Flam",
				SpellCircle.Seventh,
				269,
				9070,
				false,
				Reagent.BlackPearl,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

        public override int RequiredAptitudeValue { get { return 5; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Invocation }; } }

        public override bool Invocation { get { return true; } }

        public ElementaireEauSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 6) > Caster.FollowersMax )
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
                TimeSpan duration = GetDurationForSpell(1.8);

				SpellHelper.Summon( new SummonedWaterElemental(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}