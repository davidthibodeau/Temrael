using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class WallOfStoneScroll : SpellScroll
	{
		[Constructable]
		public WallOfStoneScroll() : this( 1 )
		{
		}

		[Constructable]
		public WallOfStoneScroll( int amount ) : base( WallOfStoneSpell.spellID, 0x1F44, amount )
		{
            Name = "Invocation: Mur de Pierre";
		}

		public WallOfStoneScroll( Serial serial ) : base( serial )
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

            Name = "Invocation: Mur de Pierre";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new WallOfStoneScroll( amount ), amount );
		}*/
	}
}