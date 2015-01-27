using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class WeakenSpell : Spell
	{
        public static int m_SpellID { get { return 801; } } // TOCHANGE

        private static short s_Cercle = 1;
        private static short durationMax = 180;
        private static short malusMax = 40;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Faiblesse", "Des Mani",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(2),
                SkillName.Ensorcellement,
				Reagent.Garlic,
				Reagent.Nightshade
            );

		public WeakenSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                int malus = (int)(malusMax * GetSpellScaling(Caster, SkillName.Providence));
                TimeSpan duration = TimeSpan.FromSeconds(durationMax * GetSpellScaling(Caster, SkillName.Providence));

                SpellHelper.AddStatCurse(Caster, m, StatType.Str, malus, duration); SpellHelper.DisableSkillCheck = true;

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
			private WeakenSpell m_Owner;

			public InternalTarget( WeakenSpell owner ) : base( 12, false, TargetFlags.Harmful )
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