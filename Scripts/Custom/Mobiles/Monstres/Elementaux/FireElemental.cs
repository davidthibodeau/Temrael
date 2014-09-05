using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Elemental de Feu" )]
	public class FireElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public FireElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Elemental de Feu";
            Body = 15;
			BaseSoundID = 838;

			SetStr( 126, 155 );
			SetDex( 166, 185 );
			SetInt( 101, 125 );

			SetHits( 150, 300 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Contondant, 75 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			//SetSkill( SkillName.EvalInt, 60.1, 75.0 );
			SetSkill( SkillName.ArtMagique, 60.1, 75.0 );
			SetSkill( SkillName.Concentration, 75.2, 105.0 );
			SetSkill( SkillName.Tactiques, 80.1, 100.0 );
			SetSkill( SkillName.Anatomie, 70.1, 100.0 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 50;
			ControlSlots = 4;

			PackItem( new SulfurousAsh( 3 ) );
            PackItem(new EclatDeVolcan(2));
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BleedImmune{ get{ return true; } }
		//public override int TreasureMapLevel{ get{ return 2; } }

		public FireElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 274 )
				BaseSoundID = 838;
		}
	}
}
