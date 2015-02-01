using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;

namespace Server.Gumps
{
	public class EditSkillGump : Gump
	{
		public static readonly bool OldStyle = PropsConfig.OldStyle;

		public static readonly int GumpOffsetX = PropsConfig.GumpOffsetX;
		public static readonly int GumpOffsetY = PropsConfig.GumpOffsetY;

		public static readonly int TextHue = PropsConfig.TextHue;
		public static readonly int TextOffsetX = PropsConfig.TextOffsetX;

		public static readonly int OffsetGumpID = PropsConfig.OffsetGumpID;
		public static readonly int HeaderGumpID = PropsConfig.HeaderGumpID;
		public static readonly int  EntryGumpID = PropsConfig.EntryGumpID;
		public static readonly int   BackGumpID = PropsConfig.BackGumpID;
		public static readonly int    SetGumpID = PropsConfig.SetGumpID;

		public static readonly int SetWidth = PropsConfig.SetWidth;
		public static readonly int SetOffsetX = PropsConfig.SetOffsetX, SetOffsetY = PropsConfig.SetOffsetY;
		public static readonly int SetButtonID1 = PropsConfig.SetButtonID1;
		public static readonly int SetButtonID2 = PropsConfig.SetButtonID2;

		public static readonly int PrevWidth = PropsConfig.PrevWidth;
		public static readonly int PrevOffsetX = PropsConfig.PrevOffsetX, PrevOffsetY = PropsConfig.PrevOffsetY;
		public static readonly int PrevButtonID1 = PropsConfig.PrevButtonID1;
		public static readonly int PrevButtonID2 = PropsConfig.PrevButtonID2;

		public static readonly int NextWidth = PropsConfig.NextWidth;
		public static readonly int NextOffsetX = PropsConfig.NextOffsetX, NextOffsetY = PropsConfig.NextOffsetY;
		public static readonly int NextButtonID1 = PropsConfig.NextButtonID1;
		public static readonly int NextButtonID2 = PropsConfig.NextButtonID2;

		public static readonly int OffsetSize = PropsConfig.OffsetSize;

		public static readonly int EntryHeight = PropsConfig.EntryHeight;
		public static readonly int BorderSize = PropsConfig.BorderSize;

		private static readonly int EntryWidth = 160;

		private static readonly int TotalWidth = OffsetSize + EntryWidth + OffsetSize + SetWidth + OffsetSize;
		private static readonly int TotalHeight = OffsetSize + (2 * (EntryHeight + OffsetSize));

		private static readonly int BackWidth = BorderSize + TotalWidth + BorderSize;
		private static readonly int BackHeight = BorderSize + TotalHeight + BorderSize;

		private Mobile m_From;
		private Mobile m_Target;
		private Skill m_Skill;

		private SkillCategory m_Selected;

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			if ( info.ButtonID == 1 )
			{
				try
				{
					if ( m_From.AccessLevel >= AccessLevel.Batisseur )
					{
						TextRelay text = info.GetTextEntry( 0 );

						if ( text != null )
						{
							m_Skill.Base = Convert.ToDouble( text.Text );
							CommandLogging.LogChangeProperty( m_From, m_Target, String.Format( "{0}.Base", m_Skill ), m_Skill.Base.ToString() );
						}
					}
					else
					{
						m_From.SendMessage( "You may not change that." );
					}

					m_From.SendGump( new SkillsGump( m_From, m_Target, m_Selected ) );
				}
				catch
				{
					m_From.SendMessage( "Bad format. ###.# expected." );
					m_From.SendGump( new EditSkillGump( m_From, m_Target, m_Skill, m_Selected ) );
				}
			}
			else
			{
				m_From.SendGump( new SkillsGump( m_From, m_Target, m_Selected ) );
			}
		}

		public EditSkillGump( Mobile from, Mobile target, Skill skill, SkillCategory selected ) : base( GumpOffsetX, GumpOffsetY )
		{
			m_From = from;
			m_Target = target;
			m_Skill = skill;
			m_Selected = selected;

			string initialText = m_Skill.Base.ToString( "F1" );

			AddPage( 0 );

			AddBackground( 0, 0, BackWidth, BackHeight, BackGumpID );
			AddImageTiled( BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), TotalHeight, OffsetGumpID );

			int x = BorderSize + OffsetSize;
			int y = BorderSize + OffsetSize;

			AddImageTiled( x, y, EntryWidth, EntryHeight, EntryGumpID );
			AddLabelCropped( x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, TextHue, skill.Name );
			x += EntryWidth + OffsetSize;

			if ( SetGumpID != 0 )
				AddImageTiled( x, y, SetWidth, EntryHeight, SetGumpID );

			x = BorderSize + OffsetSize;
			y += EntryHeight + OffsetSize;

			AddImageTiled( x, y, EntryWidth, EntryHeight, EntryGumpID );
			AddTextEntry( x + TextOffsetX, y, EntryWidth - TextOffsetX, EntryHeight, TextHue, 0, initialText );
			x += EntryWidth + OffsetSize;

			if ( SetGumpID != 0 )
				AddImageTiled( x, y, SetWidth, EntryHeight, SetGumpID );

			AddButton( x + SetOffsetX, y + SetOffsetY, SetButtonID1, SetButtonID2, 1, GumpButtonType.Reply, 0 );
		}
	}

	public class SkillsGump : Gump
	{
		public static bool OldStyle = PropsConfig.OldStyle;

		public static readonly int GumpOffsetX = PropsConfig.GumpOffsetX;
		public static readonly int GumpOffsetY = PropsConfig.GumpOffsetY;

		public static readonly int TextHue = PropsConfig.TextHue;
		public static readonly int TextOffsetX = PropsConfig.TextOffsetX;

		public static readonly int OffsetGumpID = PropsConfig.OffsetGumpID;
		public static readonly int HeaderGumpID = PropsConfig.HeaderGumpID;
		public static readonly int  EntryGumpID = PropsConfig.EntryGumpID;
		public static readonly int   BackGumpID = PropsConfig.BackGumpID;
		public static readonly int    SetGumpID = PropsConfig.SetGumpID;

		public static readonly int SetWidth = PropsConfig.SetWidth;
		public static readonly int SetOffsetX = PropsConfig.SetOffsetX, SetOffsetY = PropsConfig.SetOffsetY;
		public static readonly int SetButtonID1 = PropsConfig.SetButtonID1;
		public static readonly int SetButtonID2 = PropsConfig.SetButtonID2;

		public static readonly int PrevWidth = PropsConfig.PrevWidth;
		public static readonly int PrevOffsetX = PropsConfig.PrevOffsetX, PrevOffsetY = PropsConfig.PrevOffsetY;
		public static readonly int PrevButtonID1 = PropsConfig.PrevButtonID1;
		public static readonly int PrevButtonID2 = PropsConfig.PrevButtonID2;

		public static readonly int NextWidth = PropsConfig.NextWidth;
		public static readonly int NextOffsetX = PropsConfig.NextOffsetX, NextOffsetY = PropsConfig.NextOffsetY;
		public static readonly int NextButtonID1 = PropsConfig.NextButtonID1;
		public static readonly int NextButtonID2 = PropsConfig.NextButtonID2;

		public static readonly int OffsetSize = PropsConfig.OffsetSize;

		public static readonly int EntryHeight = PropsConfig.EntryHeight;
		public static readonly int BorderSize = PropsConfig.BorderSize;

		/*
		private static bool PrevLabel = OldStyle, NextLabel = OldStyle;

		private static readonly int PrevLabelOffsetX = PrevWidth + 1;
		
		private static readonly int PrevLabelOffsetY = 0;

		private static readonly int NextLabelOffsetX = -29;
		private static readonly int NextLabelOffsetY = 0;
		 * */

		private static readonly int NameWidth = 107;
		private static readonly int ValueWidth = 128;

		private static readonly int EntryCount = 15;

		private static readonly int TypeWidth = NameWidth + OffsetSize + ValueWidth;

		private static readonly int TotalWidth = OffsetSize + NameWidth + OffsetSize + ValueWidth + OffsetSize + SetWidth + OffsetSize;
		private static readonly int TotalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (EntryCount + 1));

		private static readonly int BackWidth = BorderSize + TotalWidth + BorderSize;
		private static readonly int BackHeight = BorderSize + TotalHeight + BorderSize;

		private static readonly int IndentWidth = 12;

		private Mobile m_From;
		private Mobile m_Target;

		private SkillCategory m_Selected;

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			int buttonID = info.ButtonID - 1;

			int index = buttonID / 3;
			int type = buttonID % 3;

			switch ( type )
			{
				case 0:
				{
					if ( index >= 0 && index < Enum.GetValues(typeof(SkillCategory)).Length )
					{
						SkillCategory newSelection = (SkillCategory)index;

						if ( m_Selected != newSelection )
							m_From.SendGump( new SkillsGump( m_From, m_Target, newSelection ) );
						else
							m_From.SendGump( new SkillsGump( m_From, m_Target, SkillCategory.Aucun ) );
					}

					break;
				}
				case 1:
				{
                    SkillName[] sks = SkillInfo.GetCategory(m_Selected);
					if ( m_Selected != SkillCategory.Aucun && index >= 0 && index < sks.Length )
					{
						Skill sk = m_Target.Skills[sks[index]];

						if ( sk != null )
						{
							if ( m_From.AccessLevel >= AccessLevel.Batisseur )
							{
								m_From.SendGump( new EditSkillGump( m_From, m_Target, sk, m_Selected ) );
							}
							else
							{
								m_From.SendMessage( "You may not change that." );
								m_From.SendGump( new SkillsGump( m_From, m_Target, m_Selected ) );
							}
						}
						else
						{
							m_From.SendGump( new SkillsGump( m_From, m_Target, m_Selected ) );
						}
					}

					break;
				}
				case 2:
				{
                    SkillName[] sks = SkillInfo.GetCategory(m_Selected);
                        if ( m_Selected != SkillCategory.Aucun && index >= 0 && index < sks.Length )
					{
						Skill sk = m_Target.Skills[sks[index]];

						if ( sk != null )
						{
							if ( m_From.AccessLevel >= AccessLevel.Batisseur )
							{
								switch ( sk.Lock )
								{
									case SkillLock.Up: sk.SetLockNoRelay( SkillLock.Down ); sk.Update(); break;
									case SkillLock.Down: sk.SetLockNoRelay( SkillLock.Locked ); sk.Update(); break;
									case SkillLock.Locked: sk.SetLockNoRelay( SkillLock.Up ); sk.Update(); break;
								}
							}
							else
							{
								m_From.SendMessage( "You may not change that." );
							}

							m_From.SendGump( new SkillsGump( m_From, m_Target, m_Selected ) );
						}
					}

					break;
				}
			}
		}

		public int GetButtonID( int type, int index )
		{
			return 1 + (index * 3) + type;
		}

		public SkillsGump( Mobile from, Mobile target ) : this( from, target, SkillCategory.Aucun )
		{
		}

		public SkillsGump( Mobile from, Mobile target, SkillCategory selected ) : base( GumpOffsetX, GumpOffsetY )
		{
			m_From = from;
			m_Target = target;

			m_Selected = selected;

			int count = Enum.GetValues(typeof(SkillCategory)).Length - 1;

            SkillName[] sks = SkillInfo.GetCategory(m_Selected);

            count += sks.Length;

			int totalHeight = OffsetSize + ((EntryHeight + OffsetSize) * (count + 1));

			AddPage( 0 );

			AddBackground( 0, 0, BackWidth, BorderSize + totalHeight + BorderSize, BackGumpID );
			AddImageTiled( BorderSize, BorderSize, TotalWidth - (OldStyle ? SetWidth + OffsetSize : 0), totalHeight, OffsetGumpID );

			int x = BorderSize + OffsetSize;
			int y = BorderSize + OffsetSize;

			int emptyWidth = TotalWidth - PrevWidth - NextWidth - (OffsetSize * 4) - (OldStyle ? SetWidth + OffsetSize : 0);

			if ( OldStyle )
				AddImageTiled( x, y, TotalWidth - (OffsetSize * 3) - SetWidth, EntryHeight, HeaderGumpID );
			else
				AddImageTiled( x, y, PrevWidth, EntryHeight, HeaderGumpID );

			x += PrevWidth + OffsetSize;

			if ( !OldStyle )
				AddImageTiled( x - (OldStyle ? OffsetSize : 0), y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0), EntryHeight, HeaderGumpID );

			x += emptyWidth + OffsetSize;

			if ( !OldStyle )
				AddImageTiled( x, y, NextWidth, EntryHeight, HeaderGumpID );

			foreach (SkillCategory sc in Enum.GetValues(typeof(SkillCategory)))
			{
                if (sc == SkillCategory.Aucun)
                    continue;

				x = BorderSize + OffsetSize;
				y += EntryHeight + OffsetSize;

				AddImageTiled( x, y, PrevWidth, EntryHeight, HeaderGumpID );

				if ( sc == selected )
					AddButton( x + PrevOffsetX, y + PrevOffsetY, 0x15E2, 0x15E6, GetButtonID( 0, (int)sc ), GumpButtonType.Reply, 0 );
				else
					AddButton( x + PrevOffsetX, y + PrevOffsetY, 0x15E1, 0x15E5, GetButtonID( 0, (int)sc ), GumpButtonType.Reply, 0 );

				x += PrevWidth + OffsetSize;

				x -= (OldStyle ? OffsetSize : 0);

				AddImageTiled( x, y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0), EntryHeight, EntryGumpID );
				AddLabel( x + TextOffsetX, y, TextHue, sc.ToString() );

				x += emptyWidth + (OldStyle ? OffsetSize * 2 : 0);
				x += OffsetSize;

				if ( SetGumpID != 0 )
					AddImageTiled( x, y, SetWidth, EntryHeight, SetGumpID );

				if ( sc == selected )
				{
					int indentMaskX = BorderSize;
					int indentMaskY = y + EntryHeight + OffsetSize;
                    int j = 0;
					foreach (SkillName skN in sks)
					{
						Skill sk = target.Skills[skN];

						x = BorderSize + OffsetSize;
						y += EntryHeight + OffsetSize;

						x += OffsetSize;
						x += IndentWidth;

						AddImageTiled( x, y, PrevWidth, EntryHeight, HeaderGumpID );

						AddButton( x + PrevOffsetX, y + PrevOffsetY, 0x15E1, 0x15E5, GetButtonID( 1, j ), GumpButtonType.Reply, 0 );

						x += PrevWidth + OffsetSize;

						x -= (OldStyle ? OffsetSize : 0);

						AddImageTiled( x, y, emptyWidth + (OldStyle ? OffsetSize * 2 : 0) - OffsetSize - IndentWidth, EntryHeight, EntryGumpID );
						AddLabel( x + TextOffsetX, y, TextHue, sk == null ? "(null)" : sk.Name );

						x += emptyWidth + (OldStyle ? OffsetSize * 2 : 0) - OffsetSize - IndentWidth;
						x += OffsetSize;

						if ( SetGumpID != 0 )
							AddImageTiled( x, y, SetWidth, EntryHeight, SetGumpID );

						if ( sk != null )
						{
							int buttonID1, buttonID2;
							int xOffset, yOffset;

							switch ( sk.Lock )
							{
								default:
								case SkillLock.Up: buttonID1 = 0x983; buttonID2 = 0x983; xOffset = 6; yOffset = 4; break;
								case SkillLock.Down: buttonID1 = 0x985; buttonID2 = 0x985; xOffset = 6; yOffset = 4; break;
								case SkillLock.Locked: buttonID1 = 0x82C; buttonID2 = 0x82C; xOffset = 5; yOffset = 2; break;
							}

							AddButton( x + xOffset, y + yOffset, buttonID1, buttonID2, GetButtonID( 2, j ), GumpButtonType.Reply, 0 );

							y += 1;
							x -= OffsetSize;
							x -= 1;
							x -= 50;

							AddImageTiled( x, y, 50, EntryHeight - 2, OffsetGumpID );

							x += 1;
							y += 1;

							AddImageTiled( x, y, 48, EntryHeight - 4, EntryGumpID );

							AddLabelCropped( x + TextOffsetX, y - 1, 48 - TextOffsetX, EntryHeight - 3, TextHue, sk.Base.ToString( "F1" ) );

							y -= 2;
                            j++;
						}
					}

					AddImageTiled( indentMaskX, indentMaskY, IndentWidth + OffsetSize, (sks.Length * (EntryHeight + OffsetSize)) - ((int)sc < (Enum.GetValues(typeof(SkillCategory)).Length - 2) ? OffsetSize : 0), BackGumpID + 4 );
                    j++;
                }
			}
		}
	}
}