using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class VampiricEmbraceSpell : TransformationSpell
	{
        public static int spellID { get { return 0; } } // TOCHANGE

        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;
        private static TimeSpan s_Duree = TimeSpan.FromSeconds(1);

		private static SpellInfo m_Info = new SpellInfo(
				"Vampirisme", "Rel Xen An Sanct",
				SpellCircle.Fifth,
				203,
				9031,
                s_ManaCost,
                s_Duree,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.BatWing,
				Reagent.NoxCrystal,
				Reagent.PigIron
            );

        //public override int Body { get { return 153; } }
        //public override int Hue { get { return 0x4001; } }
        public override int Body { get { return 100; } }
        public override int IntOffset { get { return 50; } }

		public VampiricEmbraceSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void PlayEffect( Mobile m )
		{
			Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x373A, 1, 17, 1108, 7, 9914, 0 );
			Effects.SendLocationParticles( EffectItem.Create( m.Location, m.Map, EffectItem.DefaultDuration ), 0x376A, 1, 22, 67, 7, 9502, 0 );
			Effects.PlaySound( m.Location, m.Map, 0x4B1 );
		}
	}
}