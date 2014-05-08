using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class MeteorSwarmScroll : SpellScroll
	{
		[Constructable]
		public MeteorSwarmScroll() : this( 1 )
		{
		}

		[Constructable]
		public MeteorSwarmScroll( int amount ) : base( 55, 0x1F63, amount )
		{
            Name = "Évocation: Météores";
		}

		public MeteorSwarmScroll( Serial serial ) : base( serial )
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

            Name = "Évocation: Météores";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MeteorSwarmScroll( amount ), amount );
		}*/
	}
}