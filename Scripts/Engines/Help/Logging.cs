using System;
using System.IO;
using Server;
using Server.Accounting;
using Server.Mobiles;

namespace Server.Engines.Help
{
    public class SpeechlogLogging
    {
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
                string path = Directories.AppendPath(Directories.logs, "Speechlogs");

				Account acct = from.Account as Account;

				string name = ( acct == null ? from.Name : acct.Username );

                path = Directories.AppendPath(path, from.AccessLevel.ToString());
                path = Directories.AppendPath(path, name);
                string today = Directories.FormatDay(e.Created);
				path = Path.Combine( path, String.Format( "{0} {1}.log", from.Name, today ) );

				using ( StreamWriter sw = new StreamWriter( path, true ) )
					sw.WriteLine( "[{0}] {1}: {2}", e.Created, SpeechlogLogging.Format(e.From), e.Speech);
			}
			catch
			{
			}
        }
	
    }
}
