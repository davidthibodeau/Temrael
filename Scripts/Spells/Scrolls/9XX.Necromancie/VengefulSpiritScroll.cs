using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class VengefulSpiritScroll : SpellScroll
	{
		[Constructable]
		public VengefulSpiritScroll() : this( 1 )
		{
		}

		[Constructable]
        public VengefulSpiritScroll(int amount)
            : base(VengefulSpiritSpell.m_SpellID, 0x226D, amount)
		{
            Name = "Nécromancie: Esprit Vengeur";
		}

		public VengefulSpiritScroll( Serial serial ) : base( serial )
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