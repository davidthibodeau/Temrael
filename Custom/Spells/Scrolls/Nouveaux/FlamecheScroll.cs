using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class FlamecheScroll : SpellScroll
    {
        [Constructable]
        public FlamecheScroll()
            : this(1)
        {
        }

        [Constructable]
        public FlamecheScroll(int amount)
            : base(202, 0x1F65, amount)
        {
        }

        public FlamecheScroll(Serial serial)
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