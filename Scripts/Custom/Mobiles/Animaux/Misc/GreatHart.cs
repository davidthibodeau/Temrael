using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a deer corpse" )]
	[TypeAlias( "Server.Mobiles.Greathart" )]
	public class GreatHart : BaseCreature
	{
		[Constructable]
		public GreatHart() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a great hart";
			Body = 0xEA;

			SetStr( 41, 71 );
			SetDex( 47, 77 );
			SetInt( 27, 57 );

			SetHits( 27, 41 );
			SetMana( 0 );

			SetDamage( 5, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Tranchant, 5, 10 );

			SetSkill( SkillName.Concentration, 26.8, 44.5 );
			SetSkill( SkillName.Tactiques, 29.8, 47.5 );
			SetSkill( SkillName.ArmePoing, 29.8, 47.5 );

			Fame = 300;
			Karma = 0;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 30.0;
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat{ get{ return 6; } }
		public override int Hides{ get{ return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public GreatHart(Serial serial) : base(serial)
		{
		}

		public override int GetAttackSound() 
		{ 
			return 0x82; 
		} 

		public override int GetHurtSound() 
		{ 
			return 0x83; 
		} 

		public override int GetDeathSound() 
		{ 
			return 0x84; 
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