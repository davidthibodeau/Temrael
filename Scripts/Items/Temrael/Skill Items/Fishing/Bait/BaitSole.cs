using System;

namespace Server.Items
{
    public class BaitSole : BaseBait
	{
		[Constructable]
		public BaitSole() : this( 20 )
		{
		}

		[Constructable]
		public BaitSole( int charge ) : base( Bait.Sole, charge )
		{
		}

		public BaitSole( Serial serial ) : base( serial )
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