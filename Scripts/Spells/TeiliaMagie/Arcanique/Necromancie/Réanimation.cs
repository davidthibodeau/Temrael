using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Items;
using Server.Gumps;

/*Reanimation.cs
 * 
 * Description : 
 * - Sort de nécromancie Réanimation. Relève un mort vivant avec les statistiques d'un cadavre
 * 
 * MAJ:
 * - 2010-02-08 : Diminution des statistiques de la créatures pour ne correspondre qu'à 33% de ceux de la créature originelle 
 * 
*/
namespace Server.Spells
{
	public class ReanimationSpell : Spell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Reanimation", "Uus Corp",
				SpellCircle.Seventh,
				203,
				9031,
				Reagent.GraveDust,
				Reagent.DaemonBlood,
                Reagent.DaemonBlood
            );

        public override SkillName CastSkill { get { return SkillName.ArtMagique; } }
        public override SkillName DamageSkill { get { return SkillName.Necromancie; } }

        public override bool Invocation { get { return true; } }

		public ReanimationSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
        }

        public ReanimationSpell(Mobile caster, Item scroll, Corpse corpse, Point3D location, int summon)
            : base(caster, scroll, m_Info)
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

            if (CheckSequence())
            {
                try
                {
                    //Choix du type de créature à ramener (Va définir des statistiques de base)
                    BaseCreature bc = Activator.CreateInstance(ReanimationGump.m_Entries[m_Summon].Creature) as BaseCreature;

                    if (bc != null)
                    {
                        Map map = Caster.Map;

                        if (map != null)
                        {
                            bc.ControlSlots = ReanimationGump.m_Entries[m_Summon].ControlSlot;

                            if ((Caster.Followers + bc.ControlSlots) > Caster.FollowersMax)
                            {
                                Caster.SendLocalizedMessage(1049645); // You have too many followers to summon that creature.
                            }
                            /*else if (m_Corpse != null && m_Corpse.InBones)
                            {
                                Caster.SendMessage("Vous ne pouvez animer la mort à partir de ce corps.");
                            }*/
                            else if (m_Corpse != null && m_Corpse.Owner != null)
                            {
                                int x = m_Location.X, y = m_Location.Y, z = m_Location.Z;

                                if (map.CanSpawnMobile(x, y, z))
                                {
                                    int mindam = 0;
                                    int maxdam = 0;

                                    //Si on réanime le cadavre d'un joueur ou d'un npc, met les dégâts au minimum
                                    if (m_Corpse.Owner is TMobile)
                                    {
                                        mindam = 10;
                                        maxdam = 15;
                                    }
                                    //Si on réanime une créature, met les dégâts à ceux de la créature
                                    else if (m_Corpse.Owner is BaseCreature)
                                    {
                                        mindam = ((int)(((BaseCreature)m_Corpse.Owner).DamageMin/3));
                                        maxdam = ((int)(((BaseCreature)m_Corpse.Owner).DamageMax/3));
                                    }

                                    //On assigne les statistiques du mort au monstre réanimé
                                    bc.SetStr((int)(m_Corpse.Owner.Str/3));
                                    bc.SetDex((int)(m_Corpse.Owner.Dex/3));
                                    bc.SetInt((int)(m_Corpse.Owner.Int/3));
                                    bc.SetHits((int)(m_Corpse.Owner.HitsMax * 0.60));
                                    bc.SetStam((int)(m_Corpse.Owner.StamMax * 0.60));
                                    bc.SetMana((int)(m_Corpse.Owner.ManaMax * 0.60));
                                    bc.SetDamage((int)(Utility.RandomMinMax(mindam, maxdam)));

                                    BaseCreature.Summon(bc, true, Caster, m_Location, 0x217, TimeSpan.FromDays(90));

                                    if (m_Corpse != null)
                                        m_Corpse.TurnToBones();
                                }
                            }
                            else
                                Caster.SendMessage("Le corps que vous ciblez ne peut être réanimé !");
                        }
                    }
                }
                catch
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

        public class ReanimationGump : Gump
        {
            public class ReanimationEntry
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

                public ReanimationEntry(Type creature, string name, int controlSlot, double minSkill, double maxSkill)
                {
                    m_Creature = creature;
                    m_Name = name;
                    m_ControlSlot = controlSlot;
                    m_MinSkill = minSkill;
                    m_MaxSkill = maxSkill;
                }
            }

            public static ReanimationEntry[] m_Entries = new ReanimationEntry[]
			{
				new ReanimationEntry( typeof(Zombie), "Zombie", 1, 20.0, 45.0 ),
				new ReanimationEntry( typeof(Skeleton), "Squelette", 1, 30.0, 55.0 ),
				new ReanimationEntry( typeof(Spectre), "Spectre", 2, 50.0, 90.0 ),
				new ReanimationEntry( typeof(Mummy), "Momie", 3, 70.0, 100.0 ),
			};

            private Mobile m_Caster;
            private Item m_Scroll;
            private Corpse m_Corpse;
            private Point3D m_Location;

            public ReanimationGump(Mobile caster, Item scroll, Corpse corpse, Point3D location)
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
                    m_Caster.CloseGump(typeof(ReanimationGump));
                }
                else
                {
                    Spell spell = new ReanimationSpell(m_Caster, m_Scroll, m_Corpse, m_Location, info.ButtonID - 1);
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

                    /*if (!corpse.InBones)*/
                        m_Caster.SendGump(new ReanimationGump(m_Caster, m_Scroll, corpse, corpse.Location));
                    /*else
                        m_Caster.SendMessage("Vous ne pouvez animer la mort à partir de ce corps.");*/
                }
			}
		}
	}
}