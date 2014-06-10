using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Gumps;

namespace Server.Spells.Necromancy
{
	public class AnimateDeadSpell : NecromancerSpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Animate Dead", "Uus Corp",
				SpellCircle.Eighth,
				203,
				9031,
				Reagent.GraveDust,
				Reagent.DaemonBlood,
                Reagent.NoxCrystal,
                Reagent.PigIron
            );

        public override int RequiredAptitudeValue { get { return 12; } }
        public override Aptitude[] RequiredAptitude { get { return new Aptitude[] {Aptitude.Necromancie }; } }

		public AnimateDeadSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
        }

        public AnimateDeadSpell(Mobile caster, Item scroll, Corpse corpse, Point3D location, int summon) : base(caster, scroll, m_Info)
        {
            m_Corpse = corpse;
            m_Location = location;
            m_Summon = summon;
        }

        private Corpse m_Corpse;
        private Point3D m_Location;
        private int m_Summon = -1;

        public override bool CheckCast()
        {
            if (m_Summon == -1)
            {
                Caster.Target = new InternalTarget(Caster, Scroll);
                Caster.SendLocalizedMessage(1061083); // Animate what corpse?
                return false;
            }

            return true;
        }

		public override void OnCast()
        {
            double skill = (Caster.Skills[SkillName.ArtMagique].Base + Caster.Skills[SkillName.Goetie].Base) / 2;

            if (CheckSequence())
            {
                if (skill > Utility.RandomMinMax((int)AnimateDeadGump.m_Entries[m_Summon].MinSkill, (int)AnimateDeadGump.m_Entries[m_Summon].MaxSkill))
                {
                    try
                    {
                        BaseCreature bc = Activator.CreateInstance(AnimateDeadGump.m_Entries[m_Summon].Creature) as BaseCreature;

                        if (bc != null)
                        {
                            Map map = Caster.Map;

                            if (map != null)
                            {
                                bc.ControlSlots = AnimateDeadGump.m_Entries[m_Summon].ControlSlot;

                                if ((Caster.Followers + bc.ControlSlots) > Caster.FollowersMax)
                                {
                                    Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                                }
                                /*else if (m_Corpse != null && m_Corpse.InBones)
                                {
                                    Caster.SendMessage("Vous ne pouvez animer la mort à partir de ce corps.");
                                }*/
                                else
                                {
                                    int x = m_Location.X, y = m_Location.Y, z = m_Location.Z;

                                    if (map.CanSpawnMobile(x, y, z))
                                    {
                                        bc.SetStr((int)(bc.Str / 2));
                                        bc.SetDex((int)(bc.Dex / 2));
                                        bc.SetInt((int)(bc.Int / 2));
                                        bc.SetHits((int)(bc.Hits / 2));
                                        bc.SetStam((int)(bc.Stam / 2));
                                        bc.SetMana((int)(bc.Mana / 2));
                                        bc.SetDamage((int)(Utility.RandomMinMax(bc.DamageMin, bc.DamageMax) / 2));

                                        BaseCreature.Summon(bc, true, Caster, m_Location, 0x217, TimeSpan.FromDays(90));

                                        if (m_Corpse != null)
                                            m_Corpse.TurnToBones();
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                        DoFizzle();
                    }
                }
                else
                {
                    DoFizzle();
                }
            }

            FinishSequence();
		}

        public static void Unregister(Mobile master, Mobile summoned)
        {
        }

        public static void Register(Mobile master, Mobile summoned)
        {
        }

        public class AnimateDeadGump : Gump
        {
            public class AnimateDeadEntry
            {
                private Type m_Creature;
                private string m_Name;
                private int m_ControlSlot;
                private double m_MinSkill, m_MaxSkill;

                public Type Creature { get { return m_Creature; } }
                public string Name { get { return m_Name; } }
                public int ControlSlot { get { return m_ControlSlot; } }
                public double MinSkill { get { return m_MinSkill; } }
                public double MaxSkill { get { return m_MaxSkill; } }

                public AnimateDeadEntry(Type creature, string name, int controlSlot, double minSkill, double maxSkill)
                {
                    m_Creature = creature;
                    m_Name = name;
                    m_ControlSlot = controlSlot;
                    m_MinSkill = minSkill;
                    m_MaxSkill = maxSkill;
                }
            }

            public static AnimateDeadEntry[] m_Entries = new AnimateDeadEntry[]
			{
				new AnimateDeadEntry( typeof(Zombie), "Zombie", 1, 50.0, 75.0 ),
				new AnimateDeadEntry( typeof(Skeleton), "Squelette", 1, 60.0, 85.0 ),
				new AnimateDeadEntry( typeof(Spectre), "Spectre", 3, 70.0, 95.0 ),
				new AnimateDeadEntry( typeof(Mummy), "Momie", 5, 80.0, 105.0 ),
				new AnimateDeadEntry( typeof(Lich), "Liche", 8, 90.0, 115.0 )
			};

            private Mobile m_Caster;
            private Item m_Scroll;
            private Corpse m_Corpse;
            private Point3D m_Location;

            public AnimateDeadGump(Mobile caster, Item scroll, Corpse corpse, Point3D location)
                : base(0, 0)
            {
                m_Caster = caster;
                m_Scroll = scroll;
                m_Corpse = corpse;
                m_Location = location;

                Closable = true;
                Disposable = true;
                Dragable = true;
                Resizable = false;

                AddPage(0);

                AddBackground(30, 19, 231, 190, 9270);
                AddBackground(46, 33, 200, 31, 9400);

                AddLabel(52, 39, 2101, "Choisissez le type de créature");

                for (int i = 0; i < m_Entries.Length; ++i)
                {
                    AddButton(49, 79 + (i * 22), 2103, 2104, i + 1, GumpButtonType.Reply, 0);
                    AddLabel(67, 74 + (i * 22), 2101, m_Entries[i].Name);
                }
            }

            public override void OnResponse(NetState sender, RelayInfo info)
            {
                if (info.ButtonID <= 0)
                {
                    m_Caster.CloseGump(typeof(AnimateDeadGump));
                }
                else
                {
                    Spell spell = new AnimateDeadSpell(m_Caster, m_Scroll, m_Corpse, m_Location, info.ButtonID - 1);
                    spell.Cast();
                }
            }
        }

		private class InternalTarget : Target
		{
            private Mobile m_Caster;
            private Item m_Scroll;

            public InternalTarget(Mobile caster, Item scroll) : base(12, false, TargetFlags.None)
			{
                m_Caster = caster;
                m_Scroll = scroll;
			}

			protected override void OnTarget( Mobile from, object o )
			{
                if (o is Corpse)
                {
                    Corpse corpse = (Corpse)o;

                    //if (!corpse.InBones)
                        m_Caster.SendGump(new AnimateDeadGump(m_Caster, m_Scroll, corpse, corpse.Location));
                    //else
                    //    m_Caster.SendMessage("Vous ne pouvez animer la mort à partir de ce corps.");
                }
			}
		}
	}
}