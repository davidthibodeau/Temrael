using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class MontureCelesteMiracleScroll : SpellScroll
    {
        [Constructable]
        public MontureCelesteMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public MontureCelesteMiracleScroll(int amount)
            : base(2019, 0x227B, amount)
        {
            Name = "Monture Céleste";
        }

        public MontureCelesteMiracleScroll(Serial serial)
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