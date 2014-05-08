using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class ArchProtectionScroll : SpellScroll
	{
		[Constructable]
		public ArchProtectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ArchProtectionScroll( int amount ) : base( 26, 0x1F46, amount )
		{
            Name = "Thaumaturgie: Protection Magique";
		}

		public ArchProtectionScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Protection Magique";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ArchProtectionScroll( amount ), amount );
		}*/
	}
}