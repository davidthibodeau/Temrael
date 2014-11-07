using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MagicLockScroll : SpellScroll
	{
		[Constructable]
		public MagicLockScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicLockScroll( int amount ) : base( MagicLockSpell.m_SpellID, 0x1F3F, amount )
		{
            Name = "Transmutation: Fermeture magique";
		}

		public MagicLockScroll( Serial serial ) : base( serial )
		{
		}
	}
}