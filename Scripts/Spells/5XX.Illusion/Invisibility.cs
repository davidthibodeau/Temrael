using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class InvisibilitySpell : Spell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_Duree = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Invisibilit�", "An Lor Xen",
				SpellCircle.Eighth,
				206,
				9002,
                s_ManaCost,
                s_Duree,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Bloodmoss,
				Reagent.Nightshade
            );

		public InvisibilitySpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				Effects.SendLocationParticles( EffectItem.Create( new Point3D( m.X, m.Y, m.Z + 16 ), Caster.Map, EffectItem.DefaultDuration ), 0x376A, 10, 15, 5045 );
				m.PlaySound( 0x3C4 );

				m.Hidden = true;

				RemoveTimer( m );

                double duration = ((120 * Caster.Skills[SkillName.Hallucination].Value) / 50) + 1;

                duration = SpellHelper.AdjustValue(Caster, duration);
                
				Timer t = new InternalTimer( m, TimeSpan.FromSeconds(duration) );

				m_Table[m] = t;

				t.Start();
			}

			FinishSequence();
		}

		public static Hashtable m_Table = new Hashtable();

		public static bool HasTimer( Mobile m )
		{
			return m_Table[m] != null;
		}

		public static void RemoveTimer( Mobile m )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
			{
				t.Stop();
				m_Table.Remove( m );
			}
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile;

			public InternalTimer( Mobile m, TimeSpan duration ) : base( duration )
			{
				Priority = TimerPriority.OneSecond;
				m_Mobile = m;
			}

			protected override void OnTick()
			{
				m_Mobile.RevealingAction();
				RemoveTimer( m_Mobile );
			}
		}

		public class InternalTarget : Target
		{
			private InvisibilitySpell m_Owner;

			public InternalTarget( InvisibilitySpell owner ) : base( 12, false, TargetFlags.Beneficial )
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