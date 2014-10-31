using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class SoifDuCombatSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_SoifDuCombatTable = new Hashtable();
        public static Hashtable m_SoifDuCombatRegistry = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Soif Du Combat", "Perth Sowi Toki",
                8,
                212,
                9041
            );

        public SoifDuCombatSpell(Mobile caster, Item scroll)
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

                m_SoifDuCombatTable[m] = 1.60 + (double)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 1000); //60 à 110%
                m_SoifDuCombatRegistry[m] = DateTime.Now + TimeSpan.FromSeconds(20);

                Timer t = new SoifDuCombatTimer(m);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(506);
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
                m_SoifDuCombatTable.Remove(m);
                m_SoifDuCombatRegistry.Remove(m);

                m.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(506);
            }
        }

        public class SoifDuCombatTimer : Timer
        {
            private Mobile m_target;

            public SoifDuCombatTimer(Mobile target)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(1))
            {
                m_target = target;

                Priority = TimerPriority.TwentyFiveMS;
            }

            protected override void OnTick()
            {
                DateTime endtime = (DateTime)m_SoifDuCombatRegistry[m_target];

                if (DateTime.Now >= endtime || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    SoifDuCombatSpell.m_SoifDuCombatTable.Remove(m_target);
                    SoifDuCombatSpell.m_Timers.Remove(m_target);
                    SoifDuCombatSpell.m_SoifDuCombatRegistry.Remove(m_target);

                    m_target.FixedParticles(14170, 10, 15, 5013, 44, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(506);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private SoifDuCombatSpell m_Owner;

            public InternalTarget(SoifDuCombatSpell owner)
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