using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class EspritAnimalSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Esprit animal", "Kal Xen Ort",
				SpellCircle.Third,
				269,
				9032,
				false,
				Reagent.Bloodmoss,
				Reagent.BlackPearl
			);

        public override bool Invocation { get { return true; } }

		public EspritAnimalSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 1) > Caster.FollowersMax )
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
                TimeSpan duration = GetDurationForSpell(30, 1.5);

				SpellHelper.Summon( new EspritAnimal(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();		
		}
	}
}