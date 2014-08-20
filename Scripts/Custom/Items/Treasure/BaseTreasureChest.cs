using Server;
using Server.Items;
using Server.Network;
using System;
using System.Collections;

namespace Server.Items
{
	public abstract class BaseTreasureChest : LockableContainer
	{
        private TreasureResetTimer m_ResetTimer;

        public ArrayList m_TreasureLocations;
        private int m_Delay;
        private int m_LockLevelSeed;
        private int m_TrapLevelSeed;

        #region items
        private int m_WeaponQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int WeaponQuantity
        {
            get { return m_WeaponQuantity; }
            set { m_WeaponQuantity = value; }
        }

        private int m_ArmorQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int ArmorQuantity
        {
            get { return m_ArmorQuantity; }
            set { m_ArmorQuantity = value; }
        }

        private int m_JewelQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int JewelQuantity
        {
            get { return m_JewelQuantity; }
            set { m_JewelQuantity = value; }
        }

        private int m_ClothingQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int ClothingQuantity
        {
            get { return m_ClothingQuantity; }
            set { m_ClothingQuantity = value; }
        }

        private int m_GemQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int GemQuantity
        {
            get { return m_GemQuantity; }
            set { m_GemQuantity = value; }
        }

        private int m_RegsQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int RegsQuantity
        {
            get { return m_RegsQuantity; }
            set { m_RegsQuantity = value; }
        }

        private int m_DiversQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int DiversQuantity
        {
            get { return m_DiversQuantity; }
            set { m_DiversQuantity = value; }
        }

        private int m_GoldQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int GoldQuantity
        {
            get { return m_GoldQuantity; }
            set { m_GoldQuantity = value; }
        }

        private int m_PotionQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int PotionQuantity
        {
            get { return m_PotionQuantity; }
            set { m_PotionQuantity = value; }
        }

        private int m_ArtefactQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int ArtefactQuantity
        {
            get { return m_ArtefactQuantity; }
            set { m_ArtefactQuantity = value; }
        }

        private int m_ScrollsQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int ScrollsQuantity
        {
            get { return m_ScrollsQuantity; }
            set { m_ScrollsQuantity = value; }
        }
        #endregion

        [CommandProperty(AccessLevel.Batisseur)]
        public int Delay
        {
            get { return m_Delay; }
            set { m_Delay = value; }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int LockLevelSeed
        {
            get { return m_LockLevelSeed; }
            set { m_LockLevelSeed = value; SetLockLevel(); }
        }

        [CommandProperty(AccessLevel.Batisseur)]
        public int TrapLevelSeed
        {
            get { return m_TrapLevelSeed; }
            set { m_TrapLevelSeed = value; SetTrapLevel(); }
        }

		public BaseTreasureChest( int itemID ) : base ( itemID )
		{
			Movable = false;
            MaxLockLevel = 100;
            m_TreasureLocations = new ArrayList();
            Delay = 20;

			Key key = (Key)FindItemByType( typeof(Key) );

			if( key != null )
				key.Delete();

            Reset(true, false);
		}

		protected virtual void SetLockedName()
		{
			Name = "Un coffre au tresors barre";
		}

		protected virtual void SetUnlockedName()
		{
			Name = "Un coffre au tresors";
		}

		protected virtual void SetLockLevel()
		{
            this.RequiredSkill = this.LockLevel = LockLevelSeed;

            if(LockLevelSeed > 0)
                Locked = true;
		}

        protected virtual void SetTrapLevel()
        {
            this.TrapType = TrapType.ExplosionTrap;
            this.TrapPower = TrapLevelSeed;
        }

		private void StartResetTimer()
		{
            if (m_ResetTimer != null)
            {
                if (m_ResetTimer.Running)
                    m_ResetTimer.Stop();
            }

            m_ResetTimer = new TreasureResetTimer(this);
            m_ResetTimer.Start();
		}

        protected virtual void GenerateTreasure()
        {
            Item item = null;

            try
            {
                if (m_WeaponQuantity >= 1)
                {
                    for (int i = 0; i < m_WeaponQuantity; i++)
                    {
                        item = Loot.RandomWeapon(); 

                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Weapons: {0}", e.Message);
            }

            try
            {
                if (m_ArmorQuantity >= 1)
                {
                    for (int i = 0; i < m_ArmorQuantity; i++)
                    {
                        item = Loot.RandomArmor(); 

                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Armors: {0}", e.Message);
            }

            try
            {
                if (m_JewelQuantity >= 1)
                {
                    for (int i = 0; i < m_JewelQuantity; i++)
                    {
                        item = Loot.RandomJewelry();

                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Jewels: {0}", e.Message);
            }

            try
            {
                if (m_ClothingQuantity >= 1)
                {
                    for (int i = 0; i < m_ClothingQuantity; i++)
                    {
                        item = Loot.RandomClothing();

                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Clothing: {0} {1} {2}", e.Message, (item != null ? item.GetType().ToString() : ""), this.Location);
            }


            try
            {
                if (m_GemQuantity >= 1)
                {
                    for (int i = 0; i < m_GemQuantity; i++)
                    {
                        item = Loot.RandomGem();
                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Gems: {0}", e.Message);
            }

            try
            {
                if (m_RegsQuantity >= 1)
                {
                    for (int i = 0; i < m_RegsQuantity; i++)
                    {
                        item = Loot.RandomReagent();
                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Regs: {0}", e.Message);
            }

            try
            {
                if (m_PotionQuantity >= 1)
                {
                    for (int i = 0; i < m_PotionQuantity; i++)
                    {
                        item = Loot.RandomPotion();
                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Potions: {0}", e.Message);
            }

            try
            {
                if (m_GoldQuantity >= 1)
                {
                    item = new Gold(m_GoldQuantity + Utility.Random(1,5));
                    this.DropItem(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception PutGold: {0}", e.Message);
            }

            try
            {
                if (m_ScrollsQuantity >= 1)
                {
                    for (int i = 0; i < m_ScrollsQuantity; i++)
                    {
                        /*if (0.10 > Utility.RandomDouble())
                            item = Loot.HighScroll();
                        else
                            item = Loot.RandomScrolls();*/

                        item = Loot.RandomScroll(0, 63, SpellbookType.Regular);

                        this.DropItem(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception Scrolls: {0}", e.Message);
            }
        }

        protected virtual void GenerateLocation()
        {
            if (m_TreasureLocations == null)
                m_TreasureLocations = new ArrayList();

            if (m_TreasureLocations.Count <= 1)
                return;

            Point3D newloc = new Point3D(0, 0, 0);

            newloc = (Point3D)m_TreasureLocations[Utility.Random(0, m_TreasureLocations.Count - 1)];

            MoveToWorld(newloc, this.Map);
        }

		public override void LockPick( Mobile from )
		{
			base.LockPick( from );

			SetUnlockedName();
			StartResetTimer();
		}

		public void ClearContents()
		{
			for ( int i = Items.Count - 1; i >= 0; --i )
				if ( i < Items.Count )
					((Item)Items[i]).Delete();
		}

		public void Reset(bool timer, bool resetlocation)
		{
            try
            {
                if (m_Delay < 2)
                    m_Delay = 2;

                SetLockLevel();
                SetTrapLevel();
                SetLockedName();
                ClearContents();
                GenerateTreasure();

                if(timer)
                    StartResetTimer();

                if (resetlocation)
                    GenerateLocation();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
		}

		private class TreasureResetTimer : Timer
		{
			private BaseTreasureChest m_Chest;
			
			public TreasureResetTimer( BaseTreasureChest chest ) : base (TimeSpan.FromMinutes(chest.Delay))
			{
                m_Chest = chest;
			}

			protected override void OnTick()
			{
                m_Chest.Reset(true, true);
			}
		}

        public BaseTreasureChest(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
            writer.Write(m_Delay);
            writer.Write(m_LockLevelSeed);
            writer.Write(m_TrapLevelSeed);

            ////////////////

            writer.Write(m_WeaponQuantity);

            writer.Write(m_ArmorQuantity);

            writer.Write(m_JewelQuantity);

            writer.Write(m_ClothingQuantity);

            writer.Write(m_GemQuantity);

            writer.Write(m_RegsQuantity);
            writer.Write(m_DiversQuantity);

            writer.Write(m_GoldQuantity);

            writer.Write(m_PotionQuantity);

            writer.Write(m_ArtefactQuantity);

            writer.Write(m_ScrollsQuantity);

            //////////

            if (m_TreasureLocations == null)
                m_TreasureLocations = new ArrayList();

            writer.Write((int)m_TreasureLocations.Count);

            for (int i = 0; i < m_TreasureLocations.Count; i++)
            {
                writer.Write((Point3D)m_TreasureLocations[i]);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Delay = reader.ReadInt();
            m_LockLevelSeed = reader.ReadInt();
            m_TrapLevelSeed = reader.ReadInt();

            ////////////////

            m_WeaponQuantity = reader.ReadInt();

            m_ArmorQuantity = reader.ReadInt();

            m_JewelQuantity = reader.ReadInt();

            m_ClothingQuantity = reader.ReadInt();

            m_GemQuantity = reader.ReadInt();

            m_RegsQuantity = reader.ReadInt();

            m_DiversQuantity = reader.ReadInt();

            m_GoldQuantity = reader.ReadInt();

            m_PotionQuantity = reader.ReadInt();

            m_ArtefactQuantity = reader.ReadInt();

            m_ScrollsQuantity = reader.ReadInt();

            ////////////////

            int m_TreasureLocationsCount = reader.ReadInt();
            m_TreasureLocations = new ArrayList();

            for (int i = 0; i < m_TreasureLocationsCount; i++)
            {
                m_TreasureLocations.Add((Point3D)reader.ReadPoint3D());
            }

            Reset(true, false);
        }
	}
}