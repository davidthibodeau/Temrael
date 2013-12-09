using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	public class SummonedEspritVengeur : BaseCreature
	{
		private Mobile m_Target;
		private DateTime m_ExpireTime;

		public override void DisplayPaperdollTo( Mobile to )
		{
			// Do nothing
		}

		//public override Mobile ConstantFocus{ get{ return m_Target; } }
		public override bool NoHouseRestrictions{ get{ return true; } }

		public override double DispelDifficulty{ get{ return 100.0; } }
		public override double DispelFocus{ get{ return 80.0; } }

		public SummonedEspritVengeur( Mobile caster, Mobile target, TimeSpan duration ) : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Un revenant";
			Body = 400;
			Hue = 1;
			// TODO: Sound values?

			m_Target = target;
			m_ExpireTime = DateTime.Now + duration;

			SetStr( 200 );
			SetDex( 150 );
			SetInt( 150 );

			SetDamage( 50, 55 );

			//SetSkill( SkillName.MagicResist, 100.0 ); // magic resist is absolute value of spiritspeak
			SetSkill( SkillName.Tactiques, 100.0 ); // always 100
			SetSkill( SkillName.ArmeTranchante, 100.0 ); // not displayed in animal lore but tests clearly show this is influenced
            SetSkill(SkillName.ArmePoing, 100.0); // not displayed in animal lore but tests clearly show this is influenced
			SetSkill( SkillName.Detection, 100 );

			ControlSlots = 3;

			VirtualArmor = 70;

			Item shroud = new DeathShroud();

			shroud.Hue = 0x455;

			shroud.Movable = false;

			AddItem( shroud );

            Combatant = m_Target;
            FocusMob = m_Target;
            ControlTarget = m_Target;
		}

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

			if ( AIObject != null )
				AIObject.Action = ActionType.Combat;

            Combatant = m_Target;
            FocusMob = m_Target;
            ControlTarget = m_Target;

			base.OnThink();
		}

		public override bool OnBeforeDeath()
		{
			Effects.PlaySound( Location, Map, 0x10B );
			Effects.SendLocationParticles( EffectItem.Create( Location, Map, TimeSpan.FromSeconds( 10.0 ) ), 0x37CC, 1, 50, 2101, 7, 9909, 0 );

			Delete();
			return false;
		}

        public SummonedEspritVengeur(Serial serial)
            : base(serial)
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