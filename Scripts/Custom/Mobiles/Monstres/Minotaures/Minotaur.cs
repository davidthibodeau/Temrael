using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "Minotaure" )]
	public class Minotaur : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

		[Constructable]
		public Minotaur() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) // NEED TO CHECK
		{
			Name = "Minotaure Guerrier";
            Body = 148;

			SetStr( 301, 340 );
			SetDex( 91, 110 );
			SetInt( 31, 50 );

			SetHits( 400, 800 );

			SetDamage( 20, 30 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 20, 40);
            SetResistance(ResistanceType.Contondant, 20, 40);
            SetResistance(ResistanceType.Tranchant, 20, 40);
            SetResistance(ResistanceType.Perforant, 20, 40);
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 0 );
			//SetSkill( SkillName.EvalInt, 0 );
			SetSkill( SkillName.ArtMagique, 0 );
			SetSkill( SkillName.Empoisonner, 0 );
			//SetSkill( SkillName.Anatomy, 0 );
			SetSkill( SkillName.Concentration, 56.1, 64.0 );
			SetSkill( SkillName.Tactiques, 93.3, 97.8 );
			SetSkill( SkillName.ArmePoing, 90.4, 92.1 );

			Fame = 5000;
			Karma = -5000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );  // Need to verify
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 3; } }
        public override HideType HideType { get { return HideType.Minotaure; } }
        public override BoneType BoneType { get { return BoneType.Minotaure; } }

		// Using Tormented Minotaur sounds - Need to veryfy
		public override int GetAngerSound()
		{
			return 0x597;
		}

		public override int GetIdleSound()
		{
			return 0x596;
		}

		public override int GetAttackSound()
		{
			return 0x599;
		}

		public override int GetHurtSound()
		{
			return 0x59a;
		}

		public override int GetDeathSound()
		{
			return 0x59c;
		}

		public Minotaur( Serial serial ) : base( serial )
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
