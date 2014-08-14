using System;
using Server;
using Server.Targeting;
using Server.Commands;
using System.Collections.Generic;

namespace Server.Items
{
	[FlipableAttribute( 0x1f14, 0x1f15, 0x1f16, 0x1f17 )]
	public class WayPoint : Item
	{
		public static List<WayPoint> GlobalWayPointList = new List<WayPoint>();
		
		public static void Initialize()
		{
			CommandSystem.Register( "WPSequence", AccessLevel.GameMaster, new CommandEventHandler( WayPointSeq_OnCommand ) );			
			CommandSystem.Register( "WPConnect", AccessLevel.GameMaster, new CommandEventHandler( WayPointCon_OnCommand ) );			
			CommandSystem.Register( "WPConSequence", AccessLevel.GameMaster, new CommandEventHandler( WayPointConSeq_OnCommand ) );			
			CommandSystem.Register( "WPDisconnect", AccessLevel.GameMaster, new CommandEventHandler( WayPointRem_OnCommand ) );			
			CommandSystem.Register( "WPFixLinks", AccessLevel.GameMaster, new CommandEventHandler( WayPointFixLinks_OnCommand ) );			
		}

		[Usage( "WPSequence" )]
		[Description( "Creates a sequence of linked network waypoints" )]		
		public static void WayPointSeq_OnCommand( CommandEventArgs arg )
		{
			arg.Mobile.SendMessage( "Target the position of the first way point." );
			arg.Mobile.Target = new WayPointSeqTarget( null );
		}
		
				
		[Usage( "WPConSequence" )]
		[Description( "Creates a sequence of linked network waypoints starting with an existing one" )]		
		public static void WayPointConSeq_OnCommand( CommandEventArgs arg )
		{
			arg.Mobile.SendMessage( "Target the waypoint you want to connect to." );
			arg.Mobile.Target = new PrevPointTarget();
		}
		
		
		[Usage( "WPConnect" )]
		[Description( "Connects two waypoints" )]		
		public static void WayPointCon_OnCommand( CommandEventArgs arg )
		{
			arg.Mobile.SendMessage( "Target the first way point to connect." );
			arg.Mobile.Target = new WayPointConTarget( null, false );
		}
		
		[Usage( "WPDisconnect" )]
		[Description( "Disconnects two waypoints" )]		
		public static void WayPointRem_OnCommand( CommandEventArgs arg )
		{
			arg.Mobile.SendMessage( "Target the first way point." );
			arg.Mobile.Target = new WayPointConTarget( null, true );
		}

		[Usage( "WPFixLinks" )]
		[Description( "Fixes old waypoints who only have unidirectional links" )]		
		public static void WayPointFixLinks_OnCommand( CommandEventArgs arg )
		{
			int i = 0;
			foreach (WayPoint w in GlobalWayPointList)
			{
				if (w.NextPoint != null)
				{
					if (!w.NextPoint.m_Connections.Contains(w) && w.NextPoint.NextPoint != w)
					{
						i++;
						w.NextPoint.m_Connections.Add(w);
						arg.Mobile.SendMessage("WayPoint "+w+" at X:"+w.X+" Y:"+w.Y+" Z:"+w.Z);
						
					}
				}
			}
			arg.Mobile.SendMessage("Command Completed. "+i+" waypoints fixed.");
		}
		
		
		private WayPoint m_Next;
		public List<WayPoint> m_Connections;
				

		public void FixName()
		{
			Name = DefaultName;
			InvalidateProperties();
		}
				
		[CommandProperty( AccessLevel.GameMaster )]
		public override string DefaultName
		{
			get 
			{ 
				string s = this+" cons: ";
				if (m_Connections != null)
				{
					for(int i=0;i<m_Connections.Count && i < 4;i++)
					{
						if (m_Connections[i] != null)
						{
							if (i != 0)
							{
								s = s +",";
							}
							s = s + m_Connections[i].Serial;
						}
					}
				}	
				if (m_Next != null)
				{
					if (m_Connections.Count != 0)
					{
						s = s + ",";
					}
					s = s + m_Next.Serial;
				}
				return s;				
			}
		}

