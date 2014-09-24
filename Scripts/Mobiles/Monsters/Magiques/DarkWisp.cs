using System;
using Server;
using Server.Misc;
using Server.Items;
using Server.Factions;

namespace Server.Mobiles
{
	[CorpseName( "Wisp" )]
	public class DarkWisp : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Wisp; } }
		public override TimeSpan ReacquireDelay { get { return TimeSpan.FromSeconds( 1.0 ); } }

		[Constructable]
		public DarkWisp() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Wisp";
			Body = 58;
			BaseSoundID = 466;

			SetStr( 196, 225 );
			SetDex( 196, 225 );
			SetInt( 196, 225 );

			SetHits( 100, 200 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Magie, 50 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			
			
			
			SetResistance( ResistanceType.Magie, 50, 70 );

			//SetSkill( SkillName.EvalInt, 80.0 );
			SetSkill( SkillName.ArtMagique, 80.0 );
			SetSkill( SkillName.Concentration, 80.0 );
			SetSkill( SkillName.Tactiques, 80.0 );
			SetSkill( SkillName.Anatomie, 80.0 );

			//AddItem( new LightSource() );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public override void GenerateLoot()
		{
            //AddLoot( LootPack.LowScrolls );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public DarkWisp( Serial serial )
			: base( serial )
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