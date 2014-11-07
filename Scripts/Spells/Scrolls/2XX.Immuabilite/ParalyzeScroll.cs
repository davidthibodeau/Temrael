using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ParalyzeScroll : SpellScroll
	{
		[Constructable]
		public ParalyzeScroll() : this( 1 )
		{
		}

		[Constructable]
		public ParalyzeScroll( int amount ) : base( ParalyzeSpell.m_SpellID, 0x1F52, amount )
		{
            Name = "Immuabilité: Paralysie";
		}
		
		public ParalyzeScroll( Serial serial ) : base( serial )
		{
		}
	}
}