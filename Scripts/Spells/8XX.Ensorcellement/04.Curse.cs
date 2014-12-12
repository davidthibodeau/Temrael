using System;
using System.Collections;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
	public class CurseSpell : Spell
	{
        public static int m_SpellID { get { return 804; } } // TOCHANGE

        private static short s_Cercle = 4;
        private static short durationMax = 180;
        private static short malusMax = 15;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Malediction", "Des Sanct",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(3),
                SkillName.Ensorcellement,
				Reagent.Nightshade,
				Reagent.Garlic,
				Reagent.SulfurousAsh
            );

		public CurseSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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

                SpellHelper.AddStatCurse(Caster, m, StatType.Str, malus, duration); SpellHelper.DisableSkillCheck = true;
                SpellHelper.AddStatCurse(Caster, m, StatType.Dex, malus, duration);
                SpellHelper.AddStatCurse(Caster, m, StatType.Int, malus, duration); SpellHelper.DisableSkillCheck = false;

				if ( m.Spell != null )
					m.Spell.OnCasterHurt();

				m.Paralyzed = false;

				m.FixedParticles( 0x374A, 10, 15, 5028, EffectLayer.Waist );
				m.PlaySound( 0x1EA );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private CurseSpell m_Owner;

			public InternalTarget( CurseSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}