using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Araignee de glace" )]
	public class FrostSpider : BaseCreature
	{
		[Constructable]
		public FrostSpider() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Araignee de Glace";
			Body = 19;
			BaseSoundID = 0x388;

			SetStr( 76, 100 );
			SetDex( 126, 145 );
			SetInt( 36, 60 );

			SetHits( 200, 400 );
			SetMana( 0 );

			SetDamage( 15, 30 );

            SetDamageType(ResistanceType.Physical, 20);

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

            SetSkill(SkillName.ArtMagique, 60.0, 80.0);
            SetSkill(SkillName.Concentration, 60.0, 80.0);
            SetSkill(SkillName.Tactiques, 50.0, 70.0);
            SetSkill(SkillName.Anatomie, 50.0, 70.0);

			Tamable = true;
			ControlSlots = 4;
            MinTameSkill = 85.0;

			PackItem( new SpidersSilk( 7 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
        public override int Bones { get { return 3; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }

		public FrostSpider( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 387 )
				BaseSoundID = 0x388;
		}
	}
}