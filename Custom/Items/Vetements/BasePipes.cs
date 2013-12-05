using System;
using Server.Items;

namespace Server.Items
{
    public abstract class BasePipes : BaseClothing
    {
        public BasePipes(int itemID)
            : this(itemID, 0)
        {
        }

        public BasePipes(int itemID, int hue)
            : base(itemID, Layer.OneHanded, hue)
        {
        }

        public BasePipes(Serial serial)
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
