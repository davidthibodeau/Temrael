using System;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
	public class Arrow : Item, ICommodity
	{
        public override int GoldValue { get { return 2; } }

		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Arrow() : this( 1 )
		{
		}

		[Constructable]
		public Arrow( int amount ) : base( 0xF3F )
		{
			Stackable = true;
			Amount = amount;
		}

		public Arrow( Serial serial ) : base( serial )
		{
		}

        #region Tranformer Bolts en arrow.
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (from.Backpack.Items.Contains(this))
            {
                list.Add(new TranformerArrowEntry(from, this));
            }
        }

        private class TranformerArrowEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private Item m_Item;

            public TranformerArrowEntry(Mobile from, Item item)
                : base(6285, -1)
            {
                m_From = (Mobile)from;
                m_Item = (Item)item;
            }

            public override void OnClick()
            {
                m_From.AddToBackpack(new Bolt(m_Item.Amount));
                m_Item.Delete();
            }
        }
        #endregion

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