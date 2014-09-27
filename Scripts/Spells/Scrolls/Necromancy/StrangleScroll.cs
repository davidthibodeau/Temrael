using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class StrangleScroll : SpellScroll
	{
		[Constructable]
		public StrangleScroll() : this( 1 )
		{
		}

		[Constructable]
        public StrangleScroll(int amount)
            : base(StrangleSpell.m_SpellID, 0x226A, amount)
		{
            Name = "Nécromancie: Étranglement";
		}

		public StrangleScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Étranglement";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new StrangleScroll( amount ), amount );
		}*/
	}
}