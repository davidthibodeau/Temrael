using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a liche's corpse" )]
	public class LichLord : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public LichLord() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a lich lord";
			Body = 24;
			BaseSoundID = 412;

			SetStr( 416, 505 );
			SetDex( 146, 165 );
			SetInt( 566, 655 );

			SetHits( 250, 500 );

			SetDamage( 20, 40 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Tranchant, 60 );
			SetDamageType( ResistanceType.Magie, 40 );

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Contondant, 40, 60);
            SetResistance(ResistanceType.Tranchant, 40, 60);
            SetResistance(ResistanceType.Perforant, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

			SetSkill( SkillName.Goetie, 90, 110.0 );
			//SetSkill( SkillName.SpiritSpeak, 90.0, 110.0 );

			//SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 150.5, 200.0 );
			SetSkill( SkillName.Tactiques, 50.1, 70.0 );
			SetSkill( SkillName.Anatomie, 60.1, 80.0 );

			PackNecroReg( 12, 20 );
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
            //AddLoot( LootPack.MedScrolls, 2 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 4; } }

		public LichLord( Serial serial ) : base( serial )
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