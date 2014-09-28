using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class PlumeSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_PlumeTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly SpellInfo m_Info = new SpellInfo(
                "Plume", "Toki Marc",
                SpellCircle.Second,
                212,
                9041
            );

        public PlumeSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(0.5);

                m_PlumeTable[m] = (int)(20 + (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 2);

                Timer t = new PlumeTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.InvalidateProperties();

                m.FixedParticles(14120, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(526);
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
                m_PlumeTable.Remove(m);

                m.InvalidateProperties();

                m.FixedParticles(14120, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(526);
            }
        }

        public class PlumeTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public PlumeTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && PlumeSpell.m_PlumeTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    PlumeSpell.m_PlumeTable.Remove(m_target);
                    PlumeSpell.m_Timers.Remove(m_target);
                    m_target.InvalidateProperties();

                    m_target.FixedParticles(14120, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(526);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private PlumeSpell m_Owner;

            public InternalTarget(PlumeSpell owner)
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