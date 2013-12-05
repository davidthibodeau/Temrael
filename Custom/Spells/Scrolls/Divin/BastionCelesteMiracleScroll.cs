using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BastionCelesteMiracleScroll : SpellScroll
    {
        [Constructable]
        public BastionCelesteMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public BastionCelesteMiracleScroll(int amount)
            : base(2013, 0x227B, amount)
        {
            Name = "Bastion Céleste";
        }

        public BastionCelesteMiracleScroll(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}