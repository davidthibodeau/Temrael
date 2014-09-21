using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a devourer of souls corpse" )]
	public class Devourer : BaseCreature
	{
		[Constructable]
		public Devourer() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a devourer of souls";
			Body = 104;
			BaseSoundID = 357;

			SetStr( 801, 950 );
			SetDex( 126, 175 );
			SetInt( 201, 250 );

			SetHits( 650 );

			SetDamage( 22, 26 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Magie, 20 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Magie, 40, 50 );

			//SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 90.1, 105.0 );
			SetSkill( SkillName.Tactiques, 75.1, 85.0 );
			SetSkill( SkillName.Anatomie, 80.1, 100.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int Meat{ get{ return 3; } }

		public Devourer( Serial serial ) : base( serial )
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