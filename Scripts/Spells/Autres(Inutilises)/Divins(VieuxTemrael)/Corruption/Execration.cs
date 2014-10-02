using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class ExecrationSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_ExecrationTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Exécration", "Desu Sowi",
                SpellCircle.Fourth,
                212,
                9041
            );

        public ExecrationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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

                TimeSpan duration = GetDurationForSpell(0.3);

                m_ExecrationTable[m] = 0.10 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 500); // 10 à 50%

                Timer t = new ExecrationTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14201, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(508);
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
                m_ExecrationTable.Remove(m);

                m.FixedParticles(14201, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(508);
            }
        }

        public class ExecrationTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public ExecrationTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && ExecrationSpell.m_ExecrationTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    ExecrationSpell.m_ExecrationTable.Remove(m_target);
                    ExecrationSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14201, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(508);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private ExecrationSpell m_Owner;

            public InternalTarget(ExecrationSpell owner)
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
    }
}