using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class ArmureMagiqueSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		private static SpellInfo m_Info = new SpellInfo(
                "Armure Magique", "In Jux Sanct",
				SpellCircle.Seventh,
				242,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

        public ArmureMagiqueSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

        public static void ToogleMagicReflect(Spell spell, Mobile Caster, Mobile m)
        {
            double value = 10 + Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Thaumaturgie].Value;
            value /= 1.5;

            value += Caster.Skills[SkillName.Soins].Value * 0.4;

            value = SpellHelper.AdjustValue(Caster, value);

            if (value < 0)
                value = 1;
            else if (value > 250)
                value = 250;

            m.MagicDamageAbsorb = (int)value;

            m.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);
            m.PlaySound(0x1E9);
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
                ToogleMagicReflect(this, Caster, m);
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private ArmureMagiqueSpell m_Owner;

            public InternalTarget(ArmureMagiqueSpell owner)
                : base(12, true, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                    m_Owner.Target((Mobile)o);
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
	}
}
