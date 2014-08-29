using System;
using System.Collections.Generic;
using Server.Items;
using Server.Guilds;

namespace Server.Mobiles
{
	public class SBProvisioner : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBProvisioner()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				#region Salvage Bag
				if( Core.ML )
					Add( new GenericBuyInfo( "1079931", typeof( SalvageBag ), 1255, 20, 0xE76, Utility.RandomBlueHue() ) );
				#endregion
				//Add( new GenericBuyInfo( "1060834", typeof( Engines.Plants.PlantBowl ), 2, 20, 0x15FD, 0 ) );

				Add( new GenericBuyInfo( "Fleche", typeof( Arrow ), 2, 20, 0xF3F, 0 ) );
				Add( new GenericBuyInfo( "Carreau", typeof( Bolt ), 5, 20, 0x1BFB, 0 ) );

				Add( new GenericBuyInfo( "Sac a dos", typeof( Backpack ), 15, 20, 0x9B2, 0 ) );
				Add( new GenericBuyInfo( "Bourse", typeof( Pouch ), 8, 20, 0xE79, 0 ) );
				Add( new GenericBuyInfo( "Sac", typeof( Bag ), 6, 20, 0xE76, 0 ) );
				
				Add( new GenericBuyInfo( "Chandelle", typeof( Candle ), 4, 20, 0xA28, 0 ) );
				Add( new GenericBuyInfo( "Torche", typeof( Torch ), 2, 20, 0xF6B, 0 ) );
				Add( new GenericBuyInfo( "Lanterne", typeof( Lantern ), 8, 20, 0xA25, 0 ) );
					
				//TODO: Oil Flask @ 8GP

				Add( new GenericBuyInfo( "Crochet", typeof( Lockpick ), 5, 20, 0x14FC, 0 ) );

				/*Add( new GenericBuyInfo( typeof( FloppyHat ), 7, 20, 0x1713, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WideBrimHat ), 8, 20, 0x1714, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cap ), 10, 20, 0x1715, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TallStrawHat ), 8, 20, 0x1716, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( StrawHat ), 7, 20, 0x1717, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( WizardsHat ), 11, 20, 0x1718, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( LeatherCap ), 10, 20, 0x1DB9, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( FeatheredHat ), 10, 20, 0x171A, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( TricorneHat ), 8, 20, 0x171B, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Bandana ), 6, 20, 0x1540, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SkullCap ), 7, 20, 0x1544, Utility.RandomDyedHue() ) );*/

				//Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, 10, 0x103B, 0 ) );
				//Add( new GenericBuyInfo( typeof( LambLeg ), 8, 20, 0x160A, 0 ) );
				//Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, 20, 0x1608, 0 ) );
				//Add( new GenericBuyInfo( typeof( CookedBird ), 17, 20, 0x9B7, 0 ) );

				//Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, 20, 0x99F, 0 ) );
				//Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, 20, 0x9C7, 0 ) );
				//Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, 20, 0x99B, 0 ) );
				//Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, 20, 0x9C8, 0 ) );

				//Add( new GenericBuyInfo( typeof( Pear ), 3, 20, 0x994, 0 ) );
				//Add( new GenericBuyInfo( typeof( Apple ), 3, 20, 0x9D0, 0 ) );

				Add( new GenericBuyInfo( "Cire d'Abeille", typeof( Beeswax ), 1, 20, 0x1422, 0 ) );

				//Add( new GenericBuyInfo( typeof( Garlic ), 3, 20, 0xF84, 0 ) );
				//Add( new GenericBuyInfo( typeof( Ginseng ), 3, 20, 0xF85, 0 ) );

				Add( new GenericBuyInfo( "Bouteille", typeof( Bottle ), 5, 20, 0xF0E, 0 ) );

				Add( new GenericBuyInfo( "Livre", typeof( RedBook ), 25, 20, 0xFF1, 0 ) );
				Add( new GenericBuyInfo( "Livre", typeof( BlueBook ), 25, 20, 0xFF2, 0 ) );
				Add( new GenericBuyInfo( "Livre", typeof( TanBook ), 25, 20, 0xFF0, 0 ) );

				Add( new GenericBuyInfo( "Boite", typeof( WoodenBox ), 10, 20, 0xE7D, 0 ) );
				//Add( new GenericBuyInfo( "Clef", typeof( Key ), 2, 20, 0x100E, 0 ) );

				Add( new GenericBuyInfo( "Matelas", typeof( Bedroll ), 5, 20, 0xA59, 0 ) );
				Add( new GenericBuyInfo( "Brindille", typeof( Kindling ), 2, 20, 0xDE1, 0 ) );

				//Add( new GenericBuyInfo( "1041205", typeof( Multis.SmallBoatDeed ), 10177, 20, 0x14F2, 0 ) );

				//Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 60, 20, 0xEFF, 0 ) );

				Add( new GenericBuyInfo( "Jeu d'Echec", typeof( Chessboard ), 8, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( "Damier", typeof( CheckerBoard ), 6, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( "Backgammon", typeof( Backgammon ), 5, 20, 0xE1C, 0 ) );
				if ( Core.AOS )
					Add( new GenericBuyInfo( "Mahjong", typeof( Engines.Mahjong.MahjongGame ), 10, 20, 0xFAA, 0 ) );
				Add( new GenericBuyInfo( "D�s", typeof( Dices ), 2, 20, 0xFA7, 0 ) );

				/*if ( Core.AOS )
				{
					Add( new GenericBuyInfo( typeof( SmallBagBall ), 3, 20, 0x2256, 0 ) );
					Add( new GenericBuyInfo( typeof( LargeBagBall ), 3, 20, 0x2257, 0 ) );
				}*/

				//if( !Guild.NewGuildSystem )
				//	Add( new GenericBuyInfo( "1041055", typeof( GuildDeed ), 12450, 20, 0x14F0, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Arrow ), 1 );
				Add( typeof( Bolt ), 1 );
				Add( typeof( Backpack ), 1 );
				Add( typeof( Pouch ), 1 );
				Add( typeof( Bag ), 1 );
				Add( typeof( Candle ), 1 );
				Add( typeof( Torch ), 1 );
				Add( typeof( Lantern ), 1 );
				Add( typeof( Lockpick ), 1 );

				Add( typeof( Bottle ), 1 );
				Add( typeof( RedBook ), 1 );
				Add( typeof( BlueBook ), 1 );
				Add( typeof( TanBook ), 1 );
				Add( typeof( WoodenBox ), 1 );
				Add( typeof( Kindling ), 1 );
				Add( typeof( HairDye ), 1 );
				Add( typeof( Chessboard ), 1 );
				Add( typeof( CheckerBoard ), 1 );
				Add( typeof( Backgammon ), 1 );
				Add( typeof( Dices ), 1 );

				Add( typeof( Beeswax ), 1 );

				Add( typeof( Amber ), 25 );
				Add( typeof( Amethyst ), 50 );
				Add( typeof( Citrine ), 25 );
				Add( typeof( Diamond ), 100 );
				Add( typeof( Emerald ), 50 );
				Add( typeof( Ruby ), 60 );
				Add( typeof( Sapphire ), 75 );
				Add( typeof( StarSapphire ), 125 );
				Add( typeof( Tourmaline ), 45 );
			}
		}
	}
}
