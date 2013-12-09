using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class TranscendanceSpell : ReligiousSpell
    {
        public static Hashtable m_TranscendanceTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Transcendance", "Marc Sowi Toki",
                SpellCircle.Fifth,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 4; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Fanatisme }; } }

        public TranscendanceSpell(Mobile caster, Item scroll)
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

                m_TranscendanceTable[m] = 0.02 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 5000); //2 à 5% par tile à partir de 12 tiles

                Timer t = new TranscendanceTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14186, 10, 15, 5013, 2061, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(509);
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
                m_TranscendanceTable.Remove(m);

                m.FixedParticles(14186, 10, 15, 5013, 2061, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(509);
            }
        }

        public class TranscendanceTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public TranscendanceTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && TranscendanceSpell.m_TranscendanceTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    TranscendanceSpell.m_TranscendanceTable.Remove(m_target);
                    TranscendanceSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14186, 10, 15, 5013, 2061, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(509);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private TranscendanceSpell m_Owner;

            public InternalTarget(TranscendanceSpell owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile && from != o)
                {
                    m_Owner.Target((Mobile)o);
                }
                else
                    from.SendMessage("Vous ne pouvez pas vous cibler.");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}