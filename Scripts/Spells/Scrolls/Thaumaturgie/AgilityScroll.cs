using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class AgilityScroll : SpellScroll
	{
		[Constructable]
		public AgilityScroll() : this( 1 )
		{
		}

		[Constructable]
		public AgilityScroll( int amount ) : base( AgilitySpell.m_SpellID, 0x1F35, amount )
		{
            Name = "Thaumaturgie: Agilité";
		}

		public AgilityScroll( Serial serial ) : base( serial )
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

            Name = "Thaumaturgie: Agilité";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new AgilityScroll( amount ), amount );
		}*/
	}
}