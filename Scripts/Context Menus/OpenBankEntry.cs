using System;
using Server.Items;

namespace Server.ContextMenus
{
	public class OpenBankEntry : ContextMenuEntry
	{
		private Mobile m_Banker;

		public OpenBankEntry( Mobile from, Mobile banker ) : base( 6105, 12 )
		{
			m_Banker = banker;
		}

		public override void OnClick()
		{
			if ( !Owner.From.CheckAlive() )
				return;

				Owner.From.BankBox.Open();
		}
	}
}