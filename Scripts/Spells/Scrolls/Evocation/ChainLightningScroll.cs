using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ChainLightningScroll : SpellScroll
	{
		[Constructable]
		public ChainLightningScroll() : this( 1 )
		{
		}

		[Constructable]
		public ChainLightningScroll( int amount ) : base( ChainLightningSpell.m_SpellID, 0x1F5D, amount )
		{
            Name = "Évocation: Chaîne d'Éclairs";
		}

		public ChainLightningScroll( Serial serial ) : base( serial )
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

            Name = "Évocation: Chaîne d'Éclairs";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new ChainLightningScroll( amount ), amount );
		}*/
	}
}