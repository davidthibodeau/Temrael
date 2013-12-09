using System;
using Server;
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public enum TimeOfDay
    {
        Night,
        ScaleToDay,
        Day,
        ScaleToNight
    }

    public enum Temperature
    {
        Glacial,
        Hivernal,
        Froid,
        Frais,
        Confortable,
        Chaud,
        Torride,
        Brûlant
    }

    public enum DensityOfCloud
    {
        Ensolleile,
        PassageNuageux,
        CielVariable,
        NuageuxAvecEclaircies,
        Nuageux,
        FaiblePluie,
        Pluie,
        FortePluie,
        Caverne
    }

    public enum QuantityOfWind
    {
        Aucun,
        Faible,
        Modeste,
        Rafale,
        Bourrasque,
        Tempete,
        Tornade,
        Typhon
    }
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
            Calendrier.CheckSeason();

		}

        public static TimeOfDay GetTimeofDay()
        {
            int hours, minutes;

            Server.Items.Clock.GetTime(out hours, out minutes);

            switch (Map.Felucca.Season)
            {
                case 0: // Printemps
                    {
                        if (hours < 5)
                            return TimeOfDay.Night;

                        if (hours < 8)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 19)
                            return TimeOfDay.Day;

                        if (hours < 23)
                            return TimeOfDay.ScaleToNight;

                        if (hours < 24)
                            return TimeOfDay.Night;

                        break;
                    }
                case 1: // Été
                    {
                        if (hours < 5)
                            return TimeOfDay.Night;

                        if (hours < 8)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 20)
                            return TimeOfDay.Day;

                        if (hours < 24)
                            return TimeOfDay.ScaleToNight;

                        break;
                    }
                case 2: // Automne
                    {
                        if (hours < 5)
                            return TimeOfDay.Night;

                        if (hours < 8)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 19)
                            return TimeOfDay.Day;

                        if (hours < 23)
                            return TimeOfDay.ScaleToNight;

                        if (hours < 24)
                            return TimeOfDay.Night;

                        break;
                    }
                case 3: // Hiver
                    {
                        if (hours < 6)
                            return TimeOfDay.Night;

                        if (hours < 9)
                            return TimeOfDay.ScaleToDay;

                        if (hours < 18)
                            return TimeOfDay.Day;

                        if (hours < 22)
                            return TimeOfDay.ScaleToNight;

                        if (hours < 24)
                            return TimeOfDay.Night;

                        break;
                    }
            }

            return TimeOfDay.Night; // should never be
        }

		public static int ComputeLevelFor( Mobile from )
		{
            if (m_LevelOverride > int.MinValue)
                return m_LevelOverride;

            int hours, minutes;

            int level = NightLevel;

            Server.Items.Clock.GetTime(out hours, out minutes);

            /* OSI times:
             * 
             * Midnight ->  3:59 AM : Night
             *  4:00 AM -> 11:59 PM : Day
             * 
             * RunUO times:
             * 
             * 10:00 PM -> 11:59 PM : Scale to night
             * Midnight ->  3:59 AM : Night
             *  4:00 AM ->  5:59 AM : Scale to day
             *  6:00 AM ->  9:59 PM : Day
             *
             * Server times:
             * 
             * Été
             *
             *  5:00 AM -> 7:59 AM : Scale to day
             *  8:00 AM -> 7:59 PM : Day
             *  8:00 PM -> 11:59 PM : Scale to night
             *  00:00 AM -> 4:59 AM : Night
             *
             * Automne
             *
             *  5:00 AM -> 7:59 AM : Scale to day
             *  8:00 AM -> 6:59 PM : Day
             *  7:00 PM -> 10:59 PM : Scale to night
             *  11:00 PM -> 4:59 AM : Night
             *
             * Hiver
             *
             *  6:00 AM -> 8:59 AM : Scale to day
             *  9:00 AM -> 5:59 PM : Day
             *  6:00 PM -> 9:59 PM : Scale to night
             *  10:00 PM -> 5:59 AM : Night 
             * 
             * Abyss
             *
             *  7:00 AM -> 9:59 AM : Scale to day
             *  10:00 AM -> 4:59 PM : Day
             *  5:00 PM -> 7:59 PM : Scale to night
             *  8:00 PM -> 6:59 AM : Night 
             * 
             * Printemps
             * 
             *  5:00 AM -> 7:59 AM : Scale to day
             *  8:00 AM -> 6:59 PM : Day
             *  7:00 PM -> 10:59 PM : Scale to night
             *  11:00 PM -> 4:59 AM : Night 
             * 
             */

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
