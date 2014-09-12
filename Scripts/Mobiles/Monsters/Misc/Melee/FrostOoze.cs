using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a frost ooze corpse" )]
	public class FrostOoze : BaseCreature
	{
		[Constructable]
		public FrostOoze() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a frost ooze";
            Body = 400;
			BaseSoundID = 456;

			SetStr( 18, 30 );
			SetDex( 16, 21 );
			SetInt( 16, 20 );

			SetHits( 13, 17 );

			SetDamage( 3, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Tranchant, 40, 50 );
			SetResistance( ResistanceType.Perforant, 20, 30 );
			SetResistance( ResistanceType.Magie, 10, 20 );

			SetSkill( SkillName.Concentration, 5.1, 10.0 );
			SetSkill( SkillName.Tactiques, 19.3, 34.0 );
			SetSkill( SkillName.Anatomie, 25.3, 40.0 );

			VirtualArmor = 38;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, Utility.RandomMinMax( 1, 2 ) );
		}

		public FrostOoze( Serial serial ) : base( serial )
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