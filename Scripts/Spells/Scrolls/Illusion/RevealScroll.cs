using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class RevealScroll : SpellScroll
	{
		[Constructable]
		public RevealScroll() : this( 1 )
		{
		}

		[Constructable]
		public RevealScroll( int amount ) : base( RevealSpell.m_SpellID, 0x1F5C, amount )
		{
            Name = "Illusion: Révélation";
		}

		public RevealScroll( Serial serial ) : base( serial )
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

            Name = "Illusion: Révélation";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new RevealScroll( amount ), amount );
		}*/
	}
}