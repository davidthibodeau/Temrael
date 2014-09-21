using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a wailing banshee corpse" )]
	public class WailingBanshee : BaseCreature
	{
		/*public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.MortalStrike;
		}*/

		[Constructable]
		public WailingBanshee() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a wailing banshee";
			Body = 117;
			BaseSoundID = 0x482;

			SetStr( 126, 150 );
			SetDex( 76, 100 );
			SetInt( 86, 110 );

			SetHits( 76, 90 );

			SetDamage( 10, 14 );

			SetDamageType( ResistanceType.Physical, 20 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Magie, 40, 50 );

			SetSkill( SkillName.Concentration, 70.1, 95.0 );
			SetSkill( SkillName.Tactiques, 45.1, 70.0 );
			SetSkill( SkillName.Anatomie, 50.1, 70.0 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool BleedImmune{ get{ return true; } }

		public WailingBanshee( Serial serial ) : base( serial )
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