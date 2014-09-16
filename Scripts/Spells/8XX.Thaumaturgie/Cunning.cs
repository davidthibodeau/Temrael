using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class CunningSpell : Spell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_Duree = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Ruse", "Uus Wis",
				SpellCircle.Second,
				212,
				9061,
                s_ManaCost,
                s_Duree,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.MandrakeRoot,
				Reagent.Nightshade);

		public CunningSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.AddStatBonus( Caster, m, StatType.Int );

				m.FixedParticles( 0x375A, 10, 15, 5011, EffectLayer.Head );
				m.PlaySound( 0x1EB );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private CunningSpell m_Owner;

			public InternalTarget( CunningSpell owner ) : base( 12, false, TargetFlags.Beneficial )
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