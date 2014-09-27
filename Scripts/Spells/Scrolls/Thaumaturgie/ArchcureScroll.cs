using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ArchCureScroll : SpellScroll
	{
		[Constructable]
		public ArchCureScroll() : this( 1 )
		{
		}

		[Constructable]
		public ArchCureScroll( int amount ) : base( ArchCureSpell.m_SpellID, 0x1F45, amount )
		{
            Name = "Thaumaturgie: Remède";
		}

		public ArchCureScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Remède";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ArchCureScroll( amount ), amount );
		}*/
	}
}