using System;
using System.Reflection;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Commands;
using System.Collections.Generic;

namespace Server
{
    public class Possess
    {
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

        public static void Initialize()
        {
            CommandSystem.Register("Possess", AccessLevel.GameMaster, new CommandEventHandler(Possess_OnCommand));
            CommandSystem.Register("Unpossess", AccessLevel.GameMaster, new CommandEventHandler(UnPossess_OnCommand));

            CommandSystem.Register("CopyGm", AccessLevel.GameMaster, new CommandEventHandler(CopyGm_OnCommand));
            CommandSystem.Register("CloneNPC", AccessLevel.GameMaster, new CommandEventHandler(CloneNPC_OnCommand));
            CommandSystem.Register("CopyNPC", AccessLevel.GameMaster, new CommandEventHandler(CopyNPC_OnCommand));
        }

        public static bool ToChange(string prop)
        {
            for (int i = 0; i < m_PropsToNotChange.Length; ++i)
                if (m_PropsToNotChange[i] == prop)
                    return false;

            return true;
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
                Console.WriteLine("Possess: CopyProps (Mobile) Exception: {0}", e.Message);
            }

            if (from is TMobile && to is BaseVendor)
                ((BaseVendor)to).Race = ((TMobile)from).Race;
            else if (from is BaseVendor && to is TMobile)
                ((TMobile)to).Race = ((BaseVendor)from).Race;
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
                Console.WriteLine("Possess: CopyProps (Item) Exception: {0}", e.Message);
            }
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

        public static void MoveItems(Mobile from, Mobile to)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i <= m_PossessItems.Count; i++)
                {
                    Item item = m_PossessItems[i] as Item;

                    if (Array.IndexOf(m_ItemLayers, item.Layer) != -1)
                    {
                        to.EquipItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }
        }

        public static void CopyItems(Mobile from, Mobile to)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i <= m_PossessItems.Count; i++)
                {
                    Item copy = m_PossessItems[i] as Item;
                    Item newItem = CopyItem(copy);

                    if (newItem != null)
                        to.EquipItem(newItem);
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

                for (int i = 0; i <= m_PossessItems.Count; i++)
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



        public static void CleanupItems(Mobile from)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i <= m_PossessItems.Count; i++)
                {
                    Item item = m_PossessItems[i] as Item;
                    item.Delete();
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
            }
        }

        public static void CleanupEquipItems(Mobile from)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i <= m_PossessItems.Count; i++)
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

        public static void CleanupDeathtoge(Mobile from)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i <= m_PossessItems.Count; i++)
                {
                    Item item = m_PossessItems[i] as Item;
                    if (item.ItemID == 7939)
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

        private class PossessTarget : Target
        {
            public PossessTarget()
                : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from_mob, object o)
            {
                try
                {
                    TMobile from = from_mob as TMobile;
                    if (o is Mobile)
                    {
                        Mobile m = o as Mobile;

                        if (m.Account != null)
                        {
                            from.SendMessage("Vous ne pouvez posséder un autre joueur.");
                            return;
                        }

                        if (from.Possess != null)
                        {
                            from.SendMessage("Vous posseder deja une creature");
                            return;
                        }

                        from.PossessStorage = (Mobile)Activator.CreateInstance(from.GetType());

                        from.Possess = m;

                        CopySkills(from, from.PossessStorage);
                        CopyProps(from, from.PossessStorage);
                        MoveItems(from, from.PossessStorage);

                        from.Location = from.Possess.Location;
                        from.Direction = from.Possess.Direction;
                        from.Map = from.Possess.Map;

                        CopySkills(from.Possess, from);
                        CopyProps(from.Possess, from);
                        CopyItems(from.Possess, from);

                        from.Hits = from.HitsMax;

                        from.Possess.Frozen = true;
                        from.Possess.Map = Map.Internal;

                        from.Frozen = false;
                        from.CantWalk = false;
                    }
                }
                catch (Exception e)
                {
                    Misc.ExceptionLogging.WriteLine(e, new System.Diagnostics.StackTrace(true));
                }
            }
        }



        private class CloneTarget : Target
        {
            public CloneTarget()
                : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from_mob, object o)
            {
                try
                {
                    TMobile from = from_mob as TMobile;
                    Mobile origo = o as Mobile;

                    if (from == null)
                    {
                        from.SendMessage("Vous devez être de forme MJ pour exécuter cette commande.");
                        return;
                    }

                    Mobile copy = (Mobile)Activator.CreateInstance(o.GetType());
                    CleanupItems(copy);

                    if (o is BaseVendor)
                    {
                        copy = new Mobile();
                    }

                    CopySkills(origo, copy);
                    CopyProps(origo, copy);
                    CopyItems(origo, copy);

                    copy.Location = from.Location;
                    copy.Map = from.Map;
                }
                catch (Exception ex)
                {
                    Misc.ExceptionLogging.WriteLine(ex, new System.Diagnostics.StackTrace(true));
                }
            }
        }

        private class CopyTarget : Target
        {
            public CopyTarget()
                : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from_mob, object o)
            {
                try
                {
                    TMobile from = from_mob as TMobile;
                    Mobile origo = o as Mobile;

                    if (from == null)
                    {
                        from.SendMessage("Vous devez être de forme MJ pour exécuter cette commande.");
                        return;
                    }
                    CleanupEquipItems(from);
                    CopySkills(origo, from);
                    CopyProps(origo, from);
                    CopyEquipItems(origo, from);

                    from.Hits = from.HitsMax;

                    from.Frozen = false;
                    from.CantWalk = false;
                    from.Paralyzed = false;
                }
                catch (Exception ex)
                {
                    Misc.ExceptionLogging.WriteLine(ex, new System.Diagnostics.StackTrace(true));
                }
            }
        }




        [Usage("Possess")]
        [Description("Permet à un maitre de jeu de posséder un npc.")]
        private static void Possess_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new PossessTarget();
        }

        [Usage("Unpossess")]
        [Description("Permet à un maitre de jeu de déposséder un npc.")]
        private static void UnPossess_OnCommand(CommandEventArgs e)
        {
            try
            {

                TMobile from = e.Mobile as TMobile;

                if (from.PossessStorage == null)
                {
                    from.SendMessage("Vous ne possédez aucun mobile.");
                    return;
                }

                from.Possess.Location = from.Location;
                from.Possess.Direction = from.Direction;
                from.Possess.Map = from.Map;
                from.Possess.Frozen = false;

                CleanupEquipItems(from);

                CopySkills(from.PossessStorage, from);
                CopyProps(from.PossessStorage, from);
                MoveItems(from.PossessStorage, from);

                from.Hits = from.HitsMax;
                from.Possess.Hits = from.Possess.HitsMax;

                from.PossessStorage.Delete();
                from.PossessStorage = null;
                from.Possess = null;
                from.Hidden = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Possess: CopyItem Exception: {0}", ex.Message);
            }
        }

        [Usage("CopyGm")]
        [Description("Permet à un maitre de jeu de créer un double de lui-même, mais en 'stone'.")]
        private static void CopyGm_OnCommand(CommandEventArgs e)
        {
            try
            {
                TMobile from = e.Mobile as TMobile;

                if (from == null)
                {
                    from.SendMessage("Vous devez être de forme MJ pour exécuter cette commande.");
                    return;
                }

                TMobile copy = new TMobile();

                CopySkills(from, copy);
                CopyProps(from, copy);
                CopyItems(from, copy);

                copy.Location = from.Location;
                copy.Map = from.Map;
                copy.LogoutLocation = copy.Location;
                copy.LogoutMap = copy.Map;

                copy.Direction = Direction.Down;
                copy.Frozen = false;
                copy.CantWalk = true;
                copy.Blessed = true;
                copy.Hidden = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Possess: CopyItem Exception: {0}", ex.Message);
            }
        }

        [Usage("CloneNPC")]
        [Description("Permet à un maitre de jeu de créer un double d'un NPC sur sa position")]
        private static void CloneNPC_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new CloneTarget();
        }

        [Usage("CopyNPC")]
        [Description("Permet à un maitre de jeu de se transformer en NPC choisit")]
        private static void CopyNPC_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new CopyTarget();
        }

    }
}