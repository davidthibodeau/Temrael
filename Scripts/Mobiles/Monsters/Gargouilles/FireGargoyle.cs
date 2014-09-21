using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Gargouille de Feu" )]
	public class FireGargoyle : BaseCreature
	{
		[Constructable]
		public FireGargoyle() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Gargouille de Feu";
			Body = 65;
			BaseSoundID = 0x174;

			SetStr( 351, 400 );
			SetDex( 126, 145 );
			SetInt( 226, 250 );

			SetHits( 500, 900 );

			SetDamage( 20, 40 );

			SetDamageType( ResistanceType.Physical, 20 );
			

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			//SetSkill( SkillName.Anatomy, 75.1, 85.0 );
			//SetSkill( SkillName.EvalInt, 90.1, 105.0 );
			SetSkill( SkillName.ArtMagique, 90.1, 105.0 );
			SetSkill( SkillName.Concentration, 90.1, 105.0 );
			SetSkill( SkillName.Concentration, 90.1, 105.0 );
			SetSkill( SkillName.Tactiques, 80.1, 100.0 );
			SetSkill( SkillName.Anatomie, 40.1, 80.0 );

            PackItem(new EclatDeVolcan(2));
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool HasBreath{ get{ return true; } } // fire breath enabled
		//public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }

        public override int Bones { get { return 6; } }
        public override int Hides { get { return 8; } }
        public override HideType HideType { get { return HideType.Volcanique; } }
        public override BoneType BoneType { get { return BoneType.Volcanique; } }

		public FireGargoyle( Serial serial ) : base( serial )
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