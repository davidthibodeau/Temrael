using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ManaVampireScroll : SpellScroll
	{
		[Constructable]
		public ManaVampireScroll() : this( 1 )
		{
		}

		[Constructable]
		public ManaVampireScroll( int amount ) : base( ManaVampireSpell.m_SpellID, 0x1F61, amount )
		{
            Name = "Ensorcellement: Drain Vampirique";
		}

		public ManaVampireScroll( Serial serial ) : base( serial )
		{
		}
	}
}