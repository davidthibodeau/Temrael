using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MindRotScroll : SpellScroll
	{
		[Constructable]
		public MindRotScroll() : this( 1 )
		{
		}

		[Constructable]
		public MindRotScroll( int amount ) : base( MindRotSpell.spellID, 0x2267, amount )
		{
            Name = "Nécromancie: Pourriture";
		}

		public MindRotScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Pourriture";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new MindRotScroll( amount ), amount );
		}*/
	}
}