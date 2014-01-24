using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Serpent de Mer" )]
	[TypeAlias( "Server.Mobiles.Seaserpant" )]
	public class SeaSerpent : BaseCreature
	{
		[Constructable]
		public SeaSerpent() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Serpent de Mer";
			Body = 150;
			BaseSoundID = 447;

			SetStr( 168, 225 );
			SetDex( 58, 85 );
			SetInt( 53, 95 );

			SetHits( 200, 400 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 60.1, 75.0 );
			SetSkill( SkillName.Tactiques, 60.1, 70.0 );
			SetSkill( SkillName.ArmePoing, 60.1, 70.0 );

			Fame = 6000;
			Karma = -6000;

			CanSwim = true;
			CantWalk = true;

			if ( Utility.RandomBool() )
				PackItem( new SulfurousAsh( 4 ) );
			else
				PackItem( new BlackPearl( 4 ) );

			PackItem( new RawFishSteak() );

			//PackItem( new SpecialFishingNet() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool HasBreath{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 2; } }

		public override int Scales{ get{ return 8; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Maritime; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 4; } }
        public override HideType HideType { get { return HideType.Maritime; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }

		public SeaSerpent( Serial serial ) : base( serial )
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