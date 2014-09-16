using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class FougueCelesteMiracle : ReligiousSpell
    {
        public static Hashtable m_FougueCelesteTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Fougue Céleste", "",
                SpellCircle.First,
                17,
                9041
            );

        public FougueCelesteMiracle(Mobile caster, Item scroll)
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

                m_FougueCelesteTable[m] = 0.02 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 4000); //2 à 7% par joueur.

                Timer t = new FougueCelesteTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                ReligiousSpell.MiracleEffet(m, m, 14154, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); 
                m.PlaySound(501);
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
                m_FougueCelesteTable.Remove(m);

                ReligiousSpell.MiracleEffet(m, m, 14154, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); 
                m.PlaySound(501);
            }
        }

        public class FougueCelesteTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public FougueCelesteTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && HautePrecisionSpell.m_HautePrecisionTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    HautePrecisionSpell.m_HautePrecisionTable.Remove(m_target);
                    HautePrecisionSpell.m_Timers.Remove(m_target);

                    ReligiousSpell.MiracleEffet(m_target, m_target, 14154, 10, 15, 5013, 0, 0, EffectLayer.CenterFeet); 
                    m_target.PlaySound(501);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private FougueCelesteMiracle m_Owner;

            public InternalTarget(FougueCelesteMiracle owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile && o == from)
                {
                    m_Owner.Target((Mobile)o);
                }
                else
                    from.SendMessage("Vous pouvez être la seule cible de ce sort !");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}