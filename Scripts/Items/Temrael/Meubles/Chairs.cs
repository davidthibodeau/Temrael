using System;

namespace Server.Items
{
    [Flipable(0x03A1, 0x03A, 0x03A3, 0x03A4)]
    public class TroneBois : Item
    {
        [Constructable]
        public TroneBois()
            : base(0x03A1)
        {
            Weight = 5.0;
            Name = "Trône";
        }

        public TroneBois(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }
    }

    [Flipable(0x0B91, 0x0B92, 0x0B93, 0x0B94)]
    public class BancTemple : Item
    {
        [Constructable]
        public BancTemple()
            : base(0x0B91)
        {
            Weight = 5.0;
        }

        public BancTemple(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }
    }

    [Flipable(0x0B4E, 0x0B4F, 0x0B50, 0x0B51)]
    public class ChaiseCoussinee : Item
    {
        [Constructable]
        public ChaiseCoussinee()
            : base(0x0B4E)
        {
            Weight = 5.0;
        }

        public ChaiseCoussinee(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

        }
    }
}