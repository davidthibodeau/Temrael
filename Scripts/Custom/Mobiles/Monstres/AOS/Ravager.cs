using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a ravager corpse" )]
	public class Ravager : BaseCreature
	{
		/*public override WeaponAbility GetWeaponAbility()
		{
			return Utility.RandomBool() ? WeaponAbility.Dismount : WeaponAbility.CrushingBlow;
		}*/

		[Constructable]
		public Ravager() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a ravager";
			Body = 105;
			BaseSoundID = 357;

			SetStr( 251, 275 );
			SetDex( 101, 125 );
			SetInt( 66, 90 );

			SetHits( 161, 175 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Contondant, 50, 60 );
			SetResistance( ResistanceType.Tranchant, 60, 70 );
			SetResistance( ResistanceType.Perforant, 30, 40 );
			SetResistance( ResistanceType.Magie, 20, 30 );

			SetSkill( SkillName.Concentration, 50.1, 75.0 );
			SetSkill( SkillName.Tactiques, 75.1, 100.0 );
			SetSkill( SkillName.ArmePoing, 70.1, 90.0 );

			Fame = 3500;
			Karma = -3500;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.0; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public Ravager( Serial serial ) : base( serial )
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