using System;
using Server.Items;

namespace Server.Items
{
    public abstract class BaseBrassards : BaseClothing
    {
        public BaseBrassards(int itemID)
            : this(itemID, 0)
        {
        }

        public BaseBrassards(int itemID, int hue)
            : base(itemID, Layer.Bracelet, hue)
        {
        }

        public BaseBrassards(Serial serial)
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
