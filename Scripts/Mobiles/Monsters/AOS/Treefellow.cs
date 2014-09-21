using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a treefellow corpse" )]
	public class Treefellow : BaseCreature
	{
		/*public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.Dismount;
		}*/

		[Constructable]
		public Treefellow() : base( AIType.AI_Melee, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "a treefellow";
			Body = 170;

			SetStr( 196, 220 );
			SetDex( 31, 55 );
			SetInt( 66, 90 );

			SetHits( 118, 132 );

			SetDamage( 12, 16 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 40.1, 55.0 );
			SetSkill( SkillName.Tactiques, 65.1, 90.0 );
			SetSkill( SkillName.Anatomie, 65.1, 85.0 );

			PackItem( new Log( Utility.RandomMinMax( 1, 12 ) ) );
            PackItem(new ResineAmbreBleue(1));
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int GetIdleSound()
		{
			return 443;
		}

		public override int GetDeathSound()
		{
			return 31;
		}

		public override int GetAttackSound()
		{
			return 672;
		}

		public override bool BleedImmune{ get{ return true; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public Treefellow( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 442 )
				BaseSoundID = -1;
		}
	}
}