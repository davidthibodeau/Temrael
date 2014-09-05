using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Bourbier" )]
	public class Quagmire : BaseCreature
	{
		[Constructable]
		public Quagmire() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "Bourbier";
            Body = 161;
			BaseSoundID = 352;

			SetStr( 101, 130 );
			SetDex( 66, 85 );
			SetInt( 31, 55 );

			SetHits( 150, 300 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Perforant, 40 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 65.1, 75.0 );
			SetSkill( SkillName.Tactiques, 50.1, 60.0 );
			SetSkill( SkillName.Anatomie, 60.1, 80.0 );

			Fame = 1500;
			Karma = -1500;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int GetAngerSound()
		{
			return 353;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.1; } }

		public Quagmire( Serial serial ) : base( serial )
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

			if ( BaseSoundID == -1 )
				BaseSoundID = 352;
		}
	}
}