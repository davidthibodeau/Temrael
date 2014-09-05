using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a crystal elemental corpse" )]
	public class CrystalElemental : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public CrystalElemental() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a crystal elemental";
			Body = 102;
			BaseSoundID = 278;

			SetStr( 136, 160 );
			SetDex( 51, 65 );
			SetInt( 86, 110 );

			SetHits( 150 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Magie, 20 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Contondant, 40, 50 );
			SetResistance( ResistanceType.Tranchant, 40, 50 );
			SetResistance( ResistanceType.Perforant, 100 );
			SetResistance( ResistanceType.Magie, 55, 70 );

			//SetSkill( SkillName.EvalInt, 70.1, 75.0 );
			SetSkill( SkillName.ArtMagique, 70.1, 75.0 );
			SetSkill( SkillName.Concentration, 65.1, 75.0 );
			SetSkill( SkillName.Concentration, 80.1, 90.0 );
			SetSkill( SkillName.Tactiques, 75.1, 85.0 );
			SetSkill( SkillName.Anatomie, 65.1, 75.0 );

			Fame = 6500;
			Karma = -6500;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		//public override int TreasureMapLevel{ get{ return 1; } }

		public CrystalElemental( Serial serial ) : base( serial )
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