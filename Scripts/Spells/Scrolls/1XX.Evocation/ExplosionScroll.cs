using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ExplosionScroll : SpellScroll
	{
		[Constructable]
		public ExplosionScroll() : this( 1 )
		{
		}

		[Constructable]
		public ExplosionScroll( int amount ) : base( ExplosionSpell.m_SpellID, 0x1F57, amount )
		{
            Name = "Évocation: Explosion";
		}

		public ExplosionScroll( Serial serial ) : base( serial )
		{
		}
	}
}