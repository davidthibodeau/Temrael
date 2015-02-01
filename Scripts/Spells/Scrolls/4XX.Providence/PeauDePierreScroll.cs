using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PeauDePierreScroll : SpellScroll
	{
		[Constructable]
		public PeauDePierreScroll() : this( 1 )
		{
		}

		[Constructable]
		public PeauDePierreScroll( int amount ) : base( PeauDePierreSpell.m_SpellID, 0x1F3B, amount )
		{
            Name = "Providence: Peau de pierre";
		}

		public PeauDePierreScroll( Serial serial ) : base( serial )
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