using System;

namespace Server.Items
{
    public class BaitAnguille : BaseBait
	{
		[Constructable]
		public BaitAnguille() : this( 20 )
		{
		}

		[Constructable]
		public BaitAnguille( int charge ) : base( Bait.Anguille, charge )
		{
		}

		public BaitAnguille( Serial serial ) : base( serial )
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