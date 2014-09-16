using System;

namespace Server.Items
{
    public class BaitDore : BaseBait
	{
		[Constructable]
		public BaitDore() : this( 20 )
		{
		}

		[Constructable]
		public BaitDore( int charge ) : base( Bait.Dore, charge )
		{
		}

		public BaitDore( Serial serial ) : base( serial )
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