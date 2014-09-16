using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a liche's corpse" )]
	public class Lich : BaseCreature
	{
		[Constructable]
		public Lich() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Liche";
			Body = 24;
			BaseSoundID = 0x3E9;

			SetStr( 171, 200 );
			SetDex( 126, 145 );
			SetInt( 276, 305 );

			SetHits( 300, 600 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 10 );
			SetDamageType( ResistanceType.Tranchant, 40 );
			SetDamageType( ResistanceType.Magie, 50 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			SetSkill( SkillName.Goetie, 89, 99.1 );
			//SetSkill( SkillName.SpiritSpeak, 90.0, 99.0 );

			//SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.ArtMagique, 70.1, 80.0 );
			SetSkill( SkillName.Concentration, 85.1, 95.0 );
			SetSkill( SkillName.Concentration, 80.1, 100.0 );
			SetSkill( SkillName.Tactiques, 70.1, 90.0 );

			PackNecroReg( 10, 15 );

            ControlSlots = 8;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
            //AddLoot( LootPack.MedScrolls, 2 );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 3; } }

		public Lich( Serial serial ) : base( serial )
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