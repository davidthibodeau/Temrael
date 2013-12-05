using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class JetDeFeuSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Jet de feu", "Kal Vas Flam",
				SpellCircle.Seventh,
				245,
				9042,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh,
                Reagent.BlackPearl
            );

        public override int RequiredAptitudeValue { get { return 5; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Evocation }; } }

        public JetDeFeuSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                Disturb(m);

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

                double damage = GetNewAosDamage(35, 1, 5, true);

				if ( CheckResisted( m ) )
				{
					damage *= 0.75;

					m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
				}

				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );

				SpellHelper.Damage( this, m, damage, 0, 100, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private JetDeFeuSpell m_Owner;

            public InternalTarget(JetDeFeuSpell owner)
                : base(12, false, TargetFlags.Harmful)
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}