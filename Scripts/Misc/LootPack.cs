using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Misc;

namespace Server
{
	public class LootPack
	{
		private LootPackEntry m_Entry;

		public LootPack( LootPackEntry entry )
		{
			m_Entry = entry;
		}

		public void Generate( Mobile from, Container cont )
		{
			if ( cont == null )
				return;

            Item item = m_Entry.Construct(from);

			if ( item != null )
			{
                cont.AddItem(item);
			}
		}

        #region Definitions
        private static readonly LootPackItem[] FoodTable = new LootPackItem[]
        {
            new LootPackItem( typeof (WoodenBowlOfCarrots)),
            new LootPackItem( typeof (WoodenBowlOfCorn)),
            new LootPackItem( typeof (PewterBowlOfPeas)),
            new LootPackItem( typeof (PewterBowlOfLettuce)),
            new LootPackItem( typeof (PewterBowlOfPotatos)),
            new LootPackItem( typeof (WoodenBowlOfPeas)),
            new LootPackItem( typeof (PewterBowlOfCorn)),
            new LootPackItem( typeof (WoodenBowlOfLettuce)),
            new LootPackItem( typeof (WoodenBowlOfTomatoSoup)),
            new LootPackItem( typeof (EmptyPewterBowl)),
            new LootPackItem( typeof (WoodenBowlOfStew)),
            new LootPackItem( typeof (BreadLoaf)),
            new LootPackItem( typeof (CheeseWheel)),
            new LootPackItem( typeof (LambLeg)),
            new LootPackItem( typeof (CookedBird)),
            new LootPackItem( typeof (Pitcher)),
            new LootPackItem( typeof (Ham)),
            new LootPackItem( typeof (RawLambLeg)),
            new LootPackItem( typeof (Bacon)),
            new LootPackItem( typeof (Sausage)),
            new LootPackItem( typeof (RawBird)),
            new LootPackItem( typeof (RawChickenLeg)),
            new LootPackItem( typeof (RawRibs)),
        };
        public static readonly LootPack Food = new LootPack(new LootPackEntry(false, FoodTable, 1));

        private static readonly LootPackItem[] JunkTable = new LootPackItem[]
        {
            new LootPackItem( typeof (Shaft)),
            //new LootPackItem( typeof (Bold)),
            new LootPackItem( typeof (Feather)),
            //new LootPackItem( typeof (Ore)),
            new LootPackItem( typeof (Wool)),
            new LootPackItem( typeof (Kindling)),
            new LootPackItem( typeof (Fumier)),
            new LootPackItem( typeof (Bottle)),
            new LootPackItem( typeof (Cloth)),
            new LootPackItem( typeof (FerIngot)),
            new LootPackItem( typeof (Log)),
            new LootPackItem( typeof (Board)),
            new LootPackItem( typeof (Bandage)),
            new LootPackItem( typeof (Bone)),
            new LootPackItem( typeof (Hides)),
        };
        public static readonly LootPack Junk = new LootPack(new LootPackEntry(false, JunkTable, 1));


        private static readonly LootPackItem[] UtilityItemsTable = new LootPackItem[]
        {
            new LootPackItem( typeof (Bag)),
            new LootPackItem( typeof (Candle)),
            new LootPackItem( typeof (Torch)),
            new LootPackItem( typeof (Lockpick)),
            new LootPackItem( typeof (Pouch)),
            new LootPackItem( typeof (Lantern)),
            new LootPackItem( typeof (Shovel)),
            new LootPackItem( typeof (SmithHammer)),
            new LootPackItem( typeof (Tongs)),
            new LootPackItem( typeof (SewingKit)),
            new LootPackItem( typeof (BoneLeatherSewingKit)),
            new LootPackItem( typeof (ScribesPen)),
            new LootPackItem( typeof (FletcherTools)),
            new LootPackItem( typeof (RedBook)),
        };
        public static readonly LootPack UtilityItems = new LootPack(new LootPackEntry(false, UtilityItemsTable, 1));


        private static readonly LootPackItem[] RegsTable = new LootPackItem[]
        {
            new LootPackItem( typeof (Garlic)),
            new LootPackItem( typeof (Ginseng)),
            new LootPackItem( typeof (MandrakeRoot)),
            new LootPackItem( typeof (SpidersSilk)),
            new LootPackItem( typeof (BlackPearl)),
            new LootPackItem( typeof (Bloodmoss)),
            new LootPackItem( typeof (SulfurousAsh)),
            new LootPackItem( typeof (Nightshade)),
        };
        public static readonly LootPack Regs = new LootPack(new LootPackEntry(false, RegsTable, 10));


        private static readonly LootPackItem[] NecroRegsTable = new LootPackItem[]
        {
            new LootPackItem( typeof (BatWing)),
            new LootPackItem( typeof (NoxCrystal)),
            new LootPackItem( typeof (GraveDust)),
            new LootPackItem( typeof (PigIron)),
            new LootPackItem( typeof (DaemonBlood)),
        };
        public static readonly LootPack NecroRegs = new LootPack(new LootPackEntry(false, NecroRegsTable, 10));


        private static readonly LootPackItem[] LeatherArTable = new LootPackItem[]
        {
            new LootPackItem( typeof (LeatherArms)),
            new LootPackItem( typeof (LeatherCap)),
            new LootPackItem( typeof (LeatherGloves)),
            new LootPackItem( typeof (LeatherGorget)),
            new LootPackItem( typeof (LeatherLegs)),
            new LootPackItem( typeof (LeatherChest)),
        };
        public static readonly LootPack LeatherAr = new LootPack(new LootPackEntry(false, LeatherArTable, 1));


