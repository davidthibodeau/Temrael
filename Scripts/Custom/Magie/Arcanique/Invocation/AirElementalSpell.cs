using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class ElementaireAirSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Elementaire d'air", "Kal Vas Xen Hur",
				SpellCircle.Fourth,
				269,
				9010,
				false,
				Reagent.Ginseng,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
			);

        public override int RequiredAptitudeValue { get { return 3; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Invocation }; } }

        public override bool Invocation { get { return true; } }

        public ElementaireAirSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
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
                TimeSpan duration = GetDurationForSpell(30, 1.8);

			    SpellHelper.Summon( new SummonedAirElemental(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}