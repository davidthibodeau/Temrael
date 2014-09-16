using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBFarmer : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBFarmer() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( "Chou", typeof( Cabbage ), 5, 20, 0xC7B, 0 ) );
				Add( new GenericBuyInfo( "Cantaloupe", typeof( Cantaloupe ), 6, 20, 0xC79, 0 ) );
				Add( new GenericBuyInfo( "Carotte", typeof( Carrot ), 3, 20, 0xC78, 0 ) );
				Add( new GenericBuyInfo( "Melon", typeof( HoneydewMelon ), 7, 20, 0xC74, 0 ) );
				Add( new GenericBuyInfo( "Courge", typeof( Squash ), 3, 20, 0xC72, 0 ) );
				Add( new GenericBuyInfo( "Lettue", typeof( Lettuce ), 5, 20, 0xC70, 0 ) );
				Add( new GenericBuyInfo( "Onion", typeof( Onion ), 3, 20, 0xC6D, 0 ) );
				Add( new GenericBuyInfo( "Citrouille", typeof( Pumpkin ), 11, 20, 0xC6A, 0 ) );
				Add( new GenericBuyInfo( "Gourde", typeof( GreenGourd ), 3, 20, 0xC66, 0 ) );
				//Add( new GenericBuyInfo( "", typeof( YellowGourd ), 3, 20, 0xC64, 0 ) );
				//Add( new GenericBuyInfo( typeof( Turnip ), 6, 20, XXXXXX, 0 ) );
				Add( new GenericBuyInfo( "Melon d'Eau", typeof( Watermelon ), 7, 20, 0xC5C, 0 ) );
				//Add( new GenericBuyInfo( typeof( EarOfCorn ), 3, 20, XXXXXX, 0 ) );
				Add( new GenericBuyInfo( "Oeufs", typeof( Eggs ), 3, 20, 0x9B5, 0 ) );
				Add( new BeverageBuyInfo( "Pichet", typeof( Pitcher ), BeverageType.Milk, 7, 20, 0x9AD, 0 ) );
				Add( new GenericBuyInfo( "Pêche", typeof( Peach ), 3, 20, 0x9D2, 0 ) );
				Add( new GenericBuyInfo( "Poire", typeof( Pear ), 3, 20, 0x994, 0 ) );
				Add( new GenericBuyInfo( "Citron", typeof( Lemon ), 3, 20, 0x1728, 0 ) );
				Add( new GenericBuyInfo( "Line", typeof( Lime ), 3, 20, 0x172A, 0 ) );
				Add( new GenericBuyInfo( "Raisin", typeof( Grapes ), 3, 20, 0x9D1, 0 ) );
				Add( new GenericBuyInfo( "Pomme", typeof( Apple ), 3, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( "Gerbe de Foin", typeof( SheafOfHay ), 2, 20, 0xF36, 0 ) );
                Add(new GenericBuyInfo("Pot de Botanique", typeof(SmallBowl), 2, 10, 0x11C6, 0));
                Add(new GenericBuyInfo("Pelle", typeof(Shovel), 20, 8, 0xF39, 0));
                Add(new GenericBuyInfo("Graine de Coton", typeof(CotonSeed), 2, 8, 13066, 0));

			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Pitcher ), 1 );
				Add( typeof( Eggs ), 1 );
				Add( typeof( Apple ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Watermelon ), 1 );
				Add( typeof( YellowGourd ), 1 );
				Add( typeof( GreenGourd ), 1 );
				Add( typeof( Pumpkin ), 1 );
				Add( typeof( Onion ), 1 );
				Add( typeof( Lettuce ), 1 );
				Add( typeof( Squash ), 1 );
				Add( typeof( Carrot ), 1 );
				Add( typeof( HoneydewMelon ), 1 );
				Add( typeof( Cantaloupe ), 1 );
				Add( typeof( Cabbage ), 1 );
				Add( typeof( Lemon ), 1 );
				Add( typeof( Lime ), 1 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
				Add( typeof( SheafOfHay ), 1 );
			} 
		} 
	} 
}