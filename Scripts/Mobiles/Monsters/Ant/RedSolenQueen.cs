using System;
using System.Collections;
using Server.Items;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "Reine Fourmis" )]
	public class RedSolenQueen : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		private bool m_BurstSac;
		public bool BurstSac{ get{ return m_BurstSac; } }

		[Constructable]
		public RedSolenQueen() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Reine Fourmis";
			Body = 64;
			BaseSoundID = 959;

			SetStr( 296, 320 );
			SetDex( 121, 145 );
			SetInt( 76, 100 );

			SetHits( 750, 1500 );

			SetDamage( 40, 80 );

			SetDamageType( ResistanceType.Physical, 70 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

            SetSkill(SkillName.ArtMagique, 100.0);
			SetSkill( SkillName.Concentration, 90.0 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.Anatomie, 100.0 );

            PackItem(new Cendres(5));
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Bones { get { return 16; } }
        public override int Hides { get { return 18; } }
        public override HideType HideType { get { return HideType.Volcanique; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

		public override int GetAngerSound()
		{
			return 0x259;
		}

		public override int GetIdleSound()
		{
			return 0x259;
		}

		public override int GetAttackSound()
		{
			return 0x195;
		}

		public override int GetHurtSound()
		{
			return 0x250;
		}

		public override int GetDeathSound()
		{
			return 0x25B;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
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

		public RedSolenQueen( Serial serial ) : base( serial )
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