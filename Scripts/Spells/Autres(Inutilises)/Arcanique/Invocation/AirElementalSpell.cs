using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class ElementaireAirSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Elementaire d'air", "Kal Vas Xen Hur",
				4,
				269,
				9010,
				Reagent.Ginseng,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
			);

        public override bool Invocation { get { return true; } }

        public ElementaireAirSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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