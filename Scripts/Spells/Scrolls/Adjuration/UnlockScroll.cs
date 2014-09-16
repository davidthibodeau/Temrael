using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class UnlockScroll : SpellScroll
	{
		[Constructable]
		public UnlockScroll() : this( 1 )
		{
		}

		[Constructable]
		public UnlockScroll( int amount ) : base( 23, 0x1F43, amount )
		{
            Name = "Adjuration: Ouverture Magique";
		}

		public UnlockScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Ouverture Magique";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new UnlockScroll( amount ), amount );
		}*/
	}
}