using System;
using Server;
using Server.Items;
using Server.Gumps;

namespace Server.Items
{
	public enum ScheduleAct
	{
		None,
		Eat,
		Sleep,
		Wander
	};
	
	public class ScheduleItem : Item
	{
		private ScheduleProps m_ScheduleProps;
		private ScheduleEntry[] m_Entries = new ScheduleEntry[12];
		private int m_CurEntry = -1;
		private DateTime m_nextAct = DateTime.MinValue;
	
		// constructor
		[Constructable]
		public ScheduleItem() : base ( 0xFBD )
		{
			Weight = 0;
			Name = "Schedule";
			Visible = false;
			
			SetUpScheduler();

			for (int i = 0; i < 12; i++) {
				m_Entries[i] = new ScheduleEntry();
			}
		}
		
		// serialize constructor
		public ScheduleItem( Serial serial ) : base( serial )
		{
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			from.SendGump( new PropertiesGump( from, this ) );
		}
		
		private void SetUpScheduler() {
			m_ScheduleProps = new ScheduleProps( this );
		}

		public DateTime nextAct { get { return m_nextAct; } set { m_nextAct = value; } }
		public ScheduleEntry[] Entries { get { return m_Entries; } set { m_Entries = value; } }
		public int CurEntry {
			get { return m_CurEntry; }
			set {
				m_CurEntry = value;
			}
		}
				
		[CommandProperty( AccessLevel.Batisseur )]
		public ScheduleProps Schedule { get { return m_ScheduleProps; } set { } }

		// serialize saver
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			
			writer.Write( (bool) true ); // change later to wether its on/off

			writer.Write( (int) m_CurEntry );

			writer.Write( (DateTime) m_nextAct );
			
			for (int i = 0; i < 12; i++)
			{
				writer.Write((WayPoint) m_Entries[i].waypoint);
				writer.Write((string) m_Entries[i].activity.ToString());
			}
		}
		
		// serialize loader
		public override void Deserialize( GenericReader reader ) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
			
			bool somebool = reader.ReadBool(); // change later to wether its on/off
			
			m_CurEntry = reader.ReadInt();
			
			m_nextAct = reader.ReadDateTime();
			
			for (int i = 0; i < 12; i++)
			{
				WayPoint way = (WayPoint)reader.ReadItem();
				string actstr = reader.ReadString();
				ScheduleAct act = ScheduleAct.None;
				try {
					act = (ScheduleAct)Enum.Parse(typeof(ScheduleAct), actstr);
				}
				catch {
					// TODO -- Some form of error report
				}
				
				m_Entries[i] = new ScheduleEntry(way, act);
			}
			
			SetUpScheduler();
		}
		
		[PropertyObject]
		public class ScheduleProps
		{
			private ScheduleItem m_Schedule;
		
			public ScheduleProps( ScheduleItem s )
			{
				m_Schedule = s;
			}
			
			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour00 { get { return m_Schedule.Entries[0]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour02 { get { return m_Schedule.Entries[1]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour04 { get { return m_Schedule.Entries[2]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour06 { get { return m_Schedule.Entries[3]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour08 { get { return m_Schedule.Entries[4]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour10 { get { return m_Schedule.Entries[5]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour12 { get { return m_Schedule.Entries[6]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour14 { get { return m_Schedule.Entries[7]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour16 { get { return m_Schedule.Entries[8]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour18 { get { return m_Schedule.Entries[9]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour20 { get { return m_Schedule.Entries[10]; } set { } }

			[CommandProperty( AccessLevel.Batisseur )]
			public ScheduleEntry Hour22 { get { return m_Schedule.Entries[11]; } set { } }
		}
	}
	
	[PropertyObject]
	public class ScheduleEntry
	{
		public WayPoint waypoint;
		public ScheduleAct activity;
		
		public ScheduleEntry(WayPoint w, ScheduleAct a)
		{
			waypoint = w;
			activity = a;
		}

		public ScheduleEntry()
		{
			waypoint = null;
			activity = ScheduleAct.None;
		}
		[CommandProperty( AccessLevel.Batisseur )]
		public WayPoint Waypoint { get { return waypoint; } set { waypoint = value; } }

		[CommandProperty( AccessLevel.Batisseur )]
		public ScheduleAct Activity { get { return activity; } set { activity = value; } }
	}
}