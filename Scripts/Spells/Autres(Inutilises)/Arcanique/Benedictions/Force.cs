using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class ForceSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Force", "Uus Mani",
				1,
				212,
				9061,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
            );

        public ForceSpell(Mobile caster, Item scroll)
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

                SpellHelper.AddStatBonus(Caster, m, StatType.Str, GetDurationForSpell(1));

				m.FixedParticles( 0x375A, 10, 15, 5017, EffectLayer.Waist );
				m.PlaySound( 0x1EE );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private ForceSpell m_Owner;

            public InternalTarget(ForceSpell owner)
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