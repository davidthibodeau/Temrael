using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Monture Mort-Vivante" )]
	public class MontureMortVivante : BaseMount
	{
		[Constructable]
        public MontureMortVivante()
            : this("Monture Mort-Vivante")
		{
		}

		[Constructable]
		public MontureMortVivante( string name ) : base( name, 241, 0x3EAA, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 91, 100 );
			SetDex( 46, 55 );
			SetInt( 46, 60 );

			SetHits( 41, 50 );

			SetDamage( 5, 12 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Tranchant, 50 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Tranchant, 90, 95 );
			SetResistance( ResistanceType.Perforant, 100 );
			SetResistance( ResistanceType.Magie, 10, 15 );

			SetSkill( SkillName.Concentration, 95.1, 100.0 );
			SetSkill( SkillName.Tactiques, 50.0 );
			SetSkill( SkillName.Anatomie, 70.1, 80.0 );

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 97.0;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

        public MontureMortVivante(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch( version )
			{
				case 0:
				{
					Name = "a skeletal steed";
					Tamable = false;
					MinTameSkill = 0.0;
					ControlSlots = 0;
					break;
				}
			}
		}
	}
}