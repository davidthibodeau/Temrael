using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBMage : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMage()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Grimoire", typeof( NewSpellbook ), 30, 10, 0xEFA, 0 ) );
				
				//if ( Core.AOS )
				//	Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 10, 0x2253, 0 ) );
				
				Add( new GenericBuyInfo( typeof( ScribesPen ), 8, 10, 0xFBF, 0 ) );

				Add( new GenericBuyInfo( "Rouleau Vierge", typeof( BlankScroll ), 10, 20, 0x0E34, 0 ) );

				//Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, 10, 0x1718, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( "Rune", typeof( RecallRune ), 50, 10, 0x1F14, 0 ) );

				/*Add( new GenericBuyInfo( typeof( RefreshPotion ), 15, 10, 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( AgilityPotion ), 15, 10, 0xF08, 0 ) );
				Add( new GenericBuyInfo( typeof( NightSightPotion ), 15, 10, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 15, 10, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 15, 10, 0xF09, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 15, 10, 0xF0A, 0 ) );
 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 15, 10, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 21, 10, 0xF0D, 0 ) );*/

				Add( new GenericBuyInfo( typeof( BlackPearl ), 1, 500, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 1, 500, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 1, 500, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 1, 500, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 1, 500, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 1, 500, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 1, 500, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 1, 500, 0xF8C, 0 ) );

				if ( Core.AOS )
				{
                    Add(new GenericBuyInfo(typeof(BatWing), 1, 200, 0xF78, 0));
                    Add(new GenericBuyInfo(typeof(DaemonBlood), 1, 200, 0xF7D, 0));
                    Add(new GenericBuyInfo(typeof(PigIron), 1, 200, 0xF8A, 0));
                    Add(new GenericBuyInfo(typeof(NoxCrystal), 1, 200, 0xF8E, 0));
                    Add(new GenericBuyInfo(typeof(GraveDust), 1, 200, 0xF8F, 0));
				}

				/*Type[] types = Loot.RegularScrollTypes;

				int circles = 3;

				//for ( int i = 0; i < circles*8 && i < types.Length; ++i )
                for (int i = 0; i < circles * 4 && i < types.Length; ++i)
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					Add( new GenericBuyInfo( types[i], 75 + ((i / 8) * 20), 20, itemID, 0 ) );
				}*/
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				//Add( typeof( WizardsHat ), 15 );
				Add( typeof( BlackPearl ), 1 ); 
				Add( typeof( Bloodmoss ), 1 ); 
				Add( typeof( MandrakeRoot ), 1 ); 
				Add( typeof( Garlic ), 1 ); 
				Add( typeof( Ginseng ), 1 ); 
				Add( typeof( Nightshade ), 1 ); 
				Add( typeof( SpidersSilk ), 1 ); 
				Add( typeof( SulfurousAsh ), 1 ); 

				if ( Core.AOS )
				{
					Add( typeof( BatWing ), 1 );
					Add( typeof( DaemonBlood ), 1 );
					Add( typeof( PigIron ), 1 );
					Add( typeof( NoxCrystal ), 1 );
					Add( typeof( GraveDust ), 1 );
				}

				Add( typeof( RecallRune ), 2 );
				Add( typeof( Spellbook ), 2 );

				Type[] types = Loot.RegularScrollTypes;

				/*for ( int i = 0; i < types.Length; ++i )
					Add(types[i], i + 3 + (i / 4));     // This is NOT 100% OSI accurate. Two spells per circle will be off by 1gp, as OSI's math is slightly different.*/


		    }
	    }
	}
}