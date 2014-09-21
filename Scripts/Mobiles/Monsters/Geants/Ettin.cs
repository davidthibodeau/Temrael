using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Ettin" )]
	public class Ettin : BaseCreature
	{
		[Constructable]
		public Ettin() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Ettin";
            Body = Utility.RandomList(2, 18);
			BaseSoundID = 367;

			SetStr( 136, 165 );
			SetDex( 56, 75 );
			SetInt( 31, 55 );

			SetHits( 200, 400 );

			SetDamage( 10, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 40.1, 55.0 );
			SetSkill( SkillName.Tactiques, 50.1, 70.0 );
			SetSkill( SkillName.Anatomie, 50.1, 60.0 );

			VirtualArmor = 40;
            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 50.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.5; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 4; } }
        public override int Bones { get { return 4; } }
        public override int Hides { get { return 8; } }
        public override HideType HideType { get { return HideType.Geant; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

		public Ettin( Serial serial ) : base( serial )
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