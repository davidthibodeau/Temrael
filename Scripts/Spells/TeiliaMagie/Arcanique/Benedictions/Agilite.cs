using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class AgiliteSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Agilite", "Ex Uus",
				SpellCircle.First,
				212,
				9061,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot
            );

        public AgiliteSpell(Mobile caster, Item scroll)
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
			else if ( CheckBSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

                SpellHelper.AddStatBonus(Caster, m, StatType.Dex, GetDurationForSpell(1));

				m.FixedParticles( 0x375A, 10, 15, 5010, EffectLayer.Waist );
				m.PlaySound( 0x28E );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private AgiliteSpell m_Owner;

            public InternalTarget(AgiliteSpell owner)
                : base(12, false, TargetFlags.Beneficial)
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