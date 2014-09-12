using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Homme-Rat" )]
	public class Ratman : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public Ratman() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Homme-Rat";
            Body = Utility.RandomList(42, 44, 45);
			BaseSoundID = 437;

			SetStr( 96, 120 );
			SetDex( 81, 100 );
			SetInt( 36, 60 );

			SetHits( 50, 150 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

			SetSkill( SkillName.Concentration, 35.1, 60.0 );
			SetSkill( SkillName.Tactiques, 40, 50 );
			SetSkill( SkillName.Anatomie, 40, 50 );

			VirtualArmor = 20;
            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 60.0;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override void GenerateLoot()
		{
            AddLoot( LootPack.Poor );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Regular; } }

		public Ratman( Serial serial ) : base( serial )
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