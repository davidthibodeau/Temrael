using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class LichFormSpell : TransformationSpell
	{
        public static int m_SpellID { get { return 904; } } // TOCHANGE

        private static short s_Cercle = 4;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Liche", "Rel Xen Corp Ort",
                s_Cercle,
				203,
				9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.GraveDust,
				Reagent.DaemonBlood,
				Reagent.NoxCrystal
            );

        public override int Body { get { return 24; } }
        public override int IntOffset { get { return 30; } }

		public LichFormSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void PlayEffect( Mobile m )
		{
			m.PlaySound( 0x19C );
			m.FixedParticles( 0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot );
		}
	}
}