using System; 
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "Nécromancien" )] 
	public class EvilMageLord : BaseCreature 
	{ 
		[Constructable] 
		public EvilMageLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = "Seigneur Nécromancien";
            Body = 147;

			PackItem( new Robe( Utility.RandomMetalHue() ) ); 
			PackItem( new WizardsHat( Utility.RandomMetalHue() ) ); 

			SetStr( 81, 105 );
			SetDex( 191, 215 );
			SetInt( 126, 150 );

			SetHits( 200, 400 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			//SetSkill( SkillName.EvalInt, 80.2, 100.0 );
			SetSkill( SkillName.ArtMagique, 95.1, 100.0 );
			SetSkill( SkillName.Concentration, 27.5, 50.0 );
			SetSkill( SkillName.Concentration, 77.5, 100.0 );
			SetSkill( SkillName.Tactiques, 65.0, 87.5 );
			SetSkill( SkillName.Anatomie, 20.3, 80.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Meager );
            //AddLoot( LootPack.MedScrolls, 2 );
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		//public override int TreasureMapLevel{ get{ return Core.AOS ? 2 : 0; } }

		public EvilMageLord( Serial serial ) : base( serial ) 
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