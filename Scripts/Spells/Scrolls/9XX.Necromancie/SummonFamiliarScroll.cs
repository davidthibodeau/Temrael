using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class SummonFamiliarScroll : SpellScroll
	{
		[Constructable]
		public SummonFamiliarScroll() : this( 1 )
		{
		}

		[Constructable]
        public SummonFamiliarScroll(int amount)
            : base(SummonFamiliarSpell.m_SpellID, 0x226B, amount)
		{
            Name = "Nécromancie: Minion";
		}

		public SummonFamiliarScroll( Serial serial ) : base( serial )
		{
		}
	}
}