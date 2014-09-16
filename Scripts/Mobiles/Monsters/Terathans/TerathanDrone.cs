using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "Terathan" )]
	public class TerathanDrone : BaseCreature
	{
		[Constructable]
		public TerathanDrone() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Terathan";
			Body = 71;
			BaseSoundID = 594;

            ExpKillBonus = 5;

			SetStr( 36, 65 );
			SetDex( 96, 145 );
			SetInt( 21, 45 );

			SetHits( 100, 225 );
			SetMana( 0 );

			SetDamage( 5, 15 );

            SetDamageType(ResistanceType.Physical, 50);
            SetDamageType(ResistanceType.Contondant, 75);

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

			SetSkill( SkillName.Empoisonnement, 40.0, 60.0 );
			//SetSkill( SkillName.Concentration, 30.0, 45.0 );
			SetSkill( SkillName.Tactiques, 20.0, 40.0 );
			SetSkill( SkillName.Anatomie, 40.0, 70.0 );

			VirtualArmor = 20;
			
			PackItem( new SpidersSilk( 2 ) );
            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 65.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
			// TODO: weapon?
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat{ get{ return 4; } }
        public override int Bones { get { return 2; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Arachnide; } }
        public override BoneType BoneType { get { return BoneType.Arachnide; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public TerathanDrone( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 589 )
				BaseSoundID = 594;
		}
	}
}