using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class ExaltationSpell : ReligiousSpell
    {
        public static Hashtable m_ExaltationTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Exaltation", "Maga Otil",
                SpellCircle.Third,
                212,
                9041
            );

        public ExaltationSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(0.4);

                m_ExaltationTable[m] = (int)(10 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 6) + Utility.Random(1, 12)); 

                Timer t = new ExaltationTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14265, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(534);
            }

            FinishSequence();
        }

        public static void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_ExaltationTable.Remove(m);

                m.FixedParticles(14265, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(534);
            }
        }

        public class ExaltationTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public ExaltationTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && ExaltationSpell.m_ExaltationTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    ExaltationSpell.m_ExaltationTable.Remove(m_target);
                    ExaltationSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14265, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(534);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private ExaltationSpell m_Owner;

            public InternalTarget(ExaltationSpell owner)
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