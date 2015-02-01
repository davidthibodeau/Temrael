using System;
using System.Reflection;
using System.Collections;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Commands;
using System.Collections.Generic;
using Server.Network;

namespace Server.Engines.Possess
{
    public class Possess
    {
        private Mobile mobile;
        private Mobile possessed;
        private Mobile stored;

        public Possess(Mobile m)
        {
            mobile = m;
        }

        public Possess(Mobile m, GenericReader reader)
        {
            mobile = m;
            possessed = reader.ReadMobile();
            stored = reader.ReadMobile();
        }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(possessed);
            writer.Write(stored);
        }

        public bool OnBeforeDeath()
        {
            if (stored == null)
                return true;

            CopySkills(mobile, possessed);
            CopyProps(mobile, possessed);
            MoveItems(mobile, possessed);

            possessed.Location = mobile.Location;
            possessed.Direction = mobile.Direction;
            possessed.Map = mobile.Map;
            possessed.Frozen = false;

            CopySkills(stored, mobile);
            CopyProps(stored, mobile);
            MoveItems(stored, mobile);

            stored.Delete();
            stored = null;
            possessed.Kill();
            possessed = null;
            mobile.Hidden = true;
            return false;
        }

        public void PossessMobile(Mobile target)
        {
            if (possessed != null)
            {
                mobile.SendMessage("Vous posseder deja une creature");
                return;
            }

            stored = (Mobile)Activator.CreateInstance(mobile.GetType());

            possessed = target;

            CopySkills(mobile, stored);
            CopyProps(mobile, stored);
            MoveItems(mobile, stored);

            mobile.Location = possessed.Location;
            mobile.Direction = possessed.Direction;
            mobile.Map = possessed.Map;

            CopySkills(possessed, mobile);
            CopyProps(possessed, mobile);
            CopyItems(possessed, mobile);

            mobile.Hits = mobile.HitsMax;

            possessed.Frozen = true;
            possessed.Map = Map.Internal;

            mobile.Frozen = false;
            mobile.CantWalk = false;
        }

        public void UnpossessMobile()
        {
            if (stored == null)
            {
                mobile.SendMessage("Vous ne possédez aucun mobile.");
                return;
            }

            possessed.Location = mobile.Location;
            possessed.Direction = mobile.Direction;
            possessed.Map = mobile.Map;
            possessed.Frozen = false;

            CleanupEquipItems(mobile);

            CopySkills(stored, mobile);
            CopyProps(stored, mobile);
            MoveItems(stored, mobile);

            mobile.Hits = mobile.HitsMax;
            possessed.Hits = possessed.HitsMax;

            stored.Delete();
            stored = null;
            possessed = null;
            mobile.Hidden = true;
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
                "Identities",
                "HideAdmin",
            };

