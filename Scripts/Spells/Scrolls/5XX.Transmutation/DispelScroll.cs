using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class DispelScroll : SpellScroll
	{
		[Constructable]
		public DispelScroll() : this( 1 )
		{
		}

		[Constructable]
        public DispelScroll(int amount) : base(DispelSpell.m_SpellID, 0x1F55, amount)
		{
            Name = "Transmutation: Dissipation";
		}

		public DispelScroll( Serial serial ) : base( serial )
		{
		}
	}
}