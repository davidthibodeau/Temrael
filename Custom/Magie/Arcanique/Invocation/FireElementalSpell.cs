using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class ElementaireFeuSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elementaire de feu", "Kal Vas Xen Flam",
				SpellCircle.Sixth,
				269,
				9050,
				false,
				Reagent.SulfurousAsh,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
			);

        public override int RequiredAptitudeValue { get { return 4; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Invocation }; } }

        public override bool Invocation { get { return true; } }

        public ElementaireFeuSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 4) > Caster.FollowersMax )
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

			    SpellHelper.Summon( new SummonedFireElemental(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}