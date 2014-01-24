using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Gargouille de Fer" )]
	public class StoneGargoyle : BaseCreature
	{
		[Constructable]
		public StoneGargoyle() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Gargouille de Fer";
			Body = 66;
			BaseSoundID = 0x174;

			SetStr( 246, 275 );
			SetDex( 76, 95 );
			SetInt( 81, 105 );

			SetHits( 400, 800 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 85.1, 100.0 );
			SetSkill( SkillName.Tactiques, 80.1, 100.0 );
			SetSkill( SkillName.ArmePoing, 60.1, 100.0 );

			Fame = 4000;
			Karma = -4000;

			PackItem( new FerIngot( 12 ) );
		}

		public override void GenerateLoot()
		{
            AddLoot(LootPack.Average);
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.5; } }
		//public override int TreasureMapLevel{ get{ return 2; } }

		public StoneGargoyle( Serial serial ) : base( serial )
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