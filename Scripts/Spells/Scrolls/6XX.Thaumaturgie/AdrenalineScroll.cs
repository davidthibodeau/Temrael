using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class AdrenalineScroll : SpellScroll
	{
		[Constructable]
		public AdrenalineScroll() : this( 1 )
		{
		}

		[Constructable]
		public AdrenalineScroll( int amount ) : base( AdrenalineSpell.m_SpellID, 0x1F31, amount )
		{
            Name = "Thaumaturgie: Adrénaline";
		}

        public AdrenalineScroll(Serial serial)
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