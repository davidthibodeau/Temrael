using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class LichFormScroll : SpellScroll
	{
		[Constructable]
		public LichFormScroll() : this( 1 )
		{
		}

		[Constructable]
		public LichFormScroll( int amount ) : base( LichFormSpell.spellID , 0x2266, amount )
		{
            Name = "Nécromancie: Liche";
		}

		public LichFormScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Liche";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new LichFormScroll( amount ), amount );
		}*/
	}
}