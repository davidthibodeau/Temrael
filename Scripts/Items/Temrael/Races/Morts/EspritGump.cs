using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class EspritGump : BaseMortGumps
    {
        //public override int BodyMod { get { return 84; } }
        public override int HueMod { get { return 0; } }
        public override MortEvo EMort { get { return MortEvo.Esprit; } }

        [Constructable]
        public EspritGump()
            : this(0)
        {
        }

        [Constructable]
        public EspritGump(int hue)
            : base(0x146D, hue)
        {
        }

        public EspritGump(Serial serial)
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
