using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class TelekinisisScroll : SpellScroll
	{
		[Constructable]
		public TelekinisisScroll() : this( 1 )
		{
		}

		[Constructable]
		public TelekinisisScroll( int amount ) : base( TelekinesisSpell.m_SpellID, 0x1F41, amount )
		{
            Name = "Altération: Télékinesis";
		}

		public TelekinisisScroll( Serial serial ) : base( serial )
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

            Name = "Altération: Télékinesis";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new TelekinisisScroll( amount ), amount );
		}*/
	}
}