using System;
using System.Collections;
using Server.Network;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using Server.Engines.PartySystem;

namespace Server.Spells.Seventh
{
	public class MeteorSwarmSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Météores", "Flam Kal Des Ylem",
				SpellCircle.Eighth,
				233,
				9042,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
				Reagent.SpidersSilk
            );

        public override int RequiredAptitudeValue { get { return 9; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] {Aptitude.Evocation }; } }

		public MeteorSwarmSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( IPoint3D p )
		{
            Party party = Engines.PartySystem.Party.Get(Caster);
            bool inParty = false;

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
					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), GetRadiusForSpell() );

					foreach ( Mobile m in eable )
					{
						if ( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) )
						{
                            if (party != null && party.Count > 0)
                            {
                                for (int k = 0; k < party.Members.Count; ++k)
                                {
                                    PartyMemberInfo pmi = (PartyMemberInfo)party.Members[k];
                                    Mobile member = pmi.Mobile;
                                    if (member.Serial == m.Serial)
                                        inParty = true;
                                }
                                if (!inParty)
                                    targets.Add(m);
                            }
                            else
                            {
                                targets.Add(m);
                            }
						}
                        inParty = false;
					}

					eable.Free();
				}

				if ( targets.Count > 0 )
				{
					Effects.PlaySound( p, Caster.Map, 0x160 );

					for ( int i = 0; i < targets.Count; ++i )
					{
                        Mobile m = (Mobile)targets[i];

                        //double damage = Utility.RandomMinMax(45, 90);
                        double damage = Utility.RandomMinMax(22, 45);

                        damage = SpellHelper.AdjustValue(Caster, damage, Aptitude.Sorcellerie);

						if ( CheckResisted( m ) )
						{
							damage *= 0.75;

							m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
                        }

                        damage *= GetDamageScalar(m);

						Caster.DoHarmful( m );
                        SpellHelper.Damage(this, m, damage, 0, 0, 0, 0, 100);

						Caster.MovingParticles( m, 0x36D4, 7, 0, false, true, 9501, 1, 0, 0x100 );
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MeteorSwarmSpell m_Owner;

			public InternalTarget( MeteorSwarmSpell owner ) : base( 12, true, TargetFlags.None )
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