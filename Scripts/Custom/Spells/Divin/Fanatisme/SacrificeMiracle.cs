using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class SacrificeMiracle : ReligiousSpell
    {
        public static Hashtable m_SacrificeTable = new Hashtable();
        public static Hashtable m_Timers = new Hashtable();

        private static SpellInfo m_Info = new SpellInfo(
                "Sacrifice", "",
                SpellCircle.First,
                17,
                9062
            );

        public override int RequiredAptitudeValue { get { return 1; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Fanatisme }; } }

        public SacrificeMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        private static int[] m_ManaTable = new int[] { 5, 5, 8, 8, 10, 10, 13, 13, 15, 15, 18, 20 };
        private static int[] m_ToLostTable = new int[] { 10, 12, 15, 17, 20, 22, 25, 27, 30, 35, 38, 40 };
        private static int[] m_ToGainTable = new int[] { 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60 };

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                int sacrifice = (int)(1 + ((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 300));

                if (sacrifice < 0)
                    sacrifice = 0;
                else if (sacrifice > 12)
                    sacrifice = 12;

                int toLost, toGain;

                toLost = m_ToLostTable[sacrifice - 1] * 2;
                toGain = m_ToGainTable[sacrifice - 1] * 2;

                if (toLost >= Caster.Hits)
                {
                    Caster.SendMessage("Vous n'avez pas assez de point de vie.");
                }
                else
                {
                    SpellHelper.Turn(Caster, m);

                    Caster.Hits -= toLost;
                    m.Heal(toGain);
                    Caster.Mana -= m_ManaTable[sacrifice - 1];

                    Caster.FixedParticles(0x375A, 9, 20, 5016, EffectLayer.Waist);
                    m.FixedParticles(0x376A, 9, 32, 5005, EffectLayer.Waist);
                    Caster.PlaySound(0x0F5);
                }
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private SacrificeMiracle m_Owner;

            public InternalTarget(SacrificeMiracle owner)
                : base(12, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile && !(o == from))
                {
                    m_Owner.Target((Mobile)o);
                }
                else
                    from.SendMessage("Vous ne pouvez pas vous ciblez !");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}