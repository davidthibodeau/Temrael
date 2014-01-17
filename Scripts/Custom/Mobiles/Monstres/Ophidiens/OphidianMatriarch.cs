using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ophidian corpse" )]
	public class OphidianMatriarch : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public OphidianMatriarch() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Reine Ophidiene";
			Body = 87;
			BaseSoundID = 644;

			SetStr( 416, 505 );
			SetDex( 96, 115 );
			SetInt( 366, 455 );

			SetHits( 500, 1000 );

			SetDamage( 20, 60 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Contondant, 50, 70);
            SetResistance(ResistanceType.Tranchant, 50, 70);
            SetResistance(ResistanceType.Perforant, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

			//SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 5.4, 25.0 );
			SetSkill( SkillName.Concentration, 90.1, 100.0 );
			SetSkill( SkillName.Tactiques, 50.1, 70.0 );
			SetSkill( SkillName.ArmePoing, 60.1, 80.0 );

			Fame = 16000;
			Karma = -16000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.Average, 2 );
            //AddLoot( LootPack.MedScrolls, 2 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
        public override int Bones { get { return 12; } }
        public override int Hides { get { return 15; } }
        public override HideType HideType { get { return HideType.Ophidien; } }
        public override BoneType BoneType { get { return BoneType.Ophidien; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public OphidianMatriarch( Serial serial ) : base( serial )
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