        private static readonly LootPackItem[] RingArTable = new LootPackItem[]
        {
            new LootPackItem( typeof (RingmailArms)),
            new LootPackItem( typeof (RingmailChest)),
            new LootPackItem( typeof (RingmailGloves)),
            new LootPackItem( typeof (RingmailLegs)),
        };
        public static readonly LootPack RingAr = new LootPack(new LootPackEntry(false, RingArTable, 1));


        private static readonly LootPackItem[] ChainArTable = new LootPackItem[]
        {
            new LootPackItem( typeof (ChainLegs)),
            new LootPackItem( typeof (ChainChest)),
            new LootPackItem( typeof (MailluresGreaves)),
            new LootPackItem( typeof (ChainCoif)),
        };
        public static readonly LootPack ChainAr = new LootPack(new LootPackEntry(false, ChainArTable, 1));


        private static readonly LootPackItem[] PlateArTable = new LootPackItem[]
        {
            new LootPackItem( typeof (PlateArms) ),
            new LootPackItem( typeof (PlateChest) ),
            new LootPackItem( typeof (PlateGloves) ),
            new LootPackItem( typeof (PlateGorget) ),
            new LootPackItem( typeof (PlateHelm) ),
            new LootPackItem( typeof (PlateLegs) ),
        };
        public static readonly LootPack PlateAr = new LootPack(new LootPackEntry(false, PlateArTable, 1));

        #endregion
    }

	public class LootPackEntry
	{
		private LootPackDice m_Quantity;

		private bool m_AtSpawnTime;

		private LootPackItem[] m_Items;

		public LootPackDice Quantity
		{
			get{ return m_Quantity; }
			set{ m_Quantity = value; }
		}

		public Item Construct( Mobile from )
		{
            if (m_Items == null) // m_Items == null ?.. Wtf ?
            {
                Console.WriteLine("Wtf");
                return null;
            }

            try
            {
                int f = Utility.RandomMinMax(1, m_Items.Length)-1;

                Item i = m_Items[f].Construct();


                if (i != null)
                {
                    if (i is BaseWeapon || i is BaseArmor || i is BaseJewel || i is BaseClothing)
                    {
                        int Quality = Utility.RandomList((int)WeaponQuality.Low, (int)WeaponQuality.Regular, (int)WeaponQuality.Exceptional);
                        RareteInit.InitItem(i, Quality, from);
                    }

                    if (i.Stackable)
                        i.Amount = m_Quantity.Roll();
                }

                return i;
            }
            catch (Exception e)
            {
                ExceptionLogging.WriteLine(e);
            }

            return null;
		}

		public LootPackEntry( bool atSpawnTime, LootPackItem[] items, int quantity ) : this( atSpawnTime, items, new LootPackDice( 0, 0, quantity ))
		{
		}

		public LootPackEntry( bool atSpawnTime, LootPackItem[] items, LootPackDice quantity)
		{
			m_AtSpawnTime = atSpawnTime;
			m_Items = items;
			m_Quantity = quantity;
		}
	}

	public class LootPackItem
	{
		private Type m_Type;

		public Type Type
		{
			get{ return m_Type; }
			set{ m_Type = value; }
		}

		public Item Construct( )
		{
			try
			{
				Item item;

				if ( m_Type == typeof( BaseRanged ) )
					item = Loot.RandomRangedWeapon();
				else if ( m_Type == typeof( BaseWeapon ) )
					item = Loot.RandomWeapon();
				else if ( m_Type == typeof( BaseArmor ) )
					item = Loot.RandomArmorOrHat();
				else if ( m_Type == typeof( BaseShield ) )
					item = Loot.RandomShield();
				else if ( m_Type == typeof( BaseJewel ) )
					item = Core.AOS ? Loot.RandomJewelry() : Loot.RandomArmorOrShieldOrWeapon();
				else if ( m_Type == typeof( BaseInstrument ) )
					item = Loot.RandomInstrument();
				else if ( m_Type == typeof( Amber ) ) // gem
					item = Loot.RandomGem();
				else
					item = Activator.CreateInstance( m_Type ) as Item;

				return item;
			}
			catch (Exception e)
			{
                Misc.ExceptionLogging.WriteLine(e);
			}

			return null;
		}

		public LootPackItem( Type type )
		{
			m_Type = type;
		}
	}

	public class LootPackDice
	{
		private int m_Count, m_Sides, m_Bonus;

		public int Count
		{
			get{ return m_Count; }
			set{ m_Count = value; }
		}

		public int Sides
		{
			get{ return m_Sides; }
			set{ m_Sides = value; }
		}

		public int Bonus
		{
			get{ return m_Bonus; }
			set{ m_Bonus = value; }
		}

		public int Roll()
		{
			int v = m_Bonus;

			for ( int i = 0; i < m_Count; ++i )
				v += Utility.Random( 1, m_Sides );

			return v;
		}

		public LootPackDice( string str )
		{
			int start = 0;
			int index = str.IndexOf( 'd', start );

			if ( index < start )
				return;

			m_Count = Utility.ToInt32( str.Substring( start, index-start ) );

			bool negative;

			start = index + 1;
			index = str.IndexOf( '+', start );

			if ( negative = (index < start) )
				index = str.IndexOf( '-', start );

			if ( index < start )
				index = str.Length;

			m_Sides = Utility.ToInt32( str.Substring( start, index-start ) );

			if ( index == str.Length )
				return;

			start = index + 1;
			index = str.Length;

			m_Bonus = Utility.ToInt32( str.Substring( start, index-start ) );

			if ( negative )
				m_Bonus *= -1;
		}

		public LootPackDice( int count, int sides, int bonus )
		{
			m_Count = count;
			m_Sides = sides;
			m_Bonus = bonus;
		}
	}
}