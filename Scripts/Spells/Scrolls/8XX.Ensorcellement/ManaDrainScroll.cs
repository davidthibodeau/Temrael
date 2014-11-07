using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ManaDrainScroll : SpellScroll
	{
		[Constructable]
		public ManaDrainScroll() : this( 1 )
		{
		}

		[Constructable]
		public ManaDrainScroll( int amount ) : base( ManaDrainSpell.m_SpellID, 0x1F4B, amount )
		{
            Name = "Ensorcellement: Drain de Mana";
		}

		public ManaDrainScroll( Serial serial ) : base( serial )
		{
		}
	}
}