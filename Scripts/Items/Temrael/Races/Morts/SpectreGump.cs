using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class SpectreGump : BaseMortGumps
    {
        //public override int BodyMod { get { return 26; } }
        public override int HueMod { get { return 2039; } }
        public override MortEvo EMort { get { return MortEvo.Spectre; } }

        [Constructable]
        public SpectreGump()
            : this(0)
        {
        }

        [Constructable]
        public SpectreGump(int hue)
            : base(0x1473, hue)
        {
        }

        public SpectreGump(Serial serial)
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
