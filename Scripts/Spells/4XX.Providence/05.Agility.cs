using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class AgilitySpell : Spell
	{
        public static int m_SpellID { get { return 405; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCastCast = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Agilité", "Ex Uus",
				SpellCircle.First,
				212,
				9061,
                s_ManaCost,
                s_DureeCastCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot
            );

		public AgilitySpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.AddStatBonus( Caster, m, StatType.Dex );

				m.FixedParticles( 0x375A, 10, 15, 5010, EffectLayer.Waist );
				m.PlaySound( 0x28E );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private AgilitySpell m_Owner;

			public InternalTarget( AgilitySpell owner ) : base( 12, false, TargetFlags.Beneficial )
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