using System;
using Server.Targeting;
using Server.Network;
using Server;
using Server.Mobiles;

namespace Server.Spells
{
	public class VisionDeNuitSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		private static SpellInfo m_Info = new SpellInfo(
				"Vision De Nuit", "In Lor",
				SpellCircle.First,
				236,
				9031,
				Reagent.SulfurousAsh,
				Reagent.SpidersSilk
            );

        public VisionDeNuitSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
		{
		}

		public override void OnCast()
		{
			Caster.Target = new NightSightTarget( this );
		}

		private class NightSightTarget : Target
		{
			private Spell m_Spell;

			public NightSightTarget( Spell spell ) : base( 12, false, TargetFlags.Beneficial )
			{
				m_Spell = spell;
			}

			protected override void OnTarget( Mobile from, object targeted )
			{
				if ( targeted is Mobile && m_Spell.CheckBSequence( (Mobile) targeted ) )
				{
					Mobile targ = (Mobile)targeted;

					SpellHelper.Turn( m_Spell.Caster, targ );

					if ( targ.BeginAction( typeof( LightCycle ) ) )
					{
                        double value = Utility.Random(15, 25);

                        value = SpellHelper.AdjustValue(m_Spell.Caster, value);

                        new LightCycle.NightSightTimer(targ).Start();

						targ.LightLevel = 100;

						targ.FixedParticles( 0x376A, 9, 32, 5007, EffectLayer.Waist );
						targ.PlaySound( 0x1E3 );
					}
					else
					{
						from.SendMessage( "{0} already have nightsight.", from == targ ? "You" : "They" );
					}
				}

				m_Spell.FinishSequence();
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Spell.FinishSequence();
			}
		}
	}
}
