using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class TeleportScroll : SpellScroll
	{
		[Constructable]
		public TeleportScroll() : this( 1 )
		{
		}

		[Constructable]
		public TeleportScroll( int amount ) : base( TeleportSpell.m_SpellID, 0x1F42, amount )
		{
            Name = "Transmutation: Téléportation";
		}

		public TeleportScroll( Serial serial ) : base( serial )
		{
		}
	}
}