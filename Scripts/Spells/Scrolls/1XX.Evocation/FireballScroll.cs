using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class FireballScroll : SpellScroll
	{
		[Constructable]
		public FireballScroll() : this( 1 )
		{
		}

		[Constructable]
		public FireballScroll( int amount ) : base( FireballSpell.m_SpellID, 0x1F3E, amount )
		{
            Name = "Évocation: Boule de Feu";
		}

		public FireballScroll( Serial serial ) : base( serial )
		{
		}
	}
}