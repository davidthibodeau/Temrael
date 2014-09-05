using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an arcane daemon corpse" )]
	public class ArcaneDaemon : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ConcussionBlow;
		}

		[Constructable]
		public ArcaneDaemon() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an arcane daemon";
			Body = 0x310;
			BaseSoundID = 0x47D;

			SetStr( 131, 150 );
			SetDex( 126, 145 );
			SetInt( 301, 350 );

			SetHits( 101, 115 );

			SetDamage( 12, 16 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Contondant, 20 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Contondant, 70, 80 );
			SetResistance( ResistanceType.Tranchant, 10, 20 );
			SetResistance( ResistanceType.Perforant, 50, 60 );
			SetResistance( ResistanceType.Magie, 30, 40 );

			SetSkill( SkillName.Concentration, 85.1, 95.0 );
			SetSkill( SkillName.Tactiques, 70.1, 80.0 );
			SetSkill( SkillName.Anatomie, 60.1, 80.0 );
			SetSkill( SkillName.ArtMagique, 80.1, 90.0 );
			//SetSkill( SkillName.EvalInt, 70.1, 80.0 );
			SetSkill( SkillName.Concentration, 70.1, 80.0 );

			Fame = 7000;
			Karma = -10000;

			VirtualArmor = 55;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }

		public ArcaneDaemon( Serial serial ) : base( serial )
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