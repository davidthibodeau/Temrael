using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class EspritVengeurSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Esprit vengeur", "Kal Xen Bal Beh",
				SpellCircle.Eighth,
				203,
				9031,
				Reagent.BlackPearl,
				Reagent.BlackPearl,
				Reagent.SulfurousAsh
            );

        public override bool Invocation { get { return true; } }

        public EspritVengeurSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
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

		public void Target( Mobile m )
		{
			if ( Caster == m )
			{
				Caster.SendLocalizedMessage( 1061832 ); // You cannot exact vengeance on yourself.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                TimeSpan duration = GetDurationForSpell(10, 0.2);

                SummonedEspritVengeur rev = new SummonedEspritVengeur(Caster, m, duration);

				if ( BaseCreature.Summon( rev, false, Caster, m.Location, 0x81, duration ) )
					rev.FixedParticles( 0x373A, 1, 15, 9909, EffectLayer.Waist );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private EspritVengeurSpell m_Owner;

            public InternalTarget(EspritVengeurSpell owner)
                : base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}