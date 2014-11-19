using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class CorpsElfe : RaceSkin
    {
        [Constructable]
        public CorpsElfe()
            : this(0)
        {
        }

        [Constructable]
        public CorpsElfe(int hue)
            : base(0x27F8, hue)
        {
            Name = "Elfe";
        }

        public CorpsElfe(Serial serial)
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
            Name = "Elfe";
        }
    }
}
