using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class ErranceSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_ErranceTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Errance", "Otal Tyr",
                SpellCircle.Third,
                212,
                9041
            );

        public ErranceSpell(Mobile caster, Item scroll)
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

                m_ErranceTable[m] = 25 - ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 20); //+1 à 5 HP à chaque 25...15 pas.

                Timer t = new ErranceTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14201, 10, 15, 5013, 1628, 0, EffectLayer.CenterFeet);
                m.PlaySound(529);
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
                m_ErranceTable.Remove(m);

                m.FixedParticles(14201, 10, 15, 5013, 1628, 0, EffectLayer.CenterFeet);
                m.PlaySound(529);
            }
        }

        public class ErranceTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public ErranceTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && ErranceSpell.m_ErranceTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    ErranceSpell.m_ErranceTable.Remove(m_target);
                    ErranceSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14201, 10, 15, 5013, 1628, 0, EffectLayer.CenterFeet);
                    m_target.PlaySound(529);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private ErranceSpell m_Owner;

            public InternalTarget(ErranceSpell owner)
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