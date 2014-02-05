using System;
using System.IO;
using Server;
using Server.Accounting;
using Server.Mobiles;

namespace Server.Engines.Help
{
    public class SpeechlogLogging
    {
        private static StreamWriter m_Output;

		public static StreamWriter Output
		{
			get{ return m_Output; } 
		}

		public static void Initialize()
		{

            if ( !Directory.Exists( "Backups" ) )
				Directory.CreateDirectory( "Backups" );
			if ( !Directory.Exists( "Backups/Logs" ) )
				Directory.CreateDirectory( "Backups/Logs" );

			string directory = "Backups/Logs/Speechlogs";

			if ( !Directory.Exists( directory ) )
				Directory.CreateDirectory( directory );

		}

		public static object Format( object o )
		{
			if ( o is Mobile )
			{
				Mobile m = (Mobile)o;

				if ( m.Account == null )
					return String.Format( "{0} (no account)", m );
				else
					return String.Format( "{0} ('{1}')", m, ((Account)m.Account).Username );
			}
			else if ( o is Item )
			{
				Item item = (Item)o;

				return String.Format( "0x{0:X} ({1})", item.Serial.Value, item.GetType().Name );
			}

			return o;
		}

		
        public static void WriteLine(Mobile from, SpeechLogEntry e)
        {
           try
			{
				string path = Core.BaseDirectory;

				Account acct = from.Account as Account;

				string name = ( acct == null ? from.Name : acct.Username );
               
                AppendPath( ref path, "Backups" );
				AppendPath( ref path, "Logs" );
				AppendPath( ref path, "Speechlogs" );
				AppendPath( ref path, from.AccessLevel.ToString() );
                AppendPath(ref path, name);
                DateTime now = e.Created;
                string today = String.Format("{0}-{1:D2}-{2:D2}, {3}", now.Year, now.Month, now.Day, now.DayOfWeek);
				path = Path.Combine( path, String.Format( "{0} {1}.log", from.Name, today ) );

				using ( StreamWriter sw = new StreamWriter( path, true ) )
					sw.WriteLine( "[{0}] {1}: {2}", e.Created, SpeechlogLogging.Format(e.From), e.Speech);
			}
			catch
			{
			}
        }

		public static void AppendPath( ref string path, string toAppend )
		{
			path = Path.Combine( path, toAppend );

			if ( !Directory.Exists( path ) )
				Directory.CreateDirectory( path );
		}
	
    }
}
