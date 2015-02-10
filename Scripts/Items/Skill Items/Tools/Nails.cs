using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	[Flipable( 0x102E, 0x102F )]
	public class Nails : Item
	{
        public override int GoldValue { get { return 3; } }

		[Constructable]
		public Nails() : base( 0x102E )
		{
            Weight = 0.1;
		}

		public Nails( Serial serial ) : base( serial )
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