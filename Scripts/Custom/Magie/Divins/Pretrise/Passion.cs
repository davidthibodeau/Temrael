using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class PassionSpell : ReligiousSpell
    {
        public static Hashtable m_PassionTable = new Hashtable();
        public static Hashtable m_LinkTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Passion", "Toki Kano",
                SpellCircle.Seventh,
                212,
                9041
            );

        public override int RequiredAptitudeValue { get { return 5; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] { Aptitude.Benedictions }; } }

        public PassionSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(0.4);

                int val = (int)(10 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10));

                if ((Caster.HitsMax - val) < 50)
                    val = Caster.HitsMax - 50;

                if (val > 0)
                {
                    m_PassionTable[m] = val;
                    m_PassionTable[Caster] = -1 * val;
                    m_LinkTable[m] = Caster;
                    m_LinkTable[Caster] = m;

                    Caster.FixedParticles(14154, 10, 15, 5013, 1942, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m.FixedParticles(14154, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m.PlaySound(486);
                    m.InvalidateProperties();
                    Caster.InvalidateProperties();

                    m.Hits -= 1;
                    Caster.Hits -= 1;

                    Timer t = new PassionTimer(m, DateTime.Now + duration);
                    m_Timers[m] = t;
                    t.Start();

                    m.CheckStatTimers();
                    m.Delta(MobileDelta.Hits);
                }
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
                m_PassionTable.Remove(m);

                //Si on a un caster ou un target qui possède la modification, on le retire aussi.
                if (m_LinkTable.Contains(m))
                {
                    StopTimer((Mobile)m_LinkTable[m]);
                    m_LinkTable.Remove(m);
                }

                m.CheckStatTimers();
                m.Delta(MobileDelta.Hits);
                m.InvalidateProperties();

                m.Hits -= 1;

                m.FixedParticles(14154, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(486);
            }
        }

        public class PassionTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public PassionTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && PassionSpell.m_PassionTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    PassionSpell.m_PassionTable.Remove(m_target);
                    PassionSpell.m_Timers.Remove(m_target);

                    //Si on a un caster ou un target qui possède la modification, on le retire aussi.
                    if (PassionSpell.m_LinkTable.Contains(m_target))
                    {
                        PassionSpell.StopTimer((Mobile)m_LinkTable[m_target]);
                        PassionSpell.m_LinkTable.Remove(m_target);
                    }

                    m_target.CheckStatTimers();
                    m_target.Delta(MobileDelta.Hits);
                    m_target.InvalidateProperties();

                    m_target.Hits -= 1;

                    m_target.FixedParticles(14154, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(486);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private PassionSpell m_Owner;

            public InternalTarget(PassionSpell owner)
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