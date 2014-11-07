using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class HealScroll : SpellScroll
	{
		[Constructable]
		public HealScroll() : this( 1 )
		{
		}

		[Constructable]
		public HealScroll( int amount ) : base( HealSpell.m_SpellID, 0x1F31, amount )
		{
            Name = "Thaumaturgie: Soins";
		}

        public HealScroll(Serial serial)
            : base(serial)
        {
        }
	}
}