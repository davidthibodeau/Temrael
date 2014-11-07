using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class CunningScroll : SpellScroll
	{
		[Constructable]
		public CunningScroll() : this( 1 )
		{
		}

		[Constructable]
		public CunningScroll( int amount ) : base( CunningSpell.m_SpellID, 0x1F36, amount )
		{
            Name = "Providence: Ruse";
		}

		public CunningScroll( Serial serial ) : base( serial )
		{
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
	}
}