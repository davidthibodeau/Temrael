using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Fifth
{
	public class MagicReflectSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Reflet", "In Jux Sanct",
				SpellCircle.Third,
				242,
				9012,
				Reagent.Garlic,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

		public MagicReflectSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override bool CheckCast()
		{
			if ( Caster.MagicDamageAbsorb > 0 )
			{
				Caster.SendLocalizedMessage( 1005559 ); // This spell is already in effect.
				return false;
			}
			else if ( !Caster.CanBeginAction( typeof( DefensiveSpell ) ) )
			{
				Caster.SendLocalizedMessage( 1005385 ); // The spell will not adhere to you at this time.
				return false;
			}

			return true;
		}

        public override void OnCast()
        {
            if (Caster.MagicDamageAbsorb > 0)
            {
                Caster.SendLocalizedMessage(1005559); // This spell is already in effect.
            }
            else if (!Caster.CanBeginAction(typeof(DefensiveSpell)))
            {
                Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
            }
            else if (CheckSequence())
            {
                if (Caster.BeginAction(typeof(DefensiveSpell)))
                {
                    double value = Caster.Skills[SkillName.Mysticisme].Value + Caster.Skills[SkillName.ArtMagique].Value;
                    value = 4 + (value / 300) * 7.0;//absorb from 4 to 15 "circles"

                    value = SpellHelper.AdjustValue(Caster, value);

                    Caster.MagicDamageAbsorb = (int)value;

                    Caster.FixedParticles(0x375A, 10, 15, 5037, EffectLayer.Waist);
                    Caster.PlaySound(0x1E9);
                }
                else
                {
                    Caster.SendLocalizedMessage(1005385); // The spell will not adhere to you at this time.
                }
            }

            FinishSequence();
        }
	}
}
