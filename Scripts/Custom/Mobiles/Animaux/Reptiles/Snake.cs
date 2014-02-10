using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a snake corpse" )]
	public class Snake : BaseCreature
	{
		[Constructable]
        public Snake()
            : base(AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4)
		{
			Name = "a snake";
			Body = 52;
			Hue = Utility.RandomSnakeHue();
			BaseSoundID = 0xDB;

			SetStr( 22, 34 );
			SetDex( 16, 25 );
			SetInt( 6, 10 );

			SetHits( 15, 19 );
			SetMana( 0 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Perforant, 20, 30 );

			SetSkill( SkillName.Empoisonner, 50.1, 70.0 );
			SetSkill( SkillName.Concentration, 15.1, 20.0 );
			SetSkill( SkillName.Tactiques, 19.3, 34.0 );
			SetSkill( SkillName.ArmePoing, 19.3, 34.0 );

            Fame = 150;
            Karma = 0;

			VirtualArmor = 10;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 5.0;
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

		public override bool DeathAdderCharmable{ get{ return true; } }

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Eggs; } }
        public override int Bones { get { return 1; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Reptilien; } }
        public override BoneType BoneType { get { return BoneType.Reptilien; } }
        public override PackInstinct PackInstinct { get { return PackInstinct.Canine; } }

		public Snake(Serial serial) : base(serial)
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