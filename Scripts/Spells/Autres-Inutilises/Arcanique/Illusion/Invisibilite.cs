using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells
{
	public class InvisibiliteSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Invisibility", "An Lor Xen",
				5,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.Nightshade,
                Reagent.BlackPearl
            );

        public InvisibiliteSpell(Mobile caster, Item scroll)
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

                ToogleInvisibility(this, Caster, m);
			}

			FinishSequence();
		}

        public static void ToogleInvisibility(Spell spell, Mobile Caster, Mobile m)
        {
            Effects.SendLocationParticles(EffectItem.Create(new Point3D(m.X, m.Y, m.Z + 16), Caster.Map, EffectItem.DefaultDuration), 0x376A, 10, 15, 5045);
            m.PlaySound(0x3C4);

            m.Hidden = true;

            m.AllowedStealthSteps = 80;
            m.SendLocalizedMessage(502730); // You begin to move quietly.

            RemoveTimer(m);

            TimeSpan duration = TimeSpan.FromSeconds(0);

            Timer t = new InternalTimer(m, duration);

            m_Table[m] = t;

            t.Start();
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
                Priority = TimerPriority.TwoFiftyMS;
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
            private InvisibiliteSpell m_Owner;

            public InternalTarget(InvisibiliteSpell owner)
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