using System;
using System.IO;
using Server;
using Server.Accounting;

namespace Server.Commands
{
	public class CommandLogging
	{
		private static StreamWriter m_Output;
		private static bool m_Enabled = true;
        private static readonly string directory = Directories.AppendPath(Directories.logs, "Commands");

		public static bool Enabled{ get{ return m_Enabled; } set{ m_Enabled = value; } }

		public static StreamWriter Output{ get{ return m_Output; } }

		public static void Initialize()
		{
			EventSink.Command += new CommandEventHandler( EventSink_Command );

			try
			{
				m_Output = new StreamWriter( Path.Combine( directory, String.Format( "{0}.log", Directories.Today) ), true );

				m_Output.AutoFlush = true;

				m_Output.WriteLine( "##############################" );
				m_Output.WriteLine( "Log started on {0}", DateTime.Now );
				m_Output.WriteLine();
			}
			catch
			{
			}
		}

		public static object Format( object o )
		{
			if ( o is Mobile )
			{
				Mobile m = (Mobile)o;

				if ( m.Account == null )
					return String.Format( "{0} (no account)", m );
				else
					return String.Format( "{0} ('{1}')", m, m.Account.Username );
			}
			else if ( o is Item )
			{
				Item item = (Item)o;

				return String.Format( "0x{0:X} ({1})", item.Serial.Value, item.GetType().Name );
			}

			return o;
		}

		public static void WriteLine( Mobile from, string format, params object[] args )
		{
			if ( !m_Enabled )
				return;

			WriteLine( from, String.Format( format, args ) );
		}

		public static void WriteLine( Mobile from, string text )
		{
			if ( !m_Enabled )
				return;

			try
			{
				m_Output.WriteLine( "{0}: {1}: {2}", DateTime.Now, from.NetState, text );

				Account acct = from.Account as Account;

				string name = ( acct == null ? from.Name : acct.Username );

                string path = Directories.AppendPath(directory, from.AccessLevel.ToString());
				path = Path.Combine( path, String.Format( "{0}.log", name ) );

				using ( StreamWriter sw = new StreamWriter( path, true ) )
					sw.WriteLine( "{0}: {1}: {2}", DateTime.Now, from.NetState, text );
			}
			catch
			{
			}
		}

		private static char[] m_NotSafe = new char[]{ '\\', '/', ':', '*', '?', '"', '<', '>', '|' };

		public static string Safe( string ip )
		{
			if ( ip == null )
				return "null";

			ip = ip.Trim();

			if ( ip.Length == 0 )
				return "empty";

			bool isSafe = true;

			for ( int i = 0; isSafe && i < m_NotSafe.Length; ++i )
				isSafe = ( ip.IndexOf( m_NotSafe[i] ) == -1 );

			if ( isSafe )
				return ip;

			System.Text.StringBuilder sb = new System.Text.StringBuilder( ip );

			for ( int i = 0; i < m_NotSafe.Length; ++i )
				sb.Replace( m_NotSafe[i], '_' );

			return sb.ToString();
		}

		public static void EventSink_Command( CommandEventArgs e )
		{
			WriteLine( e.Mobile, "{0} {1} used command '{2} {3}'", e.Mobile.AccessLevel, Format( e.Mobile ), e.Command, e.ArgString );
		}

		public static void LogChangeProperty( Mobile from, object o, string name, string value )
		{
			WriteLine( from, "{0} {1} set property '{2}' of {3} to '{4}'", from.AccessLevel, Format( from ), name, Format( o ), value );
		}
	}
}