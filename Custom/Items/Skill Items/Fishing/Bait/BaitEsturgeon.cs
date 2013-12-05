using System;

namespace Server.Items
{
    public class BaitEsturgeon : BaseBait
	{
		[Constructable]
		public BaitEsturgeon() : this( 20 )
		{
		}

		[Constructable]
		public BaitEsturgeon( int charge ) : base( Bait.Esturgeon, charge )
		{
		}

		public BaitEsturgeon( Serial serial ) : base( serial )
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