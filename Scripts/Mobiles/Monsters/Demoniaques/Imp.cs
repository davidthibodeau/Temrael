using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Diablotin" )]
	public class Imp : BaseCreature
	{
		[Constructable]
		public Imp() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Diablotin";
			Body = 40;
			BaseSoundID = 422;

			SetStr( 91, 115 );
			SetDex( 61, 80 );
			SetInt( 86, 105 );

			SetHits( 200, 400 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Contondant, 50 );
			SetDamageType( ResistanceType.Perforant, 50 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.EvalInt, 20.1, 30.0 );
			SetSkill( SkillName.ArtMagique, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 30.1, 50.0 );
			SetSkill( SkillName.Tactiques, 42.1, 50.0 );
			SetSkill( SkillName.Anatomie, 40.1, 44.0 );

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 85.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			//AddLoot( LootPack.MedScrolls, 2 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.0; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 1; } }
		public override HideType HideType{ get{ return HideType.Demoniaque; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Daemon; } }

		public Imp( Serial serial ) : base( serial )
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