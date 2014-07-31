using System;
using Server;
using Server.Movement;
using CalcMoves = Server.Movement.Movement;
using Server.Mobiles;

namespace Server
{
	public enum PathFollowerResult
	{
		ReachedDestination = 0,
		FollowingPath,
		UnableToFindPath,			
	}	
	
	public class PathFollower
	{
		// Should we use pathfinding? 'false' for not
		private static bool Enabled = true;

		private Mobile m_From;
		private IPoint3D m_Goal;
		private MovementPath m_Path;
		private int m_Index;
		private Point3D m_Next, m_LastGoalLoc;
		private DateTime m_LastPathTime;
		private MoveMethod m_Mover;

		public MoveMethod Mover
		{
			get{ return m_Mover; }
			set{ m_Mover = value; }
		}

		public IPoint3D Goal
		{
			get{ return m_Goal; }
		}

		public PathFollower( Mobile from, IPoint3D goal )
		{
			m_From = from;
			m_Goal = goal;
		}

		public MoveResult Move( Direction d )
		{
			if ( m_Mover == null )
				return ( m_From.Move( d ) ? MoveResult.Success : MoveResult.Blocked );

			return m_Mover( d );
		}

		public Point3D GetGoalLocation()
		{
			if ( m_Goal is Item )
				return ((Item)m_Goal).GetWorldLocation();

			return new Point3D( m_Goal );
		}

		private static TimeSpan RepathDelay = TimeSpan.FromSeconds( 2.0 );

		public void Advance( ref Point3D p, int index )
		{
			if ( m_Path != null && m_Path.Success )
			{
				Direction[] dirs = m_Path.Directions;

				if ( index >= 0 && index < dirs.Length )
				{
					int x = p.X, y = p.Y;

					CalcMoves.Offset( dirs[index], ref x, ref y );

					p.X = x;
					p.Y = y;
				}
			}
		}

		public void ForceRepath()
		{
			m_Path = null;
		}

		public bool CheckPath()
		{
			if ( !Enabled )
				return false;

			bool repath = false;

			Point3D goal = GetGoalLocation();

			if ( m_Path == null )
				repath = true;
			else if ( (!m_Path.Success || goal != m_LastGoalLoc) && (m_LastPathTime + RepathDelay) <= DateTime.Now )
				repath = true;
			else if ( m_Path.Success && Check( m_From.Location, m_LastGoalLoc, 0 ) )
				repath = true;

			if ( !repath )
				return false;

			m_LastPathTime = DateTime.Now;
			m_LastGoalLoc = goal;

			m_Path = new MovementPath( m_From, goal );

			m_Index = 0;
			m_Next = m_From.Location;

			Advance( ref m_Next, m_Index );

			return true;
		}

		public bool Check( Point3D loc, Point3D goal, int range )
		{
			if ( !Utility.InRange( loc, goal, range ) )
				return false;

			if ( range <= 1 && Math.Abs( loc.Z - goal.Z ) >= 16 )
				return false;

			return true;
		}
		
		public PathFollowerResult Follow( bool run, int range )
		{
			Point3D goal = GetGoalLocation();
			Direction d;

			if ( Check( m_From.Location, goal, range ) )
				return PathFollowerResult.ReachedDestination;

			bool repathed = CheckPath();

			if ( !Enabled || !m_Path.Success )
			{
				d = m_From.GetDirectionTo( goal );

				if ( run )
					d |= Direction.Running;

				m_From.SetDirection( d );
				Move( d );

				if 	(Check( m_From.Location, goal, range ))
					return PathFollowerResult.ReachedDestination;
			
			}

			d = m_From.GetDirectionTo( m_Next );

			if ( run )
				d |= Direction.Running;

			m_From.SetDirection( d );

			MoveResult res = Move( d );

			if (m_From is PathTester)
				m_From.Say("Move attempt: "+res);
			
			// If blocked or change direction because blocked then need to repath
			if ( res == MoveResult.Blocked || res == MoveResult.SuccessAutoTurn)
			{
				if ( repathed )
					return PathFollowerResult.UnableToFindPath;

				m_Path = null;
				CheckPath();

				if ( !m_Path.Success )
				{
					d = m_From.GetDirectionTo( goal );

					if ( run )
						d |= Direction.Running;

					m_From.SetDirection( d );
					Move( d );

					if (Check( m_From.Location, goal, range ))
						return PathFollowerResult.ReachedDestination;
				}

				d = m_From.GetDirectionTo( m_Next );

				if ( run )
					d |= Direction.Running;

				m_From.SetDirection( d );

				res = Move( d );

				if ( res == MoveResult.Blocked )
					return PathFollowerResult.UnableToFindPath;
			}

			if ( m_From.X == m_Next.X && m_From.Y == m_Next.Y )
			{
				if ( m_From.Z == m_Next.Z )
				{
					++m_Index;
					Advance( ref m_Next, m_Index );
					
					if (Check( m_From.Location, goal, range ))
						return PathFollowerResult.ReachedDestination;
					else
						return PathFollowerResult.FollowingPath;
				}
				else
				{
					m_Path = null;
					
					if (Check( m_From.Location, goal, range ))
						return PathFollowerResult.ReachedDestination;
					else
						return PathFollowerResult.UnableToFindPath;
				}
			}

			if (Check( m_From.Location, goal, range ))
				return PathFollowerResult.ReachedDestination;
			else
				return PathFollowerResult.UnableToFindPath;
		}
	}
}