using System;
using System.Collections.Generic;
using Server.Items;
using Server.Multis;

namespace Server.Mobiles
{
	public class SBShipwright : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBShipwright()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Petit Navire", typeof( SmallBoatDeed ), 2000, 20, 0x14F2, 0 ) );
				Add( new GenericBuyInfo( "Petit Drakar", typeof( SmallDragonBoatDeed ), 2500, 20, 0x14F2, 0 ) );
				Add( new GenericBuyInfo( "Navire", typeof( MediumBoatDeed ), 4000, 20, 0x14F2, 0 ) );
				Add( new GenericBuyInfo( "Drakar", typeof( MediumDragonBoatDeed ), 5000, 20, 0x14F2, 0 ) );
				Add( new GenericBuyInfo( "Grand Navire", typeof( LargeBoatDeed ), 8000, 20, 0x14F2, 0 ) );
				Add( new GenericBuyInfo( "Grand Drakar", typeof( LargeDragonBoatDeed ), 10000, 20, 0x14F2, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				//You technically CAN sell them back, *BUT* the vendors do not carry enough money to buy with
			}
		}
	}
}