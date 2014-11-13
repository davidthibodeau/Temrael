using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    public abstract class BookCaseContainer : LockableContainer
    {
        private bool m_CanModifyBooks;

        [CommandProperty(AccessLevel.Batisseur)]
        public bool CanModifyBooks
        {
            get
            {
                return m_CanModifyBooks;
            }
            set
            {
                m_CanModifyBooks = value;
            }
        }

        public override bool CheckItemUse(Mobile from, Item item)
        {

            if (item is BaseBook)
            {
                if (CanModifyBooks)
                {
                    ((BaseBook)item).Writable = true;
                }
                else
                {
                    ((BaseBook)item).Writable = false;
                }
            }
            else if (!base.CheckItemUse(from, item))
            {
                return false;
            }


            return true;
        }



        public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version

			writer.Write( m_CanModifyBooks );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            m_CanModifyBooks = reader.ReadBool();
		}

		public BookCaseContainer( int itemID ) 
            :  base( itemID )
		{
            m_CanModifyBooks = true;
		}

        public BookCaseContainer(Serial serial)
            : base(serial)
		{
            m_CanModifyBooks = true;
		}

    }
}
