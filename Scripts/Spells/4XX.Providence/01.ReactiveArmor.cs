using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class ReactiveArmorSpell : Spell
	{
        private const int AmountBlock = 50; // Quantité de dégâts qui peuvent être bloqués par le spell à 100 prov, 100 artmagique.


        public static int m_SpellID { get { return 401; } } // TOCHANGE

        private static short s_Cercle = 1;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Armure Magique", "Flam Sanct",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(4),
                SkillName.Providence,
				Reagent.Garlic,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
            );

		public ReactiveArmorSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		private static Hashtable m_Table = new Hashtable();

        public override void OnCast()
        {
            if (Caster is PlayerMobile)
            {
                Caster.Target = new InternalTarget(this);
            }
            else if (Caster.MeleeDamageAbsorb > 0)
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
            }
            else
            {
                if (CheckSequence())
                {
                    DoEffect(Caster);
                }

                FinishSequence();
            }
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m))
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (m.MeleeDamageAbsorb > 0)
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
            }
            else if (CheckSequence())
            {
                DoEffect(m);
            }

            FinishSequence();
        }

        private void DoEffect(Mobile m)
        {
            double value = Caster.Skills[SkillName.Thaumaturgie].Value + Caster.Skills[SkillName.ArtMagique].Value * AmountBlock / 200;

            if (value < 0)
                value = 1;
            else if (value > AmountBlock)
                value = AmountBlock;

            m.MeleeDamageAbsorb = (int)value;

            m.FixedParticles(0x376A, 9, 32, 5008, EffectLayer.Waist);
            m.PlaySound(0x1F2);
        }

        private class InternalTarget : Target
        {
            private ReactiveArmorSpell m_Owner;

            public InternalTarget(ReactiveArmorSpell owner)
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