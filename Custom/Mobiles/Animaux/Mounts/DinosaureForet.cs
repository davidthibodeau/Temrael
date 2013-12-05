using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Corps de Dinosaure")]
	public class DinosaureForet : BaseMount
	{
		[Constructable]
        public DinosaureForet()
            : this("Dinosaure")
		{
		}

		[Constructable]
		public DinosaureForet( string name ) : base( name, 259, 0x3EA5, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Hue = Utility.RandomSlimeHue() | 0x8000;

			BaseSoundID = 0x270;

			SetStr( 94, 170 );
			SetDex( 56, 75 );
			SetInt( 6, 10 );

			SetHits( 71, 88 );
			SetMana( 0 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );

			SetSkill( SkillName.Concentration, 27.1, 32.0 );
			SetSkill( SkillName.Tactiques, 29.3, 44.0 );
			SetSkill( SkillName.ArmePoing, 29.3, 44.0 );

			Fame = 450;
			Karma = 0;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 75.0;
		}

		public override int Meat{ get{ return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Ostard; } }

        public DinosaureForet(Serial serial)
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