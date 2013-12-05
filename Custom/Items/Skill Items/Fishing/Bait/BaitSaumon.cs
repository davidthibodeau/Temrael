using System;

namespace Server.Items
{
    public class BaitSaumon : BaseBait
	{
		[Constructable]
		public BaitSaumon() : this( 20 )
		{
		}

		[Constructable]
		public BaitSaumon( int charge ) : base( Bait.Saumon, charge )
		{
		}

		public BaitSaumon( Serial serial ) : base( serial )
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