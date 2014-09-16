using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class PenaceeMiracle : ReligiousSpell
    {
        public static int spellID { get { return 0; } } // TOCHANGE

        private static SpellInfo m_Info = new SpellInfo(
                "Penacée", "",
                SpellCircle.Third,
                17,
                9061
            );

        public PenaceeMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

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
                SpellHelper.Turn(Caster, m);

                Poison p = m.Poison;

                if (p != null)
                {
                    double chanceToCure = 10000 + (int)(Caster.Skills[SkillName.Miracles].Value * 75) - ((p.Level + 1) * 2500);
                    chanceToCure /= 100;

                    chanceToCure = SpellHelper.AdjustValue(Caster, chanceToCure);

                    if ((int)chanceToCure > Utility.Random(100))
                    {
                        if (m.CurePoison(Caster))
                        {
                            if (Caster != m)
                                Caster.SendLocalizedMessage(1010058); // You have cured the target of all poisons!

                            m.SendLocalizedMessage(1010059); // You have been cured of all poisons.
                        }
                    }
                    else
                    {
                        m.SendLocalizedMessage(1010060); // You have failed to cure your target!
                    }
                }

                m.FixedParticles(0x373A, 10, 15, 5012, EffectLayer.Waist);
                m.PlaySound(0x1E0);
            }

            FinishSequence();
        }

        public class InternalTarget : Target
        {
            private PenaceeMiracle m_Owner;

            public InternalTarget(PenaceeMiracle owner)
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