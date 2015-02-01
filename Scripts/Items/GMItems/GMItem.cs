using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    // Cette classe est la base de tous les items spéciaux qui ne doivent pas être transportés par les joueurs.
    // e.g. creationstone, gmrobe, etc.
    public abstract class GMItem : Item
    {
        public GMItem(int itemID)
            : base(itemID)
        {
            // Ces items peuvent pas etre statiqués/déstatiqués.
            CanBeAltered = false;
            // Les GMItems peuvent pas etre voles.
            LootType = LootType.Blessed;
        }

        public GMItem(Serial serial)
            : base(serial)
        {
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
    }
}
