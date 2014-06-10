using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class Revenant : BaseCreature
	{
		private Mobile m_Target;
		private DateTime m_ExpireTime;

		public override void DisplayPaperdollTo( Mobile to )
		{
			// Do nothing
		}

		public override Mobile ConstantFocus{ get{ return m_Target; } }
		public override bool NoHouseRestrictions{ get{ return true; } }

		public override double DispelDifficulty{ get{ return 80.0; } }
		public override double DispelFocus{ get{ return 20.0; } }

		public Revenant( Mobile caster, Mobile target, TimeSpan duration ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.18, 0.36 )
		{
			Name = "Esprit Vengeur";
			Body = 100;
			Hue = 1;
			// TODO: Sound values?

            double scalar = caster.Skills[SkillName.Goetie].Value * 0.01;

			m_Target = target;
			m_ExpireTime = DateTime.Now + duration;

			SetStr( 200 );
			SetDex( 150 );
			SetInt( 150 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Concentration, 100.0 * scalar );
			SetSkill( SkillName.Tactiques, 100.0 );
            SetSkill( SkillName.ArmeHaste, 100.0 * scalar );
			SetSkill( SkillName.Detection, 75.0 * scalar );

			SetResistance( ResistanceType.Physical, 40 + (int)(20 * scalar), 50 + (int)(20 * scalar)  );
			SetResistance( ResistanceType.Tranchant, 40 + (int)(20 * scalar), 50 + (int)(20 * scalar) );
			SetResistance( ResistanceType.Contondant, (int)(20 * scalar) );
			SetResistance( ResistanceType.Perforant, 100 );
			SetResistance( ResistanceType.Magie, 40 + (int)(20 * scalar), 50 + (int)(20 * scalar) );

			Fame = 0;
			Karma = 0;

			ControlSlots = 1;

			VirtualArmor = 32;

			Item shroud = new DeathShroud();

			shroud.Hue = 0x455;

			shroud.Movable = false;

			AddItem( shroud );

			Halberd weapon = new Halberd();

			weapon.Hue = 1;
			weapon.Movable = false;

			AddItem( weapon );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public override bool BleedImmune{ get{ return true; } }
		public override bool BardImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override void OnThink()
		{
			if ( !m_Target.Alive || DateTime.Now > m_ExpireTime )
			{
				Kill();
				return;
			}
			else if ( Map != m_Target.Map || !InRange( m_Target, 15 ) )
			{
				Map fromMap = Map;
				Point3D from = Location;

				Map toMap = m_Target.Map;
				Point3D to = m_Target.Location;

				if ( toMap != null )
				{
					for ( int i = 0; i < 5; ++i )
					{
						Point3D loc = new Point3D( to.X - 4 + Utility.Random( 9 ), to.Y - 4 + Utility.Random( 9 ), to.Z );

						if ( toMap.CanSpawnMobile( loc ) )
						{
							to = loc;
							break;
						}
						else
						{
							loc.Z = toMap.GetAverageZ( loc.X, loc.Y );

							if ( toMap.CanSpawnMobile( loc ) )
							{
								to = loc;
								break;
							}
						}
					}
				}

				Map = toMap;
				Location = to;

				ProcessDelta();

				Effects.SendLocationParticles( EffectItem.Create( from, fromMap, EffectItem.DefaultDuration ), 0x3728, 1, 13, 37, 7, 5023, 0 );
				FixedParticles( 0x3728, 1, 13, 5023, 37, 7, EffectLayer.Waist );

				PlaySound( 0x37D );
			}

			if ( m_Target.Hidden && InRange( m_Target, 3 ) && DateTime.Now >= this.NextSkillTime && UseSkill( SkillName.Detection ) )
			{
				Target targ = this.Target;

				if ( targ != null )
					targ.Invoke( this, this );
			}

			Combatant = m_Target;
			FocusMob = m_Target;

			if ( AIObject != null )
				AIObject.Action = ActionType.Combat;

			base.OnThink();
		}

		public override bool OnBeforeDeath()
		{
			Effects.PlaySound( Location, Map, 0x10B );
			Effects.SendLocationParticles( EffectItem.Create( Location, Map, TimeSpan.FromSeconds( 10.0 ) ), 0x37CC, 1, 50, 2101, 7, 9909, 0 );

			Delete();
			return false;
		}

		public Revenant( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			Delete();
		}
	}
}