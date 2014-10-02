using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class IntelligenceSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
                "Intelligence", "Uus Wis",
				SpellCircle.Second,
				212,
				9061,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
            );

        public IntelligenceSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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

                SpellHelper.AddStatBonus(Caster, m, StatType.Int, GetDurationForSpell(1));

				m.FixedParticles( 0x375A, 10, 15, 5011, EffectLayer.Head );
				m.PlaySound( 0x1EB );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private IntelligenceSpell m_Owner;

            public InternalTarget(IntelligenceSpell owner)
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