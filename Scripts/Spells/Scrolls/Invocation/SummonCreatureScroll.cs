using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class SummonCreatureScroll : SpellScroll
	{
		[Constructable]
		public SummonCreatureScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonCreatureScroll( int amount ) : base( SummonCreatureSpell.spellID, 0x1F54, amount )
		{
            Name = "Invocation: Convocation";
		}

		public SummonCreatureScroll( Serial serial ) : base( serial )
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

            Name = "Invocation: Convocation";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new SummonCreatureScroll( amount ), amount );
		}*/
	}
}