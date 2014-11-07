using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ProtectionScroll : SpellScroll
	{
		[Constructable]
		public ProtectionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ProtectionScroll( int amount ) : base( ProtectionSpell.m_SpellID, 0x1F3B, amount )
		{
            Name = "Providence: Protection";
		}

		public ProtectionScroll( Serial serial ) : base( serial )
		{
		}
	}
}