using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Necromancy
{
	public class LichFormSpell : TransformationSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Liche", "Rel Xen Corp Ort",
				SpellCircle.Fifth,
				203,
				9031,
				Reagent.GraveDust,
				Reagent.DaemonBlood,
				Reagent.NoxCrystal
            );

        public override int RequiredAptitudeValue { get { return 9; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] {NAptitude.Necromancie }; } }

        public override int Body { get { return 24; } }
        public override int IntOffset { get { return 30; } }

		public LichFormSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void PlayEffect( Mobile m )
		{
			m.PlaySound( 0x19C );
			m.FixedParticles( 0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot );
		}
	}
}