using System;
using Server;
using Server.Items;
using Server.Spells;

namespace Server.Items
{
	public class DernierSouffleScroll : SpellScroll
	{
		[Constructable]
		public DernierSouffleScroll() : this( 1 )
		{
		}

		[Constructable]
		public DernierSouffleScroll( int amount ) : base( DernierSouffleSpell.m_SpellID, 0x1F31, amount )
		{
            Name = "Thaumaturgie: Dernier souffle";
		}

        public DernierSouffleScroll(Serial serial)
            : base(serial)
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