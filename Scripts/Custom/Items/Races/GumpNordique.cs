using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class CorpsNordique : BaseRaceGumps
    {
        [Constructable]
        public CorpsNordique()
            : this(0)
        {
        }

        [Constructable]
        public CorpsNordique(int hue)
            : base(0x27F7, hue)
        {
            Name = "Nordique";
        }

        public CorpsNordique(Serial serial)
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
            Name = "Nordique";
        }
    }
}
