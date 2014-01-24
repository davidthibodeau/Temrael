using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Wyrm Pure" )]
	public class WhiteWyrm : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public WhiteWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Body = 172;
			Name = "Wyrm Pure";
            BaseSoundID = 362;

			SetStr( 721, 760 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 2000, 4000 );

			SetDamage( 40, 80 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Tranchant, 50 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Contondant, 50, 70);
            SetResistance(ResistanceType.Tranchant, 50, 70);
            SetResistance(ResistanceType.Perforant, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

			//SetSkill( SkillName.EvalInt, 99.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 99.1, 100.0 );
			SetSkill( SkillName.Concentration, 99.1, 100.0 );
			SetSkill( SkillName.Tactiques, 97.6, 100.0 );
			SetSkill( SkillName.ArmePoing, 90.1, 100.0 );

			Fame = 18000;
			Karma = -18000;

			Tamable = true;
			ControlSlots = 12;
			MinTameSkill = 120.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems, Utility.Random( 1, 5 ) );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Scales{ get{ return 8; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Wyrm; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Gold; } }
		public override bool CanAngerOnTame { get { return true; } }
        public override int Bones { get { return 18; } }
        public override int Hides { get { return 36; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override BoneType BoneType { get { return BoneType.Wyrm; } }

		public WhiteWyrm( Serial serial ) : base( serial )
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

			if ( Core.AOS && Body == 49 )
				Body = 180;
		}
	}
}