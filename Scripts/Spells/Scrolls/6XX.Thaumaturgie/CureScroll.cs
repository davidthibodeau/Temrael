using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class CureScroll : SpellScroll
	{
		[Constructable]
		public CureScroll() : this( 1 )
		{
		}

		[Constructable]
		public CureScroll( int amount ) : base( CureSpell.m_SpellID, 0x1F37, amount )
		{
            Name = "Thaumaturgie: Antidote";
		}

		public CureScroll( Serial serial ) : base( serial )
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