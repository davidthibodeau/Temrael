using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Wyrm Ancienne" )]
	public class AncientWyrm : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public AncientWyrm () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Wyrm Ancienne";
			Body = 91;
			BaseSoundID = 362;

			SetStr( 1096, 1185 );
			SetDex( 86, 175 );
			SetInt( 686, 775 );

			SetHits( 1500, 3000 );

			SetDamage( 50, 100 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Contondant, 25 );

            SetResistance(ResistanceType.Physical, 60, 80);
            SetResistance(ResistanceType.Contondant, 60, 80);
            SetResistance(ResistanceType.Tranchant, 60, 80);
            SetResistance(ResistanceType.Perforant, 60, 80);
            SetResistance(ResistanceType.Magie, 60, 80);

			//SetSkill( SkillName.EvalInt, 80.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 80.1, 100.0 );
			SetSkill( SkillName.Concentration, 52.5, 75.0 );
			SetSkill( SkillName.Concentration, 100.5, 150.0 );
			SetSkill( SkillName.Tactiques, 97.6, 100.0 );
			SetSkill( SkillName.Anatomie, 97.6, 100.0 );

			Fame = 22500;
			Karma = -22500;

            Tamable = true;
            ControlSlots = 12;
            MinTameSkill = 97.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss );
			AddLoot( LootPack.Gems, 5 );
		}

		public override int GetIdleSound()
		{
			return 0x2D3;
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
		public override int Meat{ get{ return 19; } }
		public override int Scales{ get{ return 12; } }
        public override ScaleType ScaleType { get { return ScaleType.Wyrm; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Utility.RandomBool() ? Poison.Lesser : Poison.Regular; } }
		//public override int TreasureMapLevel{ get{ return 5; } }
        public override int Bones { get { return 15; } }
        public override int Hides { get { return 20; } }
        public override HideType HideType { get { return HideType.Ancien; } }
        public override BoneType BoneType { get { return BoneType.Wyrm; } }

		public AncientWyrm( Serial serial ) : base( serial )
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