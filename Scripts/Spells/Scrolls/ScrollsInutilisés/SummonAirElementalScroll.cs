using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class SummonAirElementalScroll : SpellScroll
	{
		[Constructable]
		public SummonAirElementalScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonAirElementalScroll( int amount ) : base( AirElementalSpell.m_SpellID, 0x1F68, amount )
		{
            Name = "Invocation: Élémental d'Air";
		}

		public SummonAirElementalScroll( Serial serial ) : base( serial )
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

            Name = "Invocation: Élémental d'Air";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new SummonAirElementalScroll( amount ), amount );
		}*/
	}
}