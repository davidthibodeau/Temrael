using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.PathAlgorithms;
using CalcMoves = Server.Movement.Movement;
using MoveImpl = Server.Movement.MovementImpl;
using System.Collections.Generic;
using Server.Items;
using Server.PathAlgorithms.SlowAStar;
using Server.PathAlgorithms.FastAStar;

namespace Server.PathAlgorithms
{
	public class NetworkPath
	{
		public List<WayPoint> WayPointList;
		public Point3D Goal;
		public int CurrWayPoint;
		
		public NetworkPath(List<WayPoint> wpl, Point3D g)
		{
			WayPointList = wpl;
			Goal = g;
			CurrWayPoint = 0;			
		}
	}
	
	// Tries to find the best possible path
	public class NetworkPathExplorer
	{
		// Maximum node depth
		public const int DEPTH = 200;
		
		public NetworkPathExplorer ()
		{			
		}
		
		private void PrintPathToConsole(NetworkPathAlgorithm npa)
		{
			foreach (WayPoint wp in npa.Path)
				Console.Write(""+wp);
		}
		
		public bool FindPath(Mobile mob, WayPoint start, WayPoint goal, out List<WayPoint> path)
		{
			NetworkPathAlgorithm npa = new NetworkPathAlgorithm();
			// Initial search
			NetworkPathState result = npa.FindPath(mob, start, goal, DEPTH, new List<WayPoint>());
			
			// Unable to find a path at all
			if (result == NetworkPathState.Failure || result == NetworkPathState.ExceededDepth)
			{
				path = null;
				return false;
			}
				
			if (mob is PathTester && ((BaseCreature)mob).Debug)
			{
				//PrintPathToConsole(npa);
				Console.WriteLine("Path found, looking for better paths...");
				/*
				Console.Write("Path: ");
				foreach (WayPoint wp in npa.Path)
					Console.Write(""+wp);
				Console.WriteLine("");
				Console.Write("Branches List: ");
				foreach (WayPoint wp in npa.Branches)
					Console.Write(""+wp);
				Console.WriteLine("");
				*/
			}
						
			// If there were branches we didn't take its time to explore them	
			int i = 0;
			while (i < npa.Branches.Count)
			{
				NetworkPathAlgorithm npa2 = new NetworkPathAlgorithm();
				List<WayPoint> forcelist = new List<WayPoint>();
				forcelist.Add(npa.Branches[i]);
				if (mob is PathTester && ((BaseCreature)mob).Debug)
				{
					Console.WriteLine("Considering alternate path from WayPoint: "+npa.Branches[i]+" X:"+npa.Branches[i].Location.X+" Y:"+npa.Branches[i].Location.Y+" Z:"+npa.Branches[i].Location.Z );					
				}	
				result = npa2.FindPath(mob, start, goal, npa.Path.Count+(int)(npa.Path.Count*0.2), forcelist);				
				
				if (result == NetworkPathState.Success)
				{
					//PrintPathToConsole(npa2);
					if (mob is PathTester && ((BaseCreature)mob).Debug)
					{
						Console.WriteLine("Evaluation: "+npa2.Evaluate()+" vs " +npa.Evaluate());
					}
					// If new path is better then select this path
					if (npa2.Evaluate() < npa.Evaluate())
					{
						if (mob is PathTester && ((BaseCreature)mob).Debug)
						{
							Console.WriteLine("Better path found!");
						}
						npa = npa2;
					}
				}
				
				i++;
			}
			
			path = npa.Path;
			return true;						
		}
	}
	
	public enum NetworkPathState
	{
		Success,
		Failure,
		ExceededDepth,		
	}
	
	// Searches for a single path given inputs
	public class NetworkPathAlgorithm
	{
		private const bool FULL_DEBUG = false;
		
		private List<WayPoint> m_OpenList;
		private List<WayPoint> m_ClosedList;
		private List<WayPoint> m_Path;
		private List<WayPoint> m_Consideration;
		private List<WayPoint> m_Branches;
		
		public List<WayPoint> Branches
		{
			get {return m_Branches;}
		}	
		
		public List<WayPoint> OpenList
		{
			get { return m_OpenList; }
		}
		
		public List<WayPoint> Path
		{
			get { return m_Path; }
		}
		
		private WayPoint m_Goal;
		
		public NetworkPathAlgorithm()
		{
			m_OpenList = new List<WayPoint>();
			m_ClosedList = new List<WayPoint>();
			m_Branches = new List<WayPoint>();
			m_Path = new List<WayPoint>();
		}
		
		// Heuristic for ending waypoint
		// Closest is not always best eg. may be spacially close but long path
		public static int EndHeuristic(Point3D goal, WayPoint w, Mobile mob)
		{
			/* Probably too expensive to do a true analysis of all end waypoints
			? See if LOS is faster
			int d1 = -1;
			try
			{
				PathAlgorithm alg = MovementPath.OverrideAlgorithm;

				if ( alg == null )
				{
					alg = FastAStarAlgorithm.Instance;
				}

				if (alg.CheckCondition( mob, mob.Map, w.Location, goal ) )
				{
					Direction[] directions = alg.Find( mob, mob.Map, w.Location, goal );
					d1 = directions.Length;
				}
			}
			catch ( Exception e )
			{
			}
				
			// Unable to find 			
			if (d1 == -1)
				return -1;
			*/
			int d = CalcDistance(goal, w.Location);
			
			int distance = CalcDistance(mob.Location, w.Location);
			
			if (!mob.Map.LineOfSight( new Point3D(goal.X, goal.Y, goal.Z+3), new Point3D(w.X, w.Y, w.Z+3)))
			{
				return (d+distance/2)*2;
			}
			return d+distance/2;									
		}
		
		// Heuristic for starting waypoint
		// Closest is not always best eg. may be spacially close but long path
		public static int StartHeuristic(Point3D goal, WayPoint w, Mobile mob)
		{
			/*
			int d1 = -1;
			try
			{
				PathAlgorithm alg = MovementPath.OverrideAlgorithm;

				if ( alg == null )
				{
					alg = FastAStarAlgorithm.Instance;
				}

				if (alg.CheckCondition( mob, mob.Map, w.Location, mob.Location ) )
				{
					Direction[] directions = alg.Find( mob, mob.Map, w.Location, mob.Location );
					d1 = directions.Length;
				}
			}
			catch ( Exception e )
			{
			}
				
			// Unable to find 			
			if (d1 == -1)
				return -1;
			*/
			
			int distance = CalcDistance(w.Location, goal);
			int d = CalcDistance(mob.Location, w.Location);

			if (!mob.Map.LineOfSight( new Point3D(mob.X, mob.Y, mob.Z+3), new Point3D(w.X, w.Y, w.Z+3)))
			{
				return (d+distance/2)*2;
			}
			return d+distance/2;									
		}
		
		
		
		public static int CalcDistance(Point3D start, Point3D place)
		{
			int gxdelta = start.X-place.X;
			int gydelta = start.Y-place.Y;
			int gzdelta = start.Z-place.Z;
			int gxydelta = (int) Math.Sqrt(gxdelta*gxdelta + gydelta*gydelta);
			return (int) Math.Sqrt(gxydelta*gxydelta + gzdelta*gzdelta);			
		} 
		
		private static int CalcDistance(WayPoint start, WayPoint place)
		{
			return CalcDistance(new Point3D(start.X,start.Y,start.Z), new Point3D(place.X,place.Y,place.Z));
		} 
		
		// Gives a heuristic value for a completed path
		public int Evaluate()
		{
			int G = 0;
			for (int i=0;i<m_Path.Count;i++)
			{
				if (m_Path.Count > i+1)
				{
					G = G + CalcDistance(m_Path[i], m_Path[i+1]);
				}
				else
				{
					G = G + CalcDistance(m_Path[i],m_Goal); 
				}
			}
			return G;
		}
		
		public int Heuristic(WayPoint w, bool debug)
		{	
			// G is the distance to the waypoint to examine
			int G = 0;
			if (m_Path.Count > 1)
			{
				/*
				G = 0;
				for (int i=0;i<m_Path.Count;i++)
				{
					if (m_Path.Count > i+1)
					{
						G = G + CalcDistance(m_Path[i], m_Path[i+1]);
						
						if (FULL_DEBUG && debug)
						{
							Console.WriteLine("G Value for node "+i+" is "+ CalcDistance(m_Path[i], m_Path[i+1]));
						}
					}
					// If its the last in the chain calc distance to new point
					else
					{
						G = G + CalcDistance(m_Path[i], w);
						if (FULL_DEBUG && debug)
						{
							Console.WriteLine("G Value for node "+i+" is "+ CalcDistance(m_Path[i], w));
						}
					}
				}
				*/
				G = G + CalcDistance(m_Path[m_Path.Count-1], w);
				if (FULL_DEBUG && debug)
				{
					Console.WriteLine("G Value for node is "+ G);
				}				
			}
												
			int H = CalcDistance(w,m_Goal); 
			if (FULL_DEBUG && debug)
			{
				Console.WriteLine("H Value "+CalcDistance(w,m_Goal));
				Console.WriteLine("G+H Value "+(G+H));				
			}
			
			return G+H;
		}
		
		public NetworkPathState FindPath(Mobile mob, WayPoint start, WayPoint goal, int Depth, List<WayPoint> forcelist)
		{
			WayPoint curr = start;
			m_OpenList.Add(start);
			m_Goal = goal;
						
			while(m_OpenList.Count > 0 && curr != goal)
			{	
				if (!m_Path.Contains(curr))	
					m_Path.Add(curr);
					
				m_ClosedList.Add(curr);
				m_OpenList.Remove(curr);
				
				// Find waypoints from curr waypoint
				m_Consideration = new List<WayPoint>();		
				for (int i=0;i<curr.Connections.Count;i++)
				{
					if (curr.Connections[i] != null)
						m_Consideration.Add(curr.Connections[i]);					
				}
				if (curr.NextPoint != null)
				{
					if (!m_Consideration.Contains(curr.NextPoint))
					{
						m_Consideration.Add(curr.NextPoint);
					}
				}
				
				int bestheur = 20000;
				WayPoint best = null;
				
				// Consider each possible location can travel too
				// If in closed list ignore
				// Otherwise add to open list and select best possible
				// waypoint based off our heuristic
				if (FULL_DEBUG && mob is PathTester)
				{
					Console.WriteLine(mob.Name+" Examining possible waypoints from "+curr+" X:"+curr.X+" Y:"+curr.Y+" Z:"+curr.Z);
				}
				
				int j = 0;	
				bool forced = false;
				WayPoint seenprev = null;
				while (j < m_Consideration.Count)
				{
					WayPoint w = m_Consideration[j];
					if (!m_ClosedList.Contains(w))
					{
						if (forcelist.Contains(w))
						{
							forced = true;
							best = w;
							if (FULL_DEBUG && mob is PathTester)
							{
								Console.WriteLine(mob.Name+" Forced Waypoint "+w+" X:"+w.X+" Y:"+w.Y+" Z:"+w.Z);
							}																			
						}
						else if (!forced)
						{
							if (FULL_DEBUG && mob is PathTester)
							{
								Console.WriteLine(mob.Name+" Examining Waypoint "+w+" X:"+w.X+" Y:"+w.Y+" Z:"+w.Z);
							}						
						
							int h = Heuristic(w, mob is PathTester);
																			
							if (h < bestheur)
							{
								bestheur = h;
								best = w;
							}
						}
						
						if (!m_OpenList.Contains(w))
						{
							m_OpenList.Add(w);
						}
						else
						{
							// If already in open list may have taken circular path
							seenprev = w;
						}
						j++;					
					
					}	
					else
					{
						if (FULL_DEBUG && mob is PathTester)
						{
							Console.WriteLine(mob.Name+" Waypoint "+w+" X:"+w.X+" Y:"+w.Y+" Z:"+w.Z+" in closed list - ignoring");
						}		
						m_Consideration.Remove(w);				
					}
				}
				
				
				// Add non-best possibilities as branches for future path consideration
				for(int p=0; p < m_Consideration.Count;p++)
				{
					if (m_Consideration[p] != best)
					{
						if (!m_Branches.Contains(m_Consideration[p]))
						{
							if (FULL_DEBUG && mob is PathTester)
							{
								Console.WriteLine("Best: "+best+" Added branch: "+m_Consideration[p]);
							}						
							
							m_Branches.Add(m_Consideration[p]);
						}
					}
				}
				
				// We have taken an indirect path since we have passed our current
				// choice previously. Backtrack to branch we could have taken earlier.						
				// Currenly only steps back 1 step
				if (best == seenprev && best != null && m_Path.Count < Depth)
				{
					if (m_Path.Count > 1)
					{
						bool cangetfromprev = false;
						WayPoint prev = m_Path[m_Path.Count-2];	
						for (int i=0;i<prev.Connections.Count;i++)
						{
							if (prev.Connections[i] != null && best == prev.Connections[i])
								cangetfromprev = true;
						}
						if (prev.NextPoint != null && best == prev.NextPoint)
						{
							cangetfromprev = true;
						}
						
						if (cangetfromprev)
						{
							m_Path.Remove(m_Path[m_Path.Count-1]);
						}
					}					
				}
				// If we can't find anywhere to go then will need to backtrack
				// Or if we are already too deep
				if (best == null || m_Path.Count > Depth)
				{
					if (FULL_DEBUG && mob is PathTester)
					{
							Console.WriteLine(mob.Name+" Unable to find path - backtracking");
					}						
					m_Path.Remove(curr);
					m_Branches.Remove(curr);
					if (m_Path.Count < 1)
					{
						if (FULL_DEBUG && mob is PathTester)
						{
							Console.WriteLine("Unable to find WayPoint path to goal");
						}						
						return NetworkPathState.Failure;
					}
					else
						curr = m_Path[m_Path.Count -1];					
				}
				// If the best point is in the open list then backttack and go to the
				// waypoint via alternate route
				//else if (m_OpenList.Contains(best)
				//{
				//	m_Path.Remove(curr);
				//	curr = m_Path[m_Path.Count() -1];					
				//}			
				else
	 			{
					curr = best;
					if (FULL_DEBUG && mob is PathTester)
					{						
						Console.WriteLine(mob.Name+" WayPoint selected "+best+" X:"+best.X+" Y:"+best.Y+" Z:"+best.Z);
					}						
				}
				
				if (FULL_DEBUG && mob is PathTester)
				{
					foreach(WayPoint w in m_ClosedList)
					{
						Console.WriteLine(mob.Name+"Closed list contains: "+w);
					}
					foreach(WayPoint w in m_OpenList)
					{
						Console.WriteLine(mob.Name+"Open list contains: "+w);
					}
				}						
			}				
			if (curr == goal)
			{
				if (FULL_DEBUG && mob is PathTester)
				{
					Console.WriteLine("WayPoint path to goal found");
				}						
				m_Path.Add(curr);					
				return NetworkPathState.Success;
			}
			else
			{
				if (FULL_DEBUG && mob is PathTester)
				{
					Console.WriteLine("Unable to find WayPoint path to goal");
				}						
				return NetworkPathState.Failure;
			}			
		}
	}
}
