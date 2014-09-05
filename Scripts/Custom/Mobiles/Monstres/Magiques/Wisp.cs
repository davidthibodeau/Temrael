using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Factions;

namespace Server.Mobiles
{
	[CorpseName( "Wisp" )]
	public class Wisp : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Wisp; } }

		public override Faction FactionAllegiance{ get{ return CouncilOfMages.Instance; } }
		public override Ethics.Ethic EthicAllegiance { get { return Ethics.Ethic.Hero; } }

		public override TimeSpan ReacquireDelay { get { return TimeSpan.FromSeconds( 1.0 ); } }

		[Constructable]
		public Wisp() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Wisp";
			Body = 58;
			BaseSoundID = 466;

			SetStr( 196, 225 );
			SetDex( 196, 225 );
			SetInt( 196, 225 );

			SetHits( 100, 250 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Magie, 50 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.EvalInt, 80.0 );
			SetSkill( SkillName.ArtMagique, 80.0 );
			SetSkill( SkillName.Concentration, 80.0 );
			SetSkill( SkillName.Tactiques, 80.0 );
			SetSkill( SkillName.Anatomie, 80.0 );

			Fame = 4000;
			Karma = 0;

            Tamable = true;
            ControlSlots = 6;
            MinTameSkill = 80.0;

			//AddItem( new LightSource() );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public Wisp( Serial serial ) : base( serial )
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