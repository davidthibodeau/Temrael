using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Dinosaure")]
	public class DinosaureVolcan : BaseMount
	{
		[Constructable]
        public DinosaureVolcan()
            : this("Dinosaure")
		{
		}

		[Constructable]
		public DinosaureVolcan( string name ) : base( name, 0xDA, 0x3EA4, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Hue = Utility.RandomHairHue() | 0x8000;

			BaseSoundID = 0x275;

			SetStr( 94, 170 );
			SetDex( 96, 115 );
			SetInt( 6, 10 );

			SetHits( 71, 110 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Contondant, 10, 15 );
			SetResistance( ResistanceType.Perforant, 20, 25 );
			SetResistance( ResistanceType.Magie, 20, 25 );

			SetSkill( SkillName.Concentration, 75.1, 80.0 );
			SetSkill( SkillName.Tactiques, 79.3, 94.0 );
			SetSkill( SkillName.Anatomie, 79.3, 94.0 );

			Fame = 1500;
			Karma = -1500;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 80.0;
		}

		public override int Meat{ get{ return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish | FoodType.Eggs | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Ostard; } }

        public DinosaureVolcan(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}