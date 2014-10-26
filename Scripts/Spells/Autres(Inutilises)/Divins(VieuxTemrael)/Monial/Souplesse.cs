using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class SouplesseSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_SouplesseTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Souplesse", "Sowi Toki",
                SpellCircle.Fourth,
                212,
                9041
            );

        public SouplesseSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(0.4);

                m_SouplesseTable[m] = 1.10 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 400); // 10 à 60%

                Timer t = new SouplesseTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14186, 10, 20, 5013, 2077, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(501);
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
                m_SouplesseTable.Remove(m);

                m.FixedParticles(14186, 10, 20, 5013, 2077, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(501);
            }
        }

        public class SouplesseTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public SouplesseTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && SouplesseSpell.m_SouplesseTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    SouplesseSpell.m_SouplesseTable.Remove(m_target);
                    SouplesseSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14186, 10, 20, 5013, 2077, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(501);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private SouplesseSpell m_Owner;

            public InternalTarget(SouplesseSpell owner)
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