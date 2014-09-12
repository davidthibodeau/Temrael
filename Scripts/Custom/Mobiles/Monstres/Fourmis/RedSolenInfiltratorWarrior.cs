using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a solen infiltrator corpse" )]
	public class RedSolenInfiltratorWarrior : BaseCreature
	{
		[Constructable]
		public RedSolenInfiltratorWarrior() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a red solen infiltrator";
			Body = 63;
			BaseSoundID = 959;

			SetStr( 206, 230 );
			SetDex( 121, 145 );
			SetInt( 66, 90 );

			SetHits( 96, 107 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Perforant, 20 );

			SetResistance( ResistanceType.Physical, 20, 35 );
			SetResistance( ResistanceType.Contondant, 20, 35 );
			SetResistance( ResistanceType.Tranchant, 10, 25 );
			SetResistance( ResistanceType.Perforant, 20, 35 );
			SetResistance( ResistanceType.Magie, 10, 25 );

			SetSkill( SkillName.Concentration, 80.0 );
			SetSkill( SkillName.Tactiques, 80.0 );
			SetSkill( SkillName.Anatomie, 80.0 );
	
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

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
			AddLoot( LootPack.Average, 2 );
			AddLoot( LootPack.Gems, Utility.RandomMinMax( 1, 4 ) );
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

			base.OnDamage( amount, from, willKill );
		}

		public RedSolenInfiltratorWarrior( Serial serial ) : base( serial )
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