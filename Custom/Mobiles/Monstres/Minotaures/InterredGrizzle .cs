using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName("Corps de Minotaure Mage")]
	public class InterredGrizzle  : BaseCreature
	{
		[Constructable]
		public  InterredGrizzle () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Minotaure Mage";
            Body = 155;

			SetStr( 451, 500 );
			SetDex( 201, 250 );
			SetInt( 801, 850 );

			SetHits( 800, 1200 );
			SetStam( 150 );

			SetDamage( 20, 40 );

			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Contondant, 70 );

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Contondant, 40, 60);
            SetResistance(ResistanceType.Tranchant, 40, 60);
            SetResistance(ResistanceType.Perforant, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

			SetSkill(SkillName.Concentration, 77.7, 84.0 );
			//SetSkill(SkillName.EvalInt, 72.2, 79.6 );
			SetSkill(SkillName.ArtMagique, 83.7, 89.6);
			SetSkill(SkillName.Empoisonner, 0 );
			//SetSkill(SkillName.Anatomy, 0 );
			SetSkill( SkillName.Concentration, 80.2, 87.3 );
			SetSkill( SkillName.Tactiques, 104.5, 105.1 );
			SetSkill( SkillName.ArmePoing, 105.1, 109.4 );

			Fame = 3700;  // Guessed
			Karma = -3700;  // Guessed
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
        public override int Bones { get { return 12; } }
        public override int Hides { get { return 8; } }
        public override HideType HideType { get { return HideType.Minotaure; } }
        public override BoneType BoneType { get { return BoneType.Minotaure; } }

		// TODO: Acid Blood
		/*
		 * Message: 1070820
		 * Spits pool of acid (blood, hue 0x3F), hits lost 6-10 per second/step
		 * Damage is resistable (physical)
		 * Acid last 10 seconds
		 */
		 
		public override int GetAngerSound()
		{
			return 0x581;
		}

		public override int GetIdleSound()
		{
			return 0x582;
		}

		public override int GetAttackSound()
		{
			return 0x580;
		}

		public override int GetHurtSound()
		{
			return 0x583;
		}

		public override int GetDeathSound()
		{
			return 0x584;
		}

		/*
		public override bool OnBeforeDeath()
		{
			SpillAcid( 1, 4, 10, 6, 10 );

			return base.OnBeforeDeath();
		}
		*/

		public  InterredGrizzle ( Serial serial ) : base( serial )
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
