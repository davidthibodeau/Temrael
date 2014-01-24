using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "Capitaine Minotaure" )]
	public class MinotaurCaptain : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

		[Constructable]
		public MinotaurCaptain() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) // NEED TO CHECK
		{
			Name = "Capitaine Minotaure";
            Body = 158;

			SetStr( 401, 425 );
			SetDex( 91, 110 );
			SetInt( 31, 50 );

			SetHits( 500, 1000 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			SetSkill( SkillName.Concentration, 0 );
			//SetSkill( SkillName.EvalInt, 0 );
			SetSkill( SkillName.ArtMagique, 0 );
			SetSkill( SkillName.Empoisonner, 0 );
			//SetSkill( SkillName.Anatomy, 0, 6.3 );
			SetSkill( SkillName.Concentration, 66.1, 73.6 );
			SetSkill( SkillName.Tactiques, 93.0, 109.9 );
			SetSkill( SkillName.ArmePoing, 92.6, 107.2 );

			Fame = 7000;
			Karma = -7000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );  // Need to verify
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Bones { get { return 18; } }
        public override int Hides { get { return 14; } }
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

		public MinotaurCaptain( Serial serial ) : base( serial )
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
