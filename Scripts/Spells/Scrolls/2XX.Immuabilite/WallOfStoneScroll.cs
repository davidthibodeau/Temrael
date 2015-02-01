using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class WallOfStoneScroll : SpellScroll
	{
		[Constructable]
		public WallOfStoneScroll() : this( 1 )
		{
		}

		[Constructable]
		public WallOfStoneScroll( int amount ) : base( WallOfStoneSpell.m_SpellID, 0x1F44, amount )
		{
            Name = "Immuabilité: Mur de Pierre";
		}

		public WallOfStoneScroll( Serial serial ) : base( serial )
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