using System;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using System.Reflection;
using System.Collections;
using Server;
using Server.Items;
using System.Collections.Generic;


namespace Server.Items
{
    public class NPCstatue : Item
    {
        private Mobile m_Store;
        private int m_activate;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Store
        {
            get { return m_Store; }
            set { m_Store = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int activate
        {
            get { return m_activate; }
            set { m_activate = value; }
        }

        public static Layer[] m_ItemLayers =
            {
                Layer.FirstValid,
                Layer.TwoHanded,
                Layer.Shoes,
                Layer.Pants,
             Layer.Shirt,
                Layer.Helm,
                Layer.Gloves,
                Layer.Ring,
                Layer.Neck,
                Layer.Hair,
             Layer.Waist,
                Layer.InnerTorso,
                Layer.Bracelet,
                Layer.FacialHair,
                Layer.MiddleTorso,
             Layer.Earrings,
                Layer.Arms,
                Layer.Cloak,
                Layer.OuterTorso,
                Layer.OuterLegs,
                Layer.Mount
            };

        private static string[] m_PropsToNotChange = new string[]
            {
            "AccessLevel",
            "Account",
            "Possess",
            "PossessStorage",
            "Location",
            "NetState",
            "Map",
            "Location",
            "X",
            "Y",
            "Z",
            "Player",
            };

        [Constructable]
        public NPCstatue()
            : base(0x139A)
        {
            Weight = 1.0;
            activate = 0;
        }

        public NPCstatue(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
            writer.Write((Mobile)m_Store);
            writer.Write((int)m_activate); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Store = reader.ReadMobile();
            m_activate = reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.AccessLevel < AccessLevel.GameMaster)
            {
                from.SendMessage("Vous ne pouvez utiliser cela.");
                Misc.AbuseLogging.WriteLine(from, 
                    String.Format("Ce joueur utilise la npcstatue au serial {0}.", this.Serial));
                return;
            }

            TMobile from2 = from as TMobile;

            if (this.activate == 0)
            {
                from.SendMessage("Veuillez choisir un NPC");
                from.Target = new InternalTarget(this);
            }
            else
            {
                CleanupEquipItems(from2);
                CopySkills(this.Store, from2);
                CopyProps(this.Store, from2);
                CopyEquipItems(this.Store, from2);

                from2.Hits = from2.HitsMax;

                from2.Frozen = false;
                from2.CantWalk = false;
                from2.Paralyzed = false;
            }

        }

        public static bool ToChange(string prop)
        {
            for (int i = 0; i < m_PropsToNotChange.Length; ++i)
                if (m_PropsToNotChange[i] == prop)
                    return false;

            return true;
        }

        public static void CleanupEquipItems(Mobile from)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i < m_PossessItems.Count; i++)
                {
                    Item item = m_PossessItems[i] as Item;
                    if (Array.IndexOf(m_ItemLayers, item.Layer) != -1)
                    {
                        item.Delete();
                    }
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }
        }


        public static void CopyProps(Item dest, Item src)
        {
            try
            {
                PropertyInfo[] props = src.GetType().GetProperties();

                for (int i = 0; i < props.Length; i++)
                {
                    if (props[i].CanRead && props[i].CanWrite)
                    {
                        props[i].SetValue(dest, props[i].GetValue(src, null), null);
                    }
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }
        }
        public static void CopyProps(Mobile from, Mobile to)
        {
            try
            {
                PropertyInfo[] props = from.GetType().GetProperties();

                for (int i = 0; i < props.Length; i++)
                {
                    try
                    {
                        if (ToChange(props[i].Name))
                        {
                            if (props[i].CanRead && props[i].CanWrite)
                            {
                                props[i].SetValue(to, props[i].GetValue(from, null), null);
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }

            if (from is TMobile && to is BaseVendor)
                ((BaseVendor)to).Race = ((TMobile)from).Race;
            else if (from is BaseVendor && to is TMobile)
                ((TMobile)to).Race = ((BaseVendor)from).Race;
        }



        public static void CopySkills(Mobile from, Mobile to)
        {
            try
            {
                for (int i = 0; i < from.Skills.Length; i++)
                {
                    to.Skills[i].Base = from.Skills[i].Base;
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }
        }

        public static Item CopyItem(Item copy)
        {
            try
            {
                Type t = copy.GetType();

                ConstructorInfo c = t.GetConstructor(Type.EmptyTypes);

                if (c != null)
                {
                    object o = c.Invoke(null);

                    if (o != null && o is Item)
                    {
                        Item newItem = (Item)o;
                        CopyProps(newItem, copy);

                        if (copy is Container && newItem is Container)
                        {
                            Container newContainer = copy as Container;
                            List<Item> items = copy.Items;

                            newItem.Items.Clear();
                            /*newItem.SetTotalGold(0);
                            newItem.SetTotalItems(0);
                            newItem.SetTotalWeight(0);*/

                            for (int j = 0; j < items.Count; ++j)
                            {
                                Item item = items[j] as Item;
                                Item it = CopyItem(item);

                                if (it != null)
                                    newItem.AddItem(it);
                            }
                        }

                        newItem.Parent = null;

                        return newItem;
                    }
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }

            return null;
        }

        public static void CopyEquipItems(Mobile from, Mobile to)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i < m_PossessItems.Count; i++)
                {

                    Item copy = m_PossessItems[i] as Item;

                    if (Array.IndexOf(m_ItemLayers, copy.Layer) != -1)
                    {
                        Item newItem = CopyItem(copy);

                        if (newItem != null)
                            to.EquipItem(newItem);
                    }

                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }
        }





        private class InternalTarget : Target
        {
            private NPCstatue m_Item;

            public InternalTarget(NPCstatue item)
                : base(-1, false, TargetFlags.None)
            {
                m_Item = item;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile)
                {
                    try
                    {
                        Mobile origo = targeted as Mobile;
                        m_Item.Store = new Mobile();

                        CleanupEquipItems(m_Item.Store);
                        CopySkills(origo, m_Item.Store);
                        CopyProps(origo, m_Item.Store);
                        CopyEquipItems(origo, m_Item.Store);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Possess: CopyItem Exception: {0}", ex.Message);
                    }

                    from.SendMessage("La statue est maintenant active");
                    m_Item.activate = 1;
                }
                else
                {
                    from.SendMessage("Vous devez choisir un PNJ.");
                }
            }
        }
    }
}