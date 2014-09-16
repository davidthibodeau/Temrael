using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a scorpion corpse" )]
	public class Scorpion : BaseCreature
	{
		[Constructable]
		public Scorpion() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Scorpion Geant";
			Body = 48;
			BaseSoundID = 397;

            ExpKillBonus = 6;

			SetStr( 40, 50 );
			SetDex( 75, 95 );
			SetInt( 15, 30 );

			SetHits( 75, 125 );
			SetMana( 0 );

			SetDamage( 10, 25 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Perforant, 40 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Contondant, 10, 20 );
			SetResistance( ResistanceType.Tranchant, 20, 30 );
			SetResistance( ResistanceType.Perforant, 60, 80 );
			SetResistance( ResistanceType.Magie, 5, 10 );

			SetSkill( SkillName.Empoisonnement, 80.0, 100.0 );
			//SetSkill( SkillName.Concentration, 30.1, 35.0 );
			SetSkill( SkillName.Tactiques, 60.0, 75.0 );
			SetSkill( SkillName.Anatomie, 50.0, 65.0 );

			VirtualArmor = 28;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 75.0;

            PackItem(new Nightshade());
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }
        public override int Bones { get { return 8; } }
        public override int Hides { get { return 4; } }
        public override HideType HideType { get { return HideType.Desertique; } }
        public override BoneType BoneType { get { return BoneType.Desertique; } }

		public Scorpion( Serial serial ) : base( serial )
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