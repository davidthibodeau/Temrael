using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBTailor: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBTailor()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
               /* Add(new GenericBuyInfo(typeof(RobeOrdinaire), 8, 20, 0x27D3, 0));
                Add(new GenericBuyInfo(typeof(RobeDomestique), 12, 20, 0x27A5, 0));
                Add(new GenericBuyInfo(typeof(RobeACeinture), 15, 20, 0x3156, 0));
                Add(new GenericBuyInfo(typeof(RobeFleurit), 20, 20, 0x2799, 0));
                Add(new GenericBuyInfo(typeof(RobeBourgeoise), 25, 20, 0x27AA, 0));
                Add(new GenericBuyInfo(typeof(RobeGrande), 30, 20, 0x3158, 0));
                Add(new GenericBuyInfo(typeof(RobeLarge), 40, 20, 0x27A8, 0));
                Add(new GenericBuyInfo(typeof(FancyDress), 50, 20, 0x1F00, 0));
                Add(new GenericBuyInfo(typeof(Robetrainante), 75, 20, 0x27A9, 0));

                Add(new GenericBuyInfo(typeof(Chandail), 5, 20, 0x277E, 0));
                Add(new GenericBuyInfo(typeof(FancyShirt), 10, 20, 0x1EFD, 0));
                Add(new GenericBuyInfo(typeof(ChandailNoble), 25, 20, 0x2775, 0));
                Add(new GenericBuyInfo(typeof(ChemiseLongue), 35, 20, 0x2753, 0));
                Add(new GenericBuyInfo(typeof(ChemiseNoble), 50, 20, 0x274A, 0));
                Add(new GenericBuyInfo(typeof(DoubletBouton), 50, 20, 0x2760, 0));
                Add(new GenericBuyInfo(typeof(TuniquePage), 80, 20, 0x2749, 0));
                Add(new GenericBuyInfo(typeof(TuniqueNoble), 120, 20, 0x2758, 0));
                Add(new GenericBuyInfo(typeof(TabarLong), 150, 20, 0x2777, 0));

                Add(new GenericBuyInfo(typeof(Robe), 15, 20, 0x1F03, 0));
                Add(new GenericBuyInfo(typeof(TogeSoutane), 30, 20, 0x278F, 0));
                Add(new GenericBuyInfo(typeof(TogePelerin), 50, 20, 0x2797, 0));
                Add(new GenericBuyInfo(typeof(TogeDiciple), 60, 20, 0x2796, 0));
                Add(new GenericBuyInfo(typeof(ManteauLong), 80, 20, 0x2789, 0));
                Add(new GenericBuyInfo(typeof(Veston), 25, 20, 0x275F, 0));
                Add(new GenericBuyInfo(typeof(Veste), 40, 20, 0x277A, 0));

                Add(new GenericBuyInfo(typeof(SkullCap), 8, 20, 5444, 0));
                Add(new GenericBuyInfo(typeof(Bandana), 8, 20, 5440, 0));
                Add(new GenericBuyInfo(typeof(Bonnet), 8, 20, 0x1719, 0));
                Add(new GenericBuyInfo(typeof(TricorneHat), 8, 20, 0x171B, 0));
                Add(new GenericBuyInfo(typeof(Cap), 8, 20, 0x1715, 0));
                Add(new GenericBuyInfo(typeof(ChapeauPlume), 8, 20, 0x272D, 0));
                Add(new GenericBuyInfo(typeof(ChapeauCourt), 8, 20, 0x272C, 0));

                Add(new GenericBuyInfo(typeof(LongPants), 8, 20, 0x1539, 0));
                Add(new GenericBuyInfo(typeof(Pantalons), 8, 20, 0x273B, 0));
                Add(new GenericBuyInfo(typeof(PantalonsLongs), 8, 20, 0x273E, 0));
                Add(new GenericBuyInfo(typeof(PantalonsMoulant), 8, 20, 0x273F, 0));
                Add(new GenericBuyInfo(typeof(PantalonsArmure), 8, 20, 0x273C, 0));
                Add(new GenericBuyInfo(typeof(Jupe), 8, 20, 0x2741, 0));
                Add(new GenericBuyInfo(typeof(JupeLongue), 8, 20, 0x2743, 0));
                Add(new GenericBuyInfo(typeof(JupeAmple), 8, 20, 0x2744, 0));
                Add(new GenericBuyInfo(typeof(JupeNoble), 8, 20, 0x3176, 0));

                Add(new GenericBuyInfo(typeof(CapeCourte), 8, 20, 0x271D, 0));
                Add(new GenericBuyInfo(typeof(Cloak), 8, 20, 5397, 0));
                Add(new GenericBuyInfo(typeof(CapeDecore), 8, 20, 0x2716, 0));
                Add(new GenericBuyInfo(typeof(CapeTrainee), 8, 20, 0x271A, 0));
                Add(new GenericBuyInfo(typeof(CapeNoble), 8, 20, 0x2712, 0));

                Add(new GenericBuyInfo(typeof(BodySash), 8, 20, 0x1541, 0));
                Add(new GenericBuyInfo(typeof(FullApron), 8, 20, 0x153d, 0));
                Add(new GenericBuyInfo(typeof(CeintureBoucle), 8, 20, 0x2663, 0));
                Add(new GenericBuyInfo(typeof(CeintureCuir), 8, 20, 0x2661, 0));
                Add(new GenericBuyInfo(typeof(Fourreau), 8, 20, 0x2667, 0));
                Add(new GenericBuyInfo(typeof(FourreauSabre), 8, 20, 0x2672, 0));
                Add(new GenericBuyInfo(typeof(SacocheHerboriste), 8, 20, 0x2679, 0));
                Add(new GenericBuyInfo(typeof(Pardessus), 8, 20, 0x2683, 0));
                Add(new GenericBuyInfo(typeof(FoulardNoble), 8, 20, 0x268A, 0));*/

				Add( new GenericBuyInfo( typeof( SewingKit ), 3, 20, 0xF9D, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Scissors ), 11, 20, 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( DyeTub ), 8, 20, 0xFAB, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Dyes ), 8, 20, 0xFA9, 0 ) ); 

				/*Add( new GenericBuyInfo( typeof( Shirt ), 12, 20, 0x1517, 0 ) );
				Add( new GenericBuyInfo( typeof( ShortPants ), 7, 20, 0x152E, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyShirt ), 21, 20, 0x1EFD, 0 ) );
				Add( new GenericBuyInfo( typeof( LongPants ), 10, 20, 0x1539, 0 ) );
				Add( new GenericBuyInfo( typeof( FancyDress ), 26, 20, 0x1EFF, 0 ) );
				Add( new GenericBuyInfo( typeof( PlainDress ), 13, 20, 0x1F01, 0 ) );
				Add( new GenericBuyInfo( typeof( Kilt ), 11, 20, 0x1537, 0 ) );
				Add( new GenericBuyInfo( typeof( Kilt ), 11, 20, 0x1537, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( HalfApron ), 10, 20, 0x153b, 0 ) );
				Add( new GenericBuyInfo( typeof( Robe ), 18, 20, 0x1F03, 0 ) );
				Add( new GenericBuyInfo( typeof( Cloak ), 8, 20, 0x1515, 0 ) );
				Add( new GenericBuyInfo( typeof( Cloak ), 8, 20, 0x1515, 0 ) );
				Add( new GenericBuyInfo( typeof( Doublet ), 13, 20, 0x1F7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Tunic ), 18, 20, 0x1FA1, 0 ) );
				Add( new GenericBuyInfo( typeof( JesterSuit ), 26, 20, 0x1F9F, 0 ) );

				Add( new GenericBuyInfo( typeof( JesterHat ), 12, 20, 0x171C, 0 ) );
				Add( new GenericBuyInfo( typeof( FloppyHat ), 7, 20, 0x1713, Utility.RandomDyedHue() ) );
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

				Add( new GenericBuyInfo( typeof( BoltOfCloth ), 100, 20, 0xf95, Utility.RandomDyedHue() ) ); 

				//Add( new GenericBuyInfo( typeof( Cloth ), 2, 20, 0x1766, Utility.RandomDyedHue() ) ); 
				//Add( new GenericBuyInfo( typeof( UncutCloth ), 2, 20, 0x1767, Utility.RandomDyedHue() ) ); 

				//Add( new GenericBuyInfo( typeof( Cotton ), 102, 20, 0xDF9, 0 ) );
				//Add( new GenericBuyInfo( typeof( Wool ), 62, 20, 0xDF8, 0 ) );
				//Add( new GenericBuyInfo( typeof( Flax ), 102, 20, 0x1A9C, 0 ) );
				Add( new GenericBuyInfo( typeof( SpoolOfThread ), 18, 50, 0xFA0, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Scissors ), 1 );
				Add( typeof( SewingKit ), 1 );
				Add( typeof( Dyes ), 4 );
				Add( typeof( DyeTub ), 4 );

				Add( typeof( BoltOfCloth ), 20 );

				/*Add( typeof( FancyShirt ), 10 );
				Add( typeof( Shirt ), 6 );

				Add( typeof( ShortPants ), 3 );
				Add( typeof( LongPants ), 5 );

				Add( typeof( Cloak ), 4 );
				Add( typeof( FancyDress ), 12 );
				Add( typeof( Robe ), 9 );
				Add( typeof( PlainDress ), 7 );

				Add( typeof( Skirt ), 5 );
				Add( typeof( Kilt ), 5 );

				Add( typeof( Doublet ), 7 );
				Add( typeof( Tunic ), 9 );
				Add( typeof( JesterSuit ), 13 );

				Add( typeof( FullApron ), 5 );
				Add( typeof( HalfApron ), 5 );

				Add( typeof( JesterHat ), 6 );
				Add( typeof( FloppyHat ), 3 );
				Add( typeof( WideBrimHat ), 4 );
				Add( typeof( Cap ), 5 );
				Add( typeof( SkullCap ), 3 );
				Add( typeof( Bandana ), 3 );
				Add( typeof( TallStrawHat ), 4 );
				Add( typeof( StrawHat ), 4 );
				Add( typeof( WizardsHat ), 5 );
				Add( typeof( Bonnet ), 4 );
				Add( typeof( FeatheredHat ), 5 );
				Add( typeof( TricorneHat ), 4 );*/

				Add( typeof( SpoolOfThread ), 2 );

				Add( typeof( Flax ), 10 );
				Add( typeof( Cotton ), 5 );
				Add( typeof( Wool ), 3 );
			}
		}
	}
}
