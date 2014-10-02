using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class VisionReelleSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_VisionReelleTable = new Hashtable();
        public static ArrayList m_VisionReelleRegistry = new ArrayList();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Vision Réelle", "Kena Mann",
                SpellCircle.Fifth,
                212,
                9041
            );

        public VisionReelleSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(0.3);

                m_VisionReelleTable[m] = Caster;
                m_VisionReelleRegistry.Add(m);
                m_VisionReelleRegistry.Add(Caster);

                if(m is TMobile)
                    ((TMobile)m).InvalidateMyRunUO();
                
                if(Caster is TMobile)
                    ((TMobile)Caster).InvalidateMyRunUO();

                Timer t = new VisionReelleTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(7897, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(483);
            }

            FinishSequence();
        }

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();

                Mobile caster = (Mobile)m_VisionReelleTable[m];

                m_Timers.Remove(m);
                m_VisionReelleTable.Remove(m);
                m_VisionReelleRegistry.Remove(m);

                if (caster != null)
                    m_VisionReelleRegistry.Remove(caster);

                m.FixedParticles(7897, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(483);
            }
        }

        public class VisionReelleTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public VisionReelleTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && VisionReelleSpell.m_VisionReelleTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    Mobile caster = (Mobile)m_VisionReelleTable[m_target];

                    VisionReelleSpell.m_VisionReelleTable.Remove(m_target);
                    VisionReelleSpell.m_Timers.Remove(m_target);
                    VisionReelleSpell.m_VisionReelleRegistry.Remove(m_target);

                    if (caster != null)
                        VisionReelleSpell.m_VisionReelleRegistry.Remove(caster);

                    m_target.FixedParticles(7897, 10, 15, 5013, 2042, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(483);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private VisionReelleSpell m_Owner;

            public InternalTarget(VisionReelleSpell owner)
                : base(12, false, TargetFlags.Beneficial)
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