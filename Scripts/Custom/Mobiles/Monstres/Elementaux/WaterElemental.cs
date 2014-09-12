using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Elemental d'Eau" )]
	public class WaterElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public WaterElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Elemental d'Eau";
			Body = 16;
			BaseSoundID = 278;

			SetStr( 126, 155 );
			SetDex( 66, 85 );
			SetInt( 101, 125 );

			SetHits( 150, 300 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			//SetSkill( SkillName.EvalInt, 60.1, 75.0 );
			SetSkill( SkillName.ArtMagique, 60.1, 75.0 );
			SetSkill( SkillName.Concentration, 100.1, 115.0 );
			SetSkill( SkillName.Tactiques, 50.1, 70.0 );
			SetSkill( SkillName.Anatomie, 50.1, 70.0 );

			VirtualArmor = 55;
			ControlSlots = 3;
			CanSwim = true;

			PackItem( new BlackPearl( 3 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Potions );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override bool BleedImmune{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 2; } }

		public WaterElemental( Serial serial ) : base( serial )
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