		[Constructable]
		public WayPoint() : base( 0x1f14 )
		{
			this.Hue = 0x498;
			this.Visible = false;
			this.Movable = false;
			m_Connections = new List<WayPoint>();
			
			GlobalWayPointList.Add(this);
		}

		public WayPoint( WayPoint prev ) : this()
		{
			if ( prev != null )
			{
				prev.NextPoint = this;
				m_Connections.Add(prev);	
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint NextPoint
		{
			get
			{
				return m_Next;
			}
			set
			{
				if ( m_Next != this )
				{
					m_Next = value;
				}
				FixName();
			}
		}
		
		private WayPoint GetConnection(int i)
		{
				if (m_Connections.Count > i)
					return m_Connections[i];
				else
					return null;
		}			

		private void SetConnection(int i, WayPoint value)
		{
				if (m_Connections.Count > i)
				{
					m_Connections.Remove(m_Connections[i]);
				}
				if (value != null)
				{
					m_Connections.Insert(i, value);
				}
				FixName();
		}			
		
		public List<WayPoint> Connections
		{
			get { return m_Connections; }
		}
				
		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint Connection1
		{
			get { return GetConnection(0); }
			set { SetConnection(0, value); 
				FixName();
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint Connection2
		{
			get { return GetConnection(1); }
			set { SetConnection(1, value); 
				FixName();
			}

		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint Connection3
		{
			get { return GetConnection(2); }
			set { SetConnection(2, value); 
				FixName();
			}

		}

		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint Connection4
		{
			get { return GetConnection(3); }
			set { SetConnection(3, value);
				FixName();
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint Connection5
		{
			get { return GetConnection(4); }
			set { SetConnection(4, value); 
				FixName();
			}

		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public WayPoint Connection6
		{
			get { return GetConnection(5); }
			set { SetConnection(5, value); 
				FixName();
			}

		}
		
		public override void OnDoubleClick( Mobile from )
		{
			foreach(WayPoint wp in this.m_Connections)
			{
				if (wp != null)
				{
					MarkerBall mb = new MarkerBall();
					mb.MoveToWorld(wp.Location, wp.Map);
				}	
			}
			
			if (NextPoint != null)
			{
				MarkerBall mb = new MarkerBall();
				mb.MoveToWorld(NextPoint.Location, NextPoint.Map);			
			}	
		}

		public override void OnSingleClick( Mobile from )
		{
			base.OnSingleClick( from );

			if ( m_Next == null )
				LabelTo( from, "(Unlinked)" );
			else
				LabelTo( from, "(Linked: {0})", m_Next.Location );
		}

		public WayPoint( Serial serial ) : base( serial )
		{
			GlobalWayPointList.Add(this);
		}

		public override void OnRemoved(IEntity parent)
		{
			base.OnRemoved(parent);
			GlobalWayPointList.Remove(this);
			
			for(int i=0;i<GlobalWayPointList.Count;i++)
			{
				GlobalWayPointList[i].Connections.Remove(this);
			}				
		}
				
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			switch( version )
			{
				case 1:
				{
					int Len = reader.ReadInt();
					m_Connections = new List<WayPoint>();
				    for(int i=0;i<Len;i++)
				    	m_Connections.Add(reader.ReadItem() as WayPoint);
					goto case 0;
				}				
				case 0:
				{
					if (m_Connections == null)
						m_Connections = new List<WayPoint>();					
					m_Next = reader.ReadItem() as WayPoint;
					break;
				}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

		    writer.Write(m_Connections.Count);
		    for(int i=0;i<m_Connections.Count;i++)
		    	writer.Write(m_Connections[i]);
			writer.Write( m_Next );
		}
	}
	
	public class PrevPointTarget : Target
	{
		public PrevPointTarget(  ) : base( -1, false, TargetFlags.None )
		{
			
		}

		protected override void OnTarget( Mobile from, object target )
		{
			if ( target is WayPoint)
			{
				WayPoint t = (WayPoint) target;
				t.Connections.Add(t.NextPoint);
				from.SendMessage( "Select point to place next Waypoint" );
				from.Target = new WayPointSeqTarget( t );				
				t.FixName();
			}
			else
			{
				from.SendMessage( "No valid target selected - select previous waypoint" );
			}
		}
	}

	
	
	public class NextPointTarget : Target
	{
		private WayPoint m_Point;

		public NextPointTarget( WayPoint pt ) : base( -1, false, TargetFlags.None )
		{
			m_Point = pt;
		}

		protected override void OnTarget( Mobile from, object target )
		{
			if ( target is WayPoint && m_Point != null )
			{
				WayPoint t = (WayPoint) target;
				m_Point.NextPoint = t;
				t.Connections.Add(m_Point);
				t.FixName();
				m_Point.FixName();
			}
			else
			{
				from.SendMessage( "Target a way point." );
			}
		}
	}

	public class WayPointSeqTarget : Target
	{
		private WayPoint m_Last;

		public WayPointSeqTarget( WayPoint last ) : base( -1, true, TargetFlags.None )
		{
			m_Last = last;
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
			if ( targeted is WayPoint )
			{
				if ( m_Last != null )
				{
					m_Last.NextPoint = (WayPoint)targeted;
					m_Last.FixName();
					
				}
			}
			else if ( targeted is IPoint3D )
			{
				Point3D p = new Point3D( (IPoint3D)targeted );

				WayPoint point = new WayPoint( m_Last );
				point.MoveToWorld( p, from.Map );

				from.Target = new WayPointSeqTarget( point );
				from.SendMessage( "Target the position of the next way point in the sequence, or target a way point link the newest way point to." );
			}
			else
			{
				from.SendMessage( "Target a position, or another way point." );
			}
		}
	}
	
	public class WayPointConTarget : Target
	{
		private WayPoint m_Last;
		private bool m_Remove;

		public WayPointConTarget( WayPoint last, bool remove ) : base( -1, true, TargetFlags.None )
		{
			m_Last = last;
			m_Remove = remove;
		}

		protected override void OnTarget( Mobile from, object targeted )
		{
			if ( targeted is WayPoint )
			{
				WayPoint t = (WayPoint) targeted;
				if ( m_Last != null )
				{
					if (!m_Remove)
					{
						if (!m_Last.Connections.Contains(t) && m_Last.NextPoint != t)
						{ 
							if (m_Last.NextPoint == null)
								m_Last.NextPoint = t;
							else
								m_Last.Connections.Add(t);
						}
						
						if (!t.Connections.Contains(m_Last) && t.NextPoint != m_Last)
						{
							if (t.NextPoint == null)
								t.NextPoint = m_Last;
							else
								t.Connections.Add(m_Last);
						}
							
						t.FixName();
						m_Last.FixName();							
					}
					else
					{
						m_Last.Connections.Remove(t);
						t.Connections.Remove(m_Last);	
						
						if (t.NextPoint == m_Last)
							t.NextPoint = null;
						
						if (m_Last.NextPoint == t)
							m_Last.NextPoint = null;
						
						t.FixName();
						m_Last.FixName();							
					}
				}
				else
				{
					from.Target = new WayPointConTarget( t, m_Remove );
					if (!m_Remove)
						from.SendMessage( "Target the next way point to connect." );					
					else
						from.SendMessage( "Target the next way point to disconnect." );					
						
				}
			}
			else
			{
				from.SendMessage( "That is not a way point." );
			}
		}
	}
		
	public class MarkerBall : Item
	{
		[Constructable]
		public MarkerBall() : base( 14078 )
		{
			Movable = false;
			Weight = 200.0;
			Visible = false;
			InternalTimer t = new InternalTimer(this);
			t.Start();
		}

		public MarkerBall( Serial serial ) : base( serial )
		{
			Delete();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
		}
		
		private class InternalTimer : Timer
		{
			private Item m_Item;
			
			public InternalTimer( Item item) : base( TimeSpan.FromSeconds( 2.0 ) )
			{				
				Priority = TimerPriority.OneSecond;
				m_Item = item;
			}

			protected override void OnTick()
			{
				if (m_Item != null)
					m_Item.Delete();
			}
		}
	}
	
}
