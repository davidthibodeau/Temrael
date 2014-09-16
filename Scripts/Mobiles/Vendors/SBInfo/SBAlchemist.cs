using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBAlchemist : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAlchemist()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{  
			/*	Add( new GenericBuyInfo( "Potion de Rafraichissement", typeof( RefreshPotion ), 25, 10, 0xF0B, 0 ) );
				Add( new GenericBuyInfo( "Potion d'Agilité", typeof( AgilityPotion ), 40, 10, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Potion de Vision Nocturne", typeof( NightSightPotion ), 25, 10, 0xF06, 0 ) );
				Add( new GenericBuyInfo( "Potion de Soins Mineur", typeof( LesserHealPotion ), 30, 10, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Potion de Force Mineur", typeof( StrengthPotion ), 25, 10, 0xF09, 0 ) );
				Add( new GenericBuyInfo( "Potion de Poison Mineur", typeof( LesserPoisonPotion ), 40, 10, 0xF0A, 0 ) );
 				Add( new GenericBuyInfo( "Potion de Cure Mineur", typeof( LesserCurePotion ), 25, 10, 0xF07, 0 ) );
				Add( new GenericBuyInfo( "Potion Explosive Mineur", typeof( LesserExplosionPotion ), 40, 10, 0xF0D, 0 ) );
         */       
				Add( new GenericBuyInfo( "Mortar", typeof( MortarPestle ), 8, 10, 0xE9B, 0 ) );

                Add(new GenericBuyInfo(typeof(BlackPearl), 1, 20, 0xF7A, 0));
                Add(new GenericBuyInfo(typeof(Bloodmoss), 1, 20, 0xF7B, 0));
                Add(new GenericBuyInfo(typeof(Garlic), 1, 20, 0xF84, 0));
                Add(new GenericBuyInfo(typeof(Ginseng), 1, 20, 0xF85, 0));
                Add(new GenericBuyInfo(typeof(MandrakeRoot), 1, 20, 0xF86, 0));
                Add(new GenericBuyInfo(typeof(Nightshade), 1, 20, 0xF88, 0));
                Add(new GenericBuyInfo(typeof(SpidersSilk), 1, 20, 0xF8D, 0));
                Add(new GenericBuyInfo(typeof(SulfurousAsh), 1, 20, 0xF8C, 0));

                if (Core.AOS)
                {
                    Add(new GenericBuyInfo(typeof(BatWing), 2, 999, 0xF78, 0));
                    Add(new GenericBuyInfo(typeof(DaemonBlood), 2, 999, 0xF7D, 0));
                    Add(new GenericBuyInfo(typeof(PigIron), 2, 999, 0xF8A, 0));
                    Add(new GenericBuyInfo(typeof(NoxCrystal), 2, 999, 0xF8E, 0));
                    Add(new GenericBuyInfo(typeof(GraveDust), 2, 999, 0xF8F, 0));
                }

				Add( new GenericBuyInfo( "Bouteille", typeof( Bottle ), 5, 100, 0xF0E, 0 ) ); 
				Add( new GenericBuyInfo( "Pied de chauffage", typeof( HeatingStand ), 2, 100, 0x1849, 0 ) ); 

				Add( new GenericBuyInfo( "Colorant à Cheveux", typeof( HairDye ), 37, 10, 0xEFF, 0 ) );
                Add( new GenericBuyInfo( "Encre à Tatouage", typeof( TatooDye ), 37, 10, 0xEFF, 0));

				//Add( new GenericBuyInfo( typeof( HeatingStand ), 2, 100, 0x1849, 0 ) ); // This is on OSI :-P


			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( BlackPearl ), 1); 
				Add( typeof( Bloodmoss ), 1 ); 
				Add( typeof( MandrakeRoot ), 1 ); 
				Add( typeof( Garlic ), 1 ); 
				Add( typeof( Ginseng ), 1 ); 
				Add( typeof( Nightshade ), 1 ); 
				Add( typeof( SpidersSilk ), 1 ); 
				Add( typeof( SulfurousAsh ), 1 ); 
				Add( typeof( Bottle ), 1 );
				Add( typeof( MortarPestle ), 1 );
				Add( typeof( HairDye ), 2 );
                Add( typeof( TatooDye), 2 );

                if (Core.AOS)
                {
                    Add(typeof(BatWing), 1);
                    Add(typeof(DaemonBlood), 1);
                    Add(typeof(PigIron), 1);
                    Add(typeof(NoxCrystal), 1);
                    Add(typeof(GraveDust), 1);
                }


			/*	Add( typeof( NightSightPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( LesserExplosionPotion ), 10 );*/
			}
		}
	}
}
