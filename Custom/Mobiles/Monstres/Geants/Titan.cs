using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Corps de Titan" )]
	public class Titan : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public Titan() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Titan";
			Body = 169;
			BaseSoundID = 609;

			SetStr( 536, 585 );
			SetDex( 126, 145 );
			SetInt( 281, 305 );

			SetHits( 800, 1500 );

			SetDamage( 30, 60 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Contondant, 50, 70);
            SetResistance(ResistanceType.Tranchant, 50, 70);
            SetResistance(ResistanceType.Perforant, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

			//SetSkill( SkillName.EvalInt, 85.1, 100.0 );
			SetSkill( SkillName.ArtMagique, 85.1, 100.0 );
			SetSkill( SkillName.Concentration, 80.2, 110.0 );
			SetSkill( SkillName.Tactiques, 60.1, 80.0 );
			SetSkill( SkillName.ArmePoing, 40.1, 50.0 );

			Fame = 11500;
			Karma = -11500;

			VirtualArmor = 80;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
			AddLoot( LootPack.MedScrolls );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 4.0; } }
		public override int Meat{ get{ return 4; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		//public override int TreasureMapLevel{ get{ return 5; } }
        public override int Bones { get { return 12; } }
        public override int Hides { get { return 18; } }
        public override HideType HideType { get { return HideType.Geant; } }
        public override BoneType BoneType { get { return BoneType.Geant; } }

		public Titan( Serial serial ) : base( serial )
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