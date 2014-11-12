using System;
using Server;
using Server.Mobiles;
using Server.Gumps;
using Server.Network;

using Server.Misc;

namespace Server.Guilds
{
	public abstract class BaseGuildGump : Gump
	{
		private Guild m_Guild;
		private PlayerMobile m_Player;

		protected Guild guild{ get{ return m_Guild; } }
		protected PlayerMobile player{ get{ return m_Player; } }

		public BaseGuildGump( PlayerMobile pm, Guild g ) : this( pm, g, 10, 10 )
		{
		}

		public BaseGuildGump( PlayerMobile pm, Guild g, int x, int y ) : base( x, y )
		{
			m_Guild = g;
			m_Player = pm;
			
			pm.CloseGump( typeof( BaseGuildGump ) );
		}

		//There's prolly a way to have all the vars set of inherited classes before something is called in the Ctor... but... I can't think of it right now, and I can't use Timer.DelayCall here :<

		public virtual void PopulateGump()
		{
			AddPage( 0 );

			AddBackground( 0, 0, 600, 440, 0x24AE );
			AddBackground( 66, 40, 150, 26, 0x2486 );
			AddButton( 71, 45, 0x845, 0x846, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 96, 43, 110, 26, 1063014, 0x0, false, false ); // My Guild
			AddBackground( 236, 40, 150, 26, 0x2486 );
			AddButton( 241, 45, 0x845, 0x846, 2, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 266, 43, 110, 26, 1062974, 0x0, false, false ); // Guild Roster
			AddBackground( 401, 40, 150, 26, 0x2486 );
			AddButton( 406, 45, 0x845, 0x846, 3, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 431, 43, 110, 26, 1062978, 0x0, false, false ); // Diplomacy
			AddPage( 1 );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			PlayerMobile pm = sender.Mobile as PlayerMobile;

			if( !IsMember( pm, guild ) )
				return;

			switch( info.ButtonID )
			{
				case 1:
				{
					pm.SendGump( new GuildInfoGump( pm, guild ) );
					break;
				}
				case 2:
				{
					pm.SendGump( new GuildRosterGump( pm, guild ) );
					break;
				}
				case 3:
				{
					pm.SendGump( new GuildDiplomacyGump( pm, guild ) );
					break;
				}
			}
		}

		public static bool IsLeader( Mobile m, Guild g )
		{
			return !( m.Deleted || g.Disbanded || !( m is PlayerMobile ) || (m.AccessLevel < AccessLevel.Batisseur && g.Leader != m) );
		}

		public static bool IsMember( Mobile m, Guild g )
		{
			return !( m.Deleted || g.Disbanded || !( m is PlayerMobile ) || (m.AccessLevel < AccessLevel.Batisseur && !g.IsMember( m )) );
		}

		public void AddHtmlText( int x, int y, int width, int height, TextDefinition text, bool back, bool scroll )
		{
			if ( text != null && text.Number > 0 )
				AddHtmlLocalized( x, y, width, height, text.Number, back, scroll );
			else if ( text != null && text.String != null )
				AddHtml( x, y, width, height, text.String, back, scroll );
		}

		public static string Color( string text, int color )
		{
			return String.Format( "<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text );
		}
	}
}