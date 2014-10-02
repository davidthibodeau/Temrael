using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class FortificationDivineMiracle : ReligiousSpell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        public static Hashtable m_FortificationDivineTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        public static readonly new SpellInfo Info = new SpellInfo(
                "Fortification Divine", "",
                SpellCircle.Fifth,
                17,
                9041
            );

        public FortificationDivineMiracle(Mobile caster, Item scroll)
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

                TimeSpan duration = GetDurationForSpell(0.2);

                m_FortificationDivineTable[m] = Caster;

                Timer t = new FortificationDivineTimer(m, DateTime.Now + duration);
                m_Timers[m] = t;
                t.Start();

                ReligiousSpell.MiracleEffet(m, m, 14186, 10, 15, 5014, 0, 0, EffectLayer.Waist);
                m.PlaySound(490);
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
                m_FortificationDivineTable.Remove(m);

                m.FixedParticles(8902, 9, 18, 5005, EffectLayer.Waist);
                m.PlaySound(490);
            }
        }

        public class FortificationDivineTimer : Timer
        {
            private Mobile m_target;
            private DateTime endtime;

            public FortificationDivineTimer(Mobile target, DateTime end)
                : base(TimeSpan.Zero, TimeSpan.FromSeconds(2))
            {
                m_target = target;
                endtime = end;

                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                if ((DateTime.Now >= endtime && BouclierSpell.m_BouclierTable.Contains(m_target)) || m_target == null || m_target.Deleted || !m_target.Alive)
                {
                    BouclierSpell.m_BouclierTable.Remove(m_target);
                    BouclierSpell.m_Timers.Remove(m_target);

                    ReligiousSpell.MiracleEffet(m_target, m_target, 14186, 10, 15, 5014, 0, 0, EffectLayer.Waist);
                    m_target.PlaySound(490);

                    Stop();
                }
            }
        }

        private class InternalTarget : Target
        {
            private FortificationDivineMiracle m_Owner;

            public InternalTarget(FortificationDivineMiracle owner)
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
                    from.SendMessage("Vous ne pouvez cibler que vous-même avec ce sort.");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}