using System;
using Server;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a squirrel corpse" )]	
	public class Squirrel : BaseCreature
	{
		[Constructable]
		public Squirrel() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a squirrel";
            Body = 400;

			SetStr( 44, 50 );
			SetDex( 35 );
			SetInt( 5 );

			SetHits( 42, 50 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 34 );
			SetResistance( ResistanceType.Contondant, 10, 14 );
			SetResistance( ResistanceType.Tranchant, 30, 35 );
			SetResistance( ResistanceType.Perforant, 20, 25 );
			SetResistance( ResistanceType.Magie, 20, 25 );

			SetSkill( SkillName.Concentration, 4.0 );
			SetSkill( SkillName.Tactiques, 4.0 );
			SetSkill( SkillName.Anatomie, 4.0 );

			Tamable = true;	
			ControlSlots = 1;
			MinTameSkill = -21.3;
		}

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public Squirrel( Serial serial ) : base( serial )
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
