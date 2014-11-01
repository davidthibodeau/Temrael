using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Mort;

namespace Server.Items
{
    public class SqueletteGump : MortRaceGump
    {
        //public override int BodyMod { get { return 50; } }
        public override int HueMod { get { return 0; } }
        public override MortEvo EMort { get { return MortEvo.Squelette; } }

        [Constructable]
        public SqueletteGump()
            : this(0)
        {
        }

        [Constructable]
        public SqueletteGump(int hue)
            : base(0x1471, hue)
        {
        }

        public SqueletteGump(Serial serial)
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
