using System;

namespace Server.Items
{
    public class BaitMorue : BaseBait
	{
		[Constructable]
		public BaitMorue() : this( 20 )
		{
		}

		[Constructable]
		public BaitMorue( int charge ) : base( Bait.Morue, charge )
		{
		}

		public BaitMorue( Serial serial ) : base( serial )
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