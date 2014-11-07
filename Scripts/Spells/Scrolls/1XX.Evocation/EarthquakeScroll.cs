using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class EarthquakeScroll : SpellScroll
	{
		[Constructable]
		public EarthquakeScroll() : this( 1 )
		{
		}

		[Constructable]
		public EarthquakeScroll( int amount ) : base( EarthquakeSpell.m_SpellID, 0x1F65, amount )
		{
            Name = "Évocation: Tremblement";
		}

		public EarthquakeScroll( Serial serial ) : base( serial )
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