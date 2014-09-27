using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MassCurseScroll : SpellScroll
	{
		[Constructable]
		public MassCurseScroll() : this( 1 )
		{
		}

		[Constructable]
		public MassCurseScroll( int amount ) : base( MassCurseSpell.m_SpellID, 0x1F5A, amount )
		{
            Name = "Altération: Fléau";
		}

		public MassCurseScroll( Serial serial ) : base( serial )
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

            Name = "Altération: Fléau";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MassCurseScroll( amount ), amount );
		}*/
	}
}