using System;
using System.IO;
using Server;
using Server.Commands;

namespace Server.Misc
{
	public class AutoSave : Timer
	{
		private static TimeSpan m_Delay = TimeSpan.FromMinutes( 5.0 );
		private static TimeSpan m_Warning = TimeSpan.Zero;
		//private static TimeSpan m_Warning = TimeSpan.FromSeconds( 15.0 );

		public static void Initialize()
		{
			new AutoSave().Start();
			CommandSystem.Register( "SetSaves", AccessLevel.Coordinateur, new CommandEventHandler( SetSaves_OnCommand ) );
		}

		private static bool m_SavesEnabled = true;

		public static bool SavesEnabled
		{
			get{ return m_SavesEnabled; }
			set{ m_SavesEnabled = value; }
		}

		[Usage( "SetSaves <true | false>" )]
		[Description( "Enables or disables automatic shard saving." )]
		public static void SetSaves_OnCommand( CommandEventArgs e )
		{
			if ( e.Length == 1 )
			{
				m_SavesEnabled = e.GetBoolean( 0 );
				e.Mobile.SendMessage( "Saves have been {0}.", m_SavesEnabled ? "enabled" : "disabled" );
			}
			else
			{
				e.Mobile.SendMessage( "Format: SetSaves <true | false>" );
			}
		}

		public AutoSave() : base( m_Delay - m_Warning, m_Delay )
		{
			Priority = TimerPriority.OneMinute;
		}

		protected override void OnTick()
		{
			if ( !m_SavesEnabled || AutoRestart.Restarting || Core.Balancing)
				return;

			if ( m_Warning == TimeSpan.Zero )
			{
				Save( true );
			}
			else
			{
				int s = (int)m_Warning.TotalSeconds;
				int m = s / 60;
				s %= 60;

				if ( m > 0 && s > 0 )
					World.Broadcast( 0x35, true, "The world will save in {0} minute{1} and {2} second{3}.", m, m != 1 ? "s" : "", s, s != 1 ? "s" : "" );
				else if ( m > 0 )
					World.Broadcast( 0x35, true, "The world will save in {0} minute{1}.", m, m != 1 ? "s" : "" );
				else
					World.Broadcast( 0x35, true, "The world will save in {0} second{1}.", s, s != 1 ? "s" : "" );

				Timer.DelayCall( m_Warning, new TimerCallback( Save ) );
			}
		}

		public static void Save()
		{
			AutoSave.Save( false );
		}

		public static void Save( bool permitBackgroundWrite )
		{
			if ( AutoRestart.Restarting )
				return;

			World.WaitForWriteCompletion();

			try{ Backup(); }
			catch ( Exception e ) { Console.WriteLine("WARNING: Automatic backup FAILED: {0}", e); }

			World.Save( true, permitBackgroundWrite );
		}

        //Cette methode est appelee pour effectuer le restart avant un redemarrage.
        public static void SaveForRestart()
		{
			World.WaitForWriteCompletion();

			try{ Backup(); }
			catch ( Exception e ) { Console.WriteLine("WARNING: Automatic backup FAILED: {0}", e); }
            
			World.Save( true, false );
		}

		private static void Backup()
		{

            string root = Directories.AppendPath(Directories.bsaves, "Automatic");
            string back = Directories.AppendPath(Directories.bsaves, "LongTerm");

            DateTime now = DateTime.Now;
            string path = Directories.AppendPath(back, String.Format("{0:D4}-{1:D2}", now.Year, now.Month));
            string todaypath = Directories.AppendPath(root, "Today");

            string saves = Directories.saves;

            if (Directory.Exists(saves))
            {
                if (Directory.Exists(Path.Combine(path, Directories.FormatDay(now))))
                    Directory.Move(saves, FormatDirectory(todaypath, Directories.FormatTime(now)));
                else
                {
                    Directory.Move(saves, FormatDirectory(path, Directories.FormatDay(now)));
                    Directory.Delete(todaypath, true);
                }
            }
        }

		private static string FormatDirectory( string root, string timeStamp )
		{
            return Path.Combine(root, String.Format("{0}", timeStamp));
		}
	}
}