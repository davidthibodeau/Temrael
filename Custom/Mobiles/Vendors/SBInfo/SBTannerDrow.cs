using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    public class SBTannerDrow : SBInfo
    {
        private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private IShopSellInfo m_SellInfo = new InternalSellInfo();

        public SBTannerDrow()
        {
        }

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

        public class InternalBuyInfo : List<GenericBuyInfo>
        {
            public InternalBuyInfo()
            {
                /*Add( new GenericBuyInfo( "Gorget de Cuir", typeof( LeatherGorget ), 20, 20, 0x13C7, 0 ) );
                Add( new GenericBuyInfo( "Casque de Cuir", typeof( LeatherCap ), 15, 20, 0x1DB9, 0 ) );
                Add( new GenericBuyInfo( "Brassards de Cuir", typeof( LeatherArms ), 30, 20, 0x13CD, 0 ) );
                Add( new GenericBuyInfo( "Plastron de Cuir", typeof( LeatherChest ), 45, 20, 0x13CC, 0 ) );
                Add( new GenericBuyInfo( "Jambières de Cuir", typeof( LeatherLegs ), 38, 20, 0x13CB, 0 ) );
                Add( new GenericBuyInfo( "Gants de Cuir", typeof( LeatherGloves ), 18, 20, 0x13C6, 0 ) );

                Add( new GenericBuyInfo( "Gorget de Cuir Clouté", typeof( StuddedGorget ), 40, 20, 0x13D6, 0 ) );
                Add( new GenericBuyInfo( "Brassards de Cuir Clouté", typeof( StuddedArms ), 50, 20, 0x13DC, 0 ) );
                Add( new GenericBuyInfo( "Plastron de Cuir Clouté", typeof( StuddedChest ), 75, 20, 0x13DB, 0 ) );
                Add( new GenericBuyInfo( "Jambières de Cuir Clouté", typeof( StuddedLegs ), 65, 20, 0x13DA, 0 ) );
                Add( new GenericBuyInfo( "Gants de Cuir Clouté", typeof( StuddedGloves ), 35, 20, 0x13D5, 0 ) );

                Add( new GenericBuyInfo( "Plastron Féminin de Cuir Clouté", typeof( FemaleStuddedChest ), 60, 20, 0x1C02, 0 ) );
                //Add( new GenericBuyInfo( typeof( FemalePlateChest ), 207, 20, 0x1C04, 0 ) );
                Add( new GenericBuyInfo( "Plastron Féminin de Cuir", typeof( FemaleLeatherChest ), 35, 20, 0x1C06, 0 ) );
                Add( new GenericBuyInfo( "Jupe de Cuir Clouté", typeof( LeatherShorts ), 28, 20, 0x1C00, 0 ) );
                Add( new GenericBuyInfo( "Jupe de Cuir", typeof( LeatherSkirt ), 25, 20, 0x1C08, 0 ) );
                Add( new GenericBuyInfo( "Buste de Cuir", typeof( LeatherBustierArms ), 25, 20, 0x1C0A, 0 ) );
                Add( new GenericBuyInfo( "Cuirasse de Cuir", typeof( LeatherBustierArms ), 30, 20, 0x1C0B, 0 ) );
                Add( new GenericBuyInfo( "Buste de Cuir Clouté", typeof( StuddedBustierArms ), 40, 20, 0x1C0C, 0 ) );
                Add( new GenericBuyInfo( "Cuirasse de Cuir Clouté", typeof( StuddedBustierArms ), 45, 20, 0x1C0D, 0 ) );*/

                Add(new GenericBuyInfo("Bouclier de Cuir", typeof(BouclierCuir), 20, 20, 0x2A41, 0));

                Add(new GenericBuyInfo("Sac", typeof(Bag), 6, 20, 0xE76, 0));
                Add(new GenericBuyInfo("Bourse", typeof(Pouch), 8, 20, 0xE79, 0));
                Add(new GenericBuyInfo("Sac à dos", typeof(Backpack), 15, 20, 0x9B2, 0));

                Add(new GenericBuyInfo("Cuir", typeof(Leather), 12, 20, 0x1081, 0));

                //Add( new GenericBuyInfo( typeof( SkinningKnife ), 10, 20, 0xEC4, 0 ) );

                //Add( new GenericBuyInfo( "1041279", typeof( TaxidermyKit ), 100000, 20, 0x1EBA, 0 ) );
            }
        }

        public class InternalSellInfo : GenericSellInfo
        {
            public InternalSellInfo()
            {
                Add(typeof(Bag), 3);
                Add(typeof(Pouch), 3);
                Add(typeof(Backpack), 7);

                Add(typeof(Leather), 5);

                Add(typeof(SkinningKnife), 7);

                Add(typeof(LeatherArms), 18);
                Add(typeof(LeatherChest), 23);
                Add(typeof(LeatherGloves), 15);
                Add(typeof(LeatherGorget), 15);
                Add(typeof(LeatherLegs), 18);
                Add(typeof(LeatherCap), 5);

                Add(typeof(StuddedArms), 43);
                Add(typeof(StuddedChest), 37);
                Add(typeof(StuddedGloves), 39);
                Add(typeof(StuddedGorget), 22);
                Add(typeof(StuddedLegs), 33);

                Add(typeof(FemaleStuddedChest), 31);
                Add(typeof(StuddedBustierArms), 23);
                Add(typeof(FemalePlateChest), 103);
                Add(typeof(FemaleLeatherChest), 18);
                Add(typeof(LeatherBustierArms), 12);
                Add(typeof(LeatherShorts), 14);
                Add(typeof(LeatherSkirt), 12);
            }
        }
    }
}