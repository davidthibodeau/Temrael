using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Server.Accounting
{
	public class Accounts
	{
		private Dictionary<string, IAccount> m_Accounts = new Dictionary<string, IAccount>();

        private static Accounts m_ServerAccounts = new Accounts();

        public static Accounts ServerAccounts
        {
            get { return m_ServerAccounts; }
        } 

		public static void Configure()
		{
			EventSink.WorldLoad += new WorldLoadEventHandler( Load );
			EventSink.WorldSave += new WorldSaveEventHandler( Save );
		}


		public int Count { get { return m_Accounts.Count; } }

		public ICollection<IAccount> GetAccounts()
		{
#if !MONO
			return m_Accounts.Values;
#else
			return new List<IAccount>( m_Accounts.Values );
#endif
		}

		public IAccount GetAccount( string username )
		{
			IAccount a;

			m_Accounts.TryGetValue( username, out a );

			return a;
		}

		public void Add( IAccount a )
		{
			m_Accounts[a.Username] = a;
		}
		
		public void Remove( string username )
		{
			m_Accounts.Remove( username );
		}

        public static void Load()
        {
            string path = Directories.AppendPath(Directories.saves, "Accounts");
            string filePath = Path.Combine(path, "accounts.xml");

            ServerAccounts.Load(filePath);
        }

		public void Load(string filePath)
		{
			m_Accounts = new Dictionary<string, IAccount>( 32, StringComparer.OrdinalIgnoreCase );

			if ( !File.Exists( filePath ) )
				return;

			XmlDocument doc = new XmlDocument();
			doc.Load( filePath );

			XmlElement root = doc["accounts"];

			foreach ( XmlElement account in root.GetElementsByTagName( "account" ) )
			{
				try
				{
					Account acct = new Account(this, account );
				}
				catch
				{
					Console.WriteLine( "Warning: Account instance load failed" );
				}
			}
		}

        public static void Save(WorldSaveEventArgs e)
        {
            string path = Directories.AppendPath(Directories.saves, "Accounts");

            string filePath = Path.Combine(path, "accounts.xml");

            ServerAccounts.Save(filePath);
        }

        public void Save(string filePath)
        {
			using ( StreamWriter op = new StreamWriter( filePath ) )
			{
				XmlTextWriter xml = new XmlTextWriter( op );

				xml.Formatting = Formatting.Indented;
				xml.IndentChar = '\t';
				xml.Indentation = 1;

				xml.WriteStartDocument( true );

				xml.WriteStartElement( "accounts" );

				xml.WriteAttributeString( "count", m_Accounts.Count.ToString() );

				foreach ( Account a in GetAccounts() )
					a.Save( xml );

				xml.WriteEndElement();

				xml.Close();
			}
		}
	}
}