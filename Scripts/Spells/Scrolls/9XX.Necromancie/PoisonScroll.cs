using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PoisonScroll : SpellScroll
	{
		[Constructable]
		public PoisonScroll() : this( 1 )
		{
		}

		[Constructable]
		public PoisonScroll( int amount ) : base( PoisonSpell.m_SpellID, 0x1F40, amount )
		{
            Name = "Nécromancie: Poison";
		}

		public PoisonScroll( Serial serial ) : base( serial )
		{
		}
	}
}