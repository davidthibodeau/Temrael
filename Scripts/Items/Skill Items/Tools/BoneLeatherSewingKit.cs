using System;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
    public class BoneLeatherSewingKit : BaseTool
    {
        public override int GoldValue { get { return 6; } }

        public override CraftSystem CraftSystem { get { return DefBoneLeatherTailoring.CraftSystem; } }

        [Constructable]
        public BoneLeatherSewingKit()
            : base(0xF9D)
        {
            Weight = 2.0;
            Name = "Kit de couture (Cuir/Os)";
            Hue = 1833;
            Layer = Layer.TwoHanded;
        }

        [Constructable]
        public BoneLeatherSewingKit(int uses)
            : base(uses, 0xF9D)
        {
            Weight = 2.0;
            Name = "Kit de couture (Cuir/Os)";
            Hue = 1833;
            Layer = Layer.TwoHanded;
        }

        public BoneLeatherSewingKit(Serial serial)
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