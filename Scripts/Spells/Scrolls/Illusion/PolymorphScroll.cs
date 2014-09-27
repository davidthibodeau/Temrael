using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PolymorphScroll : SpellScroll
	{
		[Constructable]
		public PolymorphScroll() : this( 1 )
		{
		}

		[Constructable]
		public PolymorphScroll( int amount ) : base( PolymorphSpell.m_SpellID, 0x1F64, amount )
		{
            Name = "Illusion: Polymorph";
		}

		public PolymorphScroll( Serial serial ) : base( serial )
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

            Name = "Illusion: Polymorph";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new PolymorphScroll( amount ), amount );
		}*/
	}
}