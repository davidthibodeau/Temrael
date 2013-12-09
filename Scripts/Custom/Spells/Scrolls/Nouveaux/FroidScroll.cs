using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class FroidScroll : SpellScroll
    {
        [Constructable]
        public FroidScroll()
            : this(1)
        {
        }

        [Constructable]
        public FroidScroll(int amount)
            : base(203, 0x1F65, amount)
        {
        }

        public FroidScroll(Serial serial)
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