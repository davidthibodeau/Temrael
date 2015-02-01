using System;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Spells
{
	public class FireElementalSpell : Spell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 0;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Elemental de Feu", "Kal Vas Xen Flam",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
            );

		public FireElementalSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
				return false;

			if ( (Caster.Followers + 4) > Caster.FollowersMax )
			{
				Caster.SendLocalizedMessage( 1049645 ); // You have too many followers to summon that creature.
				return false;
			}

			return true;
		}

		public override void OnCast()
		{
			if ( CheckSequence() )
            {
                double duration = (2 * Caster.Skills.Immuabilite.Fixed) / 5;

                //SpellHelper.Summon(new FireElemental(), Caster, 0x217, TimeSpan.FromSeconds(duration), true, true);
			}

			FinishSequence();
        }

        public override TimeSpan GetCastDelay()
        {
            return base.GetCastDelay() + TimeSpan.FromSeconds(4.0);
        }
	}
}