using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class HalenePutrideSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_HalenePutrideTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Halene Putride", "Desu Kano Ehwa Lagu",
                5,
                212,
                9041
            );

        public HalenePutrideSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = TimeSpan.FromSeconds(0);

                m_HalenePutrideTable[m] = 0.10 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 400); // 10 à 55%

                Timer t = new HalenePutrideTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                Effects.SendTargetParticles(m,14138, 10, 15, 5013, 137, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(481);
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
                m_HalenePutrideTable.Remove(m);

                Effects.SendTargetParticles(m,14138, 10, 15, 5013, 137, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(481);
            }
        }

        public class HalenePutrideTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public HalenePutrideTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && HalenePutrideSpell.m_HalenePutrideTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    HalenePutrideSpell.m_HalenePutrideTable.Remove(m_target);
                    HalenePutrideSpell.m_Timers.Remove(m_target);

                    Effects.SendTargetParticles(m_target,14138, 10, 15, 5013, 137, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(481);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private HalenePutrideSpell m_Owner;

            public InternalTarget(HalenePutrideSpell owner)
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