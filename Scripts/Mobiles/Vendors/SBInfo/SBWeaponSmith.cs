using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBWeaponSmith: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBWeaponSmith() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 	
				Add( new GenericBuyInfo( typeof( FerIngot ), 10, 16, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( typeof( Tongs ), 20, 14, 0xFBB, 0 ) );
                Add(new GenericBuyInfo(typeof(Axe), 5, 15, 0xF49, 0)); 
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 	
				/*Add( typeof( BattleAxe ), 13 );
				Add( typeof( DoubleAxe ), 26 );
				Add( typeof( ExecutionersAxe ), 15 );
				Add( typeof( LargeBattleAxe ),16 );
				Add( typeof( Pickaxe ), 11 );
				Add( typeof( TwoHandedAxe ), 16 );
				Add( typeof( WarAxe ), 14 );
				Add( typeof( Axe ), 20 );

				Add( typeof( Bardiche ), 30 );
				Add( typeof( Halberd ), 21 );

				Add( typeof( ButcherKnife ), 7 );
				Add( typeof( Cleaver ), 7 );
				Add( typeof( Dagger ), 10 );
				Add( typeof( SkinningKnife ), 7 );

				Add( typeof( Club ), 8 );
				Add( typeof( HammerPick ), 13 );
				Add( typeof( Mace ), 14 );
				Add( typeof( Maul ), 10 );
				Add( typeof( WarHammer ), 12 );
				Add( typeof( WarMace ), 15 );

				Add( typeof( HeavyCrossbow ), 27 );
				Add( typeof( Bow ), 17 );
				Add( typeof( Crossbow ), 23 ); 

				if( Core.AOS )
				{
					Add( typeof( CompositeBow ), 25 );
					Add( typeof( RepeatingCrossbow ), 28 );
					Add( typeof( Scepter ), 20 );
					Add( typeof( BladedStaff ), 20 );
					Add( typeof( Scythe ), 19 );
					Add( typeof( BoneHarvester ), 17 );
					Add( typeof( Scepter ), 18 );
					Add( typeof( BladedStaff ), 16 );
					Add( typeof( Pike ), 19 );
					Add( typeof( DoubleBladedStaff ), 17 );
					Add( typeof( Lance ), 17 );
					Add( typeof( CrescentBlade ), 18 );
				}

				Add( typeof( Spear ), 15 );
				Add( typeof( Pitchfork ), 9 );
				Add( typeof( ShortSpear ), 11 );

				Add( typeof( BlackStaff ), 11 );
				Add( typeof( GnarledStaff ), 8 );
				Add( typeof( QuarterStaff ), 9 );
				Add( typeof( ShepherdsCrook ), 10 );

				Add( typeof( SmithHammer ), 10 );

				Add( typeof( Broadsword ), 17 );
				Add( typeof( Cutlass ), 12 );
				Add( typeof( Katana ), 16 );
				Add( typeof( Kryss ), 16 );
				Add( typeof( Longsword ), 27 );
				Add( typeof( Scimitar ), 18 );
				Add( typeof( ThinLongsword ), 13 );
				Add( typeof( VikingSword ), 27 );

				Add( typeof( Hatchet ), 13 );
				Add( typeof( WarFork ), 16 );*/
			} 
		} 
	} 
}
