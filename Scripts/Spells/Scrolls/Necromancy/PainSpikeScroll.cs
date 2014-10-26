using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PainSpikeScroll : SpellScroll
	{
		[Constructable]
		public PainSpikeScroll() : this( 1 )
		{
		}

		[Constructable]
        public PainSpikeScroll(int amount)
            : base(PainSpikeSpell.m_SpellID, 0x2268, amount)
		{
            Name = "Nécromancie: Corruption";
		}

		public PainSpikeScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Corruption";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new PainSpikeScroll( amount ), amount );
		}*/
	}
}