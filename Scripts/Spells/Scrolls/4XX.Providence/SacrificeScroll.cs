using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class SacrificeScroll : SpellScroll
	{
		[Constructable]
		public SacrificeScroll() : this( 1 )
		{
		}

		[Constructable]
		public SacrificeScroll( int amount ) : base( SacrificeSpell.m_SpellID, 0x1F3B, amount )
		{
            Name = "Providence: Sacrifice";
		}

		public SacrificeScroll( Serial serial ) : base( serial )
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