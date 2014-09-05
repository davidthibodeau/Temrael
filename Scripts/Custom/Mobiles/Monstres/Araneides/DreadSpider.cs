using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Araignee d'Effroie" )]
	public class DreadSpider : BaseCreature
	{
		[Constructable]
		public DreadSpider () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Araignee d'Effroie";
			Body = 11;
			BaseSoundID = 1170;

			SetStr( 196, 220 );
			SetDex( 126, 145 );
			SetInt( 286, 310 );

			SetHits( 200, 400 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Perforant, 80 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.ArtMagique, 60.0, 80.0 );
			SetSkill( SkillName.Concentration, 60.0, 80.0 );
			SetSkill( SkillName.Tactiques, 50.0, 70.0 );
			SetSkill( SkillName.Anatomie, 50.0, 70.0 );

			Fame = 5000;
			Karma = -5000;

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 80.0;

			PackItem( new SpidersSilk( 8 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		//public override int TreasureMapLevel{ get{ return 3; } }
        public override int Bones { get { return 2; } }
        public override int Hides { get { return 4; } }
        public override HideType HideType { get { return HideType.Arachnide; } }
        public override BoneType BoneType { get { return BoneType.Arachnide; } }

		public DreadSpider( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 1170;
		}
	}
}