using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps de Troll des Neiges" )]
	public class FrostTroll : BaseCreature
	{
		[Constructable]
		public FrostTroll() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Troll des Neiges";
            Body = Utility.RandomList(53, 54, 55);
			BaseSoundID = 461;
            Hue = 2056;

			SetStr( 227, 265 );
			SetDex( 66, 85 );
			SetInt( 46, 70 );

			SetHits( 300, 500 );

			SetDamage( 15, 35 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Tranchant, 25 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 65.1, 80.0 );
			SetSkill( SkillName.Tactiques, 80.1, 100.0 );
			SetSkill( SkillName.ArmePoing, 80.1, 100.0 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 50;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 3 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 2; } }
		//public override int TreasureMapLevel{ get{ return 1; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 10; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }

		public FrostTroll( Serial serial ) : base( serial )
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