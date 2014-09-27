using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class PourrissementSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_PourrissementTable = new Hashtable();
        public static Hashtable m_PourrissementRegistry = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Pourrissement", "Thur Ghua Desu",
                SpellCircle.Eighth,
                212,
                9041
            );

        public PourrissementSpell(Mobile caster, Item scroll)
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

                m_PourrissementTable[m] = (Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 1.5;
                m_PourrissementRegistry[m] = Caster;

                Timer t = new PourrissementTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14120, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(484);
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
                m_PourrissementTable.Remove(m);
                m_PourrissementRegistry.Remove(m);

                m.FixedParticles(14120, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(484);
            }
        }

        public class PourrissementTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public PourrissementTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && PourrissementSpell.m_PourrissementTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    PourrissementSpell.m_PourrissementTable.Remove(m_target);
                    PourrissementSpell.m_PourrissementRegistry.Remove(m_target);
                    PourrissementSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14120, 10, 15, 5013, 264, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(484);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private PourrissementSpell m_Owner;

            public InternalTarget(PourrissementSpell owner)
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