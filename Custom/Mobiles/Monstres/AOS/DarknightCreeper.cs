using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a darknight creeper corpse" )]
	public class DarknightCreeper : BaseCreature
	{
		public override bool IgnoreYoungProtection { get { return Core.ML; } }

		[Constructable]
		public DarknightCreeper() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "darknight creeper" );
			Body = 120;
			BaseSoundID = 0xE0;

			SetStr( 301, 330 );
			SetDex( 101, 110 );
			SetInt( 301, 330 );

			SetHits( 4000 );

			SetDamage( 22, 26 );

			SetDamageType( ResistanceType.Physical, 85 );
			SetDamageType( ResistanceType.Perforant, 15 );

			SetResistance( ResistanceType.Physical, 60 );
			SetResistance( ResistanceType.Contondant, 60 );
			SetResistance( ResistanceType.Tranchant, 100 );
			SetResistance( ResistanceType.Perforant, 90 );
			SetResistance( ResistanceType.Magie, 75 );

			SetSkill( SkillName.Detection, 80.0 );
			//SetSkill( SkillName.EvalInt, 118.1, 120.0 );
			SetSkill( SkillName.ArtMagique, 112.6, 120.0 );
			SetSkill( SkillName.Concentration, 150.0 );
			SetSkill( SkillName.Empoisonner, 120.0 );
			SetSkill( SkillName.Concentration, 90.1, 90.9 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.ArmePoing, 90.1, 90.9 );

			Fame = 22000;
			Karma = -22000;
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
        public override double AttackSpeed { get { return 3.5; } }
		public override bool BardImmune{ get{ return !Core.SE; } }
		public override bool Unprovokable{ get{ return Core.SE; } }
		public override bool AreaPeaceImmune { get { return Core.SE; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

		//public override int TreasureMapLevel{ get{ return 1; } }

		public DarknightCreeper( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 471 )
				BaseSoundID = 0xE0;
		}
	}
}