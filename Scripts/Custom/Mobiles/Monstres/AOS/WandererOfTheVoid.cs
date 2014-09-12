using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wanderer of the void corpse" )]
	public class WandererOfTheVoid : BaseCreature
	{
		[Constructable]
		public WandererOfTheVoid() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wanderer of the void";
			Body = 107;
			BaseSoundID = 377;

			SetStr( 111, 200 );
			SetDex( 101, 125 );
			SetInt( 301, 390 );

			SetHits( 351, 400 );

			SetDamage( 11, 13 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Tranchant, 15 );
			SetDamageType( ResistanceType.Magie, 85 );

			SetResistance( ResistanceType.Physical, 40, 50 );
			SetResistance( ResistanceType.Contondant, 15, 25 );
			SetResistance( ResistanceType.Tranchant, 40, 50 );
			SetResistance( ResistanceType.Perforant, 50, 75 );
			SetResistance( ResistanceType.Magie, 40, 50 );

			//SetSkill( SkillName.EvalInt, 60.1, 70.0 );
			SetSkill( SkillName.ArtMagique, 60.1, 70.0 );
			SetSkill( SkillName.Concentration, 60.1, 70.0 );
			SetSkill( SkillName.Concentration, 50.1, 75.0 );
			SetSkill( SkillName.Tactiques, 60.1, 70.0 );
			SetSkill( SkillName.Anatomie, 60.1, 70.0 );

			int count = Utility.RandomMinMax( 2, 3 );

			/*for ( int i = 0; i < count; ++i )
				PackItem( new TreasureMap( 3, Map.Trammel ) );*/
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		//public override int TreasureMapLevel{ get{ return Core.AOS ? 4 : 1; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

		public WandererOfTheVoid( Serial serial ) : base( serial )
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