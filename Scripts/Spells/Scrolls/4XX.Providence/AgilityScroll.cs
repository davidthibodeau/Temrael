using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class AgilityScroll : SpellScroll
	{
		[Constructable]
		public AgilityScroll() : this( 1 )
		{
		}

		[Constructable]
		public AgilityScroll( int amount ) : base( AgilitySpell.m_SpellID, 0x1F35, amount )
		{
            Name = "Providence: Agilité";
		}

		public AgilityScroll( Serial serial ) : base( serial )
		{
		}
	}
}