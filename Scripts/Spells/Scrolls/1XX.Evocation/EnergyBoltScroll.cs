using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class EnergyBoltScroll : SpellScroll
	{
		[Constructable]
		public EnergyBoltScroll() : this( 1 )
		{
		}

		[Constructable]
		public EnergyBoltScroll( int amount ) : base( EnergyBoltSpell.m_SpellID, 0x1F56, amount )
		{
            Name = "Évocation: Énergie";
		}

		public EnergyBoltScroll( Serial serial ) : base( serial )
		{
		}
	}
}