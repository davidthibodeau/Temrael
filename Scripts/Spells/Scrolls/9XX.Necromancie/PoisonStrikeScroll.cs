using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class PoisonStrikeScroll : SpellScroll
	{
		[Constructable]
		public PoisonStrikeScroll() : this( 1 )
		{
		}

		[Constructable]
        public PoisonStrikeScroll(int amount)
            : base(PoisonStrikeSpell.m_SpellID, 0x2269, amount)
		{
            Name = "Nécromancie: Venin";
		}

		public PoisonStrikeScroll( Serial serial ) : base( serial )
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