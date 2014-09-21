using System;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "Guerrier Fourmis" )]
	public class RedSolenWarrior : BaseCreature
	{
		private bool m_BurstSac;
		public bool BurstSac{ get{ return m_BurstSac; } }

		[Constructable]
		public RedSolenWarrior() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Guerrier Fourmis";
			Body = 63;
			BaseSoundID = 959;

			SetStr( 196, 220 );
			SetDex( 101, 125 );
			SetInt( 36, 60 );

			SetHits( 300, 900 );

			SetDamage( 20, 40 );

			SetDamageType( ResistanceType.Physical, 80 );
			

            SetResistance(ResistanceType.Physical, 20, 40);
            
            
            
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 60.0 );
			SetSkill( SkillName.Tactiques, 80.0 );
			SetSkill( SkillName.Anatomie, 80.0 );

            PackItem(new Cendres(2));
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Bones { get { return 10; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Volcanique; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

		public override int GetAngerSound()
		{
			return 0xB5;
		}

		public override int GetIdleSound()
		{
			return 0xB5;
		}

		public override int GetAttackSound()
		{
			return 0x289;
		}

		public override int GetHurtSound()
		{
			return 0xBC;
		}

		public override int GetDeathSound()
		{
			return 0xE4;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.RandomMinMax( 1, 2 ) );
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( SolenHelper.CheckRedFriendship( m ) )
				return false;
			else
				return base.IsEnemy( m );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			SolenHelper.OnRedDamage( from );

			if ( !willKill )
			{
				if ( !BurstSac )
				{
					if ( Hits < 50 )
					{
						PublicOverheadMessage( MessageType.Regular, 0x3B2, true, "* The solen's acid sac is burst open! *" );
						m_BurstSac = true;
					}
				}
				else if ( from != null && from != this && InRange( from, 1 ) )
				{
					SpillAcid( from, 1 );
				}
			}

			base.OnDamage( amount, from, willKill );
		}

		public override bool OnBeforeDeath()
		{
			SpillAcid( 4 );

			return base.OnBeforeDeath();
		}

		public RedSolenWarrior( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
			writer.Write( m_BurstSac );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
			
			switch( version )
			{
				case 1:
				{
					m_BurstSac = reader.ReadBool();
					break;
				}
			}	
		}
	}
}