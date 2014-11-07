using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class LightningScroll : SpellScroll
	{
		[Constructable]
		public LightningScroll() : this( 1 )
		{
		}

		[Constructable]
		public LightningScroll( int amount ) : base( LightningSpell.m_SpellID, 0x1F4A, amount )
		{
            Name = "Évocation: Éclair";
		}

		public LightningScroll( Serial serial ) : base( serial )
		{
		}
	}
}