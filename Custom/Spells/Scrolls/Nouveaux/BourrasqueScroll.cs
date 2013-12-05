using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class BourrasqueScroll : SpellScroll
    {
        [Constructable]
        public BourrasqueScroll()
            : this(1)
        {
        }

        [Constructable]
        public BourrasqueScroll(int amount)
            : base(201, 0x1F65, amount)
        {
        }

        public BourrasqueScroll(Serial serial)
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