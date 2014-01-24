using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Wyrm des Ombres" )]
	public class ShadowWyrm : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public ShadowWyrm() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Wyrm des Ombres";
			Body = 98;
			BaseSoundID = 362;

			SetStr( 898, 1030 );
			SetDex( 68, 200 );
			SetInt( 488, 620 );

			SetHits( 2500, 5000 );

			SetDamage( 50, 100 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Tranchant, 25 );

            SetResistance(ResistanceType.Physical, 60, 80);
            SetResistance(ResistanceType.Contondant, 60, 80);
            SetResistance(ResistanceType.Tranchant, 60, 80);
            SetResistance(ResistanceType.Perforant, 60, 80);
            SetResistance(ResistanceType.Magie, 60, 80);

			//SetSkill( SkillName.EvalInt, 80.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 80.1, 100.0 );
			SetSkill( SkillName.Concentration, 52.5, 75.0 );
			SetSkill( SkillName.Concentration, 100.3, 130.0 );
			SetSkill( SkillName.Tactiques, 97.6, 100.0 );
			SetSkill( SkillName.ArmePoing, 97.6, 100.0 );

			Fame = 22500;
			Karma = -22500;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss );
			AddLoot( LootPack.Gems, 5 );
		}

		public override int GetIdleSound()
		{
			return 0x2D5;
		}

		public override int GetHurtSound()
		{
			return 0x2D1;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool ReacquireOnMovement{ get{ return true; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		public override bool AutoDispel{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
		//public override int TreasureMapLevel{ get{ return 5; } }

		public override int Meat{ get{ return 19; } }
		public override int Scales{ get{ return 10; } }
	    public override ScaleType ScaleType{ get{ return ScaleType.Wyrm; } }
        public override int Bones { get { return 12; } }
        public override int Hides { get { return 10; } }
        public override HideType HideType { get { return HideType.Lupus; } }
        public override BoneType BoneType { get { return BoneType.Wyrm; } }

		public ShadowWyrm( Serial serial ) : base( serial )
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