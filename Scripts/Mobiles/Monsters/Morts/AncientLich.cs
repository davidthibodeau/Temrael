using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an ancient liche's corpse" )]
	public class AncientLich : BaseCreature
	{
		[Constructable]
		public AncientLich() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ancient lich" );
			Body = 24;
			BaseSoundID = 412;

			SetStr( 216, 305 );
			SetDex( 96, 115 );
			SetInt( 966, 1045 );

			SetHits( 400, 800 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Tranchant, 40 );
			SetDamageType( ResistanceType.Magie, 40 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Contondant, 50, 70);
            SetResistance(ResistanceType.Tranchant, 50, 70);
            SetResistance(ResistanceType.Perforant, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

			//SetSkill( SkillName.EvalInt, 120.1, 130.0 );
			SetSkill( SkillName.ArtMagique, 120.1, 130.0 );
			SetSkill( SkillName.Concentration, 100.1, 101.0 );
			SetSkill( SkillName.Empoisonnement, 100.1, 101.0 );
			SetSkill( SkillName.Concentration, 175.2, 200.0 );
			SetSkill( SkillName.Tactiques, 90.1, 100.0 );
			SetSkill( SkillName.Anatomie, 75.1, 100.0 );

			PackNecroReg( 15, 50 );
			
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override int GetIdleSound()
		{
			return 0x19D;
		}

		public override int GetAngerSound()
		{
			return 0x175;
		}

		public override int GetDeathSound()
		{
			return 0x108;
		}

		public override int GetAttackSound()
		{
			return 0xE2;
		}

		public override int GetHurtSound()
		{
			return 0x28B;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

		public override bool Unprovokable{ get{ return true; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override int TreasureMapLevel{ get{ return 5; } }

		public AncientLich( Serial serial ) : base( serial )
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