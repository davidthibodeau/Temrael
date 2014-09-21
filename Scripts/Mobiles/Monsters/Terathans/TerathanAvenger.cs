using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Terathan Vengeuse" )]
	public class TerathanAvenger : BaseCreature
	{
		[Constructable]
		public TerathanAvenger() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Terathan Vengeuse";
			Body = 167;
			BaseSoundID = 0x24D;

			SetStr( 467, 645 );
			SetDex( 77, 95 );
			SetInt( 126, 150 );

			SetHits( 300, 600 );
			SetMana( 46, 70 );

			SetDamage( 30, 60 );

			SetDamageType( ResistanceType.Physical, 50 );
			

            SetResistance(ResistanceType.Physical, 30, 50);
            
            
            
            SetResistance(ResistanceType.Magie, 30, 50);

			//SetSkill( SkillName.EvalInt, 70.3, 100.0 );
			SetSkill( SkillName.ArtMagique, 70.3, 100.0 );
			SetSkill( SkillName.Empoisonnement, 60.1, 80.0 );
			SetSkill( SkillName.Concentration, 65.1, 80.0 );
			SetSkill( SkillName.Tactiques, 90.1, 100.0 );
			SetSkill( SkillName.Anatomie, 90.1, 100.0 );

			VirtualArmor = 50;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		//public override int TreasureMapLevel{ get{ return 3; } }
		public override int Meat{ get{ return 2; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Arachnide; } }
        public override BoneType BoneType { get { return BoneType.Arachnide; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public TerathanAvenger( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 0x24D;
		}
	}
}
