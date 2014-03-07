using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class SauvegardeMiracle : ReligiousSpell
    {
        public static Hashtable m_SauvegardeTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Sauvegarde", "",
                SpellCircle.Second,
                17,
                9041
            );

        public override int RequiredAptitudeValue { get { return 2; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Fanatisme }; } }

        public SauvegardeMiracle(Mobile caster, Item scroll)
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
                Caster.SendMessage("Vous ne pouvez pas vous cibler !");
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                StopTimer(m);

                TimeSpan duration = GetDurationForSpell(0.3);

                m_SauvegardeTable[m] = Caster;

                Timer t = new SauvegardeTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                ReligiousSpell.MiracleEffet(Caster, m, 14138, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet);

                //m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(1923);
            }

            FinishSequence();
        }

        public static void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_SauvegardeTable.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(1923);
            }
        }

        public class SauvegardeTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public SauvegardeTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && SauvegardeSpell.m_SauvegardeTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    SauvegardeSpell.m_SauvegardeTable.Remove(m_target);
                    SauvegardeSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(1923);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private SauvegardeMiracle m_Owner;

            public InternalTarget(SauvegardeMiracle owner)
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