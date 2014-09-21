using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Fourmis Geante" )]
	public class RedSolenWorker : BaseCreature
	{
		[Constructable]
		public RedSolenWorker() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Fourmis Geante";
			Body = 62;
			BaseSoundID = 959;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 300, 500 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 60.0 );
			SetSkill( SkillName.Tactiques, 65.0 );
			SetSkill( SkillName.Anatomie, 60.0 );

            PackItem(new Cendres(1));
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
        public override int Bones { get { return 2; } }
        public override int Hides { get { return 6; } }
        public override HideType HideType { get { return HideType.Volcanique; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.Meager);
        }

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

		public RedSolenWorker( Serial serial ) : base( serial )
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