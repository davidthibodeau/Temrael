using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class LichFormScroll : SpellScroll
	{
		[Constructable]
		public LichFormScroll() : this( 1 )
		{
		}

		[Constructable]
		public LichFormScroll( int amount ) : base( LichFormSpell.m_SpellID , 0x2266, amount )
		{
            Name = "Nécromancie: Forme de Liche";
		}

		public LichFormScroll( Serial serial ) : base( serial )
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