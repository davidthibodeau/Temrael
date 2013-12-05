using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire Scarabee corpse" )]
	[Server.Engines.Craft.Forge]
	public class FireScarabee : BaseMount
	{
		public override bool SubdueBeforeTame{ get{ return true; } } // Must be beaten into submission
		public override bool StatLossAfterTame{ get{ return true; } }
		public virtual double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public FireScarabee() : base( "a fire Scarabee", 400, 0x3E95, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			SetStr( 300 );
			SetDex( 100 );
			SetInt( 500 );

			SetHits( 200 );

			SetDamage( 7, 20 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Contondant, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Contondant, 70, 75 );
			SetResistance( ResistanceType.Tranchant, 10 );
			SetResistance( ResistanceType.Perforant, 30 );
			SetResistance( ResistanceType.Magie, 30 );

			SetSkill( SkillName.Concentration, 90.0 );
			SetSkill( SkillName.Tactiques, 100.0 );
			SetSkill( SkillName.ArmePoing, 100.0 );

			Fame = 4000;
			Karma = -4000;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;

			PackItem( new SulfurousAsh( Utility.RandomMinMax( 16, 25 ) ) );
			PackItem( new FerIngot( 2 ) );

			Hue = 0x489;
		}

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

		public override bool OverrideBondingReqs()
		{
			return true;
		}

		public override int GetAngerSound()
		{
			return 0x21D;
		}

		public override int GetIdleSound()
		{
			return 0x21D;
		}

		public override int GetAttackSound()
		{
			return 0x162;
		}

		public override int GetHurtSound()
		{
			return 0x163;
		}

		public override int GetDeathSound()
		{
			return 0x21D;
		}


		public override int Meat{ get{ return 16; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override double GetControlChance( Mobile m, bool useBaseSkill )
		{
			return 1.0;
		}

		public FireScarabee( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			if( version == 0 )
				Hue = 0x489;
		}
	}
}