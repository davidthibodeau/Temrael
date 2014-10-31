using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class RepartitionSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_RepartitionTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

		public static readonly new SpellInfo Info = new SpellInfo(
                "Répartition", "Fehu Kano",
				1,
				212,
				9041
            );

        public RepartitionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (Caster == m)
            {
                Caster.SendMessage("Vous ne pouvez sûrement pas vous répartir !");
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                Timer a = (Timer)m_Timers[m];

                if (a != null)
                {
                    StopTimer(m);
                }
                else
                {
                    TimeSpan duration = GetDurationForSpell(1);

                    StopTimer(m);

                    RepartitionInfo info = new RepartitionInfo(Caster, 0.1 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 400));

                    m_RepartitionTable[m] = info;

                    Timer t = new RepartitionTimer(m, DateTime.Now + duration);
                    m_Timers[m] = t;
                    t.Start();
                }

                m.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(493);
            }

            FinishSequence();
        }

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_RepartitionTable.Remove(m);

                m.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(493);
            }
        }

        public class RepartitionTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public RepartitionTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && RepartitionSpell.m_RepartitionTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    RepartitionSpell.m_RepartitionTable.Remove(m_target);
                    RepartitionSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(493);

                    Stop();
                }
            }
        }

		private class InternalTarget : Target
		{
            private RepartitionSpell m_Owner;

            public InternalTarget(RepartitionSpell owner)
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

    public class RepartitionInfo
    {
        private Mobile m_Caster;
        private double m_Percent;

        public Mobile Caster
        {
            get { return m_Caster; }
            set { m_Caster = value; }
        }

        public double Percent
        {
            get { return m_Percent; }
            set { m_Percent = value; }
        }

        public RepartitionInfo(Mobile caster, double percent)
        {
            Caster = caster;
            Percent = percent;
        }
    }
}