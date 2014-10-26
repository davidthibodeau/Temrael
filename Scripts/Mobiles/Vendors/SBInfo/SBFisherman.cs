using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBFisherman : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBFisherman() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
                Add(new GenericBuyInfo("Truite", typeof(TruiteFish), 3, 20, 0x09CC, 0));
				//TODO: Add( new GenericBuyInfo( typeof( SmallFish ), 3, 20, 0xDD6, 0 ) );
				//TODO: Add( new GenericBuyInfo( typeof( SmallFish ), 3, 20, 0xDD7, 0 ) );
				Add( new GenericBuyInfo( "Cane à Peche", typeof( FishingPole ), 20, 20, 0xDC0, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{
                Add(typeof(TruiteFish), 1);
                Add(typeof(DoreFish), 5);
                Add(typeof(CarpeFish), 5);
                Add(typeof(AnguilleFish), 5);
                Add(typeof(EsturgeonFish), 6);
                Add(typeof(BrochetFish), 2);
                Add(typeof(SardineFish), 3);
                //Add(typeof(AnchoieFish), 2);
                Add(typeof(MorueFish), 6);
                Add(typeof(HarengFish), 6);
                Add(typeof(FletanFish), 6);
                Add(typeof(MaquereauFish), 5);
                Add(typeof(SoleFish), 3);
                Add(typeof(ThonFish), 2);
                Add(typeof(SaumonFish), 1);
                Add(typeof(GrandBrochetFish), 8);
                Add(typeof(TruiteSauvageFish), 5);
                Add(typeof(GrandDoreFish), 8);
                Add(typeof(TruiteMerFish), 3);
                Add(typeof(EsturgeonMerFish), 7);
                Add(typeof(GrandSaumonFish), 7);
                Add(typeof(RaieFish), 4);
                Add(typeof(EspadonFish), 6);
                Add(typeof(RequinGrisFish), 6);
                Add(typeof(RequinBlancFish), 8);
                Add(typeof(HuitreFish), 1);
                Add(typeof(CalmarFish), 4);
                Add(typeof(PieuvreFish), 3);
				//TODO: Add( typeof( SmallFish ), 1 );
				Add( typeof( FishingPole ), 7 );
			} 
		} 
	} 
}