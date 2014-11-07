using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ReactiveArmorScroll : SpellScroll
	{
		[Constructable]
		public ReactiveArmorScroll() : this( 1 )
		{
		}

		[Constructable]
		public ReactiveArmorScroll( int amount ) : base( ReactiveArmorSpell.m_SpellID, 0x1F2D, amount )
		{
            Name = "Providence: Armure Magique";
		}

		public ReactiveArmorScroll( Serial ser ) : base(ser)
		{
		}
	}
}