using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Mort;

namespace Server.Items
{
    public class ZombieGump : MortRaceGump
    {
        /*public override int BodyMod { get { return 3; } }
        public override int HueMod { get { return 0; } }*/
        public override MortEvo EMort { get { return MortEvo.Zombie; } }

        [Constructable]
        public ZombieGump()
            : this(0)
        {
        }

        [Constructable]
        public ZombieGump(int hue)
            : base(0x1474, hue)
        {
        }

        public ZombieGump(Serial serial)
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
