using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class RepasCelesteMiracleScroll : SpellScroll
    {
        [Constructable]
        public RepasCelesteMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public RepasCelesteMiracleScroll(int amount)
            : base(2007, 0x227B, amount)
        {
            Name = "Repas Céleste";
        }

        public RepasCelesteMiracleScroll(Serial serial)
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