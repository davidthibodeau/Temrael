using System;
using System.Collections;
using Server.Misc;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells
{
	public class RevelationSpell : Spell
    {
        public static int m_SpellID { get { return 0; } } // TOCHANGE

		public static readonly new SpellInfo Info = new SpellInfo(
				"Reveal", "Wis Quas",
				SpellCircle.First,
				206,
				9002,
				Reagent.Bloodmoss,
				Reagent.SulfurousAsh
            );

        public RevelationSpell(Mobile caster, Item scroll)
            : base(caster, scroll, Info)
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
                    double tile = SpellHelper.AdjustValue(Caster, 4 + (int)(Caster.Skills[SkillName.ArtMagique].Value / 50.0));

					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), (int)tile );

					foreach ( Mobile m in eable )
					{
						if ( m.Hidden && (m.AccessLevel == AccessLevel.Player || Caster.AccessLevel > m.AccessLevel) && CheckDifficulty( Caster, m ) )
							targets.Add( m );
					}

					eable.Free();
				}

				for ( int i = 0; i < targets.Count; ++i )
				{
					Mobile m = (Mobile)targets[i];

					m.RevealingAction();
                    m.SendLocalizedMessage(500814); // You have been revealed!

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
//			if ( InvisibilitySpell.HasTimer( m ) )
//				return true;

            double sourceSkill = from.Skills[SkillName.ArtMagique].Value;
            double targetSkill = m.Skills[SkillName.Discretion].Value;
            double value;

            if (targetSkill < 0)
                targetSkill = 1;

            if (targetSkill - sourceSkill > 0)
                value = (10000 + sourceSkill - ((sourceSkill / targetSkill) * 10450)) / -100;
            else if (sourceSkill - targetSkill > 1)
                value = ((10000 + sourceSkill - ((sourceSkill / targetSkill) * 100000)) / -100) - 900;
            else
                value = (10000 + sourceSkill - ((sourceSkill / targetSkill) * 11000)) / -100;

            return value > Utility.Random(100) && from.AccessLevel >= m.AccessLevel;
		}

		private class InternalTarget : Target
		{
            private RevelationSpell m_Owner;

            public InternalTarget(RevelationSpell owner)
                : base(12, true, TargetFlags.Harmful)
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