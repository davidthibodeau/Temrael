using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Corps d'Harpie de Pierre" )]
	public class StoneHarpy : BaseCreature
	{
		[Constructable]
		public StoneHarpy() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Harpie de Pierre";
			Body = 30;
			BaseSoundID = 402;
            Hue = 2424;

			SetStr( 296, 320 );
			SetDex( 86, 110 );
			SetInt( 51, 75 );

			SetHits( 178, 192 );
			SetMana( 0 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Perforant, 25 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			SetSkill( SkillName.Concentration, 50.1, 65.0 );
			SetSkill( SkillName.Tactiques, 70.1, 100.0 );
			SetSkill( SkillName.ArmePoing, 70.1, 100.0 );

			Fame = 4500;
			Karma = -4500;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 1 );
		}

		public override int GetAttackSound()
		{
			return 916;
		}

		public override int GetAngerSound()
		{
			return 916;
		}

		public override int GetDeathSound()
		{
			return 917;
		}

		public override int GetHurtSound()
		{
			return 919;
		}

		public override int GetIdleSound()
		{
			return 918;
		}

		public override int Meat{ get{ return 1; } }

		public StoneHarpy( Serial serial ) : base( serial )
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