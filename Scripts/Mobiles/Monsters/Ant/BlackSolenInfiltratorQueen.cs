using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a solen infiltrator corpse" )] // TODO: Corpse name?
	public class BlackSolenInfiltratorQueen : BaseCreature
	{
		[Constructable]
		public BlackSolenInfiltratorQueen() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a black solen infiltrator";
			Body = 64;
			BaseSoundID = 959;
			Hue = 0x453;

			SetStr( 326, 350 );
			SetDex( 141, 165 );
			SetInt( 96, 120 );

			SetHits( 151, 162 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Perforant, 30 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Contondant, 30, 35 );
			SetResistance( ResistanceType.Tranchant, 25, 35 );
			SetResistance( ResistanceType.Perforant, 35, 40 );
			SetResistance( ResistanceType.Magie, 25, 30 );

			SetSkill( SkillName.Concentration, 90.0 );
			SetSkill( SkillName.Tactiques, 90.0 );
			SetSkill( SkillName.Anatomie, 90.0 );

		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

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
			AddLoot( LootPack.Rich );
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

		public BlackSolenInfiltratorQueen( Serial serial ) : base( serial )
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