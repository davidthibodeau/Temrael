using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a walrus corpse" )]
	public class Walrus : BaseCreature
	{
		[Constructable]
		public Walrus() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a walrus";
			Body = 0xDD;
			BaseSoundID = 0xE0;

			SetStr( 21, 29 );
			SetDex( 46, 55 );
			SetInt( 16, 20 );

			SetHits( 14, 17 );
			SetMana( 0 );

			SetDamage( 4, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Contondant, 5, 10 );
			SetResistance( ResistanceType.Tranchant, 20, 25 );
			SetResistance( ResistanceType.Perforant, 5, 10 );
			SetResistance( ResistanceType.Magie, 5, 10 );

			SetSkill( SkillName.Concentration, 15.1, 20.0 );
			SetSkill( SkillName.Tactiques, 19.2, 29.0 );
			SetSkill( SkillName.Anatomie, 19.2, 29.0 );

			Fame = 150;
			Karma = 0;

			VirtualArmor = 18;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 30.0;
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 3; } }
        public override int Bones { get { return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish; } }

		public Walrus(Serial serial) : base(serial)
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