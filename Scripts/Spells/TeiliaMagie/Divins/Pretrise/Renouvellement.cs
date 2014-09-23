using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class RenouvellementSpell : ReligiousSpell
    {
        public static Hashtable m_RenouvellementTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Renouvellement", "Otil Fehu Algi",
                SpellCircle.Third,
                212,
                9041
            );

        public RenouvellementSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(0.3);

                m_RenouvellementTable[m] = (int)(Utility.Random(1, 10) + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 20));

                Timer t = new RenouvellementTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(482);
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
                m_RenouvellementTable.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(482);
            }
        }

        public class RenouvellementTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public RenouvellementTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && RenouvellementSpell.m_RenouvellementTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    RenouvellementSpell.m_RenouvellementTable.Remove(m_target);
                    RenouvellementSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(482);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private RenouvellementSpell m_Owner;

            public InternalTarget(RenouvellementSpell owner)
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