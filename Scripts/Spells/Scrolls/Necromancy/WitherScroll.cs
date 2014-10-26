using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class WitherScroll : SpellScroll
	{
		[Constructable]
		public WitherScroll() : this( 1 )
		{
		}

		[Constructable]
        public WitherScroll(int amount)
            : base(WitherSpell.m_SpellID, 0x226E, amount)
		{
            Name = "Nécromancie: Flétrir";
		}

		public WitherScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Flétrir";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new WitherScroll( amount ), amount );
		}*/
	}
}