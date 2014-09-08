using System;
using System.Text;
using Server.Gumps;
using Server.Network;
using Server.Items;

namespace Server.Items
{
    public class TatooDye : Item
    {
        public override int LabelNumber { get { return 1041060; } } // Hair Dye

        [Constructable]
        public TatooDye()
            : base(0xEFF)
        {
            Name = "Encre a tatouage";
            Weight = 1.0;
        }

        public TatooDye(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }


        public override void OnDoubleClick(Mobile from)
        {
            if (from.InRange(this.GetWorldLocation(), 1))
            {
                from.CloseGump(typeof(TatooDyeGump));
                from.SendGump(new TatooDyeGump(this));
            }
            else
            {
                from.LocalOverheadMessage(MessageType.Regular, 906, 1019045); // I can't reach that.
            }
        }
    }

    public class TatooDyeGump : Gump
    {
        private TatooDye m_TatooDye;

        private class TatooDyeEntry
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

            public TatooDyeEntry(string name, int hueStart, int hueCount)
            {
                m_Name = name;
                m_HueStart = hueStart;
                m_HueCount = hueCount;
            }
        }

        private static TatooDyeEntry[] m_Entries = new TatooDyeEntry[]
			{
				new TatooDyeEntry( "*****", 1602, 26 ),
				new TatooDyeEntry( "*****", 1628, 27 ),
				new TatooDyeEntry( "*****", 1502, 32 ),
				new TatooDyeEntry( "*****", 1302, 32 ),
				new TatooDyeEntry( "*****", 1402, 32 ),
				new TatooDyeEntry( "*****", 1202, 24 ),
				new TatooDyeEntry( "*****", 2402, 29 ),
				new TatooDyeEntry( "*****", 2213, 6 ),
				new TatooDyeEntry( "*****", 1102, 8 ),
				new TatooDyeEntry( "*****", 1110, 8 ),
				new TatooDyeEntry( "*****", 1118, 16 ),
				new TatooDyeEntry( "*****", 1134, 16 )
			};

        public TatooDyeGump(TatooDye dye)
            : base(50, 50)
        {
            m_TatooDye = dye;

            AddPage(0);

            AddBackground(100, 10, 350, 355, 2600);
            AddBackground(120, 54, 110, 270, 5100);

            AddHtml(70, 25, 400, 35, "<center>Menu de la sélection de la couleur du tatoo</center>", false, false);

            AddButton(149, 328, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddHtml(185, 329, 250, 35, "Teindre mon tatoo !", false, false);

            for (int i = 0; i < m_Entries.Length; ++i)
            {
                AddLabel(130, 59 + (i * 22), m_Entries[i].HueStart - 1, m_Entries[i].Name);
                AddButton(207, 60 + (i * 22), 5224, 5224, 0, GumpButtonType.Page, i + 1);
            }

            for (int i = 0; i < m_Entries.Length; ++i)
            {
                TatooDyeEntry e = m_Entries[i];

                AddPage(i + 1);

                for (int j = 0; j < e.HueCount; ++j)
                {
                    AddLabel(278 + ((j / 16) * 80), 52 + ((j % 16) * 17), e.HueStart + j - 1, "*****");
                    AddRadio(260 + ((j / 16) * 80), 52 + ((j % 16) * 17), 210, 211, false, (i * 100) + j);
                }
            }
        }

        public override void OnResponse(NetState from, RelayInfo info)
        {
            if (m_TatooDye.Deleted)
                return;

            Mobile m = from.Mobile;
            int[] switches = info.Switches;

            if (!m_TatooDye.IsChildOf(m.Backpack))
            {
                m.SendLocalizedMessage(1042010); //You must have the objectin your backpack to use it.
                return;
            }

            if (info.ButtonID != 0 && switches.Length > 0)
            {

                // To prevent this from being exploited, the hue is abstracted into an internal list
                int entryIndex = switches[0] / 100;
                int hueOffset = switches[0] % 100;

                if (entryIndex >= 0 && entryIndex < m_Entries.Length)
                {
                    TatooDyeEntry e = m_Entries[entryIndex];

                    if (hueOffset >= 0 && hueOffset < e.HueCount)
                    {
                        int hue = e.HueStart + hueOffset;

                        if (m.FindItemOnLayer(Layer.Tatoo) is GenericTatoo)
                        {
                            m.FindItemOnLayer(Layer.Tatoo).Hue = hue;
                            m.SendMessage("Vous teignez votre tatouage.");
                            m_TatooDye.Delete();
                            m.PlaySound(0x4E);
                        }
                        else
                        {
                            m.SendMessage("Vous n'avez pas de tatouage à teindre.");
                        }
                    }
                }
            }
            else
            {
                m.SendMessage("Vous décidez de ne pas teindre votre tatouage.");
            }
        }
    }

}
