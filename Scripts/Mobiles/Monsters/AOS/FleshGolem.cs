using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a flesh golem corpse" )]
	public class FleshGolem : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public FleshGolem() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a flesh golem";
			Body = 112;
			BaseSoundID = 684;

			SetStr( 176, 200 );
			SetDex( 51, 75 );
			SetInt( 46, 70 );

			SetHits( 106, 120 );

			SetDamage( 18, 22 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Contondant, 25, 35 );
			SetResistance( ResistanceType.Tranchant, 15, 25 );
			SetResistance( ResistanceType.Perforant, 60, 70 );
			SetResistance( ResistanceType.Magie, 30, 40 );

			SetSkill( SkillName.Concentration, 50.1, 75.0 );
			SetSkill( SkillName.Tactiques, 55.1, 80.0 );
			SetSkill( SkillName.Anatomie, 60.1, 70.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override bool BleedImmune{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 1; } }

		public FleshGolem( Serial serial ) : base( serial )
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