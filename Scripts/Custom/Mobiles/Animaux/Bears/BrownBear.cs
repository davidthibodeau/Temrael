using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	public class BrownBear : BaseCreature
	{
		[Constructable]
		public BrownBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a brown bear";
			Body = 167;
			BaseSoundID = 0xA3;

            ExpKillBonus = 4;

			SetStr( 76, 100 );
			SetDex( 26, 45 );
			SetInt( 23, 47 );

			SetHits( 46, 60 );
			SetMana( 0 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 30 );
			SetResistance( ResistanceType.Tranchant, 15, 20 );
			SetResistance( ResistanceType.Perforant, 10, 15 );

			SetSkill( SkillName.Concentration, 25.1, 35.0 );
			SetSkill( SkillName.Tactiques, 40.1, 60.0 );
			SetSkill( SkillName.Anatomie, 40.1, 60.0 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 45.0;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 5; } }
        public override int Bones { get { return 5; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.FruitsAndVegies | FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public BrownBear( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}