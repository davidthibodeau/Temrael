using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a bone demon corpse" )]
	public class BoneDemon : BaseCreature
	{
		[Constructable]
		public BoneDemon() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a bone demon";
			Body = 115;
			BaseSoundID = 0x48D;

			SetStr( 1000 );
			SetDex( 151, 175 );
			SetInt( 171, 220 );

			SetHits( 3600 );

			SetDamage( 34, 36 );

			SetDamageType( ResistanceType.Physical, 50 );

			SetResistance( ResistanceType.Physical, 75 );
			SetResistance( ResistanceType.Magie, 60 );

			SetSkill( SkillName.Detection, 80.0 );
			//SetSkill( SkillName.EvalInt, 77.6, 87.5 );
			SetSkill( SkillName.ArtMagique, 77.6, 87.5 );
			SetSkill( SkillName.Concentration, 100.0 );
			SetSkill( SkillName.Concentration, 50.1, 75.0 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.Anatomie, 100.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 8 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BardImmune { get { return !Core.SE; } }
		public override bool Unprovokable { get { return Core.SE; } }
		public override bool AreaPeaceImmune { get { return Core.SE; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		//public override int TreasureMapLevel{ get{ return 1; } }

		public BoneDemon( Serial serial ) : base( serial )
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