using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Troll" )]
	public class Troll : BaseCreature
	{
		[Constructable]
		public Troll () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Troll";
			Body = Utility.RandomList( 53, 54, 55 );
			BaseSoundID = 461;

			SetStr( 176, 205 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 300, 500 );

			SetDamage( 10, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 45.1, 60.0 );
			SetSkill( SkillName.Tactiques, 50.1, 70.0 );
			SetSkill( SkillName.Anatomie, 50.1, 70.0 );

			Fame = 3500;
			Karma = -3500;

			VirtualArmor = 50;
            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 60.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 3 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 2; } }
        public override int Bones { get { return 3; } }
        public override int Hides { get { return 5; } }
        public override HideType HideType { get { return HideType.Geant; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

		public Troll( Serial serial ) : base( serial )
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