using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class StrengthScroll : SpellScroll
	{
		[Constructable]
		public StrengthScroll() : this( 1 )
		{
		}

		[Constructable]
		public StrengthScroll( int amount ) : base( 16, 0x1F3C, amount )
		{
            Name = "Thaumaturgie: Force";
		}

		public StrengthScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Force";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new StrengthScroll( amount ), amount );
		}*/
	}
}