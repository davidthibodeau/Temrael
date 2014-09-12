using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a giant rat corpse" )]
	[TypeAlias( "Server.Mobiles.Giantrat" )]
	public class GiantRat : BaseCreature
	{
		[Constructable]
		public GiantRat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a giant rat";
			Body = 0xD7;
			BaseSoundID = 0x188;

			SetStr( 32, 74 );
			SetDex( 46, 65 );
			SetInt( 16, 30 );

			SetHits( 26, 39 );
			SetMana( 0 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Contondant, 5, 10 );
			SetResistance( ResistanceType.Perforant, 25, 35 );

			SetSkill( SkillName.Concentration, 25.1, 30.0 );
			SetSkill( SkillName.Tactiques, 29.3, 44.0 );
			SetSkill( SkillName.Anatomie, 29.3, 44.0 );

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.1;
		}

		public override void GenerateLoot()
		{
		}

        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 3; } }
        public override int Bones { get { return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies | FoodType.Eggs; } }

		public GiantRat(Serial serial) : base(serial)
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