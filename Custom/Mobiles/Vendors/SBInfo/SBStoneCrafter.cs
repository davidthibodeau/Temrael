using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBStoneCrafter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBStoneCrafter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Nails ), 3, 20, 0x102E, 0 ) );
				Add( new GenericBuyInfo( typeof( Axle ), 2, 20, 0x105B, 0 ) );
				Add( new GenericBuyInfo( typeof( Board ), 3, 20, 0x1BD7, 0 ) );
				Add( new GenericBuyInfo( typeof( DrawKnife ), 10, 20, 0x10E4, 0 ) );
				Add( new GenericBuyInfo( typeof( Froe ), 10, 20, 0x10E5, 0 ) );
				Add( new GenericBuyInfo( typeof( Scorp ), 10, 20, 0x10E7, 0 ) );
				Add( new GenericBuyInfo( typeof( Inshave ), 10, 20, 0x10E6, 0 ) );
				Add( new GenericBuyInfo( typeof( DovetailSaw ), 12, 20, 0x1028, 0 ) );
				Add( new GenericBuyInfo( typeof( Saw ), 15, 20, 0x1034, 0 ) );
				Add( new GenericBuyInfo( typeof( Hammer ), 17, 20, 0x102A, 0 ) );
				Add( new GenericBuyInfo( typeof( MouldingPlane ), 11, 20, 0x102C, 0 ) );
				Add( new GenericBuyInfo( typeof( SmoothingPlane ), 10, 20, 0x1032, 0 ) );
				Add( new GenericBuyInfo( typeof( JointingPlane ), 11, 20, 0x1030, 0 ) );

				Add( new GenericBuyInfo( "Making Valuables With Stonecrafting", typeof( MasonryBook ), 10625, 10, 0xFBE, 0 ) );
				Add( new GenericBuyInfo( "Mining For Quality Stone", typeof( StoneMiningBook ), 10625, 10, 0xFBE, 0 ) );
				Add( new GenericBuyInfo( "1044515", typeof( MalletAndChisel ), 3, 50, 0x12B3, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				/*Add( typeof( MasonryBook ), 5000 );
				Add( typeof( StoneMiningBook ), 5000 );
				Add( typeof( MalletAndChisel ), 1 );

				Add( typeof( WoodenBox ), 1 );
				Add( typeof( SmallCrate ), 1 );
				Add( typeof( MediumCrate ), 1 );
				Add( typeof( LargeCrate ), 1 );
				Add( typeof( WoodenChest ), 1 );
              
				Add( typeof( LargeTable ), 1 );
				Add( typeof( Nightstand ), 1 );
				Add( typeof( YewWoodTable ), 1 );

				Add( typeof( Throne ), 1 );
				Add( typeof( WoodenThrone ), 1 );
				Add( typeof( Stool ), 1 );
				Add( typeof( FootStool ), 1 );

				Add( typeof( FancyWoodenChairCushion ), 1 );
				Add( typeof( WoodenChairCushion ), 1 );
				Add( typeof( WoodenChair ), 1 );
				Add( typeof( BambooChair ), 1 );
				Add( typeof( WoodenBench ), 1 );

				Add( typeof( Saw ), 1 );
				Add( typeof( Scorp ), 1 );
				Add( typeof( SmoothingPlane ), 1 );
				Add( typeof( DrawKnife ), 1 );
				Add( typeof( Froe ), 1 );
				Add( typeof( Hammer ), 1 );
				Add( typeof( Inshave ), 1 );
				Add( typeof( JointingPlane ), 1 );
				Add( typeof( MouldingPlane ), 1 );
				Add( typeof( DovetailSaw ), 1 );
				Add( typeof( Board ), 1 );
				Add( typeof( Axle ), 1 );

				Add( typeof( WoodenShield ), 1 );
				Add( typeof( BlackStaff ), 1 );
				Add( typeof( GnarledStaff ), 1 );
				Add( typeof( QuarterStaff ), 1 );
				Add( typeof( ShepherdsCrook ), 1 );
				Add( typeof( Club ), 13 );*/

				Add( typeof( Log ), 1 );
			}
		}
	}
}