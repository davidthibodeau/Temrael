using System;
using System.Collections;
using Server.Misc;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Sixth
{
	public class RevealSpell : Spell
	{
        private static int s_ManaCost = 50;
        private static SkillName s_SkillForCast = SkillName.ArtMagique;
        private static int s_MinSkillForCast = 50;

		private static SpellInfo m_Info = new SpellInfo(
				"Révélation", "Wis Quas",
				SpellCircle.Sixth,
				206,
				9002,
                s_ManaCost,
                s_SkillForCast,
                s_MinSkillForCast,
                false,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh
            );

		public RevealSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				SpellHelper.GetSurfaceTop( ref p );

				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
				{
                    double tile = GetRadiusForSpell();

                    tile = SpellHelper.AdjustValue(Caster, tile);

					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), (int)tile );

					foreach ( Mobile m in eable )
					{
						if ( m.Hidden && (m.AccessLevel == AccessLevel.Player || Caster.AccessLevel > m.AccessLevel) && Caster.CanBeHarmful( m, false, true ) && CheckDifficulty( Caster, m ) )
							targets.Add( m );
					}

					eable.Free();
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					m.RevealingAction();

					m.FixedParticles( 0x375A, 9, 20, 5049, EffectLayer.Head );
					m.PlaySound( 0x1FD );
				}
			}

			FinishSequence();
		}

		// Reveal uses magery and detect hidden vs. hide and stealth 
		private static bool CheckDifficulty( Mobile from, Mobile m )
		{
			// Reveal always reveals vs. invisibility spell 
			if ( InvisibilitySpell.HasTimer( m ) )
				return true;

			double magery = from.Skills[SkillName.Reve].Value;
            double detectHidden = from.Skills[SkillName.ArtMagique].Value;

            double hiding = m.Skills[SkillName.Discretion].Value;
            double stealth = m.Skills[SkillName.Infiltration].Value;

            double chance;

            if (hiding + stealth > 0)
				chance = (magery + detectHidden) - (hiding + stealth);
			else
				chance = 100;

			return chance > Utility.Random( 100 );
		}

		private class InternalTarget : Target
		{
			private RevealSpell m_Owner;

			public InternalTarget( RevealSpell owner ) : base( 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}