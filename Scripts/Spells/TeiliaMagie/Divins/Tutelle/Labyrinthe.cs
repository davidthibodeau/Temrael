using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class LabyrintheSpell : ReligiousSpell
    {
        public static Hashtable m_LabyrintheTable = new Hashtable();
        public static Hashtable m_LabyrintheRegistry = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Labyrinthe", "Furo Mann Marc",
                SpellCircle.Fourth,
                212,
                9041
            );

        public LabyrintheSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(TMobile m)
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

                m_LabyrintheTable[m] = (int)(25 - ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 15));
                m_LabyrintheRegistry[m] = m.Location;

                Timer t = new LabyrintheTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(516);
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
                m_LabyrintheTable.Remove(m);
                m_LabyrintheRegistry.Remove(m);

                m.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(516);
            }
        }

        public class LabyrintheTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public LabyrintheTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && LabyrintheSpell.m_LabyrintheTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    LabyrintheSpell.m_LabyrintheTable.Remove(m_target);
                    LabyrintheSpell.m_LabyrintheRegistry.Remove(m_target);
                    LabyrintheSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14201, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(516);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private LabyrintheSpell m_Owner;

            public InternalTarget(LabyrintheSpell owner)
                : base(12, false, TargetFlags.Harmful)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is TMobile)
                {
                    m_Owner.Target((TMobile)o);
                }
                else
                    from.SendMessage("Vous devez cibler un joueur !");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}