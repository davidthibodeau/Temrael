using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBHealer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBHealer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Bandage", typeof( Bandage ), 1, 20, 0xE21, 0 ) );
                Add(new GenericBuyInfo("Grimoire", typeof(NewDivineSpellbook), 50, 20, 0xE21, 0));
				//Add( new GenericBuyInfo( "Potion de Soins Mineur", typeof( LesserHealPotion ), 30, 20, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Ginseng", typeof( Ginseng ), 3, 20, 0xF85, 0 ) );
				Add( new GenericBuyInfo( "Garlic", typeof( Garlic ), 3, 20, 0xF84, 0 ) );
				//Add( new GenericBuyInfo( "Potion de Rafraichissement", typeof( RefreshPotion ), 25, 20, 0xF0B, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Bandage ), 1 );
				Add( typeof( LesserHealPotion ), 1 );
				Add( typeof( RefreshPotion ), 1 );
				Add( typeof( Garlic ), 1 );
				Add( typeof( Ginseng ), 1 );
			}
		}
	}
}