using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a gore fiend corpse" )]
	public class GoreFiend : BaseCreature
	{
		[Constructable]
		public GoreFiend() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gore fiend";
			Body = 111;
			BaseSoundID = 224;

			SetStr( 161, 185 );
			SetDex( 41, 65 );
			SetInt( 46, 70 );

			SetHits( 97, 111 );

			SetDamage( 15, 21 );

			SetDamageType( ResistanceType.Physical, 85 );

			SetResistance( ResistanceType.Physical, 35, 45 );
			SetResistance( ResistanceType.Magie, 30, 40 );

			SetSkill( SkillName.Concentration, 40.1, 55.0 );
			SetSkill( SkillName.Tactiques, 45.1, 70.0 );
			SetSkill( SkillName.Anatomie, 50.1, 70.0 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override int GetDeathSound()
		{
			return 1218;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BleedImmune{ get{ return true; } }

		public GoreFiend( Serial serial ) : base( serial )
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