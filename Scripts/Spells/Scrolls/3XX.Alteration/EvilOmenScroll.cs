using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class EvilOmenScroll : SpellScroll
	{
		[Constructable]
		public EvilOmenScroll() : this( 1 )
		{
		}

		[Constructable]
		public EvilOmenScroll( int amount ) : base( EvilOmenSpell.m_SpellID, 0x2264, amount )
		{
            Name = "Alteration: Mauvais Présage";
		}

		public EvilOmenScroll( Serial serial ) : base( serial )
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