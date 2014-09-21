using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Seigneur Ogre des Neiges" )]
	[TypeAlias( "Server.Mobiles.ArticOgreLord" )]
	public class ArcticOgreLord : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public ArcticOgreLord() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Seigneur Ogre des Neiges";
			Body = 1;
			BaseSoundID = 427;
            Hue = 2056;

			SetStr( 767, 945 );
			SetDex( 66, 75 );
			SetInt( 46, 70 );

			SetHits( 800, 1200 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 30 );

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

			SetSkill( SkillName.Concentration, 125.1, 140.0 );
			SetSkill( SkillName.Tactiques, 90.1, 100.0 );
			SetSkill( SkillName.Anatomie, 90.1, 100.0 );

			VirtualArmor = 175;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		//public override int TreasureMapLevel{ get{ return 3; } }
        public override int Bones { get { return 16; } }
        public override int Hides { get { return 18; } }
        public override HideType HideType { get { return HideType.Nordique; } }
        public override BoneType BoneType { get { return BoneType.Nordique; } }

		public ArcticOgreLord( Serial serial ) : base( serial )
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