using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBTinker: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBTinker() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( "Horloge", typeof( Clock ), 25, 20, 0x104B, 0 ) );
				Add( new GenericBuyInfo( "Clous", typeof( Nails ), 3, 20, 0x102E, 0 ) );
				Add( new GenericBuyInfo( "Parties d'Horloge", typeof( ClockParts ), 8, 20, 0x104F, 0 ) );
				Add( new GenericBuyInfo( "Engrenade d'Axes", typeof( AxleGears ), 5, 20, 0x1051, 0 ) );
				Add( new GenericBuyInfo( "Engrenage", typeof( Gears ), 4, 20, 0x1053, 0 ) );
				Add( new GenericBuyInfo( "Charnière", typeof( Hinge ), 3, 20, 0x1055, 0 ) );

				Add( new GenericBuyInfo( "Sextant", typeof( Sextant ), 12, 20, 0x1057, 0 ) );
				Add( new GenericBuyInfo( "Parties de Sextant", typeof( SextantParts ), 5, 20, 0x1059, 0 ) );
				Add( new GenericBuyInfo( "Essieu", typeof( Axle ), 2, 20, 0x105B, 0 ) );
				Add( new GenericBuyInfo( "Ressorts", typeof( Springs ), 3, 20, 0x105D, 0 ) );

				Add( new GenericBuyInfo( "Clef d'Or", typeof( Key ), 3, 20, 0x100F, 0 ) );
				Add( new GenericBuyInfo( "Clef de Fer", typeof( Key ), 3, 20, 0x1010, 0 ) );
				Add( new GenericBuyInfo( "Clef de Cuivre", typeof( Key ), 3, 20, 0x1013, 0 ) );
				Add( new GenericBuyInfo( "Porte Clef", typeof( KeyRing ), 6, 20, 0x1010, 0 ) );
				Add( new GenericBuyInfo( "Crochet", typeof( Lockpick ), 5, 20, 0x14FC, 0 ) );

				Add( new GenericBuyInfo( "Outils de Bricoleur", typeof( TinkersTools ), 20, 20, 0x1EBC, 0 ) );
				Add( new GenericBuyInfo( "Planche", typeof( Board ), 10, 20, 0x1BD7, 0 ) );
				Add( new GenericBuyInfo( "Lingot de Fer", typeof( FerIngot ), 10, 16, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Outil de Couture", typeof( SewingKit ), 20, 20, 0xF9D, 0 ) );
                Add( new GenericBuyInfo( "Outil d'Os", typeof(Knitting), 20, 20, 0xDF6, 0) );

				Add( new GenericBuyInfo( "Plane", typeof( DrawKnife ), 20, 20, 0x10E4, 0 ) );
				Add( new GenericBuyInfo( "Froe", typeof( Froe ), 20, 20, 0x10E5, 0 ) );
				Add( new GenericBuyInfo( "Scorp", typeof( Scorp ), 20, 20, 0x10E7, 0 ) );
				Add( new GenericBuyInfo( "Inshave", typeof( Inshave ), 20, 20, 0x10E6, 0 ) );

				Add( new GenericBuyInfo( "Couteau de Boucher", typeof( ButcherKnife ), 5, 20, 0x13F6, 0 ) );

				Add( new GenericBuyInfo( "Ciseaux", typeof( Scissors ), 20, 20, 0xF9F, 0 ) );

				Add( new GenericBuyInfo( "Pinces", typeof( Tongs ), 20, 14, 0xFBB, 0 ) );

                Add(new GenericBuyInfo( "Scie à queue d'aronde", typeof(DovetailSaw), 20, 20, 0x1028, 0) );
				Add( new GenericBuyInfo( "Scie", typeof( Saw ), 20, 20, 0x1034, 0 ) );

				Add( new GenericBuyInfo( "Marteau", typeof( Hammer ), 20, 20, 0x102A, 0 ) );
				Add( new GenericBuyInfo( "Marteau de Forge", typeof( SmithHammer ), 20, 20, 0x13E3, 0 ) );
				// TODO: Sledgehammer

				Add( new GenericBuyInfo( "Pelle", typeof( Shovel ), 20, 20, 0xF39, 0 ) );

				//Add( new GenericBuyInfo( "", typeof( MouldingPlane ), 15, 20, 0x102C, 0 ) );
				//Add( new GenericBuyInfo( "", typeof( JointingPlane ), 12, 20, 0x1030, 0 ) );
				//Add( new GenericBuyInfo( "", typeof( SmoothingPlane ), 15, 20, 0x1032, 0 ) );

				Add( new GenericBuyInfo( "Pioche", typeof( Pickaxe ), 20, 20, 0xE86, 0 ) );


				Add( new GenericBuyInfo( "Tambours", typeof( Drums ), 20, 20, 0x0E9C, 0 ) );
				Add( new GenericBuyInfo( "Tambourine", typeof( Tambourine ), 10, 20, 0x0E9E, 0 ) );
				Add( new GenericBuyInfo( "Harpe", typeof( LapHarp ), 75, 20, 0x0EB2, 0 ) );
				Add( new GenericBuyInfo( "Lute", typeof( Lute ), 50, 20, 0x0EB3, 0 ) );
                Add(new GenericBuyInfo("Kit de Déguisement", typeof(DeguisementKit), 50, 20, 0x1EBA, 0));
                //Add(new GenericBuyInfo("Outil de Fermentation", typeof(OutilFermentation), 50, 20, 0x1EBA, 0));
                //Add(new GenericBuyInfo("Outil de Coagulation", typeof(OutilCoagulation), 50, 20, 0x1EBA, 0));
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				/*Add( typeof( Drums ), 10 );
				Add( typeof( Tambourine ), 10 );
				Add( typeof( LapHarp ), 10 );
				Add( typeof( Lute ), 10 );

				Add( typeof( Shovel ), 2 );
				Add( typeof( SewingKit ), 1 );
				Add( typeof( Scissors ), 1 );
				Add( typeof( Tongs ), 1 );
				Add( typeof( Key ), 1 );

				Add( typeof( DovetailSaw ), 1 );
				Add( typeof( MouldingPlane ), 1 );
				Add( typeof( Nails ), 1 );
				Add( typeof( JointingPlane ), 1 );
				Add( typeof( SmoothingPlane ), 1 );
				Add( typeof( Saw ), 2 );

				Add( typeof( Clock ), 3 );
				Add( typeof( ClockParts ), 1 );
				Add( typeof( AxleGears ), 1 );
				Add( typeof( Gears ), 1 );
				Add( typeof( Hinge ), 1 );
				Add( typeof( Sextant ), 2 );
				Add( typeof( SextantParts ), 1 );
				Add( typeof( Axle ), 1 );
				Add( typeof( Springs ), 1 );

				Add( typeof( DrawKnife ), 1 );
				Add( typeof( Froe ), 1 );
				Add( typeof( Inshave ), 1 );
				Add( typeof( Scorp ), 1 );

				Add( typeof( Lockpick ), 1 );
				Add( typeof( TinkerTools ), 2 );

				Add( typeof( Board ), 1 );
				Add( typeof( Log ), 1 );

				Add( typeof( Pickaxe ), 2 );
				Add( typeof( Hammer ), 1 );
				Add( typeof( SmithHammer ), 2 );
				Add( typeof( ButcherKnife ), 5 );*/
			} 
		} 
	} 
}