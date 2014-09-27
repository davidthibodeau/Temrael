using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class DispelScroll : SpellScroll
	{
		[Constructable]
		public DispelScroll() : this( 1 )
		{
		}

		[Constructable]
        public DispelScroll(int amount) : base(DispelSpell.m_SpellID, 0x1F55, amount)
		{
            Name = "Adjuration: Dissipation";
		}

		public DispelScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Dissipation";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new DispelScroll( amount ), amount );
		}*/
	}
}