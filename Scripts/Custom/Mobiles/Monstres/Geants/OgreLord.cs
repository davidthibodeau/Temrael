using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Factions;

namespace Server.Mobiles
{
	[CorpseName( "Seigneur Ogre" )]
	public class OgreLord : BaseCreature
	{
		public override Faction FactionAllegiance { get { return Minax.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Evil; } }

		[Constructable]
		public OgreLord () : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Seigneur Ogre";
			Body = 1;
			BaseSoundID = 427;

			SetStr( 767, 945 );
			SetDex( 66, 75 );
			SetInt( 46, 70 );

			SetHits( 800, 1000 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			SetSkill( SkillName.Concentration, 125.1, 140.0 );
			SetSkill( SkillName.Tactiques, 90.1, 100.0 );
			SetSkill( SkillName.ArmePoing, 90.1, 100.0 );

			Fame = 15000;
			Karma = -15000;

			VirtualArmor = 90;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		//public override int TreasureMapLevel{ get{ return 3; } }
		public override int Meat{ get{ return 2; } }
        public override int Bones { get { return 10; } }
        public override int Hides { get { return 15; } }
        public override HideType HideType { get { return HideType.Geant; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

		public OgreLord( Serial serial ) : base( serial )
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