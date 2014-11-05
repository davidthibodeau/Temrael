using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class InsurectionSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Insurection", "Kal Xen In Ylem Corp Sanct",
				8,
				269,
				9070,
                Reagent.GraveDust,
                Reagent.GraveDust,
                Reagent.DaemonBlood
			);

        public override bool Invocation { get { return true; } }

        public InsurectionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 5) > Caster.FollowersMax )
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

				SpellHelper.Summon( new SummonedAncientLich(), Caster, 0x217, duration, false, false );
                //else
                //    SpellHelper.Summon( new AncientLich(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}