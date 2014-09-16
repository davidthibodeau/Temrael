using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "lapin" )]
	public class Rabbit : BaseCreature
	{
		[Constructable]
		public Rabbit() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Lapin";
			Body = 205;
            BaseSoundID = 0xCA;

			if ( 0.5 >= Utility.RandomDouble() )
				Hue = Utility.RandomAnimalHue();

			SetStr( 6, 10 );
			SetDex( 26, 38 );
			SetInt( 6, 14 );

			SetHits( 4, 6 );
			SetMana( 0 );

			SetDamage( 1 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5, 10 );

			SetSkill( SkillName.Concentration, 5.0 );
			SetSkill( SkillName.Tactiques, 5.0 );
			SetSkill( SkillName.Anatomie, 5.0 );

			VirtualArmor = 6;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = -10.0;
		}

        public override double AttackSpeed { get { return 4.0; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 1; } }
        public override int Bones { get { return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public Rabbit(Serial serial) : base(serial)
		{
		}

		public override int GetAttackSound() 
		{ 
			return 0xC9; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0xCA; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0xCB; 
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