using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class WraithFormScroll : SpellScroll
	{
		[Constructable]
		public WraithFormScroll() : this( 1 )
		{
		}

		[Constructable]
		public WraithFormScroll( int amount ) : base( WraithFormSpell.m_SpellID, 0x226F, amount )
		{
            Name = "Nécromancie: Spectre";
		}

		public WraithFormScroll( Serial serial ) : base( serial )
		{
		}
	}
}