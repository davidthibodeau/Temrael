using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class FlamestrikeScroll : SpellScroll
	{
		[Constructable]
		public FlamestrikeScroll() : this( 1 )
		{
		}

		[Constructable]
		public FlamestrikeScroll( int amount ) : base( FlameStrikeSpell.m_SpellID, 0x1F5F, amount )
		{
            Name = "Évocation: Jeu de Flamme";
		}

		public FlamestrikeScroll( Serial serial ) : base( serial )
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

            Name = "Évocation: Jeu de Flamme";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new FlamestrikeScroll( amount ), amount );
		}*/
	}
}