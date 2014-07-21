using System;
using System.Collections;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.First
{
	public class ReactiveArmorSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Armure Magique", "Flam Sanct",
				SpellCircle.Third,
				236,
				9011,
				Reagent.Garlic,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
            );

		public ReactiveArmorSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			/*if ( Caster.MeleeDamageAbsorb > 0 )
			{
				Caster.SendLocalizedMessage( 1005559 ); // This spell is already in effect.
				return false;
			}*/
			/*else if ( !Caster.CanBeginAction( typeof( DefensiveSpell ) ) )
			{
				Caster.SendLocalizedMessage( 1005385 ); // The spell will not adhere to you at this time.
				return false;
			}*/

			return true;
		}

		private static Hashtable m_Table = new Hashtable();

        public override void OnCast()
        {
            if (Caster is TMobile)
            {
                Caster.Target = new InternalTarget(this);
            }
            else
            {
                if (Caster.MeleeDamageAbsorb > 0)
                {
                    Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
                }
                /*    else if (!Caster.CanBeginAction(typeof(DefensiveSpell)))
                    {
                        Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
                    }*/
                else if (CheckSequence())
                {
                    // if (Caster.BeginAction(typeof(DefensiveSpell)))
                    //{
                        double value = Caster.Skills[SkillName.Restoration].Value + Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Concentration].Value;
                        value /= 3;

                        if (value < 0)
                            value = 1;
                        else if (value > 75)
                            value = 75;

                        value = SpellHelper.AdjustValue(Caster, value);

                        Caster.MeleeDamageAbsorb = (int)value;

                        Caster.FixedParticles(0x376A, 9, 32, 5008, EffectLayer.Waist);
                        Caster.PlaySound(0x1F2);
                    //}
                    /*  else
                      {
                          Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
                      }*/
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
                double value = Caster.Skills[SkillName.Restoration].Value + Caster.Skills[SkillName.ArtMagique].Value + Caster.Skills[SkillName.Concentration].Value;
                value /= 3;

                if (value < 0)
                    value = 1;
                else if (value > 75)
                    value = 75;

                value = SpellHelper.AdjustValue(Caster, value);

                m.MeleeDamageAbsorb = (int)value;

                m.FixedParticles(0x376A, 9, 32, 5008, EffectLayer.Waist);
                m.PlaySound(0x1F2);
            }

            FinishSequence();
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