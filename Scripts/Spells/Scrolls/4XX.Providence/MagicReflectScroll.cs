using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class MagicReflectScroll : SpellScroll
	{
		[Constructable]
		public MagicReflectScroll() : this( 1 )
		{
		}

		[Constructable]
		public MagicReflectScroll( int amount ) : base( MagicReflectSpell.m_SpellID, 0x1F50, amount )
		{
            Name = "Providence: Reflet magique";
		}

		public MagicReflectScroll( Serial serial ) : base( serial )
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