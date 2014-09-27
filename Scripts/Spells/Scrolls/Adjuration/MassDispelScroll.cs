using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MassDispelScroll : SpellScroll
	{
		[Constructable]
		public MassDispelScroll() : this( 1 )
		{
		}

		[Constructable]
		public MassDispelScroll( int amount ) : base( MassDispelSpell.m_SpellID, 0x1F62, amount )
		{
            Name = "Adjuration: Dissipation de Masse";
		}

		public MassDispelScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Dissipation de Masse";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MassDispelScroll( amount ), amount );
		}*/
	}
}