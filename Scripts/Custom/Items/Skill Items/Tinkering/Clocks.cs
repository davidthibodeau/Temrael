using System;
using Server;
using Server.Misc;

namespace Server.Items
{
	[Flipable( 0x104B, 0x104C )]
	public class Clock : Item
	{

		[Constructable]
		public Clock() : this( 0x104B )
		{
		}

		[Constructable]
		public Clock( int itemID ) : base( itemID )
		{
			Weight = 3.0;
		}

		public Clock( Serial serial ) : base( serial )
		{
		}

        public override void OnDoubleClick(Mobile from)
        {
            LabelTo(from, Time.GetExactTime());
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

			if ( Weight == 2.0 )
				Weight = 3.0;
		}
	}

	[Flipable( 0x104B, 0x104C )]
	public class ClockRight : Clock
	{
		[Constructable]
		public ClockRight() : base( 0x104B )
		{
		}

		public ClockRight( Serial serial ) : base( serial )
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

	[Flipable( 0x104B, 0x104C )]
	public class ClockLeft : Clock
	{
		[Constructable]
		public ClockLeft() : base( 0x104C )
		{
		}

		public ClockLeft( Serial serial ) : base( serial )
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