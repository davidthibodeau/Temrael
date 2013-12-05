using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a solen worker corpse" )]
	public class BlackSolenWorker : BaseCreature
	{
		[Constructable]
		public BlackSolenWorker() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a black solen worker";
			Body = 62;
			BaseSoundID = 959;
			Hue = 0x453;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Contondant, 20, 30 );
			SetResistance( ResistanceType.Tranchant, 10, 20 );
			SetResistance( ResistanceType.Perforant, 10, 20 );
			SetResistance( ResistanceType.Magie, 20, 30 );

			SetSkill( SkillName.Concentration, 60.0 );
			SetSkill( SkillName.Tactiques, 65.0 );
			SetSkill( SkillName.ArmePoing, 60.0 );

			Fame = 1500;
			Karma = -1500;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override int GetAngerSound()
		{
			return 0x269;
		}

		public override int GetIdleSound()
		{
			return 0x269;
		}

		public override int GetAttackSound()
		{
			return 0x186;
		}

		public override int GetHurtSound()
		{
			return 0x1BE;
		}

		public override int GetDeathSound()
		{
			return 0x8E;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, Utility.RandomMinMax( 1, 2 ) );
		}

		public override bool IsEnemy( Mobile m )
		{
			if ( SolenHelper.CheckBlackFriendship( m ) )
				return false;
			else
				return base.IsEnemy( m );
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			SolenHelper.OnBlackDamage( from );

			base.OnDamage( amount, from, willKill );
		}

		public BlackSolenWorker( Serial serial ) : base( serial )
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