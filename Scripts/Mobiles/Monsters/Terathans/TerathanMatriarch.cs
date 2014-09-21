using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Terathan Matriarche" )]
	public class TerathanMatriarch : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public TerathanMatriarch() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Terathan Matriarche";
			Body = 72;
			BaseSoundID = 599;

            ExpKillBonus = 50;

			SetStr( 315, 400 );
			SetDex( 95, 115 );
			SetInt( 350, 450 );

			SetHits( 500, 1000 );

			SetDamage( 20, 80 );

			SetDamageType( ResistanceType.Physical, 50 );
            

            SetResistance(ResistanceType.Physical, 40, 60);
            
            
            
            SetResistance(ResistanceType.Magie, 40, 60);

			//SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 90.0, 100.0 );
			SetSkill( SkillName.Concentration, 90.0, 100.0 );
			SetSkill( SkillName.Tactiques, 70.0, 95.0 );
			SetSkill( SkillName.Anatomie, 60.0, 90.0 );
            SetSkill(SkillName.Empoisonnement, 60.0, 100.0);


            VirtualArmor = 60;

			PackItem( new SpidersSilk( 5 ) );
			PackNecroReg( Utility.RandomMinMax( 4, 10 ) );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Meat { get { return 8; } }
        public override int Bones { get { return 15; } }
        public override int Hides { get { return 8; } }
        public override HideType HideType { get { return HideType.Arachnide; } }
        public override BoneType BoneType { get { return BoneType.Arachnide; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
            //AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.Potions );
		}

		//public override int TreasureMapLevel{ get{ return 4; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public TerathanMatriarch( Serial serial ) : base( serial )
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