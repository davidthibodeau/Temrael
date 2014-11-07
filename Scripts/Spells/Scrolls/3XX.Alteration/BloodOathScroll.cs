using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class BloodOathScroll : SpellScroll
	{
		[Constructable]
		public BloodOathScroll() : this( 1 )
		{
		}

		[Constructable]
		public BloodOathScroll( int amount ) : base( BloodOathSpell.m_SpellID, 0x2261, amount )
		{
            Name = "Alteration: Serment";
		}

		public BloodOathScroll( Serial serial ) : base( serial )
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