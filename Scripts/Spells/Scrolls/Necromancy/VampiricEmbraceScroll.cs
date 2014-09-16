using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class VampiricEmbraceScroll : SpellScroll
	{
		[Constructable]
		public VampiricEmbraceScroll() : this( 1 )
		{
		}

		[Constructable]
		public VampiricEmbraceScroll( int amount ) : base( VampiricEmbraceSpell.spellID, 0x226C, amount )
		{
            Name = "Nécromancie: Vampirisme";
		}

		public VampiricEmbraceScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Vampirisme";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new VampiricEmbraceScroll( amount ), amount );
		}*/
	}
}