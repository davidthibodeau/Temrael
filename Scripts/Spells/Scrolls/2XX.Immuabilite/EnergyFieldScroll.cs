using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class EnergyFieldScroll : SpellScroll
	{
		[Constructable]
		public EnergyFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public EnergyFieldScroll( int amount ) : base( EnergyFieldSpell.m_SpellID, 0x1F5E, amount )
		{
            Name = "Immuabilité: Mur d'énergie";
		}

		public EnergyFieldScroll( Serial serial ) : base( serial )
		{
		}
	}
}