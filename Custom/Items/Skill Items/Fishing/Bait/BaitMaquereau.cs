using System;

namespace Server.Items
{
    public class BaitMaquereau : BaseBait
	{
		[Constructable]
		public BaitMaquereau() : this( 20 )
		{
		}

		[Constructable]
		public BaitMaquereau( int charge ) : base( Bait.Maquereau, charge )
		{
		}

		public BaitMaquereau( Serial serial ) : base( serial )
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