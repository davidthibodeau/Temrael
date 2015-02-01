using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class HorreurSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_HorreurTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Horreur", "Desu Algi Maga",
                7,
                212,
                9041
            );

        public HorreurSpell(Mobile caster, Item scroll)
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

                m_HorreurTable[m] = 1.05 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 800); // 5 à 30%

                Timer t = new HorreurTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                Effects.SendTargetParticles(m,7897, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(412);
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
                m_HorreurTable.Remove(m);

                Effects.SendTargetParticles(m,7897, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(412);
            }
        }

        public class HorreurTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public HorreurTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && HorreurSpell.m_HorreurTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    HorreurSpell.m_HorreurTable.Remove(m_target);
                    HorreurSpell.m_Timers.Remove(m_target);

                    Effects.SendTargetParticles(m_target,7897, 10, 15, 5013, 1109, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(412);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private HorreurSpell m_Owner;

            public InternalTarget(HorreurSpell owner)
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