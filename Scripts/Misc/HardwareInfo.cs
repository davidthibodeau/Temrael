using System;
using Server;
using Server.Commands;
using Server.Accounting;
using Server.Network;
using Server.Targeting;

namespace Server
{
	public class HardwareInfo
	{
		private int m_InstanceID;
		private int m_OSMajor, m_OSMinor, m_OSRevision;
		private int m_CpuManufacturer, m_CpuFamily, m_CpuModel, m_CpuClockSpeed, m_CpuQuantity;
		private int m_PhysicalMemory;
		private int m_ScreenWidth, m_ScreenHeight, m_ScreenDepth;
		private int m_DXMajor, m_DXMinor;
		private int m_VCVendorID, m_VCDeviceID, m_VCMemory;
		private int m_Distribution, m_ClientsRunning, m_ClientsInstalled, m_PartialInstalled;
		private string m_VCDescription;
		private string m_Language;
		private string m_Unknown;
        private DateTime m_TimeReceived;

		[CommandProperty( AccessLevel.Batisseur )]
		public int CpuModel{ get{ return m_CpuModel; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int CpuClockSpeed{ get{ return m_CpuClockSpeed; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int CpuQuantity{ get{ return m_CpuQuantity; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int OSMajor{ get{ return m_OSMajor; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int OSMinor{ get{ return m_OSMinor; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int OSRevision{ get{ return m_OSRevision; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int InstanceID{ get{ return m_InstanceID; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int ScreenWidth{ get{ return m_ScreenWidth; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int ScreenHeight{ get{ return m_ScreenHeight; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int ScreenDepth{ get{ return m_ScreenDepth; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int PhysicalMemory{ get{ return m_PhysicalMemory; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int CpuManufacturer{ get{ return m_CpuManufacturer; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int CpuFamily{ get{ return m_CpuFamily; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int VCVendorID{ get{ return m_VCVendorID; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int VCDeviceID{ get{ return m_VCDeviceID; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int VCMemory{ get{ return m_VCMemory; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int DXMajor{ get{ return m_DXMajor; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int DXMinor{ get{ return m_DXMinor; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public string VCDescription{ get{ return m_VCDescription; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public string Language{ get{ return m_Language; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int Distribution{ get{ return m_Distribution; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int ClientsRunning{ get{ return m_ClientsRunning; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int ClientsInstalled{ get{ return m_ClientsInstalled; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public int PartialInstalled{ get{ return m_PartialInstalled; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public string Unknown{ get{ return m_Unknown; } }

        [CommandProperty( AccessLevel.Batisseur )]
        public DateTime TimeReceived { get { return m_TimeReceived; } }

		public static void Initialize()
		{
			PacketHandlers.Register( 0xD9, 0x10C, false, new OnPacketReceive( OnReceive ) );

			CommandSystem.Register( "HWInfo", AccessLevel.Batisseur, new CommandEventHandler( HWInfo_OnCommand ) );
		}

		[Usage( "HWInfo" )]
		[Description( "Displays information about a targeted player's hardware." )]
		public static void HWInfo_OnCommand( CommandEventArgs e )
		{
			e.Mobile.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( HWInfo_OnTarget ) );
			e.Mobile.SendMessage( "Target a player to view their hardware information." );
		}

		public static void HWInfo_OnTarget( Mobile from, object obj )
		{
			if ( obj is Mobile && ((Mobile)obj).Player )
			{
				Mobile m = (Mobile)obj;
				Account acct = m.Account as Account;

				if ( acct != null )
				{
					HardwareInfo hwInfo = acct.HardwareInfo;

					if ( hwInfo != null )
						CommandLogging.WriteLine( from, "{0} {1} viewing hardware info of {2}", from.AccessLevel, CommandLogging.Format( from ), CommandLogging.Format( m ) );

					if ( hwInfo != null )
						from.SendGump( new Gumps.PropertiesGump( from, hwInfo ) );
					else
						from.SendMessage( "No hardware information for that account was found." );
				}
				else
				{
					from.SendMessage( "No account has been attached to that player." );
				}
			}
			else
			{
				from.BeginTarget( -1, false, TargetFlags.None, new TargetCallback( HWInfo_OnTarget ) );
				from.SendMessage( "That is not a player. Try again." );
			}
		}

		public static void OnReceive( NetState state, PacketReader pvSrc )
		{
			pvSrc.ReadByte(); // 1: <4.0.1a, 2>=4.0.1a

			HardwareInfo info = new HardwareInfo();

			info.m_InstanceID = pvSrc.ReadInt32();
			info.m_OSMajor = pvSrc.ReadInt32();
			info.m_OSMinor = pvSrc.ReadInt32();
			info.m_OSRevision = pvSrc.ReadInt32();
			info.m_CpuManufacturer = pvSrc.ReadByte();
			info.m_CpuFamily = pvSrc.ReadInt32();
			info.m_CpuModel = pvSrc.ReadInt32();
			info.m_CpuClockSpeed = pvSrc.ReadInt32();
			info.m_CpuQuantity = pvSrc.ReadByte();
			info.m_PhysicalMemory = pvSrc.ReadInt32();
			info.m_ScreenWidth = pvSrc.ReadInt32();
			info.m_ScreenHeight = pvSrc.ReadInt32();
			info.m_ScreenDepth = pvSrc.ReadInt32();
			info.m_DXMajor = pvSrc.ReadInt16();
			info.m_DXMinor = pvSrc.ReadInt16();
			info.m_VCDescription = pvSrc.ReadUnicodeStringLESafe( 64 );
			info.m_VCVendorID = pvSrc.ReadInt32();
			info.m_VCDeviceID = pvSrc.ReadInt32();
			info.m_VCMemory = pvSrc.ReadInt32();
			info.m_Distribution = pvSrc.ReadByte();
			info.m_ClientsRunning = pvSrc.ReadByte();
			info.m_ClientsInstalled = pvSrc.ReadByte();
			info.m_PartialInstalled = pvSrc.ReadByte();
			info.m_Language = pvSrc.ReadUnicodeStringLESafe( 4 );
			info.m_Unknown = pvSrc.ReadStringSafe( 64 );

            info.m_TimeReceived = DateTime.Now;

			Account acct = state.Account as Account;

			if ( acct != null )
				acct.HardwareInfo = info;
		}
	}
}