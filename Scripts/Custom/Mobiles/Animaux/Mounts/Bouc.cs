using System;
using Server.Mobiles;

namespace Server.Mobiles
{
    [CorpseName("Bouc")]
	public class Bouc : BaseMount
	{
		[Constructable]
        public Bouc()
            : this("Bouc")
		{
		}

		[Constructable]
		public Bouc( string name ) : base( name, 0xF5, 0x3EB1, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			BaseSoundID = 0x3F3;

			SetStr( 21, 49 );
			SetDex( 56, 75 );
			SetInt( 16, 30 );

			SetHits( 15, 27 );
			SetMana( 0 );

			SetDamage( 3, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );
			SetResistance( ResistanceType.Contondant, 5, 10 );
			SetResistance( ResistanceType.Tranchant, 5, 10 );
			SetResistance( ResistanceType.Perforant, 5, 10 );
			SetResistance( ResistanceType.Magie, 5, 10 );

			SetSkill( SkillName.Concentration, 15.1, 20.0 );
			SetSkill( SkillName.Tactiques, 19.2, 29.0 );
			SetSkill( SkillName.ArmePoing, 19.2, 29.0 );

			Fame = 300;
			Karma = 0;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 30.0;
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

        public Bouc(Serial serial)
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