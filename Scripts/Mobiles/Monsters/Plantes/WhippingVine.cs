using System;
using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("Vignes")]
	public class WhippingVine : BaseCreature
	{
		[Constructable]
		public WhippingVine() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Vignes";
			Body = 8;
			//Hue = 0x851;
			BaseSoundID = 352;

			SetStr( 251, 300 );
			SetDex( 76, 100 );
			SetInt( 26, 40 );

            SetHits( 300, 600 );

			SetMana( 0 );

			SetDamage( 15, 30 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Perforant, 30 );

            SetResistance(ResistanceType.Physical, 30, 50);
            SetResistance(ResistanceType.Contondant, 30, 50);
            SetResistance(ResistanceType.Tranchant, 30, 50);
            SetResistance(ResistanceType.Perforant, 30, 50);
            SetResistance(ResistanceType.Magie, 30, 50);

			SetSkill( SkillName.Concentration, 70.0 );
			SetSkill( SkillName.Tactiques, 70.0 );
			SetSkill( SkillName.Anatomie, 70.0 );

			PackReg( 3 );

		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 2.5; } }
		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public WhippingVine( Serial serial ) : base( serial )
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