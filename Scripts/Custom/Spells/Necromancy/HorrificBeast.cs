using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Necromancy
{
	public class HorrificBeastSpell : TransformationSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Bête Horrifique", "Rel Xen Vas Bal",
				SpellCircle.Fifth,
				203,
				9031,
				Reagent.BatWing,
				Reagent.DaemonBlood
            );

        public override int RequiredAptitudeValue { get { return 5; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Necromancie }; } }

        public override int Body { get { return 73; } }
        public override int StrOffset { get { return 10; } }
        public override int DexOffset { get { return 20; } }

		public HorrificBeastSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void PlayEffect( Mobile m )
		{
			m.PlaySound( 0x165 );
			m.FixedParticles( 0x3728, 1, 13, 9918, 92, 3, EffectLayer.Head );
		}
	}
}