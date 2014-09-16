using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBCarpenterOrcish : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBCarpenterOrcish()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                Add(new GenericBuyInfo("Clous", typeof(Nails), 3, 20, 0x102E, 0));
                Add(new GenericBuyInfo("Essieu", typeof(Axle), 2, 20, 0x105B, 0));
                Add(new GenericBuyInfo("Planche", typeof(Board), 5, 20, 0x1BD7, 0));
                Add(new GenericBuyInfo("Plane", typeof(DrawKnife), 20, 20, 0x10E4, 0));
                Add(new GenericBuyInfo("Froe", typeof(Froe), 20, 20, 0x10E5, 0));
                Add(new GenericBuyInfo("Scorp", typeof(Scorp), 20, 20, 0x10E7, 0));
                Add(new GenericBuyInfo("Inshave", typeof(Inshave), 20, 20, 0x10E6, 0));
                Add(new GenericBuyInfo("Scie à queue d'aronde", typeof(DovetailSaw), 20, 20, 0x1028, 0));
                Add(new GenericBuyInfo("Scie", typeof(Saw), 20, 20, 0x1034, 0));
                Add(new GenericBuyInfo("Marteau", typeof(Hammer), 20, 20, 0x102A, 0));
                /*Add( new GenericBuyInfo( typeof( MouldingPlane ), 11, 20, 0x102C, 0 ) );
                Add( new GenericBuyInfo( typeof( SmoothingPlane ), 10, 20, 0x1032, 0 ) );
                Add( new GenericBuyInfo( typeof( JointingPlane ), 11, 20, 0x1030, 0 ) );*/
                Add(new GenericBuyInfo("Tambour", typeof(Drums), 20, 20, 0xE9C, 0));
                Add(new GenericBuyInfo("Tambourine", typeof(Tambourine), 10, 20, 0xE9D, 0));
                Add(new GenericBuyInfo("Harpe", typeof(LapHarp), 75, 20, 0xEB2, 0));
                Add(new GenericBuyInfo("Lute", typeof(Lute), 50, 20, 0xEB3, 0));

                Add(new GenericBuyInfo("Fleche", typeof(Arrow), 2, 20, 0xF3F, 0));
                Add(new GenericBuyInfo("Carreau", typeof(Bolt), 5, 20, 0x1BFB, 0));
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(WoodenBox), 7);
                Add(typeof(SmallCrate), 5);
                Add(typeof(MediumCrate), 6);
                Add(typeof(LargeCrate), 7);
                Add(typeof(WoodenChest), 15);

                Add(typeof(LargeTable), 10);
                Add(typeof(Nightstand), 7);
                Add(typeof(YewWoodTable), 10);

                Add(typeof(Throne), 24);
                Add(typeof(WoodenThrone), 6);
                Add(typeof(Stool), 6);
                Add(typeof(FootStool), 6);

                Add(typeof(FancyWoodenChairCushion), 12);
                Add(typeof(WoodenChairCushion), 10);
                Add(typeof(WoodenChair), 8);
                Add(typeof(BambooChair), 6);
                Add(typeof(WoodenBench), 6);

                Add(typeof(Saw), 9);
                Add(typeof(Scorp), 6);
                Add(typeof(SmoothingPlane), 6);
                Add(typeof(DrawKnife), 6);
                Add(typeof(Froe), 6);
                Add(typeof(Hammer), 14);
                Add(typeof(Inshave), 6);
                Add(typeof(JointingPlane), 6);
                Add(typeof(MouldingPlane), 6);
                Add(typeof(DovetailSaw), 7);
                Add(typeof(Board), 2);
                Add(typeof(Axle), 1);

                Add(typeof(Club), 13);

                Add(typeof(Lute), 10);
                Add(typeof(LapHarp), 10);
                Add(typeof(Tambourine), 10);
                Add(typeof(Drums), 10);

                Add(typeof(Log), 1);
            }
        }
    }
}
