using System;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Targeting;
using Server.Network;
using Server.Commands;

namespace Server.Scripts.Commands
{
	public class Follow
	{
		public static Hashtable Collection = new Hashtable();
        
        public static void Initialize()
		{
		   CommandSystem.Register( "Follow", AccessLevel.Counselor, new CommandEventHandler( Follow_OnCommand ) );
            EventSink.Logout += new LogoutEventHandler(OnLogout);
        }

		[Usage( "Follow" )]
		[Description( "Follows a Mobile" )]
		private static void Follow_OnCommand( CommandEventArgs e )
		{
            Mobile from = e.Mobile;

            if (from != null && !from.Deleted)
            {
                from.SendMessage("Select a target to follow");
                from.Target = new FollowTarget();
            }
		}

        private static void OnLogout(LogoutEventArgs e)
        {
            Mobile m = e.Mobile;

            if (m != null)
            {
                if (Follow.Collection.Contains(m))
                    Follow.Collection.Remove(m);
            }
        }
	}

    public class FollowTarget : Target
    {
        private Timer m_Timer;
       
        public FollowTarget(): base(15, false, TargetFlags.None)
        {
        
        }

        protected override void OnTarget(Mobile from, object target)
        {
            Mobile targetted = null;

            if (from != null && !from.Deleted)
            {
                if ( target != null && target is Mobile)
                {
                    targetted = target as Mobile;
                    if (target != from)
                    {
                        if (!Follow.Collection.Contains(from))
                        {
                            if (from.AccessLevel >= targetted.AccessLevel)
                            {
                                Follow.Collection[from] = targetted;
                                m_Timer = new FollowTimer(from, targetted);
                                m_Timer.Start();
                            }
                            else
                            {
                                from.SendMessage("Vous ne pouvez pas suivre un Mj avec un rang plus élevé.");
                            }
                        }
                        else
                        {
                            from.SendMessage("Vous êtes déjà en mode Follow.");
                        }
                    }
                    else
                    {
                        from.SendMessage("Vous ne pouvez pas vous suivre vous-mêmes.");                        
                    }
                }
                else
                {
                    from.SendMessage("Cette cible est inadéquate.");
                }
            }

        }
    }

    public class FollowTimer : Timer
    {
        private Mobile m_From, m_Target;

        public FollowTimer(Mobile from, Mobile target): base(TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(2.5))
        {
            m_From = from;
            m_Target = target;

            m_From.SendGump( new FollowGump( from, target, this ));
        }

        protected override void OnTick()
        {
            if (m_From != null && !m_From.Deleted)
            {
                if (!Follow.Collection.Contains(m_From))
                {
                    Stop();
                    m_From.CloseGump(typeof(FollowGump));
                    return;
                }

                if (m_Target != null && !m_Target.Deleted)
                {
                    if (m_Target is PlayerMobile)
                    {
                        PlayerMobile m_pmTarget = m_Target as PlayerMobile;
                        if (m_From.AccessLevel == m_Target.AccessLevel && m_Target.Hidden && !m_pmTarget.VisibilityList.Contains(m_From))
                        {
                            m_From.SendMessage("Le personnage s'est caché, vous ne pouvez plus le suivre.");
                            Stop();
                            m_From.CloseGump(typeof(FollowGump));
                            Follow.Collection.Remove(m_From);
                            return;
                        }
                    }
                    
                    if ((m_From.X != m_Target.X || m_From.Y != m_Target.Y || m_From.Z != m_Target.Z) && ((m_From.X - m_Target.X >= 6) || (m_From.Y - m_Target.Y >= 6) || (m_Target.X - m_From.X >= 6) || (m_Target.Y - m_From.Y >= 6) ))
                    {
                             
                        m_From.X = m_Target.X;
                        m_From.Y = m_Target.Y;
                        m_From.Z = m_Target.Z;
                    }

                    if ((m_From.Map != m_Target.Map) && (m_Target.Map != Map.Internal))
                    {
                        m_From.Map = m_Target.Map;
                    }
                    else if (m_Target.Map == Map.Internal)
                    {
                        m_From.SendMessage("Le joueur s'est déconnecté.");
                        Stop();
                        m_From.CloseGump(typeof(FollowGump));
                        Follow.Collection.Remove(m_From);
                        return;
                    }
                }
                else
                {
                    m_From.SendMessage("Le joueur est supprimé.");
                    m_From.SendMessage("Vous ne suivez plus le joueur.");
                    Stop();
                    m_From.CloseGump(typeof(FollowGump));
                    Follow.Collection.Remove(m_From);
                    return;
                }
            }
        }
    }

    public class FollowGump : Gump
    {
        Mobile m_From;
        Mobile m_Following;
        Timer m_Timer;
        
        public FollowGump(Mobile from, Mobile following, Timer timer): base(20, 30)
        {
            Dragable = true;
            Resizable = false;
            Closable = false;

            m_From = from;
            m_Following = following;
            m_Timer = timer;

            AddBackground(0, 0, 165, 55, 5054); // 5054

            AddHtml(0, 0, 165, 50, Resize(Color(Center("Vous suivez :"), 0xFFFFFF), 100), (bool)false, (bool)false);
            AddHtml(0, 14, 165, 50, Resize(Color(Center(String.Format("{0}", following.Name)), 0x0000CC), 100), (bool)false, (bool)false);
            AddButton(47, 30, 241, 242, 1, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1:
                    {
                        if (m_From != null && !m_From.Deleted)
                        {
                            if (Follow.Collection.Contains(m_From))
                            {
                                Follow.Collection.Remove(m_From);
                            }
                            if (m_Timer != null)
                                m_Timer.Stop();

                            if ( m_Following != null && !m_Following.Deleted )
                                m_From.SendMessage("Vous ne suivez plus {0}", m_Following.Name);
                        }

                        break;
                    }
            }
        }

        public string Center(string text)
        {
            return String.Format("<CENTER>{0}</CENTER>", text);
        }

        public string Color(string text, int color)
        {
            return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
        }

        public string Resize(string text, int size)
        {
            return String.Format("<BASEFONT SIZE=#{0}>{1}</BASEFONT>", size, text);
        }
    }
}
