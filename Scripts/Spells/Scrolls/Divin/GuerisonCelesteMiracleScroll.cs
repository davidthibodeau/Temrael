using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class GuerisonCelesteMiracleScroll : SpellScroll
    {
        [Constructable]
        public GuerisonCelesteMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public GuerisonCelesteMiracleScroll(int amount)
            : base(2003, 0x227B, amount)
        {
            Name = "Guérison Céleste";
        }

        public GuerisonCelesteMiracleScroll(Serial serial)
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