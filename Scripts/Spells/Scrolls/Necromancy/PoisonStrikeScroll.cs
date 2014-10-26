using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PoisonStrikeScroll : SpellScroll
	{
		[Constructable]
		public PoisonStrikeScroll() : this( 1 )
		{
		}

		[Constructable]
        public PoisonStrikeScroll(int amount)
            : base(PoisonStrikeSpell.m_SpellID, 0x2269, amount)
		{
            Name = "Nécromancie: Venin";
		}

		public PoisonStrikeScroll( Serial serial ) : base( serial )
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

            Name = "Nécromancie: Venin";
		}

		/*public override Item Dupe( int amount )
		{
			return base.Dupe( new PoisonStrikeScroll( amount ), amount );
		}*/
	}
}