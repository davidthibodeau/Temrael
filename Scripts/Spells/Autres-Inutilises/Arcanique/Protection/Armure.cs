using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class ArmureSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Armure", "Flam Sanct",
				8,
				236,
				9011,
				Reagent.Garlic,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
            );

        public ArmureSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
		{
		}

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public static void ToogleArmure(Spell spell, Mobile Caster, Mobile m)
        {
            double value = 10 + Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Thaumaturgie].Value;
            value /= 1.5;

            value += Caster.Skills[SkillName.Soins].Value * 0.4;

            value = SpellHelper.AdjustValue(Caster, value);

            if (value < 0)
                value = 1;
            else if (value > 250)
                value = 250;

            m.MeleeDamageAbsorb = (int)value;

            Effects.SendTargetParticles(m,0x376A, 9, 32, 5008, EffectLayer.Waist);
            m.PlaySound(0x1F2);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (CheckBSequence(m))
            {
                ToogleArmure(this, Caster, m);
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private ArmureSpell m_Owner;

            public InternalTarget(ArmureSpell owner)
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