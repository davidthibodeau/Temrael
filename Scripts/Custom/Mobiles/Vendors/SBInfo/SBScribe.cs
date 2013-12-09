using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBScribe: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBScribe()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				//Add( new GenericBuyInfo( typeof( ScribesPen ), 8,  20, 0xFBF, 0 ) );
				Add( new GenericBuyInfo( "Rouleau Vierge", typeof( BlankScroll ), 10, 999, 0x0E34, 0 ) );
				//Add( new GenericBuyInfo( typeof( ScribesPen ), 8,  20, 0xFC0, 0 ) );
				Add( new GenericBuyInfo( "Livre", typeof( BrownBook ), 25, 10, 0xFEF, 0 ) );
				Add( new GenericBuyInfo( "Livre", typeof( TanBook ), 25, 10, 0xFF0, 0 ) );
				Add( new GenericBuyInfo( "Livre", typeof( BlueBook ), 25, 10, 0xFF2, 0 ) );
				//Add( new GenericBuyInfo( "1041267", typeof( Runebook ), 3500, 10, 0xEFA, 0x461 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScribesPen ), 1 );
				Add( typeof( BrownBook ), 1 );
				Add( typeof( TanBook ), 1 );
				Add( typeof( BlueBook ), 1 );
				Add( typeof( BlankScroll ), 1 );
			}
		}
	}
}