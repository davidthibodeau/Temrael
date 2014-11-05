using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Spells
{
	public class MindRotSpell : NecromancerSpell
	{
        public static int m_SpellID { get { return 301; } } // TOCHANGE

        private static short s_Cercle = 1;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Pourriture", "Wis An Ben",
                s_Cercle,
				203,
				9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(3),
                SkillName.Alteration,
				Reagent.BatWing,
				Reagent.PigIron,
				Reagent.DaemonBlood
            );

		public MindRotSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( HasMindRotScalar( m ) )
			{
				Caster.SendLocalizedMessage( 1005559 ); // This spell is already in effect.
			}
			else if ( CheckHSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				/* Attempts to place a curse on the Target that increases the mana cost of any spells they cast,
				 * for a duration based off a comparison between the Caster's Spirit Speak skill and the Target's Resisting Spells skill.
				 * The effect lasts for ((Spirit Speak skill level - target's Resist Magic skill level) / 50 ) + 20 seconds.
				 */

				m.PlaySound( 0x1FB );
				m.PlaySound( 0x258 );
				m.FixedParticles( 0x373A, 1, 17, 9903, 15, 4, EffectLayer.Head );

                double duration = 10;

                double scalar = 1 + (Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Alteration].Value) / 8;

				if ( m.Player )
                    SetMindRotScalar(Caster, m, scalar, TimeSpan.FromSeconds(duration));
				else
                    SetMindRotScalar(Caster, m, scalar + 0.75, TimeSpan.FromSeconds(duration));
			}

			FinishSequence();
		}

		private static Hashtable m_Table = new Hashtable();

		public static void ClearMindRotScalar( Mobile m )
		{
			m_Table.Remove( m );
		}

		public static bool HasMindRotScalar( Mobile m )
		{
			return m_Table.Contains( m );
		}

		public static bool GetMindRotScalar( Mobile m, ref double scalar )
		{
			object obj = m_Table[m];

			if ( obj == null )
				return false;

			scalar = (double)obj;
			return true;
		}

		public static void SetMindRotScalar( Mobile caster, Mobile target, double scalar, TimeSpan duration )
		{
			m_Table[target] = scalar;
			new ExpireTimer( caster, target, duration ).Start();
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Caster;
			private Mobile m_Target;
			private DateTime m_End;

			public ExpireTimer( Mobile caster, Mobile target, TimeSpan delay ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Caster = caster;
				m_Target = target;
				m_End = DateTime.Now + delay;

				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				if ( m_Target.Deleted || !m_Target.Alive || DateTime.Now >= m_End )
				{
					m_Target.SendLocalizedMessage( 1060872 ); // Your mind feels normal again.
					ClearMindRotScalar( m_Target );
					Stop();
				}
			}
		}

		private class InternalTarget : Target
		{
			private MindRotSpell m_Owner;

			public InternalTarget( MindRotSpell owner ) : base( 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile) o );
				else
					from.SendLocalizedMessage( 1060508 ); // You can't curse that.
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}