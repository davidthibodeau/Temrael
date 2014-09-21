using System;
using Server.Items;
using Server.Targeting;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "veuve noire geante" )] // stupid corpse name
	public class GiantBlackWidow : BaseCreature
	{
        public override bool isBoss
        {
            get
            {
                return true;
            }
        }

		[Constructable]
		public GiantBlackWidow() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Veuve noire Geante";
			Body =  79;
			BaseSoundID = 0x388; // TODO: validate

            SetStr(196, 220);
            SetDex(126, 145);
            SetInt(286, 310);

			SetHits( 1500, 2000 );

			SetDamage( 45, 90 );

			SetDamageType( ResistanceType.Physical, 100 );

            SetResistance(ResistanceType.Physical, 50, 70);
            SetResistance(ResistanceType.Magie, 50, 70);

			//SetSkill( SkillName.Anatomy, 30.3, 75.0 );
            SetSkill(SkillName.ArtMagique, 100.0, 120.0);
			SetSkill( SkillName.Empoisonnement, 100.0, 120.0 );
			SetSkill( SkillName.Concentration, 100.0, 120.0 );
			SetSkill( SkillName.Tactiques, 100.0, 120.0 );
			SetSkill( SkillName.Anatomie, 100.0, 120.0 );

            Tamable = true;
            ControlSlots = 8;
            MinTameSkill = 90.0;

			PackItem( new SpidersSilk( 5 ) );
			//PackItem( new LesserPoisonPotion() );
			//PackItem( new LesserPoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override Poison PoisonImmune{ get{ return Poison.Deadly; } }
		public override Poison HitPoison{ get{ return Poison.Deadly; } }
        public override int Bones { get { return 12; } }
        public override int Hides { get { return 15; } }
        public override HideType HideType { get { return HideType.Arachnide; } }
        public override BoneType BoneType { get { return BoneType.Arachnide; } }

		public GiantBlackWidow( Serial serial ) : base( serial )
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