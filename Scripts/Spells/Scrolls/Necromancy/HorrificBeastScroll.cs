using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class HorrificBeastScroll : SpellScroll
	{
		[Constructable]
		public HorrificBeastScroll() : this( 1 )
		{
		}

		[Constructable]
		public HorrificBeastScroll( int amount ) : base( HorrificBeastSpell.m_SpellID, 0x2265, amount )
		{
            Name = "Nécromancie: Bête Horrifique";
		}

		public HorrificBeastScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Bête Horrifique";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new HorrificBeastScroll( amount ), amount );
		}*/
	}
}