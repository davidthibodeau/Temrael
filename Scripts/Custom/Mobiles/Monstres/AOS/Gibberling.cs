using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a gibberling corpse" )]
	public class Gibberling : BaseCreature
	{
		/*public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}*/

		[Constructable]
		public Gibberling() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a gibberling";
			Body = 114;
			BaseSoundID = 422;

			SetStr( 141, 165 );
			SetDex( 101, 125 );
			SetInt( 56, 80 );

			SetHits( 85, 99 );

			SetDamage( 12, 17 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Contondant, 40 );
			SetDamageType( ResistanceType.Magie, 60 );

			SetResistance( ResistanceType.Physical, 45, 55 );
			SetResistance( ResistanceType.Contondant, 25, 35 );
			SetResistance( ResistanceType.Tranchant, 25, 35 );
			SetResistance( ResistanceType.Perforant, 10, 20 );
			SetResistance( ResistanceType.Magie, 30, 40 );

			SetSkill( SkillName.Concentration, 45.1, 70.0 );
			SetSkill( SkillName.Tactiques, 67.6, 92.5 );
			SetSkill( SkillName.ArmePoing, 60.1, 80.0 );

			Fame = 1500;
			Karma = -1500;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.0; } }
		//public override int TreasureMapLevel{ get{ return 1; } }

		public Gibberling( Serial serial ) : base( serial )
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