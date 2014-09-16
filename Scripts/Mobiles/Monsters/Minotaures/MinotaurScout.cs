using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "Minotaure" )]
	public class MinotaurScout : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

		[Constructable]
		public MinotaurScout() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) // NEED TO CHECK
		{
			Name = "Minotaure";
            Body = 157;
		   
			SetStr( 353, 375 );
			SetDex( 111, 130 );
			SetInt( 34, 50 );

			SetHits( 300, 600 );

			SetDamage( 10, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 10, 30);
            SetResistance(ResistanceType.Contondant, 10, 30);
            SetResistance(ResistanceType.Tranchant, 10, 30);
            SetResistance(ResistanceType.Perforant, 10, 30);
            SetResistance(ResistanceType.Magie, 10, 30);

			//SetSkill( SkillName.Concentration, Unknown );
			//SetSkill( SkillName.EvalInt, Unknown );
			//SetSkill( SkillName.ArtMagique, Unknown );
			//SetSkill( SkillName.Empoisonner, Unknown );
			//SetSkill( SkillName.Anatomy, 0 );
			SetSkill( SkillName.Concentration, 60.6, 67.5 );
			SetSkill( SkillName.Tactiques, 86.9, 103.6 );
			SetSkill( SkillName.Anatomie, 85.6, 104.5 );

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );  // Need to verify
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
        public override int Bones { get { return 6; } }
        public override int Hides { get { return 4; } }
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

		public MinotaurScout( Serial serial ) : base( serial )
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
