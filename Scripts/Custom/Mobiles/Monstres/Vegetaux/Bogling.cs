using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Marode" )]
	public class Bogling : BaseCreature
	{
		[Constructable]
		public Bogling() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Marode";
			Body = 34;
			BaseSoundID = 422;

			SetStr( 96, 120 );
			SetDex( 91, 115 );
			SetInt( 21, 45 );

			SetHits( 150, 300 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 0, 10);
            SetResistance(ResistanceType.Contondant, 0, 10);
            SetResistance(ResistanceType.Tranchant, 0, 10);
            SetResistance(ResistanceType.Perforant, 0, 10);
            SetResistance(ResistanceType.Magie, 0, 10);

			SetSkill( SkillName.Concentration, 75.1, 100.0 );
			SetSkill( SkillName.Tactiques, 55.1, 80.0 );
			SetSkill( SkillName.ArmePoing, 55.1, 75.0 );

			Fame = 450;
			Karma = -450;

			PackItem( new Log( 4 ) );

            PackItem(new Fumier(1));
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int Meat{ get{ return 1; } }

		public Bogling( Serial serial ) : base( serial )
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