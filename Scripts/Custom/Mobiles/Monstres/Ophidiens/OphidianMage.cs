using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ophidian corpse" )]
	[TypeAlias( "Server.Mobiles.OphidianShaman" )]
	public class OphidianMage : BaseCreature
	{
		[Constructable]
		public OphidianMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Mage Ophidien";
			Body = 85;
			BaseSoundID = 639;

			SetStr( 181, 205 );
			SetDex( 191, 215 );
			SetInt( 96, 120 );

			SetHits( 200, 400 );

			SetDamage( 10, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.EvalInt, 85.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 85.1, 100.0 );
			SetSkill( SkillName.Concentration, 75.0, 97.5 );
			SetSkill( SkillName.Tactiques, 65.0, 87.5 );
			SetSkill( SkillName.ArmePoing, 20.2, 60.0 );

			Fame = 4000;
			Karma = -4000;

			PackReg( 10 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.MedScrolls );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 4; } }
        public override int Hides { get { return 6; } }
        public override HideType HideType { get { return HideType.Ophidien; } }
        public override BoneType BoneType { get { return BoneType.Ophidien; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public OphidianMage( Serial serial ) : base( serial )
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