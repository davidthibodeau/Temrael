using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "Terathan Guerrier" )]
	public class TerathanWarrior : BaseCreature
	{
		[Constructable]
		public TerathanWarrior() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Terathan Guerrier";
			Body = 70;
			BaseSoundID = 589;

            ExpKillBonus = 10;

			SetStr( 150, 215 );
			SetDex( 95, 145 );
			SetInt( 40, 65 );

			SetHits( 150, 300 );
			SetMana( 0 );

			SetDamage( 15, 30 );

            SetDamageType(ResistanceType.Physical, 50);

            SetResistance(ResistanceType.Physical, 20, 40);
            
            
            
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Empoisonnement, 60.0, 100.0 );
			//SetSkill( SkillName.Concentration, 60.0, 75.0 );
			SetSkill( SkillName.Tactiques, 70.0, 90.0 );
			SetSkill( SkillName.Anatomie, 80.0, 100.0 );

			VirtualArmor = 50;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 4; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 3; } }
        public override HideType HideType { get { return HideType.Arachnide; } }
        public override BoneType BoneType { get { return BoneType.Arachnide; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public TerathanWarrior( Serial serial ) : base( serial )
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