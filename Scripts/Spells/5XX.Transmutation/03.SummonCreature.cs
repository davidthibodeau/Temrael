using System;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Targeting;

namespace Server.Spells
{
	public class SummonCreatureSpell : Spell
	{
        public static int m_SpellID { get { return 503; } } // TOCHANGE

        private static short s_Cercle = 3;

		public static readonly new SpellInfo Info = new SpellInfo(
                "Convocation", "Kal Xen",
                s_Cercle,
                203,
                9031,
                GetBaseManaCost(s_Cercle),
                TimeSpan.FromSeconds(1),
                SkillName.Transmutation,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
            );

		public SummonCreatureSpell( Mobile caster, Item scroll ) : base( caster, scroll, Info )
		{
        }

        public Type m_Creature;
        public int m_ControlSlots;

        public SummonCreatureSpell(Mobile caster, Item scroll, Type type, int controlSlot) : base(caster, scroll, Info)
		{
            m_Creature = type;
            m_ControlSlots = controlSlot;
		}

		public override bool CheckCast()
		{
			if ( !base.CheckCast() )
                return false;

            if ((Caster.Followers + m_ControlSlots) > Caster.FollowersMax)
            {
                Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                return false;
            }
            else if (m_Creature == null)
            {
                Caster.SendGump(new SummonCreatureGump(Caster, Scroll));
                return false;
            }

			return true;
		}

		public override void OnCast()
        {
            if ((Caster.Followers + m_ControlSlots) > Caster.FollowersMax)
            {
                Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                return;
            }
			else if ( CheckSequence() )
			{
				try
                {
                    BaseCreature creature = (BaseCreature)Activator.CreateInstance(m_Creature);
                    
                    double duration = 240 + (5 * Caster.Skills[SkillName.Immuabilite].Value);

                    SpellHelper.Summon(creature, Caster, 0x215, TimeSpan.FromSeconds(duration), true, true);
				}
				catch
				{
				}
			}

			FinishSequence();
        }

        private class SummonCreatureEntry
        {
            private int m_ItemID;
            private double m_RequiredSkill;
            private Type m_Type;

            private int m_OffsetX;
            private int m_OffsetY;

            public SummonCreatureEntry(int itemID, double requiredSkill, Type type, int offsetX, int offsetY)
            {
                m_ItemID = itemID;
                m_RequiredSkill = requiredSkill;
                m_Type = type;

                m_OffsetX = offsetX;
                m_OffsetY = offsetY;
            }

            public int ItemID { get { return m_ItemID; } }
            public double RequiredSkill { get { return m_RequiredSkill; } }
            public Type Type { get { return m_Type; } }

            public int OffsetX { get { return m_OffsetX; } }
            public int OffsetY { get { return m_OffsetY; } }
        }

        private static SummonCreatureEntry[] m_Table = new SummonCreatureEntry[]
		{
		    new SummonCreatureEntry( 0x20E2, 10.0, typeof(Rabbit), 0, 8 ),
			new SummonCreatureEntry( 0x211B, 15.0, typeof(Cat), 0, 8 ),
			new SummonCreatureEntry( 0x211C, 20.0, typeof(Dog), 0, 8 ),
			new SummonCreatureEntry( 0x2101, 25.0, typeof(Pig), 0, -3 ),
			new SummonCreatureEntry( 0x20D4, 35.0, typeof(Hind), 4, 5 ),
			new SummonCreatureEntry( 0x20F5, 40.0, typeof(Gorilla), 7, 0 ),
			new SummonCreatureEntry( 0x2124, 50.0, typeof(Horse), 0, -15 ),
			new SummonCreatureEntry( 0x2103, 55.0, typeof(Cow), 0, 0 ),
			new SummonCreatureEntry( 0x2118, 60.0, typeof(BlackBear), 7, -6 ),
			new SummonCreatureEntry( 0x20DA, 70.0, typeof(Alligator), 0, 0 ),
			new SummonCreatureEntry( 0x2119, 80.0, typeof(Panthere), 1, 6 ),
            //new SummonCreatureEntry( 0x20FC, 85.0, typeof(GiantSerpent), 3, -15 ),
            //new SummonCreatureEntry( 0x20DC, 90.0, typeof(Harpy), -52, -23 ),
            //new SummonCreatureEntry( 0x20E0, 92.0, typeof(Orc), 6, -5 ),
            //new SummonCreatureEntry( 0x20E3, 94.0, typeof(Ratman), -3, 0 ),
            //new SummonCreatureEntry( 0x20DE, 96.0, typeof(Lizardman), -28, -30 ),
            //new SummonCreatureEntry( 0x20E9, 98.0, typeof(Troll), 5, -29 ),
            //new SummonCreatureEntry( 0x2133, 100.0, typeof(OphidianWarrior), -16, -54 ),
		};

        public class SummonCreatureGump : Gump
        {
            private Mobile m_Caster;
            private Item m_Scroll;

            public SummonCreatureGump(Mobile caster, Item scroll) : base(50, 50)
            {
                m_Caster = caster;
                m_Scroll = scroll;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(69, 20, 489, 462, 9200);
                AddBackground(76, 61, 474, 413, 3500);
                AddBackground(76, 28, 474, 25, 9300);

                AddLabel(203, 30, 0, "Sélectionnez la créature à invoquer");

                AddImage(19, 21, 10440);
                AddImage(526, 21, 10441);

                for (int i = 0; i < m_Table.Length; ++i)
                {
                    if (m_Caster.Skills[SkillName.Immuabilite].Value >= m_Table[i].RequiredSkill)
                        AddButton(97 + ((i / 5) * 110), 107 + (75 * i) - ((i / 5) * 375), 2117, 2118, i + 1, GumpButtonType.Reply, 0);
                    else
                        AddImage(97 + ((i / 5) * 110), 107 + (75 * i) - ((i / 5) * 375), 2117, 972);

                    AddItem(128 + ((i / 5) * 110) + m_Table[i].OffsetX, 88 + (75 * i) - ((i / 5) * 375) + m_Table[i].OffsetY, m_Table[i].ItemID/*, magery >= m_Table[i].RequiredSkill ? 0 : 973*/ );
                }
            }

            public override void OnResponse(NetState state, RelayInfo info)
            {
                if (info.ButtonID > 0)
                {
                    int controlSlots;

                    if (info.ButtonID < 7)
                        controlSlots = 1;
                    else if (info.ButtonID < 11)
                        controlSlots = 2;
                    else if (info.ButtonID < 14)
                        controlSlots = 3;
                    else if (info.ButtonID < 18)
                        controlSlots = 4;
                    else
                        controlSlots = 5;

                    Spell spell = new SummonCreatureSpell(m_Caster, m_Scroll, m_Table[info.ButtonID - 1].Type, controlSlots);
                    spell.Cast();
                }
            }
        }

		public override TimeSpan GetCastDelay()
		{
			return base.GetCastDelay() + TimeSpan.FromSeconds( 2.0 );
		}
	}
}