using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class GreaterHealScroll : SpellScroll
	{
		[Constructable]
		public GreaterHealScroll() : this( 1 )
		{
		}

		[Constructable]
		public GreaterHealScroll( int amount ) : base( GreaterHealSpell.m_SpellID, 0x1F49, amount )
		{
            Name = "Thaumaturgie: Soins Magiques";
		}

		public GreaterHealScroll( Serial serial ) : base( serial )
		{
		}
	}
}