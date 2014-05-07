using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ResurrectionScroll : SpellScroll
	{
		[Constructable]
		public ResurrectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ResurrectionScroll( int amount ) : base( 59, 0x1F67, amount )
		{
            Name = "Thaumaturgie: Resurrection";
		}

		public ResurrectionScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Resurrection";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ResurrectionScroll( amount ), amount );
		}*/
	}
}