using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Serpent d'Hautes Mers" )]
	public class DeepSeaSerpent : BaseCreature
	{
		[Constructable]
		public DeepSeaSerpent() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Serpent d'Haute Mer";
			Body = 150;
			BaseSoundID = 447;

			Hue = Utility.Random( 0x8A0, 5 );

			SetStr( 251, 425 );
			SetDex( 87, 135 );
			SetInt( 87, 155 );

			SetHits( 250, 500 );

			SetDamage( 10, 30 );

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

			//PackItem( new SpecialFishingNet() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool HasBreath{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Scales{ get{ return 4; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Maritime; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 6; } }
        public override HideType HideType { get { return HideType.Maritime; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }

		public DeepSeaSerpent( Serial serial ) : base( serial )
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