using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class ExaltationMiracle : ReligiousSpell
    {
        public static Hashtable m_ExaltationTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Exaltation", "",
                SpellCircle.Fifth,
                17,
                9041
            );

        public override int RequiredAptitudeValue { get { return 5; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Benedictions }; } }

        public ExaltationMiracle(Mobile caster, Item scroll)
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
            else if (Caster == m)
            {
                Caster.SendMessage("La cible ne peut pas etre l'utilisateur du miracle !");
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                Timer a = (Timer)m_Timers[m];

                if (a != null)
                {
                    StopTimer(m);
                }
                else
                {
                    TimeSpan duration = GetDurationForSpell(1);

                    StopTimer(m);

                    ExaltationInfo info = new ExaltationInfo(Caster, 0.1 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 400));

                    m_ExaltationTable[m] = info;

                    Timer t = new ExaltationTimer(m, DateTime.Now + duration);
                    m_Timers[m] = t;
                    t.Start();
                }

                m.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
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
                m_ExaltationTable.Remove(m);

                m.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(493);
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
                if ((DateTime.Now >= endtime && RepartitionSpell.m_RepartitionTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    RepartitionSpell.m_RepartitionTable.Remove(m_target);
                    RepartitionSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(8902, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(493);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private ExaltationMiracle m_Owner;

            public InternalTarget(ExaltationMiracle owner)
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

    public class ExaltationInfo
    {
        private Mobile m_Caster;
        private double m_Percent;

        public Mobile Caster
        {
            get { return m_Caster; }
            set { m_Caster = value; }
        }

        public double Percent
        {
            get { return m_Percent; }
            set { m_Percent = value; }
        }

        public ExaltationInfo(Mobile caster, double percent)
        {
            Caster = caster;
            Percent = percent;
        }
    }
}