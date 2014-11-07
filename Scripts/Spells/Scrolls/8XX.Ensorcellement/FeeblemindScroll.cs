using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class FeeblemindScroll : SpellScroll
	{
		[Constructable]
		public FeeblemindScroll() : this( 1 )
		{
		}

		[Constructable]
		public FeeblemindScroll( int amount ) : base( FeeblemindSpell.m_SpellID, 0x1F30, amount )
		{
            Name = "Ensorcellement: Débilité";
		}

		public FeeblemindScroll( Serial serial ) : base( serial )
		{
		}
	}
}