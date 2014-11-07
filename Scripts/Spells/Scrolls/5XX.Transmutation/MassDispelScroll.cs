using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MassDispelScroll : SpellScroll
	{
		[Constructable]
		public MassDispelScroll() : this( 1 )
		{
		}

		[Constructable]
		public MassDispelScroll( int amount ) : base( MassDispelSpell.m_SpellID, 0x1F62, amount )
		{
            Name = "Transmutation: Dissipation de Masse";
		}

        public MassDispelScroll(Serial serial)
            : base(serial)
        {
        }
	}
}