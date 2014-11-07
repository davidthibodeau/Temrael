using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MagicTrapScroll : SpellScroll
	{
		[Constructable]
		public MagicTrapScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicTrapScroll( int amount ) : base( MagicTrapSpell.m_SpellID, 0x1F39, amount )
		{
            Name = "Transmutation: Piège Magique";
		}

		public MagicTrapScroll( Serial serial ) : base( serial )
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