using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a timber wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Timberwolf" )]
	public class TimberWolf : BaseCreature
	{
		[Constructable]
		public TimberWolf() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a timber wolf";
			Body = 225;
			BaseSoundID = 0xE5;

            ExpKillBonus = 3;

			SetStr( 56, 80 );
			SetDex( 56, 75 );
			SetInt( 11, 25 );

			SetHits( 34, 48 );
			SetMana( 0 );

			SetDamage( 5, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Contondant, 5, 10 );
			SetResistance( ResistanceType.Tranchant, 10, 15 );
			SetResistance( ResistanceType.Perforant, 5, 10 );
			SetResistance( ResistanceType.Magie, 5, 10 );

			SetSkill( SkillName.Concentration, 27.6, 45.0 );
			SetSkill( SkillName.Tactiques, 30.1, 50.0 );
			SetSkill( SkillName.ArmePoing, 40.1, 60.0 );

			Fame = 450;
			Karma = 0;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 35.0;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 3; } }
        public override int Bones { get { return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public TimberWolf(Serial serial) : base(serial)
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