using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class EnergyFieldScroll : SpellScroll
	{
		[Constructable]
		public EnergyFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public EnergyFieldScroll( int amount ) : base( 50, 0x1F5E, amount )
		{
            Name = "Évocation: Énergie de Masse";
		}

		public EnergyFieldScroll( Serial serial ) : base( serial )
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

            Name = "Évocation: Énergie de Masse";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new EnergyFieldScroll( amount ), amount );
		}*/
	}
}