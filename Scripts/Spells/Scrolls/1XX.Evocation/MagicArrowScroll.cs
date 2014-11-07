using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MagicArrowScroll : SpellScroll
	{
		[Constructable]
		public MagicArrowScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicArrowScroll( int amount ) : base( MagicArrowSpell.m_SpellID, 0x1F32, amount )
		{
            Name = "Évocation: Flèche Magique";
		}
		
		public MagicArrowScroll( Serial serial ) : base( serial )
		{
		}
	}
}