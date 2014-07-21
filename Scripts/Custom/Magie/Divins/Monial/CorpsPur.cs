using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class CorpsPurSpell : ReligiousSpell
    {
        public static Hashtable m_CorpsPurTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Corps Pur", "Lagu Sowi Ehwa",
                SpellCircle.Fifth,
                212,
                9041
            );

        public CorpsPurSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(1);

                m_CorpsPurTable[m] = 1.10 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 800); //10 à 35%

                Timer t = new CorpsPurTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 10, 20, 5013, 2042, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
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
                m_CorpsPurTable.Remove(m);

                m.FixedParticles(14170, 10, 20, 5013, 2042, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(493);
            }
        }

        public class CorpsPurTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public CorpsPurTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && CorpsPurSpell.m_CorpsPurTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    CorpsPurSpell.m_CorpsPurTable.Remove(m_target);
                    CorpsPurSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 20, 5013, 2042, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(493);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private CorpsPurSpell m_Owner;

            public InternalTarget(CorpsPurSpell owner)
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