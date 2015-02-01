using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBButcher : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBButcher() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( "Bacon", typeof( Bacon ), 4, 20, 0x979, 0 ) );
				Add( new GenericBuyInfo( "Jambon", typeof( Ham ), 5, 20, 0x9C9, 0 ) ); 
				Add( new GenericBuyInfo( "Saucisse", typeof( Sausage ), 4, 20, 0x9C0, 0 ) );
				Add( new GenericBuyInfo( "Poulet Cru", typeof( RawChickenLeg ), 2, 20, 0x1607, 0 ) );
				Add( new GenericBuyInfo( "Oiseau Cru", typeof( RawBird ), 2, 20, 0x9B9, 0 ) ); 
				Add( new GenericBuyInfo( "Agneau Cru", typeof( RawLambLeg ), 2, 20, 0x1609, 0 ) );
				Add( new GenericBuyInfo( "Cotes Cru", typeof( RawRibs ), 3, 20, 0x9F1, 0 ) );
				Add( new GenericBuyInfo( typeof( ButcherKnife ), 10, 20, 0x13F6, 0 ) );
				Add( new GenericBuyInfo( typeof( Cleaver ), 10, 20, 0xEC3, 0 ) );
				//Add( new GenericBuyInfo( typeof( SkinningKnife ), 13, 20, 0xEC4, 0 ) ); 
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( RawRibs ), 2 ); 
				Add( typeof( RawLambLeg ), 1 ); 
				Add( typeof( RawChickenLeg ), 1 ); 
				Add( typeof( RawBird ), 1 ); 
				Add( typeof( Bacon ), 2 ); 
				Add( typeof( Sausage ), 2 ); 
				Add( typeof( Ham ), 4 ); 
				Add( typeof( ButcherKnife ), 5 ); 
				Add( typeof( Cleaver ), 5 ); 
				//Add( typeof( SkinningKnife ), 5 ); 
			} 
		} 
	} 
}