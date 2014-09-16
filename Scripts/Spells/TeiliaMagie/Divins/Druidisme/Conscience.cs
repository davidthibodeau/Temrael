using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class ConscienceSpell : ReligiousSpell
    {
        public static Hashtable m_ConscienceTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Conscience", "Tyros Impa",
                SpellCircle.First,
                212,
                9041
            );

        public ConscienceSpell(Mobile caster, Item scroll)
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

                m_ConscienceTable[m] = 0.02 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 4000); //2 à 7% par joueur.

                Timer t = new ConscienceTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14276, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(527);
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
                m_ConscienceTable.Remove(m);

                m.FixedParticles(14276, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(527);
            }
        }

        public class ConscienceTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public ConscienceTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && ConscienceSpell.m_ConscienceTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    ConscienceSpell.m_ConscienceTable.Remove(m_target);
                    ConscienceSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14276, 10, 20, 5013, 1441, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(527);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private ConscienceSpell m_Owner;

            public InternalTarget(ConscienceSpell owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile && from == o)
                {
                    m_Owner.Target((Mobile)o);
                }
                else
                    from.SendMessage("Vous ne pouvez cibler que vous-même !");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}