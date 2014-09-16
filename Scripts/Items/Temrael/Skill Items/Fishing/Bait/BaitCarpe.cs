using System;

namespace Server.Items
{
    public class BaitCarpe : BaseBait
	{
		[Constructable]
		public BaitCarpe() : this( 20 )
		{
		}

		[Constructable]
		public BaitCarpe( int charge ) : base( Bait.Carpe, charge )
		{
		}

		public BaitCarpe( Serial serial ) : base( serial )
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