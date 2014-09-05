using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a ghostly corpse" )]
	public class Spectre : BaseCreature
	{
		[Constructable]
		public Spectre() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Spectre";
			Body = 84;
			//Hue = 0x4001;
			BaseSoundID = 0x482;

			SetStr( 76, 100 );
			SetDex( 76, 95 );
			SetInt( 36, 60 );

			SetHits( 150, 300 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Tranchant, 50 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.EvalInt, 55.1, 70.0 );
			SetSkill( SkillName.ArtMagique, 55.1, 70.0 );
			SetSkill( SkillName.Concentration, 55.1, 70.0 );
			SetSkill( SkillName.Tactiques, 45.1, 60.0 );
			SetSkill( SkillName.Anatomie, 45.1, 55.0 );

			Fame = 4000;
			Karma = -4000;

			PackReg( 10 );

            ControlSlots = 3;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override bool BleedImmune{ get{ return true; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public Spectre( Serial serial ) : base( serial )
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