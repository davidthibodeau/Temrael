using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class InvisibilityScroll : SpellScroll
	{
		[Constructable]
		public InvisibilityScroll() : this( 1 )
		{
		}

		[Constructable]
		public InvisibilityScroll( int amount ) : base( InvisibilitySpell.m_SpellID, 0x1F58, amount )
		{
            Name = "Hallucination: Invisibilité";
		}

		public InvisibilityScroll( Serial serial ) : base( serial )
		{
		}
	}
}