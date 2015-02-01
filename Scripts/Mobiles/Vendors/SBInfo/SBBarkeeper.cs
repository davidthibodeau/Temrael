using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBBarkeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBarkeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new BeverageBuyInfo( "Verre de Bière", typeof( BeverageBottle ), BeverageType.Ale, 6, 20, 0x99F, 0 ) );
				Add( new BeverageBuyInfo( "Verre de Vin", typeof( BeverageBottle ), BeverageType.Wine, 12, 20, 0x9C7, 0 ) );
				Add( new BeverageBuyInfo( "Verre de Liqueur", typeof( BeverageBottle ), BeverageType.Liquor, 8, 20, 0x99B, 0 ) );

				Add( new BeverageBuyInfo( "Cruche", typeof( Jug ), BeverageType.Cider, 13, 20, 0x9C8, 0 ) );
				Add( new BeverageBuyInfo( "Pichet de Lait", typeof( Pitcher ), BeverageType.Milk, 10, 20, 0x9F0, 0 ) );
				Add( new BeverageBuyInfo( "Pichet de Bière", typeof( Pitcher ), BeverageType.Ale, 12, 20, 0x1F95, 0 ) );
				Add( new BeverageBuyInfo( "Piche de Fort", typeof( Pitcher ), BeverageType.Cider, 15, 20, 0x1F97, 0 ) );
				Add( new BeverageBuyInfo( "Pichet de Liqueur", typeof( Pitcher ), BeverageType.Liquor, 13, 20, 0x1F99, 0 ) );
				Add( new BeverageBuyInfo( "Pichet de Vin", typeof( Pitcher ), BeverageType.Wine, 20, 20, 0x1F9B, 0 ) );
				Add( new BeverageBuyInfo( "Pichet d'Eau", typeof( Pitcher ), BeverageType.Water, 6, 20, 0x1F9D, 0 ) );
                Add(new BeverageBuyInfo("Verre d'Eau", typeof(GlassMug), BeverageType.Water, 2, 20, 0x1F9D, 0));

				Add( new GenericBuyInfo( "Pain", typeof( BreadLoaf ), 4, 10, 0x103B, 0 ) );
				Add( new GenericBuyInfo( "Fromage", typeof( CheeseWheel ), 8, 10, 0x97E, 0 ) );
				Add( new GenericBuyInfo( "Oiseau", typeof( CookedBird ), 5, 20, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( "Agneau", typeof( LambLeg ), 6, 20, 0x160A, 0 ) );

				Add( new GenericBuyInfo( "Bol de Carottes", typeof( WoodenBowlOfCarrots ), 3, 20, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( "Bol de Mais", typeof( WoodenBowlOfCorn ), 3, 20, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( "Bol de Lettue", typeof( WoodenBowlOfLettuce ), 3, 20, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( "Bol de Pois", typeof( WoodenBowlOfPeas ), 3, 20, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( "Bol Vide", typeof( EmptyPewterBowl ), 2, 20, 0x15FD, 0 ) );
				Add( new GenericBuyInfo( "Bol de Mais", typeof( PewterBowlOfCorn ), 3, 20, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( "Bol de Lettue", typeof( PewterBowlOfLettuce ), 3, 20, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( "Bol de Pois", typeof( PewterBowlOfPeas ), 3, 20, 0x1600, 0 ) );
				Add( new GenericBuyInfo( "Bol de Patates", typeof( PewterBowlOfPotatos ), 3, 20, 0x1601, 0 ) );
				Add( new GenericBuyInfo( "Bol de Ragout", typeof( WoodenBowlOfStew ), 3, 20, 0x1604, 0 ) );
				Add( new GenericBuyInfo( "Bol de Soupe", typeof( WoodenBowlOfTomatoSoup ), 3, 20, 0x1606, 0 ) );

				//Add( new GenericBuyInfo( typeof( ApplePie ), 7, 20, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat

				Add( new GenericBuyInfo( "Jeu d'Echecs", typeof( Chessboard ), 2, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( "Damier", typeof( CheckerBoard ), 2, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( "Backgammon", typeof( Backgammon ), 2, 20, 0xE1C, 0 ) );
				Add( new GenericBuyInfo( "Dés", typeof( Dices ), 2, 20, 0xFA7, 0 ) );
				Add( new GenericBuyInfo( "Contrat d'Emploi", typeof( ContractOfEmployment ), 2500, 20, 0x14F0, 0 ) );
				//Add( new GenericBuyInfo( "a barkeep contract", typeof( BarkeepContract ), 1252, 20, 0x14F0, 0 ) );
				//if ( Multis.BaseHouse.NewVendorSystem )
				//	Add( new GenericBuyInfo( "1062332", typeof( VendorRentalContract ), 1252, 20, 0x14F0, 0x672 ) );

				/*if ( Map == Tokuno )
					{
						Add( new GenericBuyInfo( typeof( Wasabi ), 2, 20, 0x24E8, 0 ) );
						Add( new GenericBuyInfo( typeof( Wasabi ), 2, 20, 0x24E9, 0 ) );
						Add( new GenericBuyInfo( typeof( BentoBox ), 6, 20, 0x2836, 0 ) );
						Add( new GenericBuyInfo( typeof( BentoBox ), 6, 20, 0x2837, 0 ) );
						Add( new GenericBuyInfo( typeof( GreenTeaBasket ), 2, 20, 0x284B, 0 ) );
					}*/
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( WoodenBowlOfCarrots ), 1 );
				Add( typeof( WoodenBowlOfCorn ), 1 );
				Add( typeof( WoodenBowlOfLettuce ), 1 );
				Add( typeof( WoodenBowlOfPeas ), 1 );
				Add( typeof( EmptyPewterBowl ), 1 );
				Add( typeof( PewterBowlOfCorn ), 1 );
				Add( typeof( PewterBowlOfLettuce ), 1 );
				Add( typeof( PewterBowlOfPeas ), 1 );
				Add( typeof( PewterBowlOfPotatos ), 1 );
				Add( typeof( WoodenBowlOfStew ), 1 );
				Add( typeof( WoodenBowlOfTomatoSoup ), 1 );
				Add( typeof( BeverageBottle ), 1 );
				Add( typeof( Jug ), 1 );
				Add( typeof( Pitcher ), 1 );
				Add( typeof( GlassMug ), 1 );
				Add( typeof( BreadLoaf ), 1 );
				Add( typeof( CheeseWheel ), 1 );
				Add( typeof( Ribs ), 1 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Apple ), 1 );
				Add( typeof( Banana ), 1 );
				Add( typeof( Candle ), 1 );
				Add( typeof( Chessboard ), 1 );
				Add( typeof( CheckerBoard ), 1 );
				Add( typeof( Backgammon ), 1 );
				Add( typeof( Dices ), 1 );
				//Add( typeof( ContractOfEmployment ), 626 );
			}
		}
	}
}