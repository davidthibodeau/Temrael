using System;

namespace Server.Items
{
    public class BaitFletan : BaseBait
	{
		[Constructable]
		public BaitFletan() : this( 20 )
		{
		}

		[Constructable]
		public BaitFletan( int charge ) : base( Bait.Fletan, charge )
		{
		}

		public BaitFletan( Serial serial ) : base( serial )
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