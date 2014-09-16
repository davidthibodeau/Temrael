using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Homme-Rat" )]
	public class RatmanMage : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public RatmanMage() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Homme-Rat Mage";
			Body = 42;
			BaseSoundID = 437;

			SetStr( 146, 180 );
			SetDex( 101, 130 );
			SetInt( 186, 210 );

			SetHits( 50, 100 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

			//SetSkill( SkillName.EvalInt, 70.1, 80.0 );
			SetSkill( SkillName.ArtMagique, 70.1, 80.0 );
			SetSkill( SkillName.Concentration, 65.1, 90.0 );
            SetSkill(SkillName.Tactiques, 40, 50);
            SetSkill(SkillName.Anatomie, 40, 50);

			VirtualArmor = 10;

			PackReg( 6 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override void GenerateLoot()
		{
            AddLoot(LootPack.Poor);
            //AddLoot( LootPack.LowScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Regular; } }

		public RatmanMage( Serial serial ) : base( serial )
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
