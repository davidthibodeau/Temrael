using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class StrengthScroll : SpellScroll
	{
		[Constructable]
		public StrengthScroll() : this( 1 )
		{
		}

		[Constructable]
		public StrengthScroll( int amount ) : base( StrengthSpell.m_SpellID, 0x1F3C, amount )
		{
            Name = "Providence: Force";
		}

		public StrengthScroll( Serial serial ) : base( serial )
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