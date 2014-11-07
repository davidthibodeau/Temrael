using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class HarmScroll : SpellScroll
	{
		[Constructable]
		public HarmScroll() : this( 1 )
		{
		}

		[Constructable]
		public HarmScroll( int amount ) : base( HarmSpell.m_SpellID, 0x1F38, amount )
		{
            Name = "Ensorcellement: Nuissance";
		}

        public HarmScroll(Serial serial)
            : base(serial)
        {
        }
	}
}