        public static void Initialize()
        {
            CommandSystem.Register("Possess", AccessLevel.Batisseur, new CommandEventHandler(Possess_OnCommand));
            CommandSystem.Register("Unpossess", AccessLevel.Batisseur, new CommandEventHandler(UnPossess_OnCommand));

            CommandSystem.Register("CopyGm", AccessLevel.Batisseur, new CommandEventHandler(CopyGm_OnCommand));
            CommandSystem.Register("CloneNPC", AccessLevel.Batisseur, new CommandEventHandler(CloneNPC_OnCommand));
            CommandSystem.Register("CopyNPC", AccessLevel.Batisseur, new CommandEventHandler(CopyNPC_OnCommand));

            //CommandSystem.Register("testPossess", AccessLevel.Batisseur, new CommandEventHandler(TestPossess_OnCommand));
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
                Misc.ExceptionLogging.WriteLine(e);
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
                Console.WriteLine("Possess: CopyProps (Item) Exception: {0}", e.Message);
                Misc.ExceptionLogging.WriteLine(e);
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
                Misc.ExceptionLogging.WriteLine(e);
            }
        }

        public static void MoveItems(Mobile from, Mobile to)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i < m_PossessItems.Count; i++)
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
                Misc.ExceptionLogging.WriteLine(e);
            }
        }

        public static void CopyItems(Mobile from, Mobile to)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i < m_PossessItems.Count; i++)
                {
                    Item copy = m_PossessItems[i] as Item;
                    Item newItem = CopyItem(copy);

                    if (newItem != null)
                        to.EquipItem(newItem);
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e);
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
                Misc.ExceptionLogging.WriteLine(e);
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
                Misc.ExceptionLogging.WriteLine(e);
            }
        }



        public static void CleanupItems(Mobile from)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i < m_PossessItems.Count; i++)
                {
                    Item item = m_PossessItems[i] as Item;
                    item.Delete();
                }
            }
            catch (Exception e)
            {
                Misc.ExceptionLogging.WriteLine(e);
            }
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
                Misc.ExceptionLogging.WriteLine(e);
            }
        }

        public static void CleanupDeathtoge(Mobile from)
        {
            try
            {
                ArrayList m_PossessItems = new ArrayList(from.Items);

                for (int i = 0; i < m_PossessItems.Count; i++)
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
                Misc.ExceptionLogging.WriteLine(e);
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
                    PlayerMobile from = from_mob as PlayerMobile;
                    Mobile m = o as Mobile;
                    if (m != null)
                    {
                        if (m.Account != null)
                        {
                            from.SendMessage("Vous ne pouvez posséder un autre joueur.");
                            return;
                        }

                        from.Possess.PossessMobile(m);
                    }
                }
                catch (Exception e)
                {
                    Misc.ExceptionLogging.WriteLine(e);
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
                    PlayerMobile from = from_mob as PlayerMobile;
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
                    Misc.ExceptionLogging.WriteLine(ex);
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
                    PlayerMobile from = from_mob as PlayerMobile;
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
                    Misc.ExceptionLogging.WriteLine(ex);
                }
            }
        }

        private class TestPossessTarget : Target
        {
            public TestPossessTarget()
                : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object o)
            {
                try
                {
                    Mobile m = o as Mobile;
                    if (m is BaseCreature)
                        ((BaseCreature)m).DisableAI();
                    NetState ns = from.NetState;
                    from.CloseAllGumps();

                    ns.BlockAllPackets = true;
                    from.NetState = null;
                    m.NetState = ns;
                    ns.Mobile = m;
                    ns.BlockAllPackets = false;


                    ns.Send(new LoginConfirm(m));

                    if (m.Map != null)
                        ns.Send(new MapChange(m));

                    ns.Send(new MapPatches());

                    ns.Send(SeasonChange.Instantiate(m.GetSeason(), true));

                    ns.Send(SupportedFeatures.Instantiate(ns));

                    ns.Sequence = 0;
                    ns.Send(new MobileUpdateOld(m));
                    ns.Send(new MobileUpdateOld(m));

                    m.CheckLightLevels(true);

                    ns.Send(new MobileUpdateOld(m));

                    ns.Send(new MobileIncomingOld(m, m));
                    //ns.Send( new MobileAttributes( m ) );
                    ns.Send(new MobileStatus(m, m));
                    ns.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));

                    m.SendEverything();

                    ns.Send(SupportedFeatures.Instantiate(ns));
                    ns.Send(new MobileUpdateOld(m));
                    //ns.Send( new MobileAttributes( m ) );
                    ns.Send(new MobileStatus(m, m));
                    ns.Send(Server.Network.SetWarMode.Instantiate(m.Warmode));
                    ns.Send(new MobileIncomingOld(m, m));


                    ns.Send(LoginComplete.Instance);
                    ns.Send(new CurrentTime());
                    ns.Send(SeasonChange.Instantiate(m.GetSeason(), true));
                    ns.Send(new MapChange(m));
                    from.LogoutLocation = from.Location;
                    from.Map = Map.Internal;

                    //PacketHandlers.DoLogin(ns, origo);

                    //origo.NetState = from.NetState;
                    //from.NetState.Mobile = origo;
                    //from.InvalidateProperties();
                    //from.NetState.Flush();
                    
                    
                }
                catch (Exception ex)
                {
                    Misc.ExceptionLogging.WriteLine(ex);
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

                PlayerMobile from = e.Mobile as PlayerMobile;

                from.Possess.UnpossessMobile();
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
                PlayerMobile from = e.Mobile as PlayerMobile;

                if (from == null)
                {
                    from.SendMessage("Vous devez être de forme MJ pour exécuter cette commande.");
                    return;
                }

                PlayerMobile copy = new PlayerMobile();

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

        public static void TestPossess_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new TestPossessTarget();
        }


    }
}