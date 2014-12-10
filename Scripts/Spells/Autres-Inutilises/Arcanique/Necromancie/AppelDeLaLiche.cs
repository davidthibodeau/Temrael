using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class AppelDeLaLicheSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Appel de la liche", "Kal Vas Xen In Corp",
				8,
				269,
				9070,
				Reagent.GraveDust,
				Reagent.DaemonBlood,
				Reagent.PigIron
			);

        public AppelDeLaLicheSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
                TimeSpan duration = TimeSpan.FromSeconds(0);

				SpellHelper.Summon( new SummonedLich(), Caster, 0x217, duration, false, false );
			}

			FinishSequence();
		}
	}
}