using System;
using System.Collections;
using System.Xml;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Targeting;
using Server.Regions;
using Server.Commands;

namespace Server.Scripts.Commands
{
	public class SetChestCommand
	{	
		public static void Initialize()
		{
            CommandSystem.Register("setchest", AccessLevel.Batisseur, new CommandEventHandler(SetChestCommand_OnCommand));
            CommandSystem.Register("resetchest", AccessLevel.Batisseur, new CommandEventHandler(ResetChestCommand_OnCommand));
        }

        [Usage("setchest")]
        [Description("Éditer un coffre à spawn random.")]
        public static void SetChestCommand_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new SetChestTarget();
        }

        [Usage("resetchest")]
        [Description("Reset un coffre à spawn random.")]
        public static void ResetChestCommand_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new ResetChestTarget();
        }
	}

    public class SetChestTarget : Target
    {
        public SetChestTarget()
            : base(-1, false, TargetFlags.None)
        {
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (targeted is BaseTreasureChest)
            {
                BaseTreasureChest targ = (BaseTreasureChest)targeted;

                from.SendGump(new SetChestInfo(targ));
                from.SendGump(new SetChestLocations(targ));
            }
            else
                from.SendMessage(256, "Il faut cliquer sur un coffre au trésor !");
        }
    }

    public class ResetChestTarget : Target
    {
        public ResetChestTarget()
            : base(-1, false, TargetFlags.None)
        {
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (targeted is BaseTreasureChest)
            {
                BaseTreasureChest targ = (BaseTreasureChest)targeted;
                targ.Reset(true, false);
            }
            else
                from.SendMessage(256, "Il faut cliquer sur un coffre au trésor !");
        }
    }
}

namespace Server.Gumps
{
    #region SetChestInfo
    public class SetChestInfo : Gump
    {
        private BaseTreasureChest m_Chest;
        private int m_StartTrapLevel;
        private int m_StartLockLevel;
        private int m_StartDelay;

        private int m_StartGold;
        private int m_StartFood;
        private int m_StartJunk;
        private int m_StartPlate;
        private int m_StartRegs;
        private int m_StartChain;
        private int m_StartNecroRegs;
        private int m_StartUtility;
        private int m_StartRingAR;
        private int m_StartSpecialItems;
        private int m_StartScrolls;

        public SetChestInfo(BaseTreasureChest Chest)
            : base(30, 30)
        {
            m_Chest = Chest;
            m_StartTrapLevel = Chest.TrapPower;
            m_StartLockLevel = Chest.LockLevel;
            m_StartDelay = Chest.Delay;

            m_StartGold = Chest.GoldQuantity;
            m_StartFood = Chest.FoodQuantity;
            m_StartJunk = Chest.JunkQuantity;
            m_StartPlate = Chest.PlateARQuantity;
            m_StartRegs = Chest.RegsQuantity;
            m_StartChain = Chest.ChainARQuantity;
            m_StartNecroRegs = Chest.NecroRegsQuantity;
            m_StartUtility = Chest.UtilityQuantity;
            m_StartRingAR = Chest.RingARQuantity;
            m_StartSpecialItems = Chest.SpecialItemsQuantity;
            m_StartScrolls = Chest.ScrollsQuantity;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddBackground(29, 20, 239, 392, 9270);
            AddBackground(39, 57, 217, 345, 3500);
            AddBackground(42, 31, 212, 26, 5120);
            AddLabel(85, 33, 50, @"Éditeur d'informations");

            AddLabel(127, 352, 0, @"Sauvegarder");
            AddButton(110, 352, 1209, 1210, 1, GumpButtonType.Reply, 0);

            AddLabel(55, 75, 0, "Lock Level : ");
            AddTextEntry(135, 75, 120, 20, 0, 1, Chest.LockLevelSeed.ToString());

            AddLabel(55, 95, 0, "Delay : ");
            AddTextEntry(135, 95, 120, 20, 0, 2, Chest.Delay.ToString());

            AddLabel(55, 115, 0, "Gold : ");
            AddTextEntry(135, 115, 120, 20, 0, 3, m_StartGold.ToString());

            AddLabel(55, 155, 0, "Food : ");
            AddTextEntry(135, 155, 120, 20, 0, 5, m_StartFood.ToString());

            AddLabel(55, 135, 0, "Junk : ");
            AddTextEntry(135, 135, 120, 20, 0, 4, m_StartJunk.ToString());

            AddLabel(55, 175, 0, "Regs : ");
            AddTextEntry(135, 175, 120, 20, 0, 6, m_StartRegs.ToString());

            AddLabel(55, 215, 0, "Utility : ");
            AddTextEntry(135, 215, 120, 20, 0, 8, m_StartUtility.ToString());

            AddLabel(55, 235, 0, "Scrolls : ");
            AddTextEntry(135, 235, 120, 20, 0, 9, m_StartScrolls.ToString());

            AddLabel(55, 195, 0, "NecroRegs : ");
            AddTextEntry(135, 195, 120, 20, 0, 7, m_StartNecroRegs.ToString());

            AddLabel(55, 255, 0, "SpecialItems : ");
            AddTextEntry(135, 255, 120, 20, 0, 10, m_StartSpecialItems.ToString());

            AddLabel(55, 275, 0, "Sac Item Speciaux");
            AddButton(135, 275, 1209, 1210, 2, GumpButtonType.Reply, 0);
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (info.ButtonID == 1)
            {
                #region entries
                TextRelay entry;
                string text;

                try
                {
                    entry = info.GetTextEntry(1);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.LockLevelSeed = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.LockLevelSeed = m_StartLockLevel;
                }

                try
                {
                    entry = info.GetTextEntry(2);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.Delay = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.Delay = m_StartDelay;
                }

                try
                {
                    entry = info.GetTextEntry(3);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.GoldQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.GoldQuantity = m_StartGold;
                }

                try
                {
                    entry = info.GetTextEntry(4);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.FoodQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.FoodQuantity = m_StartFood;
                }

                try
                {
                    entry = info.GetTextEntry(5);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.JunkQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.JunkQuantity = m_StartJunk;
                }

                try
                {
                    entry = info.GetTextEntry(6);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.RegsQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.RegsQuantity = m_StartRegs;
                }

                try
                {
                    entry = info.GetTextEntry(7);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.UtilityQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.UtilityQuantity = m_StartUtility;
                }


                try
                {
                    entry = info.GetTextEntry(8);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.ScrollsQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.ScrollsQuantity = m_StartScrolls;
                }


                try
                {
                    entry = info.GetTextEntry(9);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.NecroRegsQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.NecroRegsQuantity = m_StartNecroRegs;
                }


                try
                {
                    entry = info.GetTextEntry(10);
                    text = (entry == null ? "" : entry.Text.Trim());
                    m_Chest.SpecialItemsQuantity = Convert.ToInt32(Utility.FixHtml(text));
                }
                catch
                {
                    m_Chest.SpecialItemsQuantity = m_StartSpecialItems;
                }
#endregion

                from.CloseGump(typeof(SetChestInfo));
                from.CloseGump(typeof(SetChestLocations));

                m_Chest.Reset(true, false);
            }

            if (info.ButtonID == 0)
            {
                from.CloseGump(typeof(SetChestInfo));
                from.CloseGump(typeof(SetChestLocations));
            }

            if (info.ButtonID == 2)
            {
                m_Chest.GenBag();
                m_Chest.cont.DisplayTo(from);
            }
        }
    }
    #endregion

    #region SetChestLocations
    public class SetChestLocations : Gump
    {
        private BaseTreasureChest m_Chest;

        public SetChestLocations(BaseTreasureChest Chest)
            : base(550, 30)
        {
            m_Chest = Chest;

            Closable = false;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);
            AddBackground(29, 20, 239, 369, 9270);
            AddAlphaRegion(40, 30, 216, 347);
            AddBackground(42, 31, 212, 26, 5120);
            AddLabel(80, 34, 50, @"Éditeur de locations");

            AddLabel(132, 355, 2052, @"Ajouter");
            AddButton(110, 359, 1209, 1210, 1, GumpButtonType.Reply, 0);

            if (m_Chest.m_TreasureLocations == null)
                m_Chest.m_TreasureLocations = new ArrayList();

            try
            {
                for (int i = 0; i < m_Chest.m_TreasureLocations.Count; i++)
                {
                    Point3D point = (Point3D)m_Chest.m_TreasureLocations[i];

                    int index = i % 15;

                    if (index == 0)
                    {
                        if (i > 0)
                        {
                            AddButton(234, 360, 2224, 2224, 0, GumpButtonType.Page, i / 15 + 1);
                        }

                        AddPage(i / 15 + 1);

                        if (i > 0)
                        {
                            AddButton(44, 360, 2223, 2223, 0, GumpButtonType.Page, i / 15);
                        }
                    }

                    AddButton(49, 64 + (index * 20), 2223, 2223, i + 2, GumpButtonType.Reply, 0);
                    AddLabel(69, 60 + (index * 20), 2052, point.ToString());
                }
            }
            catch
            {
            }
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (info.ButtonID != 0)
            {
                if (info.ButtonID == 1)
                {
                    from.CloseGump(typeof(SetChestLocations));
                    from.Target = new AddChestLocationTarget(m_Chest);
                }
                else if (info.ButtonID >= 2)
                {
                    Point3D point = (Point3D)m_Chest.m_TreasureLocations[info.ButtonID - 2];
                    m_Chest.m_TreasureLocations.Remove(point);

                    from.CloseGump(typeof(SetChestLocations));
                    from.SendGump(new SetChestLocations(m_Chest));
                }
            }
        }
    }

    public class AddChestLocationTarget : Target
    {
        private BaseTreasureChest m_Chest;

        public AddChestLocationTarget(BaseTreasureChest Chest)
            : base(-1, true, TargetFlags.None)
        {
            m_Chest = Chest;
        }

        protected override void OnTarget(Mobile from, object targeted)
        {
            if (targeted is IPoint3D)
            {
                IPoint3D p = (IPoint3D)targeted;
                Point3D point = new Point3D(p.X, p.Y, p.Z);

                if (m_Chest.m_TreasureLocations.Contains(point))
                {
                    from.SendMessage("La liste contient déjà cette location.");
                    from.SendGump(new SetChestLocations(m_Chest));
                    return;
                }

                m_Chest.m_TreasureLocations.Add(point);

                from.SendGump(new SetChestLocations(m_Chest));
            }
            else
            {
                from.SendGump(new SetChestLocations(m_Chest));
                from.SendMessage("Ciblez une location !");
            }
        }

        protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
        {
            from.SendGump(new SetChestLocations(m_Chest));
        }
    }
    #endregion
}
