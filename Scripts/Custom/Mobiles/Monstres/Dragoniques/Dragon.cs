using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Dragon" )]
	public class Dragon : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public Dragon () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Dragon";
			Body = Utility.RandomList( 12, 59 );
			BaseSoundID = 362;

			SetStr( 796, 825 );
			SetDex( 86, 105 );
			SetInt( 436, 475 );

			SetHits( 1200, 2250 );

			SetDamage( 40, 80 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Contondant, 40, 60);
            SetResistance(ResistanceType.Tranchant, 40, 60);
            SetResistance(ResistanceType.Perforant, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

			//SetSkill( SkillName.EvalInt, 30.1, 40.0 );
			SetSkill( SkillName.ArtMagique, 30.1, 40.0 );
			SetSkill( SkillName.Concentration, 99.1, 100.0 );
			SetSkill( SkillName.Tactiques, 97.6, 100.0 );
			SetSkill( SkillName.Anatomie, 90.1, 92.5 );

			Fame = 15000;
			Karma = -15000;

			Tamable = true;
			ControlSlots = 8;
			MinTameSkill = 97.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.Gems, 8 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool ReacquireOnMovement{ get{ return !Controlled; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return !Controlled; } }
		//public override int TreasureMapLevel{ get{ return 4; } }
		public override int Meat{ get{ return 19; } }
		public override int Scales{ get{ return 5; } }
		public override ScaleType ScaleType{ get{ return ( Body == 12 ? ScaleType.Desertique : ScaleType.Volcanique ); } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override bool CanAngerOnTame { get { return true; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Dragonique; } }
        public override BoneType BoneType { get { return BoneType.Dragon; } }

		public Dragon( Serial serial ) : base( serial )
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
		}
	}
}