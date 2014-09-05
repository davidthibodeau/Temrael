using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Homme-Rat" )]
	public class RatmanArcher : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public RatmanArcher() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Homme-Rat Archer";
			Body = 42;
			BaseSoundID = 437;

			SetStr( 146, 180 );
			SetDex( 101, 130 );
			SetInt( 116, 140 );

			SetHits( 50, 150 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

			//SetSkill( SkillName.Anatomy, 60.2, 100.0 );
			SetSkill( SkillName.ArmeDistance, 40, 50 );
			SetSkill( SkillName.Concentration, 65.1, 90.0 );
			SetSkill( SkillName.Tactiques, 40, 50 );
			SetSkill( SkillName.Anatomie, 40, 50 );

			Fame = 6500;
			Karma = -6500;

			VirtualArmor = 10;

			PackItem( new Arrow( Utility.RandomMinMax( 1, 5 ) ) );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override void GenerateLoot()
		{
            AddLoot(LootPack.Poor);
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Regular; } }

		public RatmanArcher( Serial serial ) : base( serial )
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

            Body = 42;
			Hue = 0;
		}
	}
}
