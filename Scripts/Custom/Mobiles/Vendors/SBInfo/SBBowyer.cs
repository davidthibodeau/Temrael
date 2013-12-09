using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBBowyer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBowyer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( FletcherTools ), 6, 20, 0x1022, 0 ) );

                Add(new GenericBuyInfo("Fleche", typeof(Arrow), 2, 20, 0xF3F, 0));
                Add(new GenericBuyInfo("Carreau", typeof(Bolt), 5, 20, 0x1BFB, 0));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( FletcherTools ), 1 );
                //Add(typeof(Feather), 1);
			}
		}
	}
}