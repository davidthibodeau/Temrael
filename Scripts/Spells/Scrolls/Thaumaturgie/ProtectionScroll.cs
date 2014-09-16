using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ProtectionScroll : SpellScroll
	{
		[Constructable]
		public ProtectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ProtectionScroll( int amount ) : base( ProtectionSpell.spellID, 0x1F3B, amount )
		{
            Name = "Thaumaturgie: Protection";
		}

		public ProtectionScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Protection";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ProtectionScroll( amount ), amount );
		}*/
	}
}