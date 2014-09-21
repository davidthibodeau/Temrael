using System;
using System.Collections;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "Marodeur" )]
	public class BogThing : BaseCreature
	{
		[Constructable]
		public BogThing() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.6, 1.2 )
		{
			Name = "Marodeur";
			Body = 37;

			SetStr( 801, 900 );
			SetDex( 46, 65 );
			SetInt( 36, 50 );

			SetHits( 400, 800 );
			SetMana( 0 );

			SetDamage( 25, 50 );

			SetDamageType( ResistanceType.Physical, 60 );
			

            SetResistance(ResistanceType.Physical, 20, 40);
            
            
            
            SetResistance(ResistanceType.Magie, 20, 40);

			SetSkill( SkillName.Concentration, 90.1, 95.0 );
			SetSkill( SkillName.Tactiques, 70.1, 85.0 );
			SetSkill( SkillName.Anatomie, 65.1, 80.0 );

			if ( 0.25 > Utility.RandomDouble() )
				PackItem( new Board( 10 ) );
			else
				PackItem( new Log( 10 ) );

            PackItem(new Fumier(3));

			PackReg( 3 );
		}

        public override bool AlwaysMurderer { get { return true; } }
        public override double AttackSpeed { get { return 3.0; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average, 2 );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public BogThing( Serial serial ) : base( serial )
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

		public void SpawnBogling( Mobile m )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			Bogling spawned = new Bogling();

			spawned.Team = this.Team;

			bool validLocation = false;
			Point3D loc = this.Location;

			for ( int j = 0; !validLocation && j < 10; ++j )
			{
				int x = X + Utility.Random( 3 ) - 1;
				int y = Y + Utility.Random( 3 ) - 1;
				int z = map.GetAverageZ( x, y );

				if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
					loc = new Point3D( x, y, Z );
				else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
					loc = new Point3D( x, y, z );
			}

			spawned.MoveToWorld( loc, map );
			spawned.Combatant = m;
		}

		public void EatBoglings()
		{
			ArrayList toEat = new ArrayList();
  
			foreach ( Mobile m in this.GetMobilesInRange( 2 ) )
			{
				if ( m is Bogling )
					toEat.Add( m );
			}

			if ( toEat.Count > 0 )
			{
				PlaySound( Utility.Random( 0x3B, 2 ) ); // Eat sound

				foreach ( Mobile m in toEat )
				{
					Hits += (m.Hits / 2);
					m.Delete();
				}
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( this.Hits > (this.HitsMax / 4) )
			{
				if ( 0.25 >= Utility.RandomDouble() )
					SpawnBogling( attacker );
			}
			else if ( 0.25 >= Utility.RandomDouble() )
			{
				EatBoglings();
			}
		}
	}
}