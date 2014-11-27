using System;
using Server.Items;
using Server.Network;
using Server.Engines.Combat;

namespace Server.Items
{
	public class Fists : BaseMeleeWeapon
	{
		public static void Initialize()
		{
			Mobile.DefaultWeapon = new Fists();

			EventSink.DisarmRequest += new DisarmRequestEventHandler( EventSink_DisarmRequest );
			EventSink.StunRequest += new StunRequestEventHandler( EventSink_StunRequest );
		}

		public override WeaponAbility PrimaryAbility{ get{ return WeaponAbility.Disarm; } }
		public override WeaponAbility SecondaryAbility{ get{ return WeaponAbility.ParalyzingBlow; } }

		//public override int DefMinDamage{ get{ return 1; } }
		//public override int DefMaxDamage{ get{ return 4; } }
		public override int DefSpeed{ get{ return 40; } }

		public override int DefHitSound{ get{ return -1; } }
		public override int DefMissSound{ get{ return -1; } }

		public override WeaponType DefType{ get{ return WeaponType.Fists; } }
		public override WeaponAnimation DefAnimation{ get{ return WeaponAnimation.Wrestle; } }

        public override CombatStrategy Strategy { get { return StrategyPoings.Strategy; } }

		public Fists() : base( 0 )
		{
			Visible = false;
			Movable = false;
			Quality = WeaponQuality.Regular;
		}

		public Fists( Serial serial ) : base( serial )
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

			Delete();
		}

		/* Wrestling moves */

		private static bool CheckMove( Mobile m, SkillName other )
		{
			double wresValue = m.Skills[SkillName.Anatomie].Value;
			double scndValue = m.Skills[other].Value;

			/* 40% chance at 80, 80
			 * 50% chance at 100, 100
			 * 60% chance at 120, 120
			 */

			double chance = (wresValue + scndValue) / 400.0;

			return ( chance >= Utility.RandomDouble() );
		}

		private static bool HasFreeHands( Mobile m )
		{
			Item item = m.FindItemOnLayer( Layer.OneHanded );

			if ( item != null && !(item is Spellbook) )
				return false;

			return m.FindItemOnLayer( Layer.TwoHanded ) == null;
		}

		private static void EventSink_DisarmRequest( DisarmRequestEventArgs e )
		{
			Mobile m = e.Mobile;

			double armsValue = m.Skills[SkillName.Tactiques].Value;
			double wresValue = m.Skills[SkillName.Anatomie].Value;

			if ( !HasFreeHands( m ) )
			{
				m.SendLocalizedMessage( 1004029 ); // You must have your hands free to attempt to disarm your opponent.
				m.DisarmReady = false;
			}
			else if ( armsValue >= 80.0 && wresValue >= 80.0 )
			{
				m.DisruptiveAction();
				m.DisarmReady = !m.DisarmReady;
				m.SendLocalizedMessage( m.DisarmReady ? 1019013 : 1019014 );
			}
			else
			{
				m.SendLocalizedMessage( 1004002 ); // You are not skilled enough to disarm your opponent.
				m.DisarmReady = false;
			}
		}

		private static void EventSink_StunRequest( StunRequestEventArgs e )
		{
			Mobile m = e.Mobile;

			//double anatValue = m.Skills[SkillName.Anatomy].Value;
			double wresValue = m.Skills[SkillName.Anatomie].Value;

			if ( !HasFreeHands( m ) )
			{
				m.SendLocalizedMessage( 1004031 ); // You must have your hands free to attempt to stun your opponent.
				m.StunReady = false;
			}
			else if ( wresValue >= 80.0 )
			{
				m.DisruptiveAction();
				m.StunReady = !m.StunReady;
				m.SendLocalizedMessage( m.StunReady ? 1019011 : 1019012 );
			}
			else
			{
				m.SendLocalizedMessage( 1004008 ); // You are not skilled enough to stun your opponent.
				m.StunReady = false;
			}
		}

		private class MoveDelayTimer : Timer
		{
			private Mobile m_Mobile;

			public MoveDelayTimer( Mobile m ) : base( TimeSpan.FromSeconds( 10.0 ) )
			{
				m_Mobile = m;

				Priority = TimerPriority.TwoFiftyMS;

				m_Mobile.BeginAction( typeof( Fists ) );
			}

			protected override void OnTick()
			{
				m_Mobile.EndAction( typeof( Fists ) );
			}
		}

		private static void StartMoveDelay( Mobile m )
		{
			new MoveDelayTimer( m ).Start();
		}
	}
}