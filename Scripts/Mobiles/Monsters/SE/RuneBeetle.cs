using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a rune Scarabee corpse" )]
	public class RuneScarabee : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public RuneScarabee() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a rune Scarabee";
            Body = 400;

			SetStr( 401, 460 );
			SetDex( 121, 170 );
			SetInt( 376, 450 );

			SetHits( 301, 360 );

			SetDamage( 15, 22 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Perforant, 10 );
			SetDamageType( ResistanceType.Magie, 70 );

			SetResistance( ResistanceType.Physical, 40, 65 );
			SetResistance( ResistanceType.Contondant, 35, 50 );
			SetResistance( ResistanceType.Tranchant, 35, 50 );
			SetResistance( ResistanceType.Perforant, 75, 95 );
			SetResistance( ResistanceType.Magie, 40, 60 );

			//SetSkill( SkillName.EvalInt, 100.1, 125.0 );
			SetSkill( SkillName.ArtMagique, 100.1, 110.0 );
			SetSkill( SkillName.Empoisonnement, 120.1, 140.0 );
			SetSkill( SkillName.Concentration, 95.1, 110.0 );
			SetSkill( SkillName.Tactiques, 78.1, 93.0 );
			SetSkill( SkillName.Anatomie, 70.1, 77.5 );

			
			if ( Utility.RandomDouble() < .25 )
				PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
				
			switch ( Utility.Random( 10 ))
			{
				case 0: PackItem( new LeftArm() ); break;
				case 1: PackItem( new RightArm() ); break;
				case 2: PackItem( new Torso() ); break;
				case 3: PackItem( new Bone() ); break;
				case 4: PackItem( new RibCage() ); break;
				case 5: PackItem( new RibCage() ); break;
				case 6: PackItem( new BonePile() ); break;
				case 7: PackItem( new BonePile() ); break;
				case 8: PackItem( new BonePile() ); break;
				case 9: PackItem( new BonePile() ); break;
			}
				
			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 93.9;			

		}

		public override int GetAngerSound()
		{
			return 0x4E8;
		}

		public override int GetIdleSound()
		{
			return 0x4E7;
		}

		public override int GetAttackSound()
		{
			return 0x4E6;
		}

		public override int GetHurtSound()
		{
			return 0x4E9;
		}

		public override int GetDeathSound()
		{
			return 0x4E5;
		}
		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 1 );
		}

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return Poison.Greater; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.05 > Utility.RandomDouble() )
			{
				/* Rune Corruption
				 * Start cliloc: 1070846 "The creature magically corrupts your armor!"
				 * Effect: All resistances -70 (lowest 0) for 5 seconds
				 * End ASCII: "The corruption of your armor has worn off"
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if ( timer != null )
				{
					timer.DoExpire();
					defender.SendLocalizedMessage( 1070845 ); // The creature continues to corrupt your armor!
				}
				else
					defender.SendLocalizedMessage( 1070846 ); // The creature magically corrupts your armor!

				List<ResistanceMod> mods = new List<ResistanceMod>();

				if ( Core.ML )
				{
					if ( defender.PhysicalResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Physical, -(defender.PhysicalResistance / 2) ) );

					if ( defender.ContondantResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Contondant, -(defender.ContondantResistance / 2) ) );

					if ( defender.TranchantResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Tranchant, -(defender.TranchantResistance / 2) ) );

					if ( defender.PerforantResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Perforant, -(defender.PerforantResistance / 2) ) );

					if ( defender.MagieResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Magie, -(defender.MagieResistance / 2) ) );
				}
				else
				{
					if ( defender.PhysicalResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Physical, (defender.PhysicalResistance > 70) ? -70 : -defender.PhysicalResistance ) );

					if ( defender.ContondantResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Contondant, (defender.ContondantResistance > 70) ? -70 : -defender.ContondantResistance ) );

					if ( defender.TranchantResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Tranchant, (defender.TranchantResistance > 70) ? -70 : -defender.TranchantResistance ) );

					if ( defender.PerforantResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Perforant, (defender.PerforantResistance > 70) ? -70 : -defender.PerforantResistance ) );

					if ( defender.MagieResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Magie, (defender.MagieResistance > 70) ? -70 : -defender.MagieResistance ) );
				}

				for ( int i = 0; i < mods.Count; ++i )
					defender.AddResistanceMod( mods[i] );

				defender.FixedEffect( 0x37B9, 10, 5 );

				timer = new ExpireTimer( defender, mods, TimeSpan.FromSeconds( 5.0 ) );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private List<ResistanceMod> m_Mods;

			public ExpireTimer( Mobile m, List<ResistanceMod> mods, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mods = mods;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				for ( int i = 0; i < m_Mods.Count; ++i )
					m_Mobile.RemoveResistanceMod( m_Mods[i] );

				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendMessage( "The corruption of your armor has worn off" );
				DoExpire();
			}
		}

		public RuneScarabee( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if( version < 1 )
			{
				for ( int i = 0; i < Skills.Length; ++i )
				{
					Skills[i].Cap = Math.Max( 100.0, Skills[i].Cap * 0.9 );

					if ( Skills[i].Base > Skills[i].Cap )
					{
						Skills[i].Base = Skills[i].Cap;
					}
				}
			}
		}
	}
}