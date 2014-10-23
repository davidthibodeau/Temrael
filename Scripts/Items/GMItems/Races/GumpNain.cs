using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class CorpsNain : RaceGump
    {
        [Constructable]
        public CorpsNain()
            : this(0)
        {
        }

        [Constructable]
        public CorpsNain(int hue)
            : base(0x27F6, hue)
        {
            Name = "Nain";
        }

        public CorpsNain(Serial serial)
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
            Name = "Nain";
        }
    }
}
