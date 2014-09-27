using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class EchoSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_EchoTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Écho", "Tyros Desu",
                SpellCircle.Fifth,
                212,
                9041
            );

        public EchoSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

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

                TimeSpan duration = GetDurationForSpell(2);

                m_EchoTable[m] = 2 + (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 25;

                Timer t = new EchoTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(964);
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
                m_EchoTable.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(964);
            }
        }

        public class EchoTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public EchoTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && EchoSpell.m_EchoTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    EchoSpell.m_EchoTable.Remove(m_target);
                    EchoSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(964);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private EchoSpell m_Owner;

            public InternalTarget(EchoSpell owner)
                : base(12, false, TargetFlags.Beneficial)
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

        public class EchoDelayTimer : Timer
        {
            private Mobile mobile;

            public EchoDelayTimer(Mobile m, TimeSpan delay)
                : base(delay)
            {
                mobile = m;
            }

            protected override void OnTick()
            {
                if (mobile != null && !mobile.Deleted)
                {
                    m_EchoTable.Remove(mobile);
                    m_Timers.Remove(mobile);

                    /*if (mobile is BaseCreature)
                        ((BaseCreature)mobile).m_EchoDelayTimer = null;

                    if (mobile is TMobile)
                        ((TMobile)mobile).m_EchoDelayTimer = null;*/

                    mobile.RevealingAction();

                    Stop();
                }
            }
        }
    }
}