using Server;
using Server.Items;
using Server.Network;
using System;
using System.Collections;
using Server.Commands;

namespace Server.Items
{
	public abstract class BaseTreasureChest : LockableContainer
	{
        private TreasureResetTimer m_ResetTimer;

        public ArrayList m_TreasureLocations;
        private int m_Delay;
        private int m_LockLevelSeed;

        public Container cont;

        #region items

        /*
         * Gold
         * Food
         * Junk
         * UtilityItems
         * Regs
         * NecroRegs
         * LeatherAR
         * ChainAR
         * RingAR
         * PlateAR
         * Special items
         * */


        private int m_GoldQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int GoldQuantity
        {
            get { return m_GoldQuantity; }
            set { m_GoldQuantity = value; }
        }

        private int m_FoodQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int FoodQuantity
        {
            get { return m_FoodQuantity; }
            set { m_FoodQuantity = value; }
        }

        private int m_JunkQuantity;

        [CommandProperty(AccessLevel.Batisseur)]
        public int JunkQuantity
        {
            get { return m_JunkQuantity; }
            set { m_JunkQuantity = value; }
        }

        private int m_UtilityQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int UtilityQuantity
        {
            get { return m_UtilityQuantity; }
            set { m_UtilityQuantity = value; }
        }

        private int m_RegsQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int RegsQuantity
        {
            get { return m_RegsQuantity; }
            set { m_RegsQuantity = value; }
        }

        private int m_NecroRegsQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int NecroRegsQuantity
        {
            get { return m_NecroRegsQuantity; }
            set { m_NecroRegsQuantity = value; }
        }

        private int m_ScrollsQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int ScrollsQuantity
        {
            get { return m_ScrollsQuantity; }
            set { m_ScrollsQuantity = value; }
        }

        private int m_SpecialItemsQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int SpecialItemsQuantity
        {
            get { return m_SpecialItemsQuantity; }
            set { m_SpecialItemsQuantity = value; }
        }

        private int m_LeatherARQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int LeatherARQuantity
        {
            get { return m_LeatherARQuantity; }
            set { m_LeatherARQuantity = value; }
        }

        private int m_ChainARQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int ChainARQuantity
        {
            get { return m_ChainARQuantity; }
            set { m_ChainARQuantity = value; }
        }

        private int m_RingARQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int RingARQuantity
        {
            get { return m_RingARQuantity; }
            set { m_RingARQuantity = value; }
        }

        private int m_PlateARQuantity;
        [CommandProperty(AccessLevel.Batisseur)]
        public int PlateARQuantity
        {
            get { return m_PlateARQuantity; }
            set { m_PlateARQuantity = value; }
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

		public BaseTreasureChest( int itemID ) : base ( itemID )
		{
			Movable = false;
            MaxLockLevel = 100;
            m_TreasureLocations = new ArrayList();
            Delay = 20;

			Key key = (Key)FindItemByType( typeof(Key) );

            GenBag();

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

        public void GenBag()
        {
            if (cont == null)
            {
                Bag b = new Bag();
                cont = b;
            }

            cont.Map = this.Map;
            cont.MoveToWorld(new Point3D(this.Location.X, this.Location.Y, this.Location.Z - 50));

            //cont.Visible = false;
        }

        protected virtual void GenerateTreasure()
        {
            Item item = null;

            AddLoot(LootPack.Food, m_FoodQuantity);
            AddLoot(LootPack.Junk, m_JunkQuantity);
            AddLoot(LootPack.UtilityItems, m_UtilityQuantity);
            AddLoot(LootPack.Regs, m_RegsQuantity);
            AddLoot(LootPack.NecroRegs, m_NecroRegsQuantity);
            AddLoot(LootPack.LeatherAr, m_LeatherARQuantity);
            AddLoot(LootPack.ChainAr, m_ChainARQuantity);
            AddLoot(LootPack.RingAr, m_RingARQuantity);
            AddLoot(LootPack.PlateAr, m_PlateARQuantity);
            //AddLoot(LootPack.Scrolls, m_ScrollsQuantity);

            if (m_GoldQuantity >= 1)
            {
                item = new Gold(m_GoldQuantity + Utility.Random(1, 5));
                this.DropItem(item);
            }

            if (m_SpecialItemsQuantity >= 1)
            {
                for (int i = 0; i < m_SpecialItemsQuantity; ++i)
                {
                    this.DropItem(Dupe.DupeItem(null, cont.Items[Utility.Random(0, cont.Items.Count - 1)], true));
                }
            }
        }

        private void AddLoot( LootPack lootpack, int amount)
        {
            try
            {
                if (amount >= 1)
                {
                    for (int i = 0; i < amount; ++i)
                    {
                        lootpack.Generate(this);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("TreasureChest Exception: {0}", e.Message);
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
                SetLockedName();
                GenBag();
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

            writer.Write((int)3);
            writer.Write(m_Delay);
            writer.Write(m_LockLevelSeed);

            ////////////////

            writer.Write(m_FoodQuantity);

            writer.Write(m_JunkQuantity);

            writer.Write(m_UtilityQuantity);

            writer.Write(m_RegsQuantity);

            writer.Write(m_NecroRegsQuantity);

            writer.Write(m_LeatherARQuantity);

            writer.Write(m_ChainARQuantity);

            writer.Write(m_GoldQuantity);

            writer.Write(m_RingARQuantity);

            writer.Write(m_PlateARQuantity);

            writer.Write(m_ScrollsQuantity);

            //////////

            if (m_TreasureLocations == null)
                m_TreasureLocations = new ArrayList();

            writer.Write((int)m_TreasureLocations.Count);

            for (int i = 0; i < m_TreasureLocations.Count; i++)
            {
                writer.Write((Point3D)m_TreasureLocations[i]);
            }

            writer.Write(m_SpecialItemsQuantity);

            writer.Write((Item)cont);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_Delay = reader.ReadInt();
            m_LockLevelSeed = reader.ReadInt();

            if(version == 0)
                reader.ReadInt();

            ////////////////

            m_FoodQuantity = reader.ReadInt();

            m_JunkQuantity = reader.ReadInt();

            m_UtilityQuantity = reader.ReadInt();

            m_RegsQuantity = reader.ReadInt();

            m_NecroRegsQuantity = reader.ReadInt();

            m_LeatherARQuantity = reader.ReadInt();

            m_ChainARQuantity = reader.ReadInt();

            m_GoldQuantity = reader.ReadInt();

            m_RingARQuantity = reader.ReadInt();

            m_PlateARQuantity = reader.ReadInt();

            m_ScrollsQuantity = reader.ReadInt();

            ////////////////

            int m_TreasureLocationsCount = reader.ReadInt();
            m_TreasureLocations = new ArrayList();

            for (int i = 0; i < m_TreasureLocationsCount; i++)
            {
                m_TreasureLocations.Add((Point3D)reader.ReadPoint3D());
            }

            if (version >= 2)
            {
                m_SpecialItemsQuantity = reader.ReadInt();
            }

            if (version >= 3)
            {
                cont = (Bag)reader.ReadItem();
            }

            Reset(true, false);
        }
	}
}