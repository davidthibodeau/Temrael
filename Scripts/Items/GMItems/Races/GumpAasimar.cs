using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class CorpsAasimar : RaceGump
    {
        [Constructable]
        public CorpsAasimar()
            : this(0)
        {
        }

        [Constructable]
        public CorpsAasimar(int hue)
            : base(0x2FC7, hue)
        {
            Name = "Aasimar";
            Layer = Layer.Shirt;
        }

        public CorpsAasimar(Serial serial)
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
            Name = "Tieffelin";
        }
    }
}
