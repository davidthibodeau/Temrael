using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "un corps de vortex d'energie" )]
	public class SummonedEnergyVortex : BaseCreature
	{
		public override bool DeleteCorpseOnDeath{ get{ return Summoned; } }

		public override double DispelDifficulty{ get{ return 60.0; } }
		public override double DispelFocus{ get{ return 40.0; } }

		[Constructable]
		public SummonedEnergyVortex() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.2 )
		{
			Name = "un vortex d'energie";
			Body = 164;

			SetStr( 250 );
			SetDex( 200 );
			SetInt( 100 );

			SetHits( 400, 425 );
			SetStam( 250 );
			SetMana( 0 );

			SetDamage( 65, 70 );

			//SetSkill( SkillName.MagicResist, 99.9 );
			SetSkill( SkillName.Tactiques, 90.0 );
			SetSkill( SkillName.Anatomie, 100.0 );

            VirtualArmor = 60;
            ControlSlots = 6;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override int GetAngerSound()
		{
			return 0x15;
		}

		public override int GetAttackSound()
		{
			return 0x28;
		}

		public SummonedEnergyVortex( Serial serial ) : base( serial )
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
            ControlSlots = 6;
		}
	}
}
