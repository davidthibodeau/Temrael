using System;
using System.Collections;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a blade spirit corpse" )]
	public class BladeSpirits : BaseCreature
	{
		public override bool DeleteCorpseOnDeath { get { return Core.AOS; } }
		public override bool IsHouseSummonable { get { return true; } }

		public override double DispelDifficulty { get { return 0.0; } }
		public override double DispelFocus { get { return 20.0; } }

		public override double GetFightModeRanking( Mobile m, FightMode acqType, bool bPlayerOnly )
		{
			return ( m.Str + m.Skills[SkillName.Tactiques].Value ) / Math.Max( GetDistanceToSqrt( m ), 1.0 );
		}

		[Constructable]
		public BladeSpirits()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.3, 0.6 )
		{
			Name = "a blade spirit";
			Body = 112;

			SetStr( 150 );
			SetDex( 150 );
			SetInt( 100 );

			SetHits( 400 );
			SetStam( 250 );
			SetMana( 0 );

			SetDamage( 10, 30 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Perforant, 20 );
			SetDamageType( ResistanceType.Magie, 20 );

            SetResistance(ResistanceType.Physical, 40, 60);
            SetResistance(ResistanceType.Contondant, 40, 60);
            SetResistance(ResistanceType.Tranchant, 40, 60);
            SetResistance(ResistanceType.Perforant, 40, 60);
            SetResistance(ResistanceType.Magie, 40, 60);

			SetSkill( SkillName.Concentration, 70.0 );
			SetSkill( SkillName.Tactiques, 90.0 );
			SetSkill( SkillName.Anatomie, 90.0 );

			ControlSlots = 2;
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }

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

		public override void OnThink()
		{
			if ( Core.SE && Summoned )
			{
				ArrayList spirtsOrVortexes = new ArrayList();

				foreach ( Mobile m in GetMobilesInRange( 5 ) )
				{
					if ( m is EnergyVortex || m is BladeSpirits )
					{
						if ( ( (BaseCreature) m ).Summoned )
							spirtsOrVortexes.Add( m );
					}
				}

				while ( spirtsOrVortexes.Count > 6 )
				{
					int index = Utility.Random( spirtsOrVortexes.Count );
					Dispel( ( (Mobile) spirtsOrVortexes[index] ) );
					spirtsOrVortexes.RemoveAt( index );
				}
			}

			base.OnThink();
		}

		public BladeSpirits( Serial serial )
			: base( serial )
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
		}
	}
}