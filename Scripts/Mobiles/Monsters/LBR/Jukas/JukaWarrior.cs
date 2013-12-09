using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a jukan corpse" )]
	public class JukaWarrior : BaseCreature
	{
		[Constructable]
		public JukaWarrior() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a juka warrior";
            Body = 400;

			SetStr( 251, 350 );
			SetDex( 61, 80 );
			SetInt( 101, 150 );

			SetHits( 151, 210 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Contondant, 30, 40 );
			SetResistance( ResistanceType.Tranchant, 25, 35 );
			SetResistance( ResistanceType.Perforant, 10, 20 );
			SetResistance( ResistanceType.Magie, 10, 20 );

			//SetSkill( SkillName.Anatomy, 80.1, 90.0 );
			SetSkill( SkillName.ArmePerforante, 80.1, 90.0 );
			SetSkill( SkillName.ArmeContondante, 80.1, 90.0 );
			SetSkill( SkillName.Concentration, 120.1, 130.0 );
			SetSkill( SkillName.ArmeTranchante, 80.1, 90.0 );
			SetSkill( SkillName.Tactiques, 80.1, 90.0 );
			SetSkill( SkillName.ArmePoing, 80.1, 90.0 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 22;

			if ( Utility.RandomDouble() < 0.1 )
				PackItem( new ArcaneGem() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems, 1 );
		}

		public override int GetIdleSound()
		{
			return 0x1AC;
		}

		public override int GetAngerSound()
		{
			return 0x1CD;
		}

		public override int GetHurtSound()
		{
			return 0x1D0;
		}

		public override int GetDeathSound()
		{
			return 0x28D;
		}

		public override bool AlwaysMurderer{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.2 < Utility.RandomDouble() )
				return;

			switch ( Utility.Random( 3 ) )
			{
				case 0:
				{
					defender.SendLocalizedMessage( 1004014 ); // You have been stunned!
					defender.Freeze( TimeSpan.FromSeconds( 4.0 ) );
					break;
				}
				case 1:
				{
					defender.SendAsciiMessage( "You have been hit by a paralyzing blow!" );
					defender.Freeze( TimeSpan.FromSeconds( 3.0 ) );
					break;
				}
				case 2:
				{
					AOS.Damage( defender, this, Utility.Random( 10, 5 ), 100, 0, 0, 0, 0 );
					defender.SendAsciiMessage( "You have been hit by a critical strike!" );
					break;
				}
			}
		}

		public JukaWarrior( Serial serial ) : base( serial )
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
		}
	}
}
