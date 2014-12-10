using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Network;

namespace Server.Spells
{
    public class SecoursSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static ArrayList m_Registry = new ArrayList();
        public static ArrayList Registry { get { return m_Registry; } }

        public static readonly new SpellInfo Info = new SpellInfo(
                "Secours", "Por Tym",
                5,
                242,
                9012,
                Reagent.Garlic,
                Reagent.MandrakeRoot,
                Reagent.SulfurousAsh
            );

        public SecoursSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
        {
        }

        public static Hashtable m_Table = new Hashtable();

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckBSequence(m))
            {
                ToogleReflect(this, Caster, m);
            }

            FinishSequence();
        }

        public static void UnToogleReflect(Mobile target)
        {
            if (target == null || target.Deleted)
                return;

            if (m_Registry.Contains(target))
            {
                target.PlaySound(0x1ED);
                target.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);

                m_Registry.Remove(target);
            }
        }

        public static void ToogleReflect(Spell spell, Mobile caster, Mobile target)
        {
            if (!m_Registry.Contains(target))
            {
                target.PlaySound(0x1E9);
                target.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);

                m_Registry.Add(target);

                TimeSpan duration = TimeSpan.FromSeconds(0);

                new InternalTimer(target, duration).Start();
            }
            else
            {
                caster.SendMessage(0, "Le sort est déjà effectif sur : " + target.Name);
            }
        }

        public class InternalTarget : Target
        {
            private SecoursSpell m_Owner;

            public InternalTarget(SecoursSpell owner)
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

        private class InternalTimer : Timer
        {
            private Mobile m_Caster;

            public InternalTimer(Mobile caster, TimeSpan duration)
                : base(duration)
            {
                m_Caster = caster;

                Priority = TimerPriority.TwoFiftyMS;
            }

            protected override void OnTick()
            {
                if (m_Caster == null || m_Caster.Deleted)
                    return;

                if (Registry.Contains(m_Caster))
                {
                    m_Caster.PlaySound(0x1ED);
                    m_Caster.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);

                   m_Registry.Remove(m_Caster);
                }
            }
        }
    }
}
