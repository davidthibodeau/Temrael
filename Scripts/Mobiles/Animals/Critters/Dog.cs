using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dog corpse" )]
	public class Dog : BaseCreature
	{
		[Constructable]
		public Dog() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a dog";
			Body = 0xD9;
			Hue = Utility.RandomAnimalHue();
			BaseSoundID = 0x85;

			SetStr( 27, 37 );
			SetDex( 28, 43 );
			SetInt( 29, 37 );

			SetHits( 17, 22 );
			SetMana( 0 );

			SetDamage( 2, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10, 15 );

			SetSkill( SkillName.Concentration, 22.1, 47.0 );
			SetSkill( SkillName.Tactiques, 19.2, 31.0 );
			SetSkill( SkillName.Anatomie, 19.2, 31.0 );

			VirtualArmor = 12;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 0.0;
		}

        public override double AttackSpeed { get { return 2.0; } }
		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public Dog(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}