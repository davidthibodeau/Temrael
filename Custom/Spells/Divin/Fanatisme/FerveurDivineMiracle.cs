using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class FerveurDivineMiracle : ReligiousSpell
    {
        public static Hashtable m_FerveurDivineTable = new Hashtable();
        public static Hashtable m_FerveurDivineRegistry = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Ferveur Divine", "",
                SpellCircle.Third,
                17,
                9050
            );

        public override int RequiredAptitudeValue { get { return 3; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Fanatisme }; } }

        public FerveurDivineMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                m_FerveurDivineTable[Caster] = (int) (1.60 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 1000)); //60 à 110%
                m_FerveurDivineRegistry[Caster] = DateTime.Now + TimeSpan.FromSeconds(20);

                Timer t = new FerveurDivineTimer(Caster);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(506);
            }

            FinishSequence();
        }

        public override bool DelayedDamage { get { return false; } }

        public void StopTimer(Mobile m)
        {
            Timer t = (Timer)m_Timers[m];

            if (t != null)
            {
                t.Stop();
                m_Timers.Remove(m);
                m_FerveurDivineTable.Remove(m);
                m_FerveurDivineRegistry.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(506);
            }
        }

        public class FerveurDivineTimer : Timer
        {
            private Mobile m_target;

            public FerveurDivineTimer(Mobile target)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_target = target;

                Priority = TimerPriority.TwentyFiveMS;
            }

            protected override void OnTick()
            {
                DateTime endtime = (DateTime)m_FerveurDivineRegistry[m_target];

                if (endtime == null || DateTime.Now >= endtime || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    FerveurDivineMiracle.m_FerveurDivineTable.Remove(m_target);
                    FerveurDivineMiracle.m_Timers.Remove(m_target);
                    FerveurDivineMiracle.m_FerveurDivineRegistry.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(506);

                    Stop();
                }
            }
        }
    }
}