using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MagicReflectScroll : SpellScroll
	{
		[Constructable]
		public MagicReflectScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicReflectScroll( int amount ) : base( 36, 0x1F50, amount )
		{
            Name = "Altération: Reflet";
		}

		public MagicReflectScroll( Serial serial ) : base( serial )
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

            Name = "Altération: Reflet";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MagicReflectScroll( amount ), amount );
		}*/
	}
}