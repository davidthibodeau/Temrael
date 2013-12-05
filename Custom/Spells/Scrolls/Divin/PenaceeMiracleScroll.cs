using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class PenaceeMiracleScroll : SpellScroll
    {
        [Constructable]
        public PenaceeMiracleScroll()
            : this(1)
        {
        }

        [Constructable]
        public PenaceeMiracleScroll(int amount)
            : base(2005, 0x227B, amount)
        {
            Name = "Penacée";
        }

        public PenaceeMiracleScroll(Serial serial)
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