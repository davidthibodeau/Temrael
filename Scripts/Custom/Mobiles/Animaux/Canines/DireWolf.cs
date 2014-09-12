using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dire wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Direwolf" )]
	public class DireWolf : BaseCreature
	{
		[Constructable]
		public DireWolf() : base( AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dire wolf";
			Body = 225;
			BaseSoundID = 0xE5;

            ExpKillBonus = 3;

			SetStr( 96, 120 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetHits( 58, 72 );
			SetMana( 0 );

			SetDamage( 11, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Contondant, 10, 20 );
			SetResistance( ResistanceType.Tranchant, 5, 10 );
			SetResistance( ResistanceType.Perforant, 5, 10 );
			SetResistance( ResistanceType.Magie, 10, 15 );

			SetSkill( SkillName.Concentration, 57.6, 75.0 );
			SetSkill( SkillName.Tactiques, 50.1, 70.0 );
			SetSkill( SkillName.Anatomie, 60.1, 80.0 );

			VirtualArmor = 22;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 50.0;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 3; } }
		public override HideType HideType{ get{ return HideType.Lupus; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public DireWolf(Serial serial) : base(serial)
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