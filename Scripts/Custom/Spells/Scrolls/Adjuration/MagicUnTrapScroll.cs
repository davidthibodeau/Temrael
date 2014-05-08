using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MagicUnTrapScroll : SpellScroll
	{
		[Constructable]
		public MagicUnTrapScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicUnTrapScroll( int amount ) : base( 14, 0x1F3A, amount )
		{
            Name = "Adjuration: Supreesion de Pi�ge";
		}

		public MagicUnTrapScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Supreesion de Pi�ge";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MagicUnTrapScroll( amount ), amount );
		}*/
	}
}