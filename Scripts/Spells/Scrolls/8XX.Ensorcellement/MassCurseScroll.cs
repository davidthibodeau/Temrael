using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MassCurseScroll : SpellScroll
	{
		[Constructable]
		public MassCurseScroll() : this( 1 )
		{
		}

		[Constructable]
		public MassCurseScroll( int amount ) : base( MassCurseSpell.m_SpellID, 0x1F5A, amount )
		{
            Name = "Ensorcellement: Fléau";
		}

		public MassCurseScroll( Serial serial ) : base( serial )
		{
		}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
        }
	}
}