using System;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Targeting;

namespace Server.Spells
{
	public class AnimauxSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
                "Animaux", "Haga Maga",
				SpellCircle.Third,
				266,
				9040
            );

        public override int RequiredAptitudeValue { get { return 3; } }
        public override NAptitude[] RequiredAptitude { get { return new NAptitude[] { NAptitude.Monial }; } }

        public override bool Invocation { get { return true; } }

		public AnimauxSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
        }

        public Type m_Creature;
        public int m_ControlSlots;

        public AnimauxSpell(Mobile caster, Item scroll, Type type, int controlSlot)
            : base(caster, scroll, m_Info)
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
                Caster.SendGump(new SummonAnimauxGump(Caster, Scroll));
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
                    
                    TimeSpan duration = GetDurationForSpell(20, 1.8);

                    SpellHelper.Summon(creature, Caster, 0x215, duration, true, true);
				}
				catch
				{
				}
			}

			FinishSequence();
        }

        private class SummonAnimauxEntry
        {
            private int m_ItemID;
            private double m_RequiredSkill;
            private Type m_Type;

            private int m_OffsetX;
            private int m_OffsetY;

            public SummonAnimauxEntry(int itemID, double requiredSkill, Type type, int offsetX, int offsetY)
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

        private static SummonAnimauxEntry[] m_Table = new SummonAnimauxEntry[]
		{
		    new SummonAnimauxEntry( 0x2123, 10.0, typeof(Rat), 0, 8 ),
			new SummonAnimauxEntry( 0x2401, 12.0, typeof(GiantRat), 0, 8 ),
			new SummonAnimauxEntry( 0x20FC, 14.0, typeof(Snake), 0, 8 ),
			new SummonAnimauxEntry( 0x2122, 17.0, typeof(TimberWolf), 0, -3 ),
			new SummonAnimauxEntry( 0x20D5, 20.0, typeof(GreyWolf), 4, 5 ),
            new SummonAnimauxEntry( 0x2131, 45.0, typeof(Alligator), 0, -15 ),
			new SummonAnimauxEntry( 0x211C, 55.0, typeof(WhiteWolf), 7, 0 ),
			new SummonAnimauxEntry( 0x2102, 65.0, typeof(Panther), 0, 0 ),
			new SummonAnimauxEntry( 0x25BF, 75.0, typeof(GiantSerpent), 7, -6 )
		};

        public class SummonAnimauxGump : Gump
        {
            private Mobile m_Caster;
            private Item m_Scroll;

            public SummonAnimauxGump(Mobile caster, Item scroll) : base(50, 50)
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
                    if (m_Caster.Skills[SkillName.ArtMagique].Value >= m_Table[i].RequiredSkill)
                        AddButton(97 + ((i / 5) * 110), 107 + (75 * i) - ((i / 5) * 375), 2117, 2118, i + 1, GumpButtonType.Reply, 0);
                    else
                        AddImage(97 + ((i / 5) * 110), 107 + (75 * i) - ((i / 5) * 375), 2117, 972);

                    AddItem(128 + ((i / 5) * 110) + m_Table[i].OffsetX, 88 + (75 * i) - ((i / 5) * 375) + m_Table[i].OffsetY, m_Table[i].ItemID );
                }
            }

            public override void OnResponse(NetState state, RelayInfo info)
            {
                if (info.ButtonID > 0)
                {
                    int controlSlots = 2;

                    if (info.ButtonID < 7)
                        controlSlots = 1;

                    Spell spell = new AnimauxSpell(m_Caster, m_Scroll, m_Table[info.ButtonID - 1].Type, controlSlots);
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