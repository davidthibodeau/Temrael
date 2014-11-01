using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class ArchCureSpell : Spell
	{
        public static int m_SpellID { get { return 0; } } // TOCHANGE

        private static short s_Cercle = 0;

		public static readonly new SpellInfo Info = new SpellInfo(
				"Remède", "Vas An Nox",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.ArtMagique,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.MandrakeRoot
            );

		public ArchCureSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		// Archcure is now 1/4th of a second faster
	//	public override double CastDelayBase{ get{ return base.CastDelayBase - 1; } }

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
					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), GetRadiusForSpell() );

					foreach ( Mobile m in eable )
					{
						if ( Caster.CanBeBeneficial( m, false ) )
							targets.Add( m );
					}

					eable.Free();
				}

				Effects.PlaySound( p, Caster.Map, 0x299 );

				if ( targets.Count > 0 )
				{
					int cured = 0;

					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = (Mobile)targets[i];

						Caster.DoBeneficial( m );

						Poison poison = m.Poison;

						if ( poison != null )
                        {
                            double chanceToCure = 10000 + (int)(Caster.Skills[SkillName.Thaumaturgie].Value * 75) - ((poison.Level + 1) * 2500);
                            chanceToCure /= 100;

                            chanceToCure = SpellHelper.AdjustValue(Caster, chanceToCure);

							if ( chanceToCure > Utility.Random( 100 ) && m.CurePoison( Caster ) )
								++cured;
						}

						m.FixedParticles( 0x373A, 10, 15, 5012, EffectLayer.Waist );
						m.PlaySound( 0x1E0 );
					}

					if ( cured > 0 )
						Caster.SendLocalizedMessage( 1010058 ); // You have cured the target of all poisons!
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private ArchCureSpell m_Owner;

			public InternalTarget( ArchCureSpell owner ) : base( 12, true, TargetFlags.None )
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