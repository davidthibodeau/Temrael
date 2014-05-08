using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class SummonWaterElementalScroll : SpellScroll
	{
		[Constructable]
		public SummonWaterElementalScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonWaterElementalScroll( int amount ) : base( 64, 0x1F6C, amount )
		{
            Name = "Invocation: Élémental d'Eau";
		}

		public SummonWaterElementalScroll( Serial serial ) : base( serial )
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

            Name = "Invocation: Élémental d'Eau";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new SummonWaterElementalScroll( amount ), amount );
		}*/
	}
}