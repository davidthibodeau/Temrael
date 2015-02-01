using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells
{
	public class HorrificBeastSpell : TransformationSpell
	{
        public static int m_SpellID { get { return 308; } }// TOCHANGE

        private static short s_Cercle = 8;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Bête Horrifique", "Rel Xen Vas Bal",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.Alteration,
				Reagent.BatWing,
				Reagent.DaemonBlood
            );

        public override int Body { get { return 73; } }
        public override int StrOffset { get { return 10; } }
        public override int DexOffset { get { return 20; } }

		public HorrificBeastSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void PlayEffect( Mobile m )
		{
			m.PlaySound( 0x165 );
			Effects.SendTargetParticles(m, 0x3728, 1, 13, 9918, 92, 3, EffectLayer.Head );
		}
	}
}