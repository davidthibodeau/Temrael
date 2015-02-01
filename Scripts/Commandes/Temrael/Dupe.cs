using System;
using System.Reflection;
using Server.Items;
using Server.Targeting;
using Server.Commands;

namespace Server.Commands
{
    public class Dupe
    {
        public static void Initialize()
        {
            CommandSystem.Register("Dupe", AccessLevel.Batisseur, new CommandEventHandler(Dupe_OnCommand));
            CommandSystem.Register("DupeInBag", AccessLevel.Batisseur, new CommandEventHandler(DupeInBag_OnCommand));
        }

        [Usage("Dupe [amount]")]
        [Description("Dupes a targeted item.")]
        private static void Dupe_OnCommand(CommandEventArgs e)
        {
            int amount = 1;
            if (e.Length >= 1)
                amount = e.GetInt32(0);
            e.Mobile.Target = new DupeTarget(false, amount > 0 ? amount : 1);
            e.Mobile.SendMessage("What do you wish to dupe?");
        }

        [Usage("DupeInBag &lt;count>")]
        [Description("Dupes an item at it's current location (count) number of times.")]
        private static void DupeInBag_OnCommand(CommandEventArgs e)
        {
            int amount = 1;
            if (e.Length >= 1)
                amount = e.GetInt32(0);

            e.Mobile.Target = new DupeTarget(true, amount > 0 ? amount : 1);
            e.Mobile.SendMessage("What do you wish to dupe?");
        }

        private class DupeTarget : Target
        {
            private bool m_InBag;
            private int m_Amount;

            public DupeTarget(bool inbag, int amount)
                : base(15, false, TargetFlags.None)
            {
                m_InBag = inbag;
                m_Amount = amount;
            }

            protected override void OnTarget(Mobile from, object targ)
            {
                bool done = false;
                if (!(targ is Item))
                {
                    from.SendMessage("You can only dupe items.");
                    return;
                }

                CommandLogging.WriteLine(from, "{0} {1} duping {2} (inBag={3}; amount={4})", from.AccessLevel, CommandLogging.Format(from), CommandLogging.Format(targ), m_InBag, m_Amount);

                Item copy = (Item)targ;
                Container pack;

                if (m_InBag)
                {
                    if (copy.Parent is Container)
                        pack = (Container)copy.Parent;
                    else if (copy.Parent is Mobile)
                        pack = ((Mobile)copy.Parent).Backpack;
                    else
                        pack = null;
                }
                else
                    pack = from.Backpack;

                from.SendMessage("Duping {0}...", m_Amount);
                for (int i = 0; i < m_Amount; i++)
                {
                    Item a = DupeItem(from, copy, true);
                    if (a == null)
                        break;

                    if (pack != null)
                        pack.DropItem(a);
                    else
                        a.MoveToWorld(from.Location, from.Map);
                    done = true;
                }

                if (done)
                    from.SendMessage("Done");
                else
                    from.SendMessage("Error!");
            }
        }

        public static Item DupeItem(Mobile from, object item, bool RecurseContainers)
        {
            Type t = item.GetType();
            object o = Construct(t);
            if (o == null)
            {
                if (from != null)
                    from.SendMessage("Unable to dupe {0}. Item must have a 0 parameter constructor.", t.Name);

                return null;
            }

            if (o is Item)
            {
                Item newItem = (Item)o;
                Item srcItem = (Item)item;
                CopyProperties(o, item, t, "Parent");

                if ((o is Container) && RecurseContainers)
                {
                    Container srcContainer = (Container)item;
                    Container newContainer = (Container)o;

                    newContainer.Items.Clear(); // if container object type adds items in its constructor, we need to remove them.
                    for (int i = 0; i < srcContainer.Items.Count; i++)
                    {
                        Item a = DupeItem(from, srcContainer.Items[i], true);

                        if (a != null)
                        {
                            newContainer.AddItem(a);
                            newContainer.UpdateTotals();
                        }
                    }
                }

                newItem.UpdateTotals();
                return newItem;
            }

            return null;
        }

        public static object Construct(Type type, params object[] constructParams)
        {
            bool constructed = false;
            object toReturn = null;
            ConstructorInfo[] info = type.GetConstructors();

            foreach (ConstructorInfo c in info)
            {
                if (constructed) break;
                ParameterInfo[] paramInfo = c.GetParameters();

                if (paramInfo.Length == constructParams.Length)
                {
                    try
                    {
                        object o = c.Invoke(constructParams);

                        if (o != null)
                        {
                            constructed = true;
                            toReturn = o;
                        }
                    }
                    catch
                    {
                        toReturn = null;
                    }
                }
            }
            return toReturn;
        }

        public static bool CompareType(object o, Type type)
        {
            if (o.GetType() == type || o.GetType().IsSubclassOf(type))
                return true;
            else
                return false;
        }

        public static void CopyProperties(object dest, object src, Type type, params string[] omitProps)
        {
            if (!CompareType(dest, type) || !CompareType(src, type) || (dest.GetType() != src.GetType()))
                return;

            PropertyInfo[] props = type.GetProperties();

            for (int i = 0; i < props.Length; i++)
            {
                try
                {
                    bool omit = false;
                    for (int j = 0; j < omitProps.Length; j++)
                        if (string.Compare(omitProps[j], props[i].Name, true) == 0)
                        {
                            omit = true;
                            break;
                        }

                    if (props[i].CanRead && props[i].CanWrite && !omit)
                    {
                        //Console.WriteLine( "Setting {0} = {1}", props.Name, props.GetValue( src, null ) );
                        props[i].SetValue(dest, props[i].GetValue(src, null), null);
                    }
                }
                catch (Exception e)
                {
                    Misc.ExceptionLogging.WriteLine(e, "item type: {0}. props that failed: {1}", dest.GetType(), props[i]);
                    //Console.WriteLine( "Denied" );
                }
            }
        }
    }
}