using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class EvilOmenScroll : SpellScroll
	{
		[Constructable]
		public EvilOmenScroll() : this( 1 )
		{
		}

		[Constructable]
		public EvilOmenScroll( int amount ) : base( EvilOmenSpell.m_SpellID, 0x2264, amount )
		{
            Name = "Nécromancie: Présage";
		}

		public EvilOmenScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Présage";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new EvilOmenScroll( amount ), amount );
		}*/
	}
}