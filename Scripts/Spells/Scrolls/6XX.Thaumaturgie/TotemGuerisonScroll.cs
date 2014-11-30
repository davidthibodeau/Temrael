using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class TotemGuerisonScroll : SpellScroll
	{
		[Constructable]
		public TotemGuerisonScroll() : this( 1 )
		{
		}

		[Constructable]
		public TotemGuerisonScroll( int amount ) : base( TotemRegenSpell.m_SpellID, 0x1F31, amount )
		{
            Name = "Thaumaturgie: Soins";
		}

        public TotemGuerisonScroll(Serial serial)
            : base(serial)
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