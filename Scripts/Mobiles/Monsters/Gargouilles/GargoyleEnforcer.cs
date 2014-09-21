using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Gargouille Geante" )]
	public class GargoyleEnforcer : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.WhirlwindAttack;
		}

		[Constructable]
		public GargoyleEnforcer() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Gargouille Geante";
			Body = 67;
			BaseSoundID = 0x174;

			SetStr( 760, 850 );
			SetDex( 102, 150 );
			SetInt( 152, 200 );

			SetHits( 600, 1200 );

			SetDamage( 30, 60 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			SetSkill( SkillName.Concentration, 120.1, 130.0 );
			SetSkill( SkillName.Tactiques, 70.1, 80.0 );
			SetSkill( SkillName.Anatomie, 80.1, 90.0 );
			SetSkill( SkillName.ArmeTranchante, 80.1, 90.0 );
			//SetSkill( SkillName.Anatomy, 70.1, 80.0 );
			SetSkill( SkillName.ArtMagique, 80.1, 90.0 );
			//SetSkill( SkillName.EvalInt, 70.3, 100.0 );
			SetSkill( SkillName.Concentration, 70.3, 100.0 );

            PackItem(new EclatDeVolcan(4));
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			//AddLoot( LootPack.MedScrolls );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.5; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 12; } }
        public override int Hides { get { return 14; } }
        public override HideType HideType { get { return HideType.Volcanique; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

		public GargoyleEnforcer( Serial serial ) : base( serial )
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