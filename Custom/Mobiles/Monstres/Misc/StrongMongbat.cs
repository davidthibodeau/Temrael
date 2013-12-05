using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
    [CorpseName("Corps de Chauve-Souris des Cavernes")]
	public class StrongMongbat : BaseCreature
	{
		[Constructable]
		public StrongMongbat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
            Name = "Chauve-Souris des Cavernes Ancienne";
			Body = 39;
			BaseSoundID = 422;

			SetStr( 6, 10 );
			SetDex( 26, 38 );
			SetInt( 6, 14 );

			SetHits( 150, 300 );
			SetMana( 0 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 15.1, 30.0 );
			SetSkill( SkillName.Tactiques, 35.1, 50.0 );
			SetSkill( SkillName.ArmePoing, 20.1, 35.0 );

			Fame = 150;
			Karma = -150;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 71.1;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 6; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public StrongMongbat( Serial serial ) : base( serial )
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