using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class MortificationSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_Timers = new Hashtable();
        public static Hashtable m_MortificationTable = new Hashtable();

		public static readonly SpellInfo m_Info = new SpellInfo(
                "Mortification", "Algi Desu",
				SpellCircle.Second,
				236,
				9011
            );

        public MortificationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                StopTimer(m);

                TimeSpan duration = GetDurationForSpell(0.3);

                m_MortificationTable[m] = (int)(5 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 8)); // 10 à 50%

                Timer t = new MortificationTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 10, 15, 5013, 980, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(534);
            }
        }

        public static void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_MortificationTable.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 980, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(534);
            }
        }

        private class MortificationTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public MortificationTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && MortificationSpell.m_MortificationTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    MortificationSpell.m_MortificationTable.Remove(m_target);
                    MortificationSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14201, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(508);

                    Stop();
                }
            }
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        private class InternalTarget : Target
        {
            private MortificationSpell m_Owner;

            public InternalTarget(MortificationSpell owner)
                : base(12, true, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
	}
}
