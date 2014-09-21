using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a bear corpse" )]
	[TypeAlias( "Server.Mobiles.Bear" )]
	public class BlackBear : BaseCreature
	{
		[Constructable]
		public BlackBear() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a black bear";
			Body = 211;
			BaseSoundID = 0xA3;

            ExpKillBonus = 4;

			SetStr( 76, 100 );
			SetDex( 56, 75 );
			SetInt( 11, 14 );

			SetHits( 46, 60 );
			SetMana( 0 );

			SetDamage( 4, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );

			SetSkill( SkillName.Concentration, 20.1, 40.0 );
			SetSkill( SkillName.Tactiques, 40.1, 60.0 );
			SetSkill( SkillName.Anatomie, 40.1, 60.0 );

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 50.0;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 5; } }
        public override int Bones { get { return 5; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat | FoodType.FruitsAndVegies; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bear; } }

		public BlackBear( Serial serial ) : base( serial )
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