using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a polar bear corpse" )]
	[TypeAlias( "Server.Mobiles.Polarbear" )]
	public class PolarBear : BaseCreature
	{
		[Constructable]
		public PolarBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a polar bear";
			Body = 213;
			BaseSoundID = 0xA3;

            ExpKillBonus = 4;

			SetStr( 116, 140 );
			SetDex( 81, 105 );
			SetInt( 26, 50 );

			SetHits( 70, 84 );
			SetMana( 0 );

			SetDamage( 7, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Magical, 10, 15 );

			SetSkill( SkillName.Concentration, 45.1, 60.0 );
			SetSkill( SkillName.Tactiques, 60.1, 90.0 );
			SetSkill( SkillName.Anatomie, 45.1, 70.0 );

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 60.0;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 2; } }
		public override int Hides{ get{ return 5; } }
        public override int Bones { get { return 5; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public PolarBear( Serial serial ) : base( serial )
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