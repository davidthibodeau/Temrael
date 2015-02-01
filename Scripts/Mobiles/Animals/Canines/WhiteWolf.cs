using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a white wolf corpse" )]
	[TypeAlias( "Server.Mobiles.Whitewolf" )]
	public class WhiteWolf : BaseCreature
	{
		[Constructable]
		public WhiteWolf() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a white wolf";
			Body = 225;
			BaseSoundID = 0xE5;
            Hue = 2168;

            ExpKillBonus = 3;

			SetStr( 56, 80 );
			SetDex( 56, 75 );
			SetInt( 31, 55 );

			SetHits( 34, 48 );
			SetMana( 0 );

			SetDamage( 3, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Magical, 10, 15 );

			SetSkill( SkillName.Concentration, 20.1, 35.0 );
			SetSkill( SkillName.Tactiques, 45.1, 60.0 );
			SetSkill( SkillName.Anatomie, 45.1, 60.0 );

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 45.0;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 3; } }
        public override int Bones { get { return 3; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

		public WhiteWolf( Serial serial ) : base( serial )
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