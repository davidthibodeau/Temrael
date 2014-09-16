using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class NightSightScroll : SpellScroll
	{
		[Constructable]
		public NightSightScroll() : this( 1 )
		{
		}

		[Constructable]
		public NightSightScroll( int amount ) : base( NightSightSpell.spellID, 0x1F33, amount )
		{
            Name = "Illusion: Vision Nocturne";
		}

		public NightSightScroll( Serial ser ) : base(ser)
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

            Name = "Illusion: Vision Nocturne";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new NightSightScroll( amount ), amount );
		}*/
	}
}