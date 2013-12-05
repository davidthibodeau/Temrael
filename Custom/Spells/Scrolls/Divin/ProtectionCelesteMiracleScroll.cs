using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class ProtectionCelesteMiracleScroll : SpellScroll
    {
        [Constructable]
        public ProtectionCelesteMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public ProtectionCelesteMiracleScroll(int amount)
            : base(2020, 0x227B, amount)
        {
            Name = "Protection Céleste";
        }

        public ProtectionCelesteMiracleScroll(Serial serial)
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