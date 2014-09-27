using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class InvisibilityScroll : SpellScroll
	{
		[Constructable]
		public InvisibilityScroll() : this( 1 )
		{
		}

		[Constructable]
		public InvisibilityScroll( int amount ) : base( InvisibilitySpell.m_SpellID, 0x1F58, amount )
		{
            Name = "Illusion: Invisibilité";
		}

		public InvisibilityScroll( Serial serial ) : base( serial )
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

            Name = "Illusion: Invisibilité";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new InvisibilityScroll( amount ), amount );
		}*/
	}
}