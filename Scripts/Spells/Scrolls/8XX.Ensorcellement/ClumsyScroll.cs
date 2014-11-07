using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ClumsyScroll : SpellScroll
	{
		[Constructable]
		public ClumsyScroll() : this( 1 )
		{
		}

		[Constructable]
		public ClumsyScroll( int amount ) : base( ClumsySpell.m_SpellID, 0x1F2E, amount )
		{
            Name = "Ensorcellement: Maladroit";
		}

		public ClumsyScroll( Serial serial ) : base( serial )
		{
		}
	}
}