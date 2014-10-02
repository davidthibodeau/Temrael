using System;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;
using System.Collections;

namespace Server.Spells
{
    public class MalaiseSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Malaise", "Des Ex Sanct",
				SpellCircle.Fourth,
				224,
				9061,
				Reagent.Garlic,
				Reagent.SulfurousAsh,
                Reagent.Ginseng
			);

		public MalaiseSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

        private static Hashtable m_Timers = new Hashtable();

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
                TimeSpan duration = GetDurationForSpell(0.1);
                DateTime endtime = DateTime.Now + duration;

                SpellHelper.Turn(Caster, m);

                SpellHelper.CheckReflect((int)this.Circle, Caster, ref m);

                StopTimer(m);

                Timer m_Timer = new InternalTimer(endtime, m);

                m_Timers[m] = m_Timer;

                m_Timer.Start();
			}

			FinishSequence();
		}

        public static bool StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
            }

            return (t != null);
        }

        private class InternalTimer : Timer
        {
            private Mobile m_target;
            private DateTime ending;

            public InternalTimer(DateTime endtime, Mobile target)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                ending = endtime;
                m_target = target;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_target == null || m_target.Deleted)
                    return;

                if (DateTime.Now >= ending)
                {
                    Stop();
                }
                else
                {
                    m_target.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
                    m_target.PlaySound(22);
                    m_target.Stam -= 2;

                    if(m_target is TMobile)
                        ((TMobile)m_target).Fatigue += 2;
                }
            }
        }

		public class InternalTarget : Target
		{
            private MalaiseSpell m_Owner;

            public InternalTarget(MalaiseSpell owner)
                : base(12, false, TargetFlags.Harmful)
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