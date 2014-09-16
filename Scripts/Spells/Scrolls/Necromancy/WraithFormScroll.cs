using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class WraithFormScroll : SpellScroll
	{
		[Constructable]
		public WraithFormScroll() : this( 1 )
		{
		}

		[Constructable]
		public WraithFormScroll( int amount ) : base( WraithFormSpell.spellID, 0x226F, amount )
		{
            Name = "Nécromancie: Spectre";
		}

		public WraithFormScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Spectre";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new WraithFormScroll( amount ), amount );
		}*/
	}
}