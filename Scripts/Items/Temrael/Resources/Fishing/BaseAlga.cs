using System;
using Server;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
    [FlipableAttribute(0x14EF, 0x14F0)]
    public abstract class BaseAlga : Item
    {
        [Constructable]
        public BaseAlga() : base(0x14EF)
        {
            Weight = 2.0;
        }

        public BaseAlga(Serial serial) : base(serial)
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