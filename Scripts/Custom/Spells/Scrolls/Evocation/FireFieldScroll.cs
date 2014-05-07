using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class FireFieldScroll : SpellScroll
	{
		[Constructable]
		public FireFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public FireFieldScroll( int amount ) : base( 28, 0x1F48, amount )
		{
            Name = "Evocation: Mur de Feu";
		}

		public FireFieldScroll( Serial serial ) : base( serial )
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

            Name = "Evocation: Mur de Feu";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new FireFieldScroll( amount ), amount );
		}*/
	}
}