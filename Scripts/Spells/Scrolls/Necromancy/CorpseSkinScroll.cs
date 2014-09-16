using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class CorpseSkinScroll : SpellScroll
	{
		[Constructable]
		public CorpseSkinScroll() : this( 1 )
		{
		}

		[Constructable]
		public CorpseSkinScroll( int amount ) : base( CorpseSkinSpell.spellID, 0x2262, amount )
		{
            Name = "Nécromancie: Corps Mortifié";
		}

		public CorpseSkinScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Corps Mortifié";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new CorpseSkinScroll( amount ), amount );
		}*/
	}
}