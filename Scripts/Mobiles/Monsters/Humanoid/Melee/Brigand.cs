using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;

namespace Server.Mobiles
{
	public class Brigand : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }

		[Constructable]
		public Brigand() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SpeechHue = Utility.RandomDyedHue();
			Title = "the brigand";
			Hue = Utility.RandomSkinHue();

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 0x191;
				Name = NameList.RandomName( "female" );
				AddItem( new Skirt( Utility.RandomNeutralHue() ) );
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
			}

			SetStr( 86, 100 );
			SetDex( 40, 60 );
			SetInt( 61, 75 );

			SetDamage( 10, 23 );

			SetSkill( SkillName.ArmePerforante, 66.0, 97.5 );
			SetSkill( SkillName.ArmeContondante, 65.0, 87.5 );
			SetSkill( SkillName.Concentration, 25.0, 47.5 );
			SetSkill( SkillName.ArmeTranchante, 65.0, 87.5 );
			SetSkill( SkillName.Tactiques, 65.0, 87.5 );
			SetSkill( SkillName.Anatomie, 15.0, 37.5 );

			AddItem( new Boots( Utility.RandomNeutralHue() ) );
			AddItem( new FancyShirt());
			AddItem( new Bandana());

			switch ( Utility.Random( 7 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Broadsword() ); break;
				case 3: AddItem( new Axe() ); break;
				case 4: AddItem( new Club() ); break;
				case 5: AddItem( new Dagger() ); break;
				case 6: AddItem( new Spear() ); break;
			}

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override bool AlwaysMurderer{ get{ return true; } }
        public override double AttackSpeed { get { return 4.0; } }

		public Brigand( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}