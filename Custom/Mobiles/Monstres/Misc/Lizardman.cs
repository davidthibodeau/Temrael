using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "Corps de Lezard Geant" )]
	public class Lizardman : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		[Constructable]
		public Lizardman() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Lezard Geant";
			Body = Utility.RandomList( 33, 35, 36 );
			BaseSoundID = 417;

            ExpKillBonus = 8;

			SetStr( 96, 120 );
			SetDex( 86, 105 );
			SetInt( 36, 60 );

			SetHits( 150, 300 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.Concentration, 35.1, 60.0 );
			SetSkill( SkillName.Tactiques, 55.0, 80.0 );
			SetSkill( SkillName.ArmePoing, 50.0, 70.0 );

			Fame = 1500;
			Karma = -1500;

            Tamable = true;
            ControlSlots = 4;
            MinTameSkill = 70.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			// TODO: weapon
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Reptilien; } }
        public override BoneType BoneType { get { return BoneType.Reptilien; } }

		public Lizardman( Serial serial ) : base( serial )
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