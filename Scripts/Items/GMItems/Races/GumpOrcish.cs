using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class CorpsOrcish : RaceGump
    {
        [Constructable]
        public CorpsOrcish()
            : this(0)
        {
        }

        [Constructable]
        public CorpsOrcish(int hue)
            : base(0x27F9, hue)
        {
            Name = "Orcish";
        }

        public CorpsOrcish(Serial serial)
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
            Name = "Orcish";
        }
    }
}
