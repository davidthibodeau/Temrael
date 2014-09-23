using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ParalyzeFieldScroll : SpellScroll
	{
		[Constructable]
		public ParalyzeFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public ParalyzeFieldScroll( int amount ) : base( ParalyzeFieldSpell.spellID, 0x1F5B, amount )
		{
            Name = "Alt�ration: P�trification";
		}

		public ParalyzeFieldScroll( Serial serial ) : base( serial )
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

            Name = "Alt�ration: P�trification";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ParalyzeFieldScroll( amount ), amount );
		}*/
	}
}