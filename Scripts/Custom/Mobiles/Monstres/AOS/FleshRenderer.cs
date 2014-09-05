using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fleshrenderer corpse" )]
	public class FleshRenderer : BaseCreature
	{
		/*public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.Dismount : WeaponAbility.ParalyzingBlow;
		}

		public override bool IgnoreYoungProtection { get { return Core.ML; } }*/
        
		[Constructable]
		public FleshRenderer() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fleshrenderer";
			Body = 106;

			SetStr( 401, 460 );
			SetDex( 201, 210 );
			SetInt( 221, 260 );

			SetHits( 4500 );

			SetDamage( 16, 20 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Perforant, 20 );

			SetResistance( ResistanceType.Physical, 80, 90 );
			SetResistance( ResistanceType.Contondant, 50, 60 );
			SetResistance( ResistanceType.Tranchant, 50, 60 );
			SetResistance( ResistanceType.Perforant, 100 );
			SetResistance( ResistanceType.Magie, 70, 80 );

			SetSkill( SkillName.Detection, 80.0 );
			SetSkill( SkillName.Concentration, 155.1, 160.0 );
			SetSkill( SkillName.Concentration, 100.0 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.Anatomie, 90.1, 100.0 );

			Fame = 23000;
			Karma = -23000;
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
        public override double AttackSpeed { get { return 2.5; } }
		public override bool AutoDispel{ get{ return true; } }
		public override bool BardImmune { get { return !Core.SE; } }
		public override bool Unprovokable { get { return Core.SE; } }
		public override bool AreaPeaceImmune { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		//public override int TreasureMapLevel{ get{ return 1; } }

		public override int GetAttackSound()
		{
			return 0x34C;
		}

		public override int GetHurtSound()
		{
			return 0x354;
		}

		public override int GetAngerSound()
		{
			return 0x34C;
		}

		public override int GetIdleSound()
		{
			return 0x34C;
		}

		public override int GetDeathSound()
		{
			return 0x354;
		}

		public FleshRenderer( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 660 )
				BaseSoundID = -1;
		}
	}
}