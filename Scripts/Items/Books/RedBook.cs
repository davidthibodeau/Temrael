using System;
using Server;

namespace Server.Items
{
	public class RedBook : BaseBook
	{
		[Constructable]
		public RedBook() : base( 0xFF1 )
		{
            GoldValue = 6;
		}

		[Constructable]
		public RedBook( int pageCount, bool writable ) : base( 0xFF1, pageCount, writable )
		{
            GoldValue = 6;
		}

		[Constructable]
		public RedBook( string title, string author, int pageCount, bool writable ) : base( 0xFF1, title, author, pageCount, writable )
		{
            GoldValue = 6;
		}

		// Intended for defined books only
		public RedBook( bool writable ) : base( 0xFF1, writable )
		{
            GoldValue = 6;
		}

		public RedBook( Serial serial ) : base( serial )
		{
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version
		}
	}
}