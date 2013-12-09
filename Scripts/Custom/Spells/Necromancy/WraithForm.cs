using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Necromancy
{
	public class WraithFormSpell : TransformationSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Spectre", "Rel Xen Um",
				SpellCircle.First,
				203,
				9031,
				Reagent.NoxCrystal,
				Reagent.PigIron
            );

        public override int RequiredAptitudeValue { get { return 1; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Necromancie }; } }

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