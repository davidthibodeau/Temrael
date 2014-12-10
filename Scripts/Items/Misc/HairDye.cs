using System;
using System.Text;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class HairDye : Item
	{
		public override int LabelNumber{ get{ return 1041060; } } // Hair Dye

		[Constructable]
		public HairDye() : base( 0xEFF )
		{
            GoldValue = 30;
            Name = "Teinture a cheveux";
			Weight = 1.0;
		}

		public HairDye( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				from.CloseGump( typeof( HairDyeGump ) );
				from.SendGump( new HairDyeGump( this ) );
			}
			else
			{
				from.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that.
			}	
		}
	}

	public class HairDyeGump : Gump
	{
		private HairDye m_HairDye;

		private class HairDyeEntry
		{
			private string m_Name;
			private int m_HueStart;
			private int m_HueCount;

			public string Name
			{
				get
				{
					return m_Name;
				}
			}

			public int HueStart
			{
				get
				{
					return m_HueStart;
				}
			}

			public int HueCount
			{
				get
				{
					return m_HueCount;
				}
			}

			public HairDyeEntry( string name, int hueStart, int hueCount )
			{
				m_Name = name;
				m_HueStart = hueStart;
				m_HueCount = hueCount;
			}
		}

		private static HairDyeEntry[] m_Entries = new HairDyeEntry[]
			{
				new HairDyeEntry( "*****", 1602, 26 ),
				new HairDyeEntry( "*****", 1628, 27 ),
				new HairDyeEntry( "*****", 1502, 32 ),
				new HairDyeEntry( "*****", 1302, 32 ),
				new HairDyeEntry( "*****", 1402, 32 ),
				new HairDyeEntry( "*****", 1202, 24 ),
				new HairDyeEntry( "*****", 2402, 29 ),
				new HairDyeEntry( "*****", 2213, 6 ),
				new HairDyeEntry( "*****", 1102, 8 ),
				new HairDyeEntry( "*****", 1110, 8 ),
				new HairDyeEntry( "*****", 1118, 16 ),
				new HairDyeEntry( "*****", 1134, 16 )
			};

		public HairDyeGump( HairDye dye ) : base( 50, 50 )
		{
			m_HairDye = dye;

			AddPage( 0 );

			AddBackground( 100, 10, 350, 355, 2600 );
			AddBackground( 120, 54, 110, 270, 5100 );

			AddHtml( 70, 25, 400, 35, "<center>Menu de la sélection de la couleur des cheveux</center>", false, false ); // <center>Hair Color Selection Menu</center>

            AddButton(119, 328, 4005, 4007, 2, GumpButtonType.Reply, 0);
            AddHtml(155, 329, 250, 35, "Tester", false, false);

			AddButton( 219, 328, 4005, 4007, 1, GumpButtonType.Reply, 0 );
            AddHtml(255, 329, 250, 35, "Teindre mes cheveux !", false, false);

			for ( int i = 0; i < m_Entries.Length; ++i )
			{
				AddLabel( 130, 59 + (i * 22), m_Entries[i].HueStart - 1, m_Entries[i].Name );
				AddButton( 207, 60 + (i * 22), 5224, 5224, 0, GumpButtonType.Page, i + 1 );
			}

			for ( int i = 0; i < m_Entries.Length; ++i )
			{
				HairDyeEntry e = m_Entries[i];

				AddPage( i + 1 );

				for ( int j = 0; j < e.HueCount; ++j )
				{
					AddLabel( 278 + ((j / 16) * 80), 52 + ((j % 16) * 17), e.HueStart + j - 1, "*****" );
					AddRadio( 260 + ((j / 16) * 80), 52 + ((j % 16) * 17), 210, 211, false, (i * 100) + j );
				}
			}
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_HairDye.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			if ( !m_HairDye.IsChildOf( m.Backpack ) ) 
			{
				m.SendLocalizedMessage( 1042010 ); //You must have the objectin your backpack to use it.
				return;
			}

			if ( info.ButtonID != 0 && switches.Length > 0 )
			{
				if( m.HairItemID == 0 && m.FacialHairItemID == 0 )
				{
					m.SendLocalizedMessage( 502623 );	// You have no hair to dye and cannot use this
				}
				else if (info.ButtonID == 1)
				{
					// To prevent this from being exploited, the hue is abstracted into an internal list

					int entryIndex = switches[0] / 100;
					int hueOffset = switches[0] % 100;

					if ( entryIndex >= 0 && entryIndex < m_Entries.Length )
					{
						HairDyeEntry e = m_Entries[entryIndex];

						if ( hueOffset >= 0 && hueOffset < e.HueCount )
						{
							int hue = e.HueStart + hueOffset;

							m.HairHue = hue;
							m.FacialHairHue = hue;

							m.SendMessage( "Vous teignez vos cheveux" );
							m_HairDye.Delete();
							m.PlaySound( 0x4E );
						}
					}
				}
                else if (info.ButtonID == 2)
                {
                    int entryIndex = switches[0] / 100;
					int hueOffset = switches[0] % 100;

                    if (entryIndex >= 0 && entryIndex < m_Entries.Length)
                    {
                        HairDyeEntry e = m_Entries[entryIndex];

                        if (hueOffset >= 0 && hueOffset < e.HueCount)
                        {
                            int hue = e.HueStart + hueOffset;

                            m.SendGump(new EchantillonGump(m, hue, m_HairDye));
                        }

                    }
                }
			}
			else
			{
                m.SendMessage("Vous décidez de ne pas teindre vos cheveux."); // You decide not to dye your hair
			}
		}

        private class EchantillonGump : Gump
        {
            private HairDye m_HairDye;
            private int Hue;

            public EchantillonGump(Mobile m, int hue, HairDye Dye)
                : base(50, 50)
            {
                m_HairDye = Dye;
                Hue = hue;

                AddBackground(0, 0, 300, 380, 5054);
                //AddItem(20, 300, target.ItemID, hue);
                AddBackground(20, 20, 250, 250, 0xa3c);
                AddLabel(95, 305, 0, "Utiliser cette couleur");
                AddButton(235, 304, 4005, 4007, 1, GumpButtonType.Reply, 0);
                if (m.Female)
                {
                    AddImage(30, 30, 0xD);
                    if (m.HairItemID > 0)
                    {
                        AddImage(30, 30, TileData.ItemTable[m.HairItemID].Animation + 60000, hue);
                    }

                    if (m.FacialHairItemID > 0)
                    {
                        AddImage(30, 30, TileData.ItemTable[m.FacialHairItemID].Animation + 60000, hue);
                    }
                }
                else
                {
                    AddImage(30, 30, 0xC);

                    if (m.HairItemID > 0)
                    {
                        AddImage(30, 30, TileData.ItemTable[m.HairItemID].Animation + 50000, hue);
                    }

                    if (m.FacialHairItemID > 0)
                    {
                        AddImage(30, 30, TileData.ItemTable[m.FacialHairItemID].Animation + 50000, hue);
                    }
                }
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                Mobile m = sender.Mobile;

                if (info.ButtonID == 1)
                {
                    m.HairHue = Hue;
                    m.FacialHairHue = Hue;

                    m.SendMessage("Vous teignez vos cheveux");
                    m_HairDye.Delete();
                    m.PlaySound(0x4E);
                }
                else
                {
                    m.SendGump(new HairDyeGump(m_HairDye));
                }
            }
        }
	}
}