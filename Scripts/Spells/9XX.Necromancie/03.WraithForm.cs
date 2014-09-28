using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class WraithFormSpell : TransformationSpell
	{
        public static int m_SpellID { get { return 903; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_DureeCastCast = TimeSpan.FromSeconds(1);

		public static readonly SpellInfo m_Info = new SpellInfo(
				"Spectre", "Rel Xen Um",
				SpellCircle.First,
				203,
				9031,
                s_ManaCost,
                s_DureeCastCast,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.NoxCrystal,
				Reagent.PigIron
            );

		public override int Body{ get{ return Caster.Female ? 84 : 26; } }
        public override int Hue { get { return 0; } }
        public override int IntOffset { get { return 5; } }

		public WraithFormSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void PlayEffect( Mobile m )
		{
			m.PlaySound( 0x17F );
			m.FixedParticles( 0x374A, 1, 15, 9902, 1108, 4, EffectLayer.Waist );
		}
	}
}