using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an inhuman corpse" )]
	public class Cursed : BaseCreature
	{
		public override bool ClickTitle{ get{ return false; } }
		public override bool ShowFameTitle{ get{ return false; } }

		[Constructable]
		public Cursed() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Title = "the Cursed";

			Hue = Utility.RandomMinMax( 0x8596, 0x8599 );
			Body = 0x190;
			Name = NameList.RandomName( "male" );
			BaseSoundID = 471;

			AddItem( new ShortPants( Utility.RandomNeutralHue() ) );
			AddItem( new Shirt( Utility.RandomNeutralHue() ) );

			BaseWeapon weapon = Loot.RandomWeapon();
			weapon.Movable = false;
			AddItem( weapon );

			SetStr( 91, 100 );
			SetDex( 86, 95 );
			SetInt( 61, 70 );

			SetHits( 91, 120 );

			SetDamage( 5, 13 );

			SetResistance( ResistanceType.Physical, 15, 25 );
			SetResistance( ResistanceType.Contondant, 5, 10 );
			SetResistance( ResistanceType.Tranchant, 25, 35 );
			SetResistance( ResistanceType.Perforant, 5, 10 );
			SetResistance( ResistanceType.Magie, 5, 10 );

			SetSkill( SkillName.ArmePerforante, 46.0, 77.5 );
			SetSkill( SkillName.ArmeContondante, 35.0, 57.5 );
			SetSkill( SkillName.Concentration, 53.5, 62.5 );
			SetSkill( SkillName.ArmeTranchante, 55.0, 77.5 );
			SetSkill( SkillName.Tactiques, 60.0, 82.5 );
			SetSkill( SkillName.Empoisonner, 60.0, 82.5 );

			Fame = 1000;
			Karma = -2000;
		}

		public override int GetAttackSound()
		{
			return -1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			//AddLoot( LootPack.Miscellaneous );
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public Cursed( Serial serial ) : base( serial )
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