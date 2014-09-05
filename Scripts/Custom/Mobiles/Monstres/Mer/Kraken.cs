using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Kraken" )]
	public class Kraken : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public Kraken() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Kraken";
			Body = 74;
			BaseSoundID = 353;

			SetStr( 756, 780 );
			SetDex( 226, 245 );
			SetInt( 26, 40 );

			SetHits( 500, 1000 );
			SetMana( 0 );

			SetDamage( 30, 60 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Tranchant, 30 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			SetSkill( SkillName.Concentration, 15.1, 20.0 );
			SetSkill( SkillName.Tactiques, 45.1, 60.0 );
			SetSkill( SkillName.Anatomie, 45.1, 60.0 );

			Fame = 11000;
			Karma = -11000;

			CanSwim = true;
			CantWalk = true;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		//public override int TreasureMapLevel{ get{ return 4; } }
        public override int Bones { get { return 10; } }
        public override int Hides { get { return 12; } }
        public override HideType HideType { get { return HideType.Maritime; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }

		public Kraken( Serial serial ) : base( serial )
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
