using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a giant toad corpse" )]
	[TypeAlias( "Server.Mobiles.Gianttoad" )]
	public class GiantToad : BaseCreature
	{
		[Constructable]
		public GiantToad() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a giant toad";
			Body = 80;
			BaseSoundID = 0x26B;

			SetStr( 76, 100 );
			SetDex( 6, 25 );
			SetInt( 11, 20 );

			SetHits( 46, 60 );
			SetMana( 0 );

			SetDamage( 5, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Contondant, 5, 10 );
			SetResistance( ResistanceType.Magie, 5, 10 );

			SetSkill( SkillName.Concentration, 25.1, 40.0 );
			SetSkill( SkillName.Tactiques, 40.1, 60.0 );
			SetSkill( SkillName.ArmePoing, 40.1, 60.0 );

			Fame = 750;
			Karma = -750;

			VirtualArmor = 24;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 40.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override int Hides{ get{ return 6; } }
		public override HideType HideType{ get{ return HideType.Regular; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public GiantToad(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 1);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			if ( version < 1 )
			{
					AI = AIType.AI_Melee;
					FightMode = FightMode.Closest;
			}
		}
	}
}