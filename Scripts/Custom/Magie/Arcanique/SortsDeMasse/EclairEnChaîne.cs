using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Spells
{
	public class EclairEnChaineSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Eclair en Chaîne", "Vas Ort Grav",
				SpellCircle.Seventh,
				209,
				9022,
				false,
				Reagent.BlackPearl,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot
            );

        public override int RequiredAptitudeValue { get { return 4; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Evocation }; } }

		public EclairEnChaineSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				if ( p is Item )
					p = ((Item)p).GetWorldLocation();

				ArrayList targets = new ArrayList();

				Map map = Caster.Map;

				if ( map != null )
				{
                    IPooledEnumerable eable = map.GetMobilesInRange(new Point3D(p), (int)SpellHelper.AdjustValue(Caster, 2 + Caster.Skills[CastSkill].Value / 50, NAptitude.Sorcellerie, true));

					foreach ( Mobile m in eable )
					{
                        if (Caster != m && SpellHelper.ValidIndirectTarget(Caster, m) && Caster.CanBeHarmful(m, false) && !(Caster.Party == m.Party))
						{
							targets.Add( m );
						}
					}

					eable.Free();
                }

                double damage = GetNewAosDamage(15, 1, 5, true);

				if ( targets.Count > 0 )
				{
					for ( int i = 0; i < targets.Count; ++i )
					{
                        Mobile m = (Mobile)targets[i];

                        Disturb(m);

						if ( CheckResisted( m ) )
						{
							damage *= 0.75;

							m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
                        }

						Caster.DoHarmful( m );
                        SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);

						m.BoltEffect( 0 );
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
            private EclairEnChaineSpell m_Owner;

            public InternalTarget(EclairEnChaineSpell owner)
                : base(12, true, TargetFlags.None)
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