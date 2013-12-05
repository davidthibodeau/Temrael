using System;
using Server;
using Server.Items;

namespace Server.Items
{
    public class VoileScroll : SpellScroll
    {
        [Constructable]
        public VoileScroll()
            : this(1)
        {
        }

        [Constructable]
        public VoileScroll(int amount)
            : base(200, 0x1F65, amount)
        {
        }

        public VoileScroll(Serial serial)
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