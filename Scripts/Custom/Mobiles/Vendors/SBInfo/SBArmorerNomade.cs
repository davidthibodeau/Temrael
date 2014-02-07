using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBArmorerNomade : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBArmorerNomade()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo(typeof(FerIngot), 10, 16, 0x1BF2, 0));
                Add(new GenericBuyInfo(typeof(SmithHammer), 20, 14, 0x13E3, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Tongs), 1);
                Add(typeof(FerIngot), 1);
                Add(typeof(SmithHammer), 2);
            }
        }
    }
}