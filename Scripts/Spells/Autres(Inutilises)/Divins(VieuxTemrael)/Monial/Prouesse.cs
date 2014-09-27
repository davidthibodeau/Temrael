using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class ProuesseSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_ProuesseTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Prouesse", "Sowi Toki Berk",
                SpellCircle.Eighth,
                212,
                9041
            );

        public ProuesseSpell(Mobile caster, Item scroll)
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

                m_ProuesseTable[m] = 1.10 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 1000); // 10 à 30%

                Timer t = new ProuesseTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 10, 20, 5013, 2407, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
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
                m_ProuesseTable.Remove(m);

                m.FixedParticles(14170, 10, 20, 5013, 2407, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(493);
            }
        }

        public class ProuesseTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public ProuesseTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && ProuesseSpell.m_ProuesseTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    ProuesseSpell.m_ProuesseTable.Remove(m_target);
                    ProuesseSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 20, 5013, 2407, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(493);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private ProuesseSpell m_Owner;

            public InternalTarget(ProuesseSpell owner)
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