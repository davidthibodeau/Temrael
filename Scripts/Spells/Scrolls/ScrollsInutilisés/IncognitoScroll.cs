using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class IncognitoScroll : SpellScroll
	{
		[Constructable]
		public IncognitoScroll() : this( 1 )
		{
		}

		[Constructable]
		public IncognitoScroll( int amount ) : base( IncognitoSpell.m_SpellID, 0x1F4F, amount )
		{
            Name = "Illusion: Incognito";
		}

		public IncognitoScroll( Serial serial ) : base( serial )
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

            Name = "Illusion: Incognito";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new IncognitoScroll( amount ), amount );
		}*/
	}
}