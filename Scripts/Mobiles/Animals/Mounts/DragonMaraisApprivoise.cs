using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "Dragon Apprivois�" )]
	public class DragonMaraisApprivoise : BaseMount
	{
		[Constructable]
		public DragonMaraisApprivoise() : this( "Dragon Apprivois�" )
		{
		}

		[Constructable]
		public DragonMaraisApprivoise( string name ) : base( name, 0xF4, 0x3EB2, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 201, 300 );
			SetDex( 66, 85 );
			SetInt( 61, 100 );

			SetHits( 121, 180 );

			SetDamage( 3, 4 );

			SetDamageType( ResistanceType.Physical, 75 );

			SetResistance( ResistanceType.Physical, 35, 40 );
			SetResistance( ResistanceType.Magie, 30, 40 );

			//SetSkill( SkillName.Anatomy, 45.1, 55.0 );
			SetSkill( SkillName.Concentration, 45.1, 55.0 );
			SetSkill( SkillName.Tactiques, 45.1, 55.0 );
			SetSkill( SkillName.Anatomie, 45.1, 55.0 );

			Tamable = true;
			ControlSlots = 2;
			MinTameSkill = 95.0;
		}

		public override double GetControlChance( Mobile m, bool useBaseSkill )
		{
			return 1.0;
		}

		public override bool AutoDispel{ get{ return !Controlled; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

        public DragonMaraisApprivoise(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}