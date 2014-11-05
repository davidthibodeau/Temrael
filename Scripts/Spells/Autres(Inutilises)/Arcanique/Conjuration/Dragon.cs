using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
    public class DragonSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Dragon", "Kal Vas Xen Grav",
				7,
				269,
				9050,
				Reagent.Bloodmoss,
                Reagent.Bloodmoss,
                Reagent.Bloodmoss
			);

        public override bool Invocation { get { return true; } }

        public DragonSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 8) > Caster.FollowersMax )
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
                TimeSpan duration = TimeSpan.FromSeconds(0);

			    SpellHelper.Summon( new SummonedDragon(), Caster, 0x216, duration, false, false );
			}

			FinishSequence();
		}
	}
}