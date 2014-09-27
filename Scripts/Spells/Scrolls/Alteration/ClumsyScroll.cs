using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ClumsyScroll : SpellScroll
	{
		[Constructable]
		public ClumsyScroll() : this( 1 )
		{
		}

		[Constructable]
		public ClumsyScroll( int amount ) : base( ClumsySpell.m_SpellID, 0x1F2E, amount )
		{
            Name = "Altération: Maladroit";
		}

		public ClumsyScroll( Serial serial ) : base( serial )
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

            Name = "Altération: Maladroit";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ClumsyScroll( amount ), amount );
		}*/
	}
}