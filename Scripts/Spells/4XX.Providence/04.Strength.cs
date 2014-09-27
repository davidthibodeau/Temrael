using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class StrengthSpell : Spell
	{
        public static int m_SpellID { get { return 404; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCast = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Force", "Uus Mani",
				SpellCircle.First,
				212,
				9061,
                s_ManaCost,
                s_DureeCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.MandrakeRoot,
				Reagent.Nightshade
            );

		public StrengthSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.AddStatBonus( Caster, m, StatType.Str );

				m.FixedParticles( 0x375A, 10, 15, 5017, EffectLayer.Waist );
				m.PlaySound( 0x1EE );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private StrengthSpell m_Owner;

			public InternalTarget( StrengthSpell owner ) : base( 12, false, TargetFlags.Beneficial )
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