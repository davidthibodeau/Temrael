using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MindRotScroll : SpellScroll
	{
		[Constructable]
		public MindRotScroll() : this( 1 )
		{
		}

		[Constructable]
		public MindRotScroll( int amount ) : base( MindRotSpell.m_SpellID, 0x2267, amount )
		{
            Name = "Alteration: Pourriture d'esprit";
		}

		public MindRotScroll( Serial serial ) : base( serial )
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