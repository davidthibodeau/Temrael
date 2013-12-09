using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a reapers corpse" )]
	public class Reaper : BaseCreature
	{
		[Constructable]
		public Reaper() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a reaper";
			Body = 73;
			BaseSoundID = 442;

			SetStr( 66, 215 );
			SetDex( 66, 75 );
			SetInt( 101, 250 );

			SetHits( 300, 600 );
			SetStam( 0 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Perforant, 20 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			//SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			//SetSkill( SkillName.ArtMagique, 90.1, 100.0 );
			//SetSkill( SkillName.Concentration, 100.1, 125.0 );
			SetSkill( SkillName.Tactiques, 45.1, 60.0 );
			SetSkill( SkillName.ArmePoing, 50.1, 60.0 );

			Fame = 3500;
			Karma = -3500;

            ControlSlots = 12;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override int TreasureMapLevel{ get{ return 2; } }
		public override bool DisallowAllMoves{ get{ return true; } }

		public Reaper( Serial serial ) : base( serial )
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