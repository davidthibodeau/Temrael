using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class AnimateDeadScroll : SpellScroll
	{
		[Constructable]
		public AnimateDeadScroll() : this( 1 )
		{
		}

		[Constructable]
		public AnimateDeadScroll( int amount ) : base( AnimateDeadSpell.m_SpellID, 0x2260, amount )
		{
            Name = "Nécromancie: Animation";
		}

		public AnimateDeadScroll( Serial serial ) : base( serial )
		{
		}
	}
}