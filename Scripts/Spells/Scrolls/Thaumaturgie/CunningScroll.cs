using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class CunningScroll : SpellScroll
	{
		[Constructable]
		public CunningScroll() : this( 1 )
		{
		}

		[Constructable]
		public CunningScroll( int amount ) : base( CunningSpell.m_SpellID, 0x1F36, amount )
		{
            Name = "Thaumaturgie: Ruse";
		}

		public CunningScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Ruse";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new CunningScroll( amount ), amount );
		}*/
	}
}