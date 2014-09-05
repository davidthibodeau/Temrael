using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Cyclope" )]
	public class Cyclops : BaseCreature
	{
		[Constructable]
		public Cyclops() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Cyclope";
            Body = Utility.RandomList(75, 76);
			BaseSoundID = 604;

			SetStr( 336, 385 );
			SetDex( 96, 115 );
			SetInt( 31, 55 );

			SetHits( 500, 800 );
			SetMana( 0 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 10);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 60.3, 105.0 );
			SetSkill( SkillName.Tactiques, 80.1, 100.0 );
			SetSkill( SkillName.Anatomie, 80.1, 90.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 75;
            Tamable = true;
            ControlSlots = 6;
            MinTameSkill = 90.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override int Meat{ get{ return 4; } }
		//public override int TreasureMapLevel{ get{ return 3; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Geant; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

		public Cyclops( Serial serial ) : base( serial )
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