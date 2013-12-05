using System;
using System.Collections;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "un corps d'esprit de lames" )]
	public class SummonedBladeSpirits : BaseCreature
	{
		public override bool IsHouseSummonable{ get{ return true; } }

        public override bool DeleteCorpseOnDeath { get { return Summoned; } }

		public override double DispelDifficulty{ get{ return 45.0; } }
		public override double DispelFocus{ get{ return 30.0; } }

		[Constructable]
		public SummonedBladeSpirits() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.1, 0.1 )
		{
			Name = "un esprit de lames";
			Body = 574;

			SetStr( 150 );
			SetDex( 250 );
			SetInt( 100 );

			SetHits( 136, 150 );
			SetStam( 250, 320 );
			SetMana( 0 );

			SetDamage( 50, 55 );

			//SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactiques, 100 );
			SetSkill( SkillName.ArmePoing, 100 );

            VirtualArmor = 40;
            ControlSlots = 4;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int GetAngerSound()
		{
			return 0x23A;
		}

		public override int GetAttackSound()
		{
			return 0x3B8;
		}

		public override int GetHurtSound()
		{
			return 0x23A;
		}

        public SummonedBladeSpirits(Serial serial)
            : base(serial)
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

            int version = reader.ReadInt();
            ControlSlots = 4;
		}
	}
}