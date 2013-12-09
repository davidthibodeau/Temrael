using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Commands;
using Server.Misc;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Regions;
using Server.Movement;
using Server.Spells.Fifth;
using Server.Spells.Seventh;
using Server.Spells.Necromancy;
using Server.Spells;
using Server.Mobiles;
using Server.Multis;
using Server.ContextMenus;

namespace Server.Mobiles
{
    abstract class BaseGardes : BaseCreature
    {
        private bool m_isGuarding = false;
        private GeoController m_controller = null;
        private ArmyController m_army = null;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool IsGuarding { get { return m_isGuarding; } set { m_isGuarding = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public GeoController Controller { get { return m_controller; } set { m_controller = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public ArmyController Army { get { return m_army; } set { m_army = value; } }

        public BaseGardes(GeoController controller, ArmyController army)
            : base(AIType.AI_Army, FightMode.Closest, 2, 1, 0.5, 2)
        {
            Title = "Garde";
            m_isGuarding = false;
            this.m_controller = controller;
            this.m_army = army;
        }

        public override void OnThink()
        {
            base.OnThink();
            if (m_isGuarding)
                DoGuard();
        }

        public void DoGuard()
        {
            ArrayList list = new ArrayList();
            foreach (Mobile m in this.GetMobilesInRange(8))
            {
                if (!(m_controller == null))
                {
                    for (int i = 0; i < m_controller.Conseillers.Count; i++)
                    {
                        if (m_controller.Conseillers[i].Mob.Serial == m.Serial)
                            continue;
                    }
                    for (int i = 0; i < m_controller.Citoyens.Count; i++)
                    {
                        if (m_controller.Citoyens[i].Mob.Serial == m.Serial)
                            continue;
                    }
                    if (m == this || !CanBeHarmful(m) || !m.Alive || !InLOS(m) || !m.Warmode || !(m.Aggressed.Count == 0))
                        continue;
                    else
                        list.Add(m);
                }
            }
            if (list.Count == 0)
            {
                if (Location == Home)
                {
                    Frozen = true;
                }
                else
                {
                    Move(GetDirectionTo(Home));
                }
            }
            else
            {
                Frozen = false;
                foreach (Mobile m in list)
                {
                    m.Attack(m);
                }
            }
            list.Clear();
        }

        private class GarderEntry : ContextMenuEntry
        {
            private BaseGardes m_from;

            public GarderEntry(BaseGardes from)
                : base(6288, -1)
            {
                m_from = from;
            }

            public override void OnClick()
            {
                if (m_from.IsGuarding == false)
                {
                    m_from.IsGuarding = true;
                    m_from.AI = AIType.AI_Melee;
                    m_from.Home = m_from.Location;
                }
                else
                {
                    m_from.IsGuarding = false;
                    m_from.AI = AIType.AI_Army;
                    m_from.Frozen = false;
                }
            }
        }

        public override void GetContextMenuEntries(Mobile m_from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(m_from, list);

            if (m_army != null)
            {
                if (m_army.Owner == m_from)
                {
                    list.Add(new GarderEntry(this));
                }
                else
                {
                    m_from.SendMessage(m_army.Owner.Name);
                }
            }
        }

        public BaseGardes(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write( (bool) m_isGuarding);
            writer.Write( (GeoController) m_controller);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    reader.ReadBool();
                    reader.ReadItem();
                    break;
                default: break;
            }
        }
    }
}
