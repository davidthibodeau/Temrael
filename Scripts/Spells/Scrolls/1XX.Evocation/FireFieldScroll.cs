using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class FireFieldScroll : SpellScroll
	{
		[Constructable]
		public FireFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public FireFieldScroll( int amount ) : base( FireFieldSpell.m_SpellID, 0x1F48, amount )
		{
            Name = "Évocation: Mur de Feu";
		}

		public FireFieldScroll( Serial serial ) : base( serial )
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