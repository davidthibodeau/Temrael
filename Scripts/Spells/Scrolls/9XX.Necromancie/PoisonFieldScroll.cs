using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PoisonFieldScroll : SpellScroll
	{
		[Constructable]
		public PoisonFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public PoisonFieldScroll( int amount ) : base( PoisonFieldSpell.m_SpellID, 0x1F53, amount )
		{
            Name = "Nécromancie: Mur de Poison";
		}

		public PoisonFieldScroll( Serial serial ) : base( serial )
		{
		}
	}
}