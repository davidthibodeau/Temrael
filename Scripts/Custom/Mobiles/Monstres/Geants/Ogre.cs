using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Ogre" )]
	public class Ogre : BaseCreature
	{
		[Constructable]
		public Ogre () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Ogre";
			Body = 1;
			BaseSoundID = 427;

			SetStr( 166, 195 );
			SetDex( 46, 65 );
			SetInt( 46, 70 );

			SetHits( 450, 600 );
			SetMana( 0 );

			SetDamage( 20, 40 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 10);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 55.1, 70.0 );
			SetSkill( SkillName.Tactiques, 60.1, 70.0 );
			SetSkill( SkillName.Anatomie, 70.1, 80.0 );

			Fame = 3000;
			Karma = -3000;

			VirtualArmor = 80;
            Tamable = true;
            ControlSlots = 5;
            MinTameSkill = 80.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 2; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 10; } }
        public override HideType HideType { get { return HideType.Geant; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

		public Ogre( Serial serial ) : base( serial )
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