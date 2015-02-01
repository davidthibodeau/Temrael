using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class WitherScroll : SpellScroll
	{
		[Constructable]
		public WitherScroll() : this( 1 )
		{
		}

		[Constructable]
        public WitherScroll(int amount)
            : base(WitherSpell.m_SpellID, 0x226E, amount)
		{
            Name = "Nécromancie: Flétrir";
		}

		public WitherScroll( Serial serial ) : base( serial )
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