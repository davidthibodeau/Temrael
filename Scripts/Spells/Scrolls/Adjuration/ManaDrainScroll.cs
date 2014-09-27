using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ManaDrainScroll : SpellScroll
	{
		[Constructable]
		public ManaDrainScroll() : this( 1 )
		{
		}

		[Constructable]
		public ManaDrainScroll( int amount ) : base( ManaDrainSpell.m_SpellID, 0x1F4B, amount )
		{
            Name = "Adjuration: Drain de Mana";
		}

		public ManaDrainScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Drain de Mana";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ManaDrainScroll( amount ), amount );
		}*/
	}
}