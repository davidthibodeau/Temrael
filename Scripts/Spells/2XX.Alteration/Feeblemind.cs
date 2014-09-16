using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class FeeblemindSpell : Spell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;

		private static SpellInfo m_Info = new SpellInfo(
                "Débilité", "Rel Wis",
				SpellCircle.Third,
				212,
				9031,
                s_ManaCost,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Ginseng,
				Reagent.Nightshade
            );

		public FeeblemindSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.AddStatCurse( Caster, m, StatType.Int );

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				m.FixedParticles( 0x3779, 10, 15, 5004, EffectLayer.Head );
				m.PlaySound( 0x1E4 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private FeeblemindSpell m_Owner;

			public InternalTarget( FeeblemindSpell owner ) : base( 12, false, TargetFlags.Harmful )
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