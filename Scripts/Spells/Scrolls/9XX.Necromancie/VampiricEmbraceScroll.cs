using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class VampiricEmbraceScroll : SpellScroll
	{
		[Constructable]
		public VampiricEmbraceScroll() : this( 1 )
		{
		}

		[Constructable]
		public VampiricEmbraceScroll( int amount ) : base( VampiricEmbraceSpell.m_SpellID, 0x226C, amount )
		{
            Name = "Nécromancie: Vampirisme";
		}

		public VampiricEmbraceScroll( Serial serial ) : base( serial )
		{
		}
	}
}