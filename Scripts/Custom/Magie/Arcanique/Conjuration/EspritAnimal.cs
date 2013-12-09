using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "un corps d'esprit animal corpse" )]
	public class EspritAnimal : BaseCreature
	{
		public override bool DeleteCorpseOnDeath{ get{ return Summoned; } }

        public override double DispelDifficulty { get { return 30; } }
        public override double DispelFocus { get { return 15; } }

		[Constructable]
		public EspritAnimal() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.3 )
		{
			Name = "un esprit animal";
			Body = Utility.RandomList( 34, 37 );
			BaseSoundID = 0xE5;

			SetStr( 120, 150 );
			SetDex( 70, 100 );
			SetInt( 70, 100 );

			SetHits( 210, 240 );
			SetMana( 0 );

			SetDamage( 40, 50 );

			//SetSkill( SkillName.MagicResist, 20.1, 35.0 );
			SetSkill( SkillName.Tactiques, 75.1, 90.0 );
			SetSkill( SkillName.ArmePoing, 75.1, 90.0 );

			VirtualArmor = 30;

			ControlSlots = 2;
			Hue = 999999;
		}

		public EspritAnimal( Serial serial ) : base( serial )
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
		}
	}
}