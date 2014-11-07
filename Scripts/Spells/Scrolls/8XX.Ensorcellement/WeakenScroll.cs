using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class WeakenScroll : SpellScroll
	{
		[Constructable]
		public WeakenScroll() : this( 1 )
		{
		}

		[Constructable]
		public WeakenScroll( int amount ) : base( WeakenSpell.m_SpellID, 0x1F34, amount )
		{
            Name = "Ensorcellement: Faiblesse";
		}

		public WeakenScroll( Serial serial ) : base( serial )
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