using System;
using System.Collections.Generic;
using Server;
using Server.Multis;
using Server.Network;

namespace Server.Items
{
	[Furniture]
	[Flipable( 0x188E, 0x188F )]
	public class ArmoireA : BaseContainer
	{
		[Constructable]
		public ArmoireA() : base( 0x188E)
		{
			Weight = 5.0;
		}

		public ArmoireA( Serial serial ) : base( serial )
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
	
	[Furniture]
	[Flipable( 0x1892, 0x189C )]
	public class ArmoireB : BaseContainer
	{
		[Constructable]
		public ArmoireB() : base( 0x1892)
		{
			Weight = 5.0;
		}

		public ArmoireB( Serial serial ) : base( serial )
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