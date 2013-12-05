using System;

namespace Server.Items
{
    public class BaitThon : BaseBait
	{
		[Constructable]
		public BaitThon() : this( 20 )
		{
		}

		[Constructable]
		public BaitThon( int charge ) : base( Bait.Thon, charge )
		{
		}

		public BaitThon( Serial serial ) : base( serial )
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