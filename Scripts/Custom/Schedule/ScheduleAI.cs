using System;
using System.Collections;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Items;
using Server.Misc;

namespace Server.Mobiles
{
	public class ScheduleAI
	{
		private BaseCreature m_Mobile;
		private BaseAI m_AI;
		private ScheduleItem m_Schedule;
		
		private bool IsWalking;
		private PathFollower m_Path;
		
		public ScheduleAI(BaseCreature m, BaseAI a, ScheduleItem s)
		{
			m_Mobile = m;
			m_AI = a;
			m_Schedule = s;
			
			// TODO -- Init stuff for current state of schedule item
		}

		public void Tick()
		{
			// don't do activities if you're still moving
			if (m_Mobile.CurrentWayPoint != null)
				return;

			int hours;
			int minutes;
			
			Time.GetTime(out hours, out minutes);
			
			// Divide hours by 2 to get current schedule
			int entry = hours >> 1;
			
			if (m_Schedule.CurEntry != entry && m_Schedule.Entries[entry].activity != ScheduleAct.None )
			{
				// Clean up before starting on the new entry
				CleanUp();
			
				m_Schedule.CurEntry = entry;

				// Check to see if there's a waypoint, and thus movement first
				if (m_Schedule.Entries[entry].waypoint != null)
				{
					WayPoint wp = m_Schedule.Entries[entry].waypoint;
				
					// if thewaypoint isn't close enough teleport the npc there
					//if (!m_Mobile.InLOS(wp))
					//	m_Mobile.MoveToWorld(wp.Location, wp.Map);
						
					m_Mobile.CurrentWayPoint = wp;
					
					// TODO : make this an option, use custom speed if given
					if ( m_Mobile.CurrentSpeed <= 0.25 )
						m_Mobile.CurrentSpeed = m_Mobile.ActiveSpeed;
					else
						m_Mobile.CurrentSpeed = 0.25;
					
					IsWalking = true;
					
					return;
				}
			}
			
			// No waypoint, no new stuffs, so do stuff!

			// Return speed to passive once arrived at location
			if (IsWalking)
			{
				m_Mobile.CurrentSpeed = m_Mobile.PassiveSpeed;
				IsWalking = false;
				m_Schedule.nextAct = DateTime.Now;
			}
			
			if ( m_Schedule.nextAct != DateTime.MinValue )
			{
				ScheduleAct act = m_Schedule.Entries[entry].activity;
			
				if ( act == ScheduleAct.Wander )
				{
					Wander();
				}
				else if ( act == ScheduleAct.Sleep )
				{
					// TODO : make not a magic number but configurable
					FindBed( 7 );
				}
				else if ( act == ScheduleAct.Eat )
				{
					FindSeat( 15 );
				}
			}
		}
		
		// Clean up code goes here, for instance getting up before wandering off
		public void CleanUp()
		{
			if ( m_Schedule.CurEntry < 0 )
				return;
		
			ScheduleAct act = m_Schedule.Entries[m_Schedule.CurEntry].activity;

			if ( act == ScheduleAct.Sleep ) {
				EndSleep();
			}
			//else if ( act == ) {
			//}
		}
		
		public void FindSeat( int range )
		{
            //Map map = m_Mobile.Map;
            //for (int i = 1; i < range; i++)
            //{
            //    for (int j = 1; j < range; i++)
            //   {

            //    }
                //StaticTile[] tiles = map.Tiles.GetStaticTiles(x, y, true);
            //}
		}
		
		public void FindBed( int range )
		{
			IPooledEnumerable eable = m_Mobile.GetItemsInRange( range );
			
			foreach ( Item item in eable )
			{
				if ( item is SleeperBaseAddon ) {
					SleeperBaseAddon bed = (SleeperBaseAddon)item;
					if ( !bed.Asleep )
					{
						if ( MoveTo( item, false, 2 ) )
						{
							// Nobody is sleeping here, go go go gooooo!
							bed.OnDoubleClick( m_Mobile );
							
							if ( bed.SleeperBedBody != null )
								bed.SleeperBedBody.OnDoubleClick( m_Mobile );
							
							// Set nextAct to -1 so it stops trying to do anything
							m_Schedule.nextAct = DateTime.MinValue;
							
							break;
						}
					}
				}
			}
			
			eable.Free();
		}
		
		public void EndSleep()
		{
			IPooledEnumerable eable = m_Mobile.GetItemsInRange( 3 );
			foreach ( Item item in eable ) {
				if ( item is SleeperBaseAddon ) {
					SleeperBaseAddon bed = (SleeperBaseAddon)item;
					if ( bed.Asleep && bed.Mobile == m_Mobile ) {
						// Get up
						bed.OnDoubleClick( m_Mobile );
						break;
					}
				}
			}
			eable.Free();
		}
		
		public bool MoveTo( Item m, bool run, int range )
		{
			if( m_Mobile.Deleted || m_Mobile.DisallowAllMoves || m == null || m.Deleted )
				return false;

			if( m_Mobile.InRange( m, range ) )
			{
				m_Path = null;
				return true;
			}

			if( m_Path != null && m_Path.Goal == m )
			{
                //Temrael Fix
                if (m_Path.Follow(run, 1) == PathFollowerResult.ReachedDestination)
				{
					m_Path = null;
					return true;
				}
			}
			else if( !m_AI.DoMove( m_Mobile.GetDirectionTo( m ), true ) )
			{
				m_Path = new PathFollower( m_Mobile, m );
				m_Path.Mover = new MoveMethod( m_AI.DoMoveImpl );

                //Temrael Fix
				//if( m_Path.Follow( run, 1 ) )
                if (m_Path.Follow(run, 1) == PathFollowerResult.ReachedDestination)
				{
					m_Path = null;
					return true;
				}
			}
			else
			{
				m_Path = null;
				return true;
			}

			return false;
		}
		
		public void Wander()
		{
			if( m_AI.CheckMove() )
			{
				if( !m_Mobile.CheckIdle() )
					m_AI.WalkRandomInHome( 2, 2, 1 );
			}
		}
        public void Mine( int range )
        {

        }
        public void CutWood( int range )
        {
            
        }
        //Todo : Weapon held
        public void HitDummy( int range )
        {
            IPooledEnumerable eable = m_Mobile.GetItemsInRange(range);

            foreach (Item item in eable)
            {
                if (item is TrainingDummy)
                {
                    TrainingDummy dummy = (TrainingDummy)item;

                    if (!dummy.Swinging)
                    {
                        if (MoveTo(item, false, 1))
                        {
                            dummy.Use(m_Mobile, (BaseWeapon)m_Mobile.Weapon);


                            // Repeat the animation
                            m_Schedule.nextAct = DateTime.Now;

                            break;
                        }
                    }
                }
            }

            eable.Free();
        }
        public void CarpentryWork( int range )
        {

        }
        public void Forge( int range )
        {
            IPooledEnumerable eable = m_Mobile.GetItemsInRange(range);

            foreach (Item item in eable)
            {
                if (item is Anvil)
                {
                    Anvil anvil = (Anvil)item;

                    if (MoveTo(item, false, 1))
                    {
                        BaseWeapon weapon = (BaseWeapon)m_Mobile.Weapon;

                        m_Mobile.Direction = m_Mobile.GetDirectionTo(anvil.GetWorldLocation());
                        weapon.PlaySwingAnimation(m_Mobile);

                        Effects.PlaySound(anvil.GetWorldLocation(), anvil.Map, 0x2b);


                        // Repeat the animation
                        m_Schedule.nextAct = DateTime.Now;

                        break;
                    }
                }
            }

            eable.Free();
        }
        public void Sew( int range )
        {
            IPooledEnumerable eable = m_Mobile.GetItemsInRange(range);

            foreach (Item item in eable)
            {
                if (item is ISpinningWheel)
                {
                    ISpinningWheel wheel = (ISpinningWheel)item;

                    if (wheel.Spinning)
                    {
                        if (MoveTo(item, false, 1))
                        {
                            wheel.BeginSpin(new SpinCallback(Cotton.OnSpun), m_Mobile, item.Hue);

                            //Repeat
                            m_Schedule.nextAct = DateTime.Now;

                            break;
                        }
                    }
                }
            }

            eable.Free();
        }
	}
}