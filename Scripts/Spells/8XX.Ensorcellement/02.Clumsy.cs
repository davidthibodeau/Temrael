using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class ClumsySpell : Spell
	{
        public static int m_SpellID { get { return 802; } } // TOCHANGE

        private static short s_Cercle = 1;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Maladroit", "Uus Jux",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(2),
                SkillName.Ensorcellement,
				Reagent.Bloodmoss,
				Reagent.Nightshade
            );

        private static short durationMax = 60;
        private static short malusMax = 15;

		public ClumsySpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                int malus = (int)(malusMax * GetSpellScaling(Caster, Info.skillForCasting));
                TimeSpan duration = TimeSpan.FromSeconds(durationMax * GetSpellScaling(Caster, Info.skillForCasting));

                SpellHelper.AddStatCurse(Caster, m, StatType.Dex, malus, duration); SpellHelper.DisableSkillCheck = true;

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				m.FixedParticles( 0x3779, 10, 15, 5002, EffectLayer.Head );
				m.PlaySound( 0x1DF );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ClumsySpell m_Owner;

			public InternalTarget( ClumsySpell owner ) : base( 12, false, TargetFlags.Harmful )
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