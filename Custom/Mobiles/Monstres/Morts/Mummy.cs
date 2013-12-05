using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a mummy corpse" )]
	public class Mummy : BaseCreature
	{
		[Constructable]
		public Mummy() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "a mummy";
			Body = 159;
			BaseSoundID = 471;

			SetStr( 346, 370 );
			SetDex( 71, 90 );
			SetInt( 26, 40 );

			SetHits( 300, 600 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 40 );
			SetDamageType( ResistanceType.Tranchant, 60 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 15.1, 40.0 );
			SetSkill( SkillName.Tactiques, 35.1, 50.0 );
			SetSkill( SkillName.ArmePoing, 35.1, 50.0 );

			Fame = 4000;
			Karma = -4000;

			PackItem( new Garlic( 5 ) );
			PackItem( new Bandage( 10 ) );

            ControlSlots = 6;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Gems );
			AddLoot( LootPack.Potions );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lesser; } }

		public Mummy( Serial serial ) : base( serial )
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