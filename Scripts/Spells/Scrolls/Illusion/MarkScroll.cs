using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MarkScroll : SpellScroll
	{
		[Constructable]
		public MarkScroll() : this( 1 )
		{
		}

		[Constructable]
		public MarkScroll( int amount ) : base( MarkSpell.spellID, 0x1F59, amount )
		{
            Name = "Illusion: Marque";
		}

		public MarkScroll( Serial serial ) : base( serial )
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

            Name = "Illusion: Marque";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MarkScroll( amount ), amount );
		}*/
	}
}