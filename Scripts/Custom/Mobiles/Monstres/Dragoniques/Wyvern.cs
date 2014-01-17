using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corps de Wyverne" )]
	public class Wyvern : BaseCreature
	{
		[Constructable]
		public Wyvern () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Wyverne";
			Body = 92;
            BaseSoundID = 362;

			SetStr( 202, 240 );
			SetDex( 153, 172 );
			SetInt( 51, 90 );

			SetHits( 700, 1400 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Perforant, 50 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Empoisonner, 60.1, 80.0 );
			SetSkill( SkillName.Concentration, 65.1, 80.0 );
			SetSkill( SkillName.Tactiques, 65.1, 90.0 );
			SetSkill( SkillName.ArmePoing, 65.1, 80.0 );

			Fame = 4000;
			Karma = -4000;

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 80.0;
			
			PackItem( new LesserPoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			//AddLoot( LootPack.MedScrolls );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool ReacquireOnMovement{ get{ return true; } }

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		//public override int TreasureMapLevel{ get{ return 2; } }

        public override int Scales { get { return 1; } }
        public override ScaleType ScaleType { get { return ScaleType.Wyrm; } }
		public override int Meat{ get{ return 10; } }
        public override int Bones { get { return 1; } }
        public override int Hides { get { return 4; } }
        public override HideType HideType { get { return HideType.Desertique; } }
        public override BoneType BoneType { get { return BoneType.Wyrm; } }

		public override int GetAttackSound()
		{
			return 713;
		}

		public override int GetAngerSound()
		{
			return 718;
		}

		public override int GetDeathSound()
		{
			return 716;
		}

		public override int GetHurtSound()
		{
			return 721;
		}

		public override int GetIdleSound()
		{
			return 725;
		}

		public Wyvern( Serial serial ) : base( serial )
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