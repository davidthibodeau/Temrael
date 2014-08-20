using Server.ContextMenus;
using Server.Factions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    public abstract class BaseWearable : Item, IFactionItem
    {
        #region Factions
        private FactionItem m_FactionState;

        public FactionItem FactionItemState
        {
            get { return m_FactionState; }
            set
            {
                m_FactionState = value;

                if (m_FactionState == null)
                    Hue = 0;// CraftResources.GetHue(Resource);

                LootType = (m_FactionState == null ? LootType.Regular : LootType.Blessed);
            }
        }
        #endregion

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (RootParent is Mobile)
            {
                if ((Mobile)RootParent == from)
                {
                    if (from.FindItemOnLayer(this.Layer) == this)
                        list.Add(new UnEquipEntry(from, this));
                    else
                        list.Add(new EquipEntry(from, this));
                }
            }
            else if (RootParent is Item || RootParent == null)
            {
                if (from.FindItemOnLayer(this.Layer) == this)
                    list.Add(new UnEquipEntry(from, this));
                else
                    list.Add(new EquipEntry(from, this));
            }
        }

        private class EquipEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private BaseArmor m_Item;

            public EquipEntry(Mobile from, Item item)
                : base(6163, -1)
            {
                m_From = (Mobile)from;
                m_Item = (BaseArmor)item;
            }

            public override void OnClick()
            {
                Item[] candidates = m_From.Backpack.FindItemsByType(m_Item.GetType());
                Boolean found = false;
                foreach(Item i in candidates)
                {
                    if (m_Item == i) found = true;
                }
                if (!found)
                {
                    m_From.SendMessage("L'objet doit être dans votre sac pour que vous l'équipiez.");
                    return;
                }
                if (((BaseArmor)m_Item).CanEquip(m_From))
                {
                    if (!(m_From.EquipItem(m_Item)))
                        m_From.SendMessage("Vous ne parvenez pas a equiper cet objet.");
                }
                else
                {
                    m_From.SendMessage("Vous ne pouvez pas equiper cet objet !");
                }
            }
        }

        private class UnEquipEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private BaseArmor m_Item;

            public UnEquipEntry(Mobile from, Item item)
                : base(6164, -1)
            {
                m_From = (Mobile)from;
                m_Item = (BaseArmor)item;
            }

            public override void OnClick()
            {
                m_From.PlaceInBackpack(m_Item);
                //m_From.EquipItem(m_Item);
            }
        }

        public BaseWearable(Serial serial)
            : base(serial)
        {
        }

        public BaseWearable(int itemID)
            : base(itemID)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); //version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
