using System;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Gargouille" )]
	public class GargoyleDestroyer : BaseCreature
	{
		[Constructable]
		public GargoyleDestroyer() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Gargouille";
			Body = 68;
			BaseSoundID = 0x174;

			SetStr( 760, 850 );
			SetDex( 102, 150 );
			SetInt( 152, 200 );

			SetHits( 400, 800 );

			SetDamage( 20, 40 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			SetSkill( SkillName.Anatomie, 90.1, 100.0 );
			SetSkill( SkillName.Tactiques, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 120.4, 160.0 );
			//SetSkill( SkillName.Anatomy, 50.5, 100.0 );
			SetSkill( SkillName.ArmeTranchante, 90.1, 100.0 );
			SetSkill( SkillName.ArmeContondante, 90.1, 100.0 );
			SetSkill( SkillName.ArmePerforante, 90.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 90.1, 100.0 );
			//SetSkill( SkillName.EvalInt, 90.1, 100.0 );
			SetSkill( SkillName.Concentration, 90.1, 100.0 );

            PackItem(new EclatDeVolcan(3));
		}

		public override void GenerateLoot()
		{
            AddLoot(LootPack.Rich);
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override int Meat{ get{ return 1; } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Volcanique; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ThrowHatchet( from );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.4 > Utility.RandomDouble() )
			{
				ThrowHatchet( attacker );
			}
		}

		public void ThrowHatchet( Mobile to )
		{
			int damage = 50;
			this.MovingEffect( to, 0xF43, 10, 0, false, false );
			this.DoHarmful( to );
			AOS.Damage( to, this, damage, 100, 0, 0, 0, 0 );
		}

		public GargoyleDestroyer( Serial serial ) : base( serial )
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