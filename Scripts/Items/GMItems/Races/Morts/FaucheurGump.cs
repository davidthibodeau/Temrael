using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class OmbreGump : MortRaceGump
    {
        //public override int BodyMod { get { return 100; } }
        public override int HueMod { get { return 0; } }
        public override MortEvo EMort { get { return MortEvo.Ombre; } }

        [Constructable]
        public OmbreGump()
            : this(0)
        {
        }

        [Constructable]
        public OmbreGump(int hue)
            : base(0x146E, hue)
        {
        }

        public OmbreGump(Serial serial)
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
