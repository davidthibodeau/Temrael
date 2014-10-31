using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class VehemenceMiracle : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_VehemencetTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Vehemence", "",
                3,
                17,
                9041
            );

        public VehemenceMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public override void OnCast()
        {
            if (CheckSequence())
            {
                StopTimer(Caster);

                TimeSpan duration = GetDurationForSpell(0.3);

                m_VehemencetTable[Caster] = (int)(Utility.Random(1, 10) + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 20));

                Timer t = new VehemenceTimer(Caster, DateTime.Now + duration);
                m_Timers[Caster] = t;
                t.Start();

                Caster.FixedParticles(14170, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                Caster.PlaySound(482);
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
                m_VehemencetTable.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(482);
            }
        }

        public class VehemenceTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public VehemenceTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && RenouvellementSpell.m_RenouvellementTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    RenouvellementSpell.m_RenouvellementTable.Remove(m_target);
                    RenouvellementSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 1437, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(482);

                    Stop();
                }
            }
        }
    }
}