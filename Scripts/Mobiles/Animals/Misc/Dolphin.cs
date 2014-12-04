using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a dolphin corpse" )]
	public class Dolphin : BaseCreature
	{
		[Constructable]
		public Dolphin()
			: base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a dolphin";
			Body = 0x97;
			BaseSoundID = 0x8A;

			SetStr( 21, 49 );
			SetDex( 66, 85 );
			SetInt( 96, 110 );

			SetHits( 15, 27 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Magical, 10, 15 );

			SetSkill( SkillName.Concentration, 15.1, 20.0 );
			SetSkill( SkillName.Tactiques, 19.2, 29.0 );
			SetSkill( SkillName.Anatomie, 19.2, 29.0 );

			VirtualArmor = 16;
			CanSwim = true;
			CantWalk = true;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 50.0;
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override int Meat { get { return 1; } }
        public override int Bones { get { return 1; } }
        public override int Hides { get { return 1; } }
        public override HideType HideType { get { return HideType.Maritime; } }
        public override BoneType BoneType { get { return BoneType.Maritime; } }

		public Dolphin( Serial serial )
			: base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( from.AccessLevel >= AccessLevel.Batisseur )
				Jump();
		}

		public virtual void Jump()
		{
			if( Utility.RandomBool() )
				Animate( 3, 16, 1, true, false, 0 );
			else
				Animate( 4, 20, 1, true, false, 0 );
		}

		public override void OnThink()
		{
			if( Utility.RandomDouble() < .005 ) // slim chance to jump
				Jump();

			base.OnThink();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}