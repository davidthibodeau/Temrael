using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an abyssmal horror corpse" )]
	public class AbysmalHorror : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.MortalStrike : WeaponAbility.WhirlwindAttack;
		}

		public override bool IgnoreYoungProtection { get { return Core.ML; } }

		[Constructable]
		public AbysmalHorror() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an abyssmal horror";
			Body = 119;
			BaseSoundID = 0x451;

			SetStr( 401, 420 );
			SetDex( 81, 90 );
			SetInt( 401, 420 );

			SetHits( 6000 );

			SetDamage( 13, 17 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Perforant, 50 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Contondant, 100 );
			SetResistance( ResistanceType.Tranchant, 50, 55 );
			SetResistance( ResistanceType.Perforant, 60, 65 );
			SetResistance( ResistanceType.Magie, 77, 80 );

			//SetSkill( SkillName.EvalInt, 200.0 );
			SetSkill( SkillName.ArtMagique, 112.6, 117.5 );
			SetSkill( SkillName.Concentration, 200.0 );
			SetSkill( SkillName.Concentration, 117.6, 120.0 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.Anatomie, 84.1, 88.0 );

			Fame = 26000;
			Karma = -26000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
		}

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			//if ( !Summoned && !NoKillAwards && DemonKnight.CheckArtifactChance( this ) )
			//	DemonKnight.DistributeArtifact( this );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool AreaPeaceImmune { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		//public override int TreasureMapLevel{ get{ return 1; } }

		public AbysmalHorror( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 357 )
				BaseSoundID = 0x451;
		}
	}
}