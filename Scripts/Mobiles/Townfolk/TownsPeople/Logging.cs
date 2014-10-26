using System;
using System.IO;
using Server;
using Server.Accounting;
using Server.Mobiles;

namespace Server.Commands
{
	public class TownspersonLogging
	{
		private static StreamWriter m_Output;

		public static StreamWriter Output
		{
			get{ return m_Output; } 
		}

		public static void Initialize()
		{


			string directory = Directories.AppendPath(Directories.logs,"Townsperson");



			try
			{
                string today = Directories.Today;
				m_Output = new StreamWriter( Path.Combine( directory, String.Format( "{0}.log", today) ), true );
				
				m_Output.AutoFlush = true;

				m_Output.WriteLine( "##############################" );
				m_Output.WriteLine( "Log started on {0}", DateTime.Now );
				m_Output.WriteLine( "Townsperson Logging set to {0}", Townsperson.Logging.ToString() );
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
					return String.Format( "{0} ('{1}')", m, ((Account)m.Account).Username );
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
			WriteLine( from, String.Format( format, args ) );
		}

		public static void WriteLine( Mobile from, string text )
		{
			try
			{
				m_Output.WriteLine( "{0}: {1}: {2}", DateTime.Now.ToShortTimeString(), TownspersonLogging.Format( from ), text );

                // Crée un double des logs sans réelle raison ?
                //string path = Directories.AppendPath(Directories.logs, "Townsperson" );
                //path = Path.Combine(path, String.Format("{0}.log", Directories.Today));

                //using ( StreamWriter sw = new StreamWriter( path, true ) )
                //    sw.WriteLine( "{0}: {1}: {2}", DateTime.Now, TownspersonLogging.Format( from ), text );
			}
			catch
			{
			}
		}
	}
}