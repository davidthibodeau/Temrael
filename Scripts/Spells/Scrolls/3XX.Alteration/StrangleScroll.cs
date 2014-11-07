using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class StrangleScroll : SpellScroll
	{
		[Constructable]
		public StrangleScroll() : this( 1 )
		{
		}

		[Constructable]
        public StrangleScroll(int amount)
            : base(StrangleSpell.m_SpellID, 0x226A, amount)
		{
            Name = "Alteration: Étranglement";
		}

		public StrangleScroll( Serial serial ) : base( serial )
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