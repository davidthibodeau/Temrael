using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class SummonCreatureScroll : SpellScroll
	{
		[Constructable]
		public SummonCreatureScroll() : this( 1 )
		{
		}

		[Constructable]
		public SummonCreatureScroll( int amount ) : base( SummonCreatureSpell.m_SpellID, 0x1F54, amount )
		{
            Name = "Transmutation: Convocation";
		}

		public SummonCreatureScroll( Serial serial ) : base( serial )
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