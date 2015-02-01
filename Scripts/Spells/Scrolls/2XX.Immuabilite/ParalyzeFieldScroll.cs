using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class ParalyzeFieldScroll : SpellScroll
	{
		[Constructable]
		public ParalyzeFieldScroll() : this( 1 )
		{
		}

		[Constructable]
		public ParalyzeFieldScroll( int amount ) : base( ParalyzeFieldSpell.m_SpellID, 0x1F5B, amount )
		{
            Name = "Immuabilité: Mur de Paralysie";
		}

		public ParalyzeFieldScroll( Serial serial ) : base( serial )
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