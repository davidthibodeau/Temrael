using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a skeletal corpse" )]
	public class SkeletalMage : BaseCreature
	{
		[Constructable]
		public SkeletalMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Squelette Mage";
			Body = 82;
			BaseSoundID = 451;

			SetStr( 76, 100 );
			SetDex( 56, 75 );
			SetInt( 186, 210 );

			SetHits( 100, 200 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

            SetSkill(SkillName.Tactiques, 40.0, 60.0);
            SetSkill(SkillName.Anatomie, 40.0, 60.0);

			Fame = 3000;
			Karma = -3000;

			PackReg( 3 );
			PackNecroReg( 3, 10 );
			PackItem( new Bone() );

            ControlSlots = 4;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
            //AddLoot( LootPack.LowScrolls );
			AddLoot( LootPack.Potions );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BleedImmune{ get{ return true; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public SkeletalMage( Serial serial ) : base( serial )
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