using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
    class LenteurScroll : SpellScroll
    {
        [Constructable]
		public LenteurScroll() : this( 1 )
		{
		}

		[Constructable]
		public LenteurScroll( int amount ) : base( LenteurSpell.m_SpellID, 0x1F5E, amount )
		{
            Name = "Immuabilité: Lenteur";
		}

        public LenteurScroll(Serial serial)
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
