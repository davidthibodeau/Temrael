using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class UnlockScroll : SpellScroll
	{
		[Constructable]
		public UnlockScroll() : this( 1 )
		{
		}

		[Constructable]
		public UnlockScroll( int amount ) : base( UnlockSpell.m_SpellID, 0x1F43, amount )
		{
            Name = "Transmutation: Ouverture Magique";
		}

		public UnlockScroll( Serial serial ) : base( serial )
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