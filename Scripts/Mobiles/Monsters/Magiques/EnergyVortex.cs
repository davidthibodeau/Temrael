using System;
using Server;
using Server.Items;
using System.Collections;

namespace Server.Mobiles
{
	[CorpseName( "an energy vortex corpse" )]
	public class EnergyVortex : BaseCreature
	{
		public override bool DeleteCorpseOnDeath { get { return Summoned; } }
		public override bool AlwaysMurderer{ get{ return true; } } // Or Llama vortices will appear gray.

		public override double DispelDifficulty { get { return 80.0; } }
		public override double DispelFocus { get { return 20.0; } }

		public override double GetFightModeRanking( Mobile m, FightMode acqType, bool bPlayerOnly )
		{
			return ( m.Int + m.Skills[SkillName.ArtMagique].Value ) / Math.Max( GetDistanceToSqrt( m ), 1.0 );
		}

		[Constructable]
		public EnergyVortex()
			: base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Vortex d'Énergie";

			Body = 84;
            Hue = 2192;

			SetStr( 200 );
			SetDex( 200 );
			SetInt( 100 );

			SetHits( 200 );
			SetStam( 250 );
			SetMana( 0 );

			SetDamage( 14, 17 );

			SetDamageType( ResistanceType.Physical, 0 );
			SetDamageType( ResistanceType.Magie, 100 );

			SetResistance( ResistanceType.Physical, 60, 70 );
			
			
			
			SetResistance( ResistanceType.Magie, 90, 100 );

			SetSkill( SkillName.Concentration, 99.9 );
			SetSkill( SkillName.Tactiques, 100.0 );

            ControlSlots = 1;
		}

        public override double AttackSpeed { get { return 2.5; } }
		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune { get { return Poison.Lethal; } }

		public override int GetAngerSound()
		{
			return 0x15;
		}

		public override int GetAttackSound()
		{
			return 0x28;
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
					//TODO: Confim if it's the dispel with all the pretty effects or just a Deletion of it.
					Dispel( ( (Mobile) spirtsOrVortexes[index] ) );
					spirtsOrVortexes.RemoveAt( index );
				}
			}

			base.OnThink();
		}


		public EnergyVortex( Serial serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 0;
		}
	}
}