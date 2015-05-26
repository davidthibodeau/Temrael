using System;
using Server.ContextMenus;
using System.Collections.Generic;

namespace Server.Items
{
	public class Bolt : Item, ICommodity
	{
        public override int GoldValue { get { return 2; } }

		int ICommodity.DescriptionNumber { get { return LabelNumber; } }
		bool ICommodity.IsDeedable { get { return true; } }

		public override double DefaultWeight
		{
			get { return 0.1; }
		}

        #region Tranformer Bolts en arrow.
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);

            if (from.Backpack.Items.Contains(this))
            {
                list.Add(new TranformerBoltEntry(from, this));
            }
        }

        private class TranformerBoltEntry : ContextMenuEntry
        {
            private Mobile m_From;
            private Item m_Item;

            public TranformerBoltEntry(Mobile from, Item item)
                : base(6285, -1)
            {
                m_From = (Mobile)from;
                m_Item = (Item)item;
            }

            public override void OnClick()
            {
                m_From.AddToBackpack(new Arrow(m_Item.Amount));
                m_Item.Delete();
            }
        }
        #endregion

        [Constructable]
		public Bolt() : this( 1 )
		{
		}

		[Constructable]
		public Bolt( int amount ) : base( 0x1BFB )
		{
			Stackable = true;
			Amount = amount;
		}

		public Bolt( Serial serial ) : base( serial )
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