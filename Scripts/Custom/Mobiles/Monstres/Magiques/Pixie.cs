using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "Pixie" )]
	public class Pixie : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public Pixie() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "Pixie";
			Body = 49;
			BaseSoundID = 0x467;

			SetStr( 21, 30 );
			SetDex( 301, 400 );
			SetInt( 201, 250 );

			SetHits( 200, 300 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 100.5, 150.0 );
			SetSkill( SkillName.Tactiques, 10.1, 20.0 );
			SetSkill( SkillName.Anatomie, 10.1, 12.5 );

			Fame = 7000;
			Karma = 7000;

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 75.0;
		}

		public override void GenerateLoot()
		{
            //AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 1; } }
        public override int Hides { get { return 3; } }
        public override HideType HideType { get { return HideType.Magique; } }
        public override BoneType BoneType { get { return BoneType.Magique; } }

		public Pixie( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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