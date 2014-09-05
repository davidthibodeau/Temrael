using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Elemental de Terre" )]
	public class EarthElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public EarthElemental() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Elemental de Terre";
			Body = 14;
			BaseSoundID = 268;

			SetStr( 126, 155 );
			SetDex( 66, 85 );
			SetInt( 71, 92 );

			SetHits( 200, 400 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 50.1, 95.0 );
			SetSkill( SkillName.Tactiques, 60.1, 100.0 );
			SetSkill( SkillName.Anatomie, 60.1, 100.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 40;
			ControlSlots = 2;

			//PackItem( new FertileDirt( Utility.RandomMinMax( 1, 4 ) ) );
			PackItem( new MandrakeRoot() );
			
			Item ore = new FerOre( 5 );
			ore.ItemID = 0x19B7;
			PackItem( ore );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BleedImmune{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 1; } }

		public EarthElemental( Serial serial ) : base( serial )
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