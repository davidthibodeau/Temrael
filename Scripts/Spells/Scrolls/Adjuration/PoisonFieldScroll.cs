using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PoisonFieldScroll : SpellScroll
	{
		[Constructable]
		public PoisonFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public PoisonFieldScroll( int amount ) : base( PoisonFieldSpell.spellID, 0x1F53, amount )
		{
            Name = "Adjuration: Mur de Poison";
		}

		public PoisonFieldScroll( Serial serial ) : base( serial )
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

            Name = "Adjuration: Mur de Poison";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new PoisonFieldScroll( amount ), amount );
		}*/
	}
}