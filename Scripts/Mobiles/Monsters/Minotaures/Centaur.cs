using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Centaure" )]
	public class Centaur : BaseCreature
	{
		[Constructable]
		public Centaur() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Centaure";
            Body = 136;
			BaseSoundID = 679;

			SetStr( 202, 300 );
			SetDex( 104, 260 );
			SetInt( 91, 100 );

			SetHits( 200, 400 );

			SetDamage( 10, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            
            
            
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.Anatomy, 95.1, 115.0 );
			SetSkill( SkillName.ArmeDistance, 95.1, 100.0 );
			SetSkill( SkillName.Concentration, 50.3, 80.0 );
			SetSkill( SkillName.Tactiques, 90.1, 100.0 );
			SetSkill( SkillName.Anatomie, 95.1, 100.0 );

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 70.0;
			PackItem( new Arrow( Utility.RandomMinMax( 1, 15 ) ) ); // OSI it is different: in a sub backpack, this is probably just a limitation of their engine
		}

        public override double AttackSpeed { get { return 2.5; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

        public override bool AlwaysMurderer { get { return true; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 1; } }
        public override int Hides { get { return 2; } }
        public override HideType HideType { get { return HideType.Minotaure; } }
        public override BoneType BoneType { get { return BoneType.Minotaure; } }

		public Centaur( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 678 )
				BaseSoundID = 679;
		}
	}
}