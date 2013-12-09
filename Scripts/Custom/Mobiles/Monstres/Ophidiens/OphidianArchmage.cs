using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ophidian corpse" )]
	[TypeAlias( "Server.Mobiles.OphidianJusticar", "Server.Mobiles.OphidianZealot" )]
	public class OphidianArchmage : BaseCreature
	{
		[Constructable]
		public OphidianArchmage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Archimage Ophidien";
			Body = 85;
			BaseSoundID = 639;

			SetStr( 281, 305 );
			SetDex( 191, 215 );
			SetInt( 226, 250 );

			SetHits( 169, 183 );
			SetStam( 300, 600 );

			SetDamage( 5, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			//SetSkill( SkillName.EvalInt, 95.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 95.1, 100.0 );
			SetSkill( SkillName.Concentration, 75.0, 97.5 );
			SetSkill( SkillName.Tactiques, 65.0, 87.5 );
			SetSkill( SkillName.ArmePoing, 20.2, 60.0 );

			Fame = 11500;
			Karma = -11500;

			PackReg( 5, 15 );
			PackNecroReg( 5, 15 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls, 2 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 10; } }
        public override HideType HideType { get { return HideType.Ophidien; } }
        public override BoneType BoneType { get { return BoneType.Ophidien; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public OphidianArchmage( Serial serial ) : base( serial )
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