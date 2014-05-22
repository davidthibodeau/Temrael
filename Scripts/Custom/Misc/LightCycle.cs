using System;
using Server;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;
using Server.Misc;

namespace Server
{

	public class LightCycle
	{
		public const int DayLevel = 0;
		public const int NightLevel = 25;
		public const int DungeonLevel = 26;
		public const int JailLevel = 0;

		private static int m_LevelOverride = int.MinValue;

		public static int LevelOverride
		{
			get{ return m_LevelOverride; }
			set
			{
				m_LevelOverride = value;

				for ( int i = 0; i < NetState.Instances.Count; ++i )
				{
					NetState ns = NetState.Instances[i];
					Mobile m = ns.Mobile;

					if ( m != null )
						m.CheckLightLevels( false );
				}
			}
		}

        public static Mobile NightLevelOverride
        {
            set
            {
                m_LevelOverride = -30;

                for (int i = 0; i < NetState.Instances.Count; ++i)
                {
                    NetState ns = NetState.Instances[i];
                    Mobile m = ns.Mobile;

                    if (m != null)
                        if (m == value)
                            m.CheckLightLevels(false);
                }
            }
        }

		public static void Initialize()
		{
			new LightCycleTimer().Start();
			EventSink.Login += new LoginEventHandler( OnLogin );

			CommandSystem.Register( "GlobalLight", AccessLevel.GameMaster, new CommandEventHandler( Light_OnCommand ) );
		}

		[Usage( "GlobalLight <value>" )]
		[Description( "Sets the current global light level." )]
		private static void Light_OnCommand( CommandEventArgs e )
		{
			if ( e.Length >= 1 )
			{
				LevelOverride = e.GetInt32( 0 );
				e.Mobile.SendMessage( "Global light level override has been changed to {0}.", m_LevelOverride );
			}
			else
			{
				LevelOverride = int.MinValue;
				e.Mobile.SendMessage( "Global light level override has been cleared." );
			}
		}

		public static void OnLogin( LoginEventArgs args )
		{
			Mobile m = args.Mobile;

			m.CheckLightLevels( true );
            Time.CheckSeason();

		}

		public static int ComputeLevelFor( Mobile from )
		{
            if (m_LevelOverride > int.MinValue)
                return m_LevelOverride;

            int hours, minutes;

            int level = NightLevel;

            Time.GetTime(out hours, out minutes);



            int season = Map.Felucca.Season;

            if (season == 0) // Printemps
            {
                if (hours < 5)
                    level = NightLevel;

                else if (hours < 8)
                    level = NightLevel + (((((hours - 5) * 60) + minutes) * (DayLevel - NightLevel)) / 180);

                else if (hours < 19)
                    level = DayLevel;

                else if (hours < 23)
                    level = DayLevel + (((((hours - 19) * 60) + minutes) * (NightLevel - DayLevel)) / 240);

                else if (hours < 24)
                    level = NightLevel;
            }
            else if (season == 1) // Été
            {
                if (hours < 5)
                    level = NightLevel;

                else if (hours < 8)
                    level = NightLevel + (((((hours - 5) * 60) + minutes) * (DayLevel - NightLevel)) / 180);

                else if (hours < 20)
                    level = DayLevel;

                else if (hours < 24)
                    level = DayLevel + (((((hours - 20) * 60) + minutes) * (NightLevel - DayLevel)) / 240);
            }
            else if (season == 2) // Automne
            {
                if (hours < 5)
                    level = NightLevel;

                else if (hours < 8)
                    level = NightLevel + (((((hours - 5) * 60) + minutes) * (DayLevel - NightLevel)) / 180);

                else if (hours < 19)
                    level = DayLevel;

                else if (hours < 23)
                    level = DayLevel + (((((hours - 19) * 60) + minutes) * (NightLevel - DayLevel)) / 240);

                else if (hours < 24)
                    level = NightLevel;
            }
            else if (season == 3) // Hiver
            {
                if (hours < 6)
                    level = NightLevel;

                else if (hours < 9)
                    level = NightLevel + (((((hours - 6) * 60) + minutes) * (DayLevel - NightLevel)) / 180);

                else if (hours < 18)
                    level = DayLevel;

                else if (hours < 22)
                    level = DayLevel + (((((hours - 18) * 60) + minutes) * (NightLevel - DayLevel)) / 240);

                else if (hours < 24)
                    level = NightLevel;
            }
            else if (season == 4) // Abyss
            {
                if (hours < 7)
                    level = NightLevel;

                else if (hours < 10)
                    level = NightLevel + (((((hours - 7) * 60) + minutes) * (DayLevel - NightLevel)) / 180);

                else if (hours < 17)
                    level = DayLevel;

                else if (hours < 20)
                    level = DayLevel + (((((hours - 17) * 60) + minutes) * (NightLevel - DayLevel)) / 180);

                else if (hours < 24)
                    level = NightLevel;
            }

            //from.SendMessage(level.ToString());

            /*Server.Misc.Weather weather = Server.Misc.Weather.GetWeather(from.Location);

            if (weather != null)
            {
                DensityOfCloud c = weather.tDensityOfCloud;

                if (c != DensityOfCloud.Cloud8)
                    level += (int)c / 3;
            }*/

            return level; // should never be

            /*if (hours < 6)
                return NightLevel;

            if (hours < 8)
                return NightLevel + (((((hours - 6) * 60) + minutes) * (DayLevel - NightLevel)) / 120);

            if (hours < 20)
                return DayLevel;

            if (hours < 22)
                return DayLevel + (((((hours - 20) * 60) + minutes) * (NightLevel - DayLevel)) / 120);

            if (hours < 24)
                return NightLevel;*/
		}

		private class LightCycleTimer : Timer
		{
			public LightCycleTimer() : base( TimeSpan.FromSeconds( 0 ), TimeSpan.FromSeconds( 5.0 ) )
			{
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				for ( int i = 0; i < NetState.Instances.Count; ++i )
				{
					NetState ns = NetState.Instances[i];
					Mobile m = ns.Mobile;

					if ( m != null )
						m.CheckLightLevels( false );
				}
			}
		}

		public class NightSightTimer : Timer
		{
			private Mobile m_Owner;

			public NightSightTimer( Mobile owner ) : base( TimeSpan.FromMinutes( Utility.Random( 15, 25 ) ) )
			{
				m_Owner = owner;
				Priority = TimerPriority.OneMinute;
			}

			protected override void OnTick()
			{
				m_Owner.EndAction( typeof( LightCycle ) );
				m_Owner.LightLevel = 0;
				BuffInfo.RemoveBuff( m_Owner, BuffIcon.NightSight );
			}
		}
	}
}
