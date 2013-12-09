using System; 
using Server;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "a golem controller corpse" )] 
	public class GolemController : BaseCreature 
	{ 
		[Constructable] 
		public GolemController() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 ) 
		{ 
			Name = NameList.RandomName( "golem controller" );
			Title = "the controller";

			Body = 400;
			Hue = 0x455;

			AddArcane( new Robe() );
			AddArcane( new ThighBoots() );
			AddArcane( new LeatherGloves() );
			AddArcane( new Cloak() );

			SetStr( 126, 150 );
			SetDex( 96, 120 );
			SetInt( 151, 175 );

			SetHits( 76, 90 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30, 40 );
			SetResistance( ResistanceType.Contondant, 25, 35 );
			SetResistance( ResistanceType.Tranchant, 35, 45 );
			SetResistance( ResistanceType.Perforant, 5, 15 );
			SetResistance( ResistanceType.Magie, 15, 25 );

			//SetSkill( SkillName.EvalInt, 95.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 95.1, 100.0 );
			SetSkill( SkillName.Concentration, 95.1, 100.0 );
			SetSkill( SkillName.Concentration, 102.5, 125.0 );
			SetSkill( SkillName.Tactiques, 65.0, 87.5 );
			SetSkill( SkillName.ArmePoing, 65.0, 87.5 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 16;

			if ( 0.7 > Utility.RandomDouble() )
				PackItem( new ArcaneGem() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public void AddArcane( Item item )
		{
			if ( item is IArcaneEquip )
			{
				IArcaneEquip eq = (IArcaneEquip)item;
				eq.CurArcaneCharges = eq.MaxArcaneCharges = 20;
			}

			item.Hue = ArcaneGem.DefaultArcaneHue;
			item.LootType = LootType.Newbied;

			AddItem( item );
		}

		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public GolemController( Serial serial ) : base( serial ) 
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