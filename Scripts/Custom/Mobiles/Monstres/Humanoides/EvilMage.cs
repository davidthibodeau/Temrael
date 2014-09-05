using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "Corps d'Acolyte" )] 
	public class EvilMage : BaseCreature 
	{ 
		[Constructable] 
		public EvilMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Acolyte";
			Body = 146;

			SetStr( 81, 105 );
			SetDex( 91, 115 );
			SetInt( 96, 120 );

			SetHits( 100, 200 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			//SetSkill( SkillName.EvalInt, 75.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 75.1, 100.0 );
			SetSkill( SkillName.Concentration, 75.0, 97.5 );
			SetSkill( SkillName.Tactiques, 65.0, 87.5 );
			SetSkill( SkillName.Anatomie, 20.2, 60.0 );

			Fame = 2500;
			Karma = -2500;

			PackReg( 6 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
            //AddLoot( LootPack.MedScrolls );
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		//public override int TreasureMapLevel{ get{ return Core.AOS ? 1 : 0; } }

		public EvilMage( Serial serial ) : base( serial )
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