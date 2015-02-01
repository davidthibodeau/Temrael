using System;
using Server.Items;

namespace Server.Items
{
    public abstract class BaseFoulards : BaseClothing
    {
        public override bool Disguise { get { return false; } }

        public BaseFoulards(int itemID)
            : this(itemID, 0)
        {
        }

        public BaseFoulards(int itemID, int hue)
            : base(itemID, Layer.Neck, hue)
        {
        }

        public BaseFoulards(Serial serial)
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
