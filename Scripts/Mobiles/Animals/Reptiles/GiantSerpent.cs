using System;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a giant serpent corpse" )]
	[TypeAlias( "Server.Mobiles.Serpant" )]
	public class GiantSerpent : BaseCreature
	{
		[Constructable]
		public GiantSerpent() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a giant serpent";
			Body = 0x15;
			Hue = Utility.RandomSnakeHue();
			BaseSoundID = 219;

			SetStr( 186, 215 );
			SetDex( 56, 80 );
			SetInt( 66, 85 );

			SetHits( 112, 129 );
			SetMana( 0 );

			SetDamage( 7, 17 );

			SetDamageType( ResistanceType.Physical, 40 );

			SetResistance( ResistanceType.Physical, 30, 35 );
			SetResistance( ResistanceType.Magical, 10, 20 );

			SetSkill( SkillName.Empoisonnement, 70.1, 100.0 );
			SetSkill( SkillName.Concentration, 25.1, 40.0 );
			SetSkill( SkillName.Tactiques, 65.1, 70.0 );
			SetSkill( SkillName.Anatomie, 60.1, 80.0 );

			VirtualArmor = 20;
            Tamable = true;
            ControlSlots = 3;
            MinTameSkill = 50.0;

			PackItem( new Bone() );
			// TODO: Body parts
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return (0.8 >= Utility.RandomDouble() ? Poison.Greater : Poison.Deadly); } }

		public override bool DeathAdderCharmable{ get{ return true; } }

        public override int Meat { get { return 2; } }
        public override int Bones { get { return 4; } }
        public override int Hides { get { return 6; } }
        public override HideType HideType { get { return HideType.Reptilien; } }
        public override BoneType BoneType { get { return BoneType.Reptilien; } }

		public GiantSerpent(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			if ( BaseSoundID == -1 )
				BaseSoundID = 219;
		}
	}
}