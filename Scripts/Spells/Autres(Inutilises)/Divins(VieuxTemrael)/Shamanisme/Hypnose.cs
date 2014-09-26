using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class HypnoseSpell : ReligiousSpell
    {
        public static Hashtable m_HypnoseTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Hypnose", "Desu Berk",
                SpellCircle.Fifth,
                212,
                9041
            );

        public HypnoseSpell(Mobile caster, Item scroll)
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

                m_HypnoseTable[m] = ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 15);

                Timer t = new HypnoseTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 10, 15, 5013, 1108, 0, EffectLayer.CenterFeet);
                m.PlaySound(516);
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
                m_HypnoseTable.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 1108, 0, EffectLayer.CenterFeet);
                m.PlaySound(516);
            }
        }

        public class HypnoseTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public HypnoseTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && HypnoseSpell.m_HypnoseTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    HypnoseSpell.m_HypnoseTable.Remove(m_target);
                    HypnoseSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 1108, 0, EffectLayer.CenterFeet);
                    m_target.PlaySound(516);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private HypnoseSpell m_Owner;

            public InternalTarget(HypnoseSpell owner)
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