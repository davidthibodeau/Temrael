using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PolymorphScroll : SpellScroll
	{
		[Constructable]
		public PolymorphScroll() : this( 1 )
		{
		}

		[Constructable]
		public PolymorphScroll( int amount ) : base( PolymorphSpell.m_SpellID, 0x1F64, amount )
		{
            Name = "Transmutation: Polymorph";
		}

		public PolymorphScroll( Serial serial ) : base( serial )
		{
		}
	}
}