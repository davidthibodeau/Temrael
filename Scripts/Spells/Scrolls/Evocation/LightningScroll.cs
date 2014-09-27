using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class LightningScroll : SpellScroll
	{
		[Constructable]
		public LightningScroll() : this( 1 )
		{
		}

		[Constructable]
		public LightningScroll( int amount ) : base( LightningSpell.m_SpellID, 0x1F4A, amount )
		{
            Name = "Évocation: Éclair";
		}

		public LightningScroll( Serial serial ) : base( serial )
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

            Name = "Évocation: Éclair";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new LightningScroll( amount ), amount );
		}*/
	}
}