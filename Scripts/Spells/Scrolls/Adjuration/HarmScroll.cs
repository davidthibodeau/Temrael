using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class HarmScroll : SpellScroll
	{
		[Constructable]
		public HarmScroll() : this( 1 )
		{
		}

		[Constructable]
		public HarmScroll( int amount ) : base( HarmSpell.spellID, 0x1F38, amount )
		{
            Name = "Adjuration: Nuissance";
		}

		public HarmScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Nuissance";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new HarmScroll( amount ), amount );
		}*/
	}
}