using System;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
    public class RepasCelesteMiracle : ReligiousSpell
    {
        private static SpellInfo m_Info = new SpellInfo(
                "Repas Celeste", "",
                SpellCircle.First,
                17,
                9041
            );

        public RepasCelesteMiracle(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public override bool DelayedDamage { get { return false; } }

        public void Target(TMobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckSequence())
            {
                SpellHelper.Turn(Caster, m);

                m.Hunger += 1 + (int)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10); // 1 à 21
                m.Thirst += 1 + (int)((Caster.Skills[CastSkill].Value + Caster.Skills[DamageSkill].Value) / 10); // 1 à 21

                if (m.Hunger > 20)
                    m.Hunger = 20;

                if (m.Thirst > 20)
                    m.Thirst = 20;

                m.FixedParticles(14170, 10, 20, 5013, 2010, 0, EffectLayer.Head); //ID, speed, dura, effect, hue, render, layer
                m.PlaySound(586);
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private RepasCelesteMiracle m_Owner;

            public InternalTarget(RepasCelesteMiracle owner)
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
                    from.SendMessage("Vous ne pouvez cibler que les joueurs !");
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}