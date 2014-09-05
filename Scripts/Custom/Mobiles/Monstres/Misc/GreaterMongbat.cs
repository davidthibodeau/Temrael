using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Chauve-Souris des Cavernes" )]
	public class GreaterMongbat : BaseCreature
	{
		[Constructable]
		public GreaterMongbat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Grande Chauve-Souris des Cavernes";
			Body = 39;
			BaseSoundID = 422;

			SetStr( 56, 80 );
			SetDex( 61, 80 );
			SetInt( 26, 50 );

			SetHits( 100, 200 );
			SetStam( 61, 80);
			SetMana( 26, 50 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 15.1, 30.0 );
			SetSkill( SkillName.Tactiques, 35.1, 50.0 );
			SetSkill( SkillName.Anatomie, 20.1, 35.0 );

			Fame = 450;
			Karma = -450;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 71.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public GreaterMongbat( Serial serial ) : base( serial )
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
