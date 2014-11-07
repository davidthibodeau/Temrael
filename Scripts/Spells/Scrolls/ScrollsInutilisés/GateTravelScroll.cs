using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class GateTravelScroll : SpellScroll
	{
		[Constructable]
		public GateTravelScroll() : this( 1 )
		{
		}

		[Constructable]
		public GateTravelScroll( int amount ) : base( GateTravelSpell.m_SpellID, 0x1F60, amount )
		{
            Name = "Illusion: Voyagement";
		}

		public GateTravelScroll( Serial serial ) : base( serial )
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

            Name = "Illusion: Voyagement";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new GateTravelScroll( amount ), amount );
		}*/
	}
}