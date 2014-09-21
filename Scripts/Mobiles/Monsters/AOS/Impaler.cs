using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an impaler corpse" )]
	public class Impaler : BaseCreature
	{
		/*public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.MortalStrike : WeaponAbility.BleedAttack;
		}*/

		public override bool IgnoreYoungProtection { get { return Core.ML; } }

		[Constructable]
		public Impaler() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "impaler" );
			Body = 113;
			BaseSoundID = 0x2A7;

			SetStr( 190 );
			SetDex( 45 );
			SetInt( 190 );

			SetHits( 5000 );

			SetDamage( 31, 35 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 90 );
			SetResistance( ResistanceType.Magie, 100 );

			SetSkill( SkillName.Detection, 80.0 );
			SetSkill( SkillName.Concentration, 120.0 );
			SetSkill( SkillName.Empoisonnement, 160.0 );
			SetSkill( SkillName.Concentration, 100.0 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.Anatomie, 80.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 2 );
		}

		/*public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if ( !Summoned && !NoKillAwards && DemonKnight.CheckArtifactChance( this ) )
				DemonKnight.DistributeArtifact( this );
		}*/

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 1.5; } }
		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool AreaPeaceImmune { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }

		//public override int TreasureMapLevel{ get{ return 1; } }

		public Impaler( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 1200 )
				BaseSoundID = 0x2A7;
		}
	}
}