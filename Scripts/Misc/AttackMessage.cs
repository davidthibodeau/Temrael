using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;

namespace Server.Misc
{
	public class AttackMessage
	{
		private const string AggressorFormat = "Vous attaquez !";
		private const string AggressedFormat = "Vous êtes sous attaque !";
		private const int Hue = 0x22;

		private static TimeSpan Delay = TimeSpan.FromMinutes( 1.0 );

		public static void Initialize()
		{
			EventSink.AggressiveAction += new AggressiveActionEventHandler( EventSink_AggressiveAction );
		}

		public static void EventSink_AggressiveAction( AggressiveActionEventArgs e )
		{
			Mobile aggressor = e.Aggressor;
			Mobile aggressed = e.Aggressed;

			if ( !aggressor.Player || !aggressed.Player )
				return;

			if ( !CheckAggressions( aggressor, aggressed ) )
			{
				aggressor.LocalOverheadMessage( MessageType.Regular, Hue, true, String.Format( AggressorFormat ) );
				aggressed.LocalOverheadMessage( MessageType.Regular, Hue, true, String.Format( AggressedFormat ) );
			}
		}

		public static bool CheckAggressions( Mobile m1, Mobile m2 )
		{
			List<AggressorInfo> list = m1.Aggressors;

			for ( int i = 0; i < list.Count; ++i )
			{
				AggressorInfo info = list[i];

				if ( info.Attacker == m2 && DateTime.Now < (info.LastCombatTime + Delay) )
					return true;
			}

			list = m2.Aggressors;

			for ( int i = 0; i < list.Count; ++i )
			{
				AggressorInfo info = list[i];

				if ( info.Attacker == m1 && DateTime.Now < (info.LastCombatTime + Delay) )
					return true;
			}

			return false;
		}
	}
}