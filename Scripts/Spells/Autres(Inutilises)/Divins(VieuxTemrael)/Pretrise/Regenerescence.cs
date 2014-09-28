using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class RegenerescenceSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_RegenerescenceTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly SpellInfo m_Info = new SpellInfo(
                "Regenerescence", "Toki Otil",
                SpellCircle.Eighth,
                212,
                9041
            );

        public RegenerescenceSpell(Mobile caster, Item scroll)
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

                m_RegenerescenceTable[m] = 1 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 800);

                Timer t = new RegenerescenceTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14217, 10, 20, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(508);
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
                m_RegenerescenceTable.Remove(m);

                m.FixedParticles(14217, 10, 20, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(508);
            }
        }

        public class RegenerescenceTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public RegenerescenceTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && RegenerescenceSpell.m_RegenerescenceTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    RegenerescenceSpell.m_RegenerescenceTable.Remove(m_target);
                    RegenerescenceSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14217, 10, 20, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(508);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private RegenerescenceSpell m_Owner;

            public InternalTarget(RegenerescenceSpell owner)
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