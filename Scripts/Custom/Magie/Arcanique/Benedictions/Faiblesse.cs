using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class FaiblesseSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Faiblesse", "Des Mani",
				SpellCircle.First,
				212,
				9031,
				Reagent.Garlic,
				Reagent.Nightshade
            );

        public override int RequiredAptitudeValue { get { return 2; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Thaumaturgie }; } }

        public FaiblesseSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

                SpellHelper.AddStatCurse(Caster, m, StatType.Str, GetDurationForSpell(1));

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				m.FixedParticles( 0x3779, 10, 15, 5009, EffectLayer.Waist );
				m.PlaySound( 0x1E6 );
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
            private FaiblesseSpell m_Owner;

            public InternalTarget(FaiblesseSpell owner)
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