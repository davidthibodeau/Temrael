using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MagicUnTrapScroll : SpellScroll
	{
		[Constructable]
		public MagicUnTrapScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicUnTrapScroll( int amount ) : base( RemoveTrapSpell.m_SpellID, 0x1F3A, amount )
		{
            Name = "Transmutation: Supression de Piège";
		}

		public MagicUnTrapScroll( Serial serial ) : base( serial )
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