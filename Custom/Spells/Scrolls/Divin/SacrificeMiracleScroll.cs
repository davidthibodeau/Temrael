using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class SacrificeMiracleScroll : SpellScroll
    {
        [Constructable]
        public SacrificeMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public SacrificeMiracleScroll(int amount)
            : base(2021, 0x227B, amount)
        {
            Name = "Sacrifice";
        }

        public SacrificeMiracleScroll(Serial serial)
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