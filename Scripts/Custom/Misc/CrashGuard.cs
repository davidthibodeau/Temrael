using System;
using System.IO;
//using System.Web.Mail;
using System.Collections;
using System.Diagnostics;
using Server;
using Server.Network;
using Server.Accounting;
using System.Collections.Generic;

namespace Server.Misc
{
	public class CrashGuard
	{
		private static bool Enabled = true;
		private static bool SaveBackup = true;
		private static bool RestartServer = true;
		private static bool GenerateReport = true;

		public static void Initialize()
		{
			if ( Enabled ) // If enabled, register our crash event handler
				EventSink.Crashed += new CrashedEventHandler( CrashGuard_OnCrash );
		}

		public static void CrashGuard_OnCrash( CrashedEventArgs e )
		{
			if ( SaveBackup )
				Backup();

			if ( GenerateReport )
				GenerateCrashReport( e );

			if ( Core.Service )
				e.Close = true;
			else if ( RestartServer )
				Restart( e );
		}

		private static void Restart( CrashedEventArgs e )
		{
			Console.Write( "Crash: Restarting..." );

			try
			{
				Process.Start( Core.ExePath, Core.Arguments );
				Console.WriteLine( "done" );

				e.Close = true;
			}
			catch
			{
				Console.WriteLine( "failed" );
			}
		}

		private static void CopyFile( string rootOrigin, string rootBackup, string path )
		{
			string originPath = Path.Combine( rootOrigin, path );
			string backupPath = Path.Combine( rootBackup, path );

			try
			{
				if ( File.Exists( originPath ) )
					File.Copy( originPath, backupPath );
			}
			catch
			{
			}
		}

		private static void Backup()
		{
			Console.Write( "Crash: Backing up..." );

			try
			{
                string rootBackup = Directories.AppendPath(Directories.bsaves, String.Format("Crashed/{0}", Directories.Now));
                string rootOrigin = Directories.saves;

				// Create new directories
                Directories.AppendPath(rootBackup, "Accounts/");
                Directories.AppendPath(rootBackup, "Items/");
                Directories.AppendPath(rootBackup, "Mobiles/");
                Directories.AppendPath(rootBackup, "Guilds/");
                Directories.AppendPath(rootBackup, "Regions/");

				// Copy files
                CopyFile(rootOrigin, rootBackup, "Accounts/Accounts.xml");

                CopyFile(rootOrigin, rootBackup, "Items/Items.bin");
                CopyFile(rootOrigin, rootBackup, "Items/Items.idx");
                CopyFile(rootOrigin, rootBackup, "Items/Items.tdb");

				CopyFile( rootOrigin, rootBackup, "Mobiles/Mobiles.bin" );
				CopyFile( rootOrigin, rootBackup, "Mobiles/Mobiles.idx" );
				CopyFile( rootOrigin, rootBackup, "Mobiles/Mobiles.tdb" );

				CopyFile( rootOrigin, rootBackup, "Guilds/Guilds.bin" );
				CopyFile( rootOrigin, rootBackup, "Guilds/Guilds.idx" );

				CopyFile( rootOrigin, rootBackup, "Regions/Regions.bin" );
				CopyFile( rootOrigin, rootBackup, "Regions/Regions.idx" );

				Console.WriteLine( "done" );
			}
			catch
			{
				Console.WriteLine( "failed" );
			}
		}

		private static void GenerateCrashReport( CrashedEventArgs e )
		{
			Console.Write( "Crash: Generating report..." );

			try
			{
                string fileName = String.Format("{0}.log", Directories.Now);

                string rootCrash = Directories.AppendPath(Directories.errors, "Crashes");
				string filePath = Path.Combine( rootCrash, fileName );

				using ( StreamWriter op = new StreamWriter( filePath ) )
				{
					Version ver = Core.Assembly.GetName().Version;

					op.WriteLine( "Server Crash Report" );
					op.WriteLine( "===================" );
					op.WriteLine();
					op.WriteLine( "RunUO Version {0}.{1}.{3}, Build {2}", ver.Major, ver.Minor, ver.Revision, ver.Build );
					op.WriteLine( "Operating System: {0}", Environment.OSVersion );
					op.WriteLine( ".NET Framework: {0}", Environment.Version );
					op.WriteLine( "Time: {0}", DateTime.Now );

					try { op.WriteLine( "Mobiles: {0}", World.Mobiles.Count ); }
					catch {}

					try { op.WriteLine( "Items: {0}", World.Items.Count ); }
					catch {}

					op.WriteLine( "Clients:" );

					try
					{
                        List<NetState> states = NetState.Instances;

						op.WriteLine( "- Count: {0}", states.Count );

						for ( int i = 0; i < states.Count; ++i )
						{
							NetState state = (NetState)states[i];

							op.Write( "+ {0}:", state );

							Account a = state.Account as Account;

							if ( a != null )
								op.Write( " (account = {0})", a.Username );

							Mobile m = state.Mobile;

							if ( m != null )
								op.Write( " (mobile = 0x{0:X} '{1}')", m.Serial.Value, m.Name );

							op.WriteLine();
						}
					}
					catch
					{
						op.WriteLine( "- Failed" );
					}

					op.WriteLine();

					op.WriteLine( "Exception:" );
					op.WriteLine( e.Exception );
				}

				Console.WriteLine( "done" );
			}
			catch
			{
				Console.WriteLine( "failed" );
			}
		}
    }
}