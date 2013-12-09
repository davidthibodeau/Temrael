using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Targets;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Mobiles;

namespace Server.Gumps
{
	public class MetamorphoseGump : Gump
	{
		public class MetamorphoseEntry
		{
            private int m_Art, m_Body, m_Num, m_StrMod, m_DexMod, m_IntMod, m_Hue;
            private double m_SkillReq;
            private string m_Name;

            public int ArtID { get { return m_Art; } }
            public int BodyID { get { return m_Body; } }
            public int LocNumber { get { return m_Num; } }
            public int StrMod { get { return m_StrMod; } }
            public int DexMod { get { return m_DexMod; } }
            public int IntMod { get { return m_IntMod; } }
            public string Name { get { return m_Name; } }
            public double SkillReq { get { return m_SkillReq; } }
            public int Hue { get { return m_Hue; } }

            public MetamorphoseEntry(string name, int Art, int Body, int LocNum, int StrMod, int DexMod, int IntMod, double SkillReq, int hue)
			{
				m_Art = Art;
				m_Body = Body;
				m_Num = LocNum;
                m_StrMod = StrMod;
                m_DexMod = DexMod;
                m_IntMod = IntMod;
                m_SkillReq = SkillReq;
                m_Name = name;
                m_Hue = hue;
			}

            public MetamorphoseEntry(GenericReader reader)
            {
                int version = reader.ReadInt();

                switch (version)
                {
                    case 0:
                        {
                            m_Art = reader.ReadInt();
                            m_Body = reader.ReadInt();
                            m_Num = reader.ReadInt();
                            m_StrMod = reader.ReadInt();
                            m_DexMod = reader.ReadInt();
                            m_IntMod = reader.ReadInt();
                            m_SkillReq = reader.ReadDouble();
                            m_Name = reader.ReadString();
                            m_Hue = reader.ReadInt();

                            break;
                        }
                }
            }

            public void Serialize(GenericWriter writer)
            {
                writer.Write((int)0);

                writer.Write(m_Art);
                writer.Write(m_Body);
                writer.Write(m_Num);
                writer.Write(m_StrMod);
                writer.Write(m_DexMod);
                writer.Write(m_IntMod);
                writer.Write(m_SkillReq);
                writer.Write(m_Name);
                writer.Write(m_Hue);
            }
        }

        //private static MetamorphoseCategory[] Categories = new MetamorphoseCategory[]
        //{
        //    new MetamorphoseCategory( 1015235, new MetamorphoseEntry[] //Animals
        //    {   
        //        new MetamorphoseEntry( "Poulet", 8401, 0xD0, 1015236, 0, 0, 0, 0 ),//Chicken
        //        new MetamorphoseEntry( "Chien", 8405, 0xD9, 1015237, 0, 0, 0, 0 ),//Dog
        //        new MetamorphoseEntry( "Loup", 8426, 0xE1, 1015238, 0, 5, 0, 10 ),//Wolf
        //        new MetamorphoseEntry( "Panthere", 8473, 0xD6, 1015239, 0, 10, 0, 15 ),//Panther
        //        new MetamorphoseEntry( "Gorille", 8437, 0x1D, 1015240, 10, 0, 0, 20 ),//Gorilla
        //        new MetamorphoseEntry( "Ours noir", 8399, 0xD3, 1015241, 15, 0, 0, 25 ),//Black Bear
        //        new MetamorphoseEntry( "Grizzly", 8411, 0xD4, 1015242, 20, 0, 0, 35 ),//Grizzly Bear
        //        new MetamorphoseEntry( "Ours polaire", 8417, 0xD5, 1015243, 25, 0, 0, 40 ),//Polar Bear
        //    } ),

        //    new MetamorphoseCategory( 1015245, new MetamorphoseEntry[] //Monsters
        //    {
        //        new MetamorphoseEntry( "Slime", 8424, 0x33, 1015246, 0, 0, 0, 0),//Slime
        //        new MetamorphoseEntry( "Orc", 8416, 0x11, 1015247, 15, 10, 0, 30 ),//Orc
        //        new MetamorphoseEntry( "Homme-lezard", 8414, 0x21, 1015248, 20, 10, 0, 50 ),//Lizard Man
        //        new MetamorphoseEntry( "Gargouille", 8409, 0x04, 1015249, 0, 0, 10, 60 ),//Gargoyle
        //        new MetamorphoseEntry( "Ogre", 8415, 0x01, 1015250, 25, 15, 0, 65 ),//Orge
        //        new MetamorphoseEntry( "Troll", 8425, 0x36, 1015251, 30, 10, 0, 85 ),//Troll
        //        new MetamorphoseEntry( "Ettin", 8408, 0x02, 1015252, 50, 0, 0, 90 ),//Ettin
        //    } )
        //};

		private Mobile m_Caster;
		private Item m_Scroll;
        private ArrayList m_Entries;
        private int m_Owner;

        public MetamorphoseGump(Mobile caster, Item scroll, ArrayList entries, int owner)//Owner == niveau du sort de métamorphose...
            : base(50, 50)
        {
            m_Caster = caster;
            m_Scroll = scroll;
            m_Entries = entries;
            m_Owner = owner;

            if (entries == null)
                return;

            if (m_Owner < 1 || m_Owner >= 7)
                return;

            int x, y;
            AddPage(0);
            AddBackground(0, 0, 427, 372, 5054);
            AddBackground(10, 20, 407, 342, 3000);
            AddLabel(15, 3, 50, "Choix de transformation"); 

            if (owner == 5)
            {
                for (int c = 0; c < entries.Count; c++)
                {
                    MetamorphoseEntry entry = (MetamorphoseEntry)entries[c];
                    x = 15 + (c % 4) * 100;
                    y = 18 + (c / 4) * 67;

                    AddLabel(x, y, 0, entry.Name);
                    AddItem(x + 25, y + 25, entry.ArtID);
                    AddButton(x, y + 20, 2103, 2104, c + 1, GumpButtonType.Reply, 1);
                    AddButton(x, y + 40, 2223, 2223, c + 21, GumpButtonType.Reply, 1);
                }
            }
            else
            {
                for (int c = 0; c < entries.Count; c++)
                {
                    MetamorphoseEntry entry = (MetamorphoseEntry)entries[c];
                    x = 15 + (c % 4) * 100;
                    y = 18 + (c / 4) * 67;

                    AddLabel(x, y, 0, entry.Name);
                    AddItem(x + 15, y + 25, entry.ArtID);
                    AddButton(x, y + 20, 2103, 2104, c + 1, GumpButtonType.Reply, 1);
                }
            }
        }

		public override void OnResponse( NetState state, RelayInfo info )
		{
            if (info.ButtonID >= 21)
            {
                if ((info.ButtonID - 21) < m_Entries.Count)
                {
                    int button = info.ButtonID - 21;

                    if (state.Mobile is TMobile)
                    {
                        TMobile pm = (TMobile)state.Mobile;

                        if (pm.MetamorphoseList != null && button < pm.MetamorphoseList.Count && button >= 0)
                            pm.MetamorphoseList.RemoveAt(button);

                        pm.SendGump(new MetamorphoseGump(pm, m_Scroll, pm.MetamorphoseList, 5));
                    }
                }
            }
			else if ( info.ButtonID >= 1)
			{
                if ((info.ButtonID - 1) < m_Entries.Count)
                {
                    int button = info.ButtonID - 1;
                    MetamorphoseEntry entry = (MetamorphoseEntry)m_Entries[button];

                    switch (m_Owner)
                    {
                        case 6:
                            {
                                Spell spell = new Spells.MutationSpell(m_Caster, m_Scroll, entry.Name, entry.BodyID, entry.Hue);
                                spell.Cast();
                                break;
                            }
                        case 5:
                            {
                                Spell spell = new Spells.MetamorphoseSpell(m_Caster, m_Scroll, entry.Name, entry.BodyID, entry.StrMod, entry.DexMod, entry.IntMod, entry.SkillReq, entry.Hue);
                                spell.Cast();
                                break;
                            }
                        case 4:
                            {
                                Spell spell = new Spells.TransmutationSpell(m_Caster, m_Scroll, entry.Name, entry.BodyID, entry.Hue);
                                spell.Cast();
                                break;
                            }
                        case 3:
                            {
                                Spell spell = new Spells.ChimereSpell(m_Caster, m_Scroll, entry.Name, entry.BodyID, entry.Hue);
                                spell.Cast();
                                break;
                            }
                        case 2:
                            {
                                Spell spell = new Spells.SubterfugeSpell(m_Caster, m_Scroll, entry.Name, entry.BodyID, entry.Hue);
                                spell.Cast();
                                break;
                            }
                        case 1:
                            {
                                Spell spell = new Spells.AlterationSpell(m_Caster, m_Scroll, entry.Name, entry.BodyID, entry.Hue);
                                spell.Cast();
                                break;
                            }
                    }
                }
			}
		}
	}
}
