using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class VampiricEmbraceSpell : TransformationSpell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 5;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Vampirisme", "Rel Xen An Sanct",
                s_Cercle,
				203,
				9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.BatWing,
				Reagent.NoxCrystal,
				Reagent.PigIron
            );

        //public override int Body { get { return 153; } }
        //public override int Hue { get { return 0x4001; } }
        public override int Body { get { return 100; } }
        public override int IntOffset { get { return 50; } }

		public VampiricEmbraceSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
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