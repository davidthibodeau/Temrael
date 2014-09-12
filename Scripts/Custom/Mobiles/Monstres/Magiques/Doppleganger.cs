using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Changelin" )]
	public class Doppleganger : BaseCreature
	{
		[Constructable]
		public Doppleganger() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Changelin";
			Body = 162;
			BaseSoundID = 0x451;

			SetStr( 81, 110 );
			SetDex( 56, 75 );
			SetInt( 81, 105 );

			SetHits( 200, 400 );

			SetDamage( 15, 30 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 75.1, 85.0 );
			SetSkill( SkillName.Tactiques, 70.1, 80.0 );
			SetSkill( SkillName.Anatomie, 80.1, 90.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 10; } }
        public override HideType HideType { get { return HideType.Magique; } }
        public override BoneType BoneType { get { return BoneType.Magique; } }

		public Doppleganger( Serial serial ) : base( serial )
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