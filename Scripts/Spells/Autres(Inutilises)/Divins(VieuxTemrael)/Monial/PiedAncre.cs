using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class PiedAncreSpell : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_PiedAncreTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Pied Ancré", "Tyros Sowi",
                1,
                212,
                9041
            );

        public PiedAncreSpell(Mobile caster, Item scroll)
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

                TimeSpan duration = TimeSpan.FromSeconds(0);

                m_PiedAncreTable[m] = (int)(5 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10)); //5 à 25%

                Timer t = new PiedAncreTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                m.FixedParticles(14154, 10, 20, 5013, 2063, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(487);
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
                m_PiedAncreTable.Remove(m);

                m.FixedParticles(14154, 10, 20, 5013, 2063, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(487);
            }
        }

        public class PiedAncreTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public PiedAncreTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && PiedAncreSpell.m_PiedAncreTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    PiedAncreSpell.m_PiedAncreTable.Remove(m_target);
                    PiedAncreSpell.m_Timers.Remove(m_target);

                    m_target.FixedParticles(14154, 10, 20, 5013, 2063, 0, EffectLayer.CenterFeet); //ID, speed, dura, effect, hue, render, layer
                    m_target.PlaySound(487);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private PiedAncreSpell m_Owner;

            public InternalTarget(PiedAncreSpell owner)
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