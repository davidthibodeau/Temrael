using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class SummonDaemonScroll : SpellScroll
	{
		[Constructable]
		public SummonDaemonScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonDaemonScroll( int amount ) : base( SummonCreatureSpell.m_SpellID, 0x1F69, amount )
		{
            Name = "Nécromancie: Conjuration";
		}

		public SummonDaemonScroll( Serial serial ) : base( serial )
		{
		}
	}
}