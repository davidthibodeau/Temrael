using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class ElementaireTerreSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elementaire de terre", "Kal Vas Xen Ylem Choma",
				SpellCircle.Third,
				269,
				9020,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
                Reagent.BlackPearl
			);

        public override bool Invocation { get { return true; } }

        public ElementaireTerreSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 2) > Caster.FollowersMax )
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
                TimeSpan duration = GetDurationForSpell(30, 1.8);

				SpellHelper.Summon( new SummonedEarthElemental